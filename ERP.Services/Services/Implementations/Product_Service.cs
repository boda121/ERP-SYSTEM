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
        private readonly ILogger<product_service> _logger;


        public product_service(IUnitOfWork cotext,IMapper mapper, IHostingEnvironment env)
        {
            _Context = cotext;
            _mapper = mapper;
            _env = env;
        }

        public async Task<IEnumerable<productDto>> GetAllProductsAsync()
        {
            var products= await _Context.product.GetAllAsync(x=> x.ProductVariants, x => x.ProductAttributes, x=> x.ProductImages);
            products = products.Where(x => x.IsDeleted != true);
            var prod= _mapper.Map<IEnumerable<productDto>>(products);
            return prod;
        }

        public async Task<CreateProductDto> Add([FromForm] CreateProductDto prod)
        {
            var res = _mapper.Map<Product>(prod);
            _Context.product.Add(res);
            await _Context.Commit();
            foreach (var img in prod.ProductImages)
            {
                var fileName = $"{Guid.NewGuid()}_{img.FileName}";
                var savePath = Path.Combine(_env.ContentRootPath, "Uploads", "Products", fileName);
                using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    await img.CopyToAsync(stream);
                }
                // إضافة الصورة لقائمة الـ ProductImages
                res.ProductImages.Add(new ProductImage
                {
                    Url = fileName// نخزن الاسم فقط
                });
                //  prod.ProductImagesUrl.Add(fileName);
            }
            await _Context.Commit();
            return prod;
        }
        

        public async Task<productDto> GetByID(int id)
        {
            var products =await _Context.product.GetAllAsync(x => x.ProductVariants, x => x.ProductImages, x => x.ProductAttributes);
            var product = products.Where(x=>x.Id == id).FirstOrDefault();
            var pto = _mapper.Map<productDto>(product);
            return pto;
        }

        public async Task<CreateProductDto> update(int id, CreateProductDto product)
        {
            var products = await _Context.product.GetAllAsync(x => x.ProductVariants, x => x.ProductImages, x => x.ProductAttributes);
            var res = products.Where(x => x.Id == id).FirstOrDefault();
            res = _mapper.Map(product, res);
            await _Context.Commit();
            return product;
        }

        public async Task<string> DeleteProduct(int id)
        {
            var res = await _Context.product.GetByIdAsync(id);
            if (res != null)
            {
                if (res.IsDeleted == false)
                {
                    res.IsDeleted = true;
                    res.IsActive = false;
                    await _Context.Commit();
                    return ("Deleted is Done");
                }
                else if (res.IsDeleted == true)
                {
                    return ("Product is Deleted already");
                }
                else
                {
                    return ("Error");

                }
            }
            else
            {

                return ("Product Not Found");
            }
        }
        public async Task<string> RecovryProduct(int id)
        {
            var res = await _Context.product.GetByIdAsync(id);
            if (res != null)
            {
                if (res.IsDeleted == true)
                {
                    res.IsDeleted = false;
                    res.IsActive = true;
                    await _Context.Commit();
                    return ("Recovry is Done");
                }
                else if (res.IsDeleted == false)
                {
                    return ("Product is Recovryed already");
                }
                else
                {
                    return ("Error");

                }
            }
            else
            {

                return ("Product Not Found");
            }
        }
    }
}
