using AutoMapper;
using ERP.Core.DTOs;
using ERP.Core.Interfaces;
using ERP.Core.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace ERP.Services.Services.Implementations
{
    public class product_service : IProduct_Service
    {
        private readonly IUnitOfWork _Context;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _env;
      //  private readonly ILogger<product_service> _logger;

        public product_service(IUnitOfWork cotext,IMapper mapper, IHostingEnvironment env)
        {
            _Context = cotext;
            _mapper = mapper;
            _env = env;
        }
        public async Task<ApiResponse<Product, IEnumerable<productDto>>> GetAllProductsAsync()
        {
            var products= await _Context.product.GetAllAsync(x=> x.ProductVariants, x => x.ProductAttributes, x=> x.ProductImages);
            products = products.Where(x => x.IsDeleted != true);
            var prod= _mapper.Map<IEnumerable<productDto>>(products);
            return new ApiResponse<Product, IEnumerable<productDto>>(prod,"dssd");
        }
        public async Task<ApiResponse<Product, productDto>> Add([FromForm] CreateProductDto prod)
        {
            try
            {

                var res = _mapper.Map<Product>(prod);
                //  await _Context.Commit();
                foreach (var img in prod.ProductImages)
                {
                    var fileName = $"{Guid.NewGuid()}_{img.FileName}";
                    var savePath = Path.Combine(_env.ContentRootPath, "Uploads", "Products", fileName);
                    using (var stream = new FileStream(savePath, FileMode.Create))
                    {
                        await img.CopyToAsync(stream);
                    }
                    res.ProductImages.Add(new ProductImage
                    {
                        Url = fileName// نخزن الاسم فقط
                    });
                }
                _Context.product.Add(res);
                await _Context.Commit();
                var resultafterMap = _mapper.Map<productDto>(res);
                return new ApiResponse<Product, productDto>(resultafterMap, "success");
            }
            catch (Exception ex)
            {
                return new ApiResponse<Product, productDto>(ex.Message,400);
            }
        }
        public async Task<ApiResponse<Product, productDto>> GetByID(int id)
        {
            try
            {
                var products = await _Context.product.GetAllAsync(x => x.ProductVariants, x => x.ProductImages, x => x.ProductAttributes);
                var product = products.Where(x => x.Id == id).FirstOrDefault();
                if (product != null)
                {
                    var productFTERMAP = _mapper.Map<productDto>(product);
                    return new ApiResponse<Product, productDto>(productFTERMAP,"Success");
                }
                return new ApiResponse<Product, productDto>("Not Found Any Item",404);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Product, productDto>(ex.Message,400);
            }
        }
        public async Task<ApiResponse<Product, productDto>> update(int id, CreateProductDto product)
        {
            try
            {

                var products = await _Context.product.GetAllAsync(x => x.ProductVariants, x => x.ProductImages, x => x.ProductAttributes);
                var res = products.Where(x => x.Id == id).FirstOrDefault();
                if (res != null)
                {
                   var mapresult  = _mapper.Map(product,res);
                    var dto = _mapper.Map<productDto>(mapresult);
                    await _Context.Commit();
                    return new ApiResponse<Product, productDto>(dto,"Success");

                }
                return new ApiResponse<Product, productDto>("Not Found Any Item For This ID",404);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Product, productDto>(ex.Message, 400);
            }
        }
        public async Task<ApiResponse<Product, productDto>> DeleteProduct(int id)
        {
            try
            {

                var res = await _Context.product.GetByIdAsync(id);
                if (res != null)
                {
                    if (res.IsDeleted == false)
                    {
                        res.IsDeleted = true;
                        res.IsActive = false;
                        await _Context.Commit();
                        var result = _mapper.Map<productDto>(res);
                        return new ApiResponse<Product, productDto>(result,"Success");

                    }
                    else 
                    {
                    return new ApiResponse<Product, productDto>("Product is Deleted already", 401);

                    }
                }
                else
                {

                    return new ApiResponse<Product, productDto>("Not Found Any Item", 404);
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<Product, productDto>(ex.Message, 400);
            }

        }
        public async Task<ApiResponse<Product, productDto>> RecovryProduct(int id)
        {
            var res = await _Context.product.GetByIdAsync(id);
            if (res != null)
            {
                if (res.IsDeleted == true)
                {
                    res.IsDeleted = false;
                    res.IsActive = true;
                    await _Context.Commit();
                    var result = _mapper.Map<productDto>(res);
                    return new ApiResponse<Product, productDto>(result, "Success");
                }
                else 
                {
                    return new ApiResponse<Product, productDto>("Product is Recovryed already", 401);

                }

            }
            else
            {
                return new ApiResponse<Product, productDto>("Product Not Found", 404);

            }
        }
    }
}
