using AutoMapper;
using ERP.Core.DTOs;
using ERP.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProduct_Service _service;
        public ProductController(IProduct_Service _Layer)
        {
            this._service = _Layer;
        }
        [HttpGet("GetAllProduct")]
        public async Task<IActionResult> Get()
        {

            return Ok(await _service.GetAllProductsAsync());
        }

        [HttpPost("AddProduct")]
        [Authorize]
        public async Task<IActionResult> Add([FromForm] CreateProductDto prod )
        {
           await _service.Add(prod);
            return Ok(prod);
        }
        [HttpPut("UpdateProduct/id")]
        public async Task<IActionResult> Update(int id , [FromForm] CreateProductDto prod)
        {
           await _service.update(id,prod);
            return Ok(prod);
        }

        [HttpGet("GetById/id")]
        public async Task<IActionResult> GetByID(int id)
        {
            var product = await _service.GetByID(id);
                return Ok(product);
        }

        [HttpPatch("DeleteProduct/id")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _service.DeleteProduct(id);
            if(res== "Deleted is Done")
            return Ok(res);
            else if(res== "Product is Deleted already")
            return BadRequest(res);
            else return NotFound(res);
        }
        [HttpPatch("RecovryProduct/id")]
        public async Task<IActionResult> RecovryProduct(int id)
        {
            var res = await _service.RecovryProduct(id);
            if (res == "Recovry is Done")
                return Ok(res);
            else if (res == "Product is Recovryed already")
                return BadRequest(res);
            else return NotFound(res);

        }
    }
}
