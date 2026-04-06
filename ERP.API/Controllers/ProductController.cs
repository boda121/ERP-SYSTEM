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
            if(ModelState.IsValid)
            {

           var Result = await _service.Add(prod);
                if(Result.IsSuccess)
            return Ok(await _service.Add(prod));
                return BadRequest($"{Result.Message+Result.StatusCode}");
            }
            return BadRequest();
        }
        [HttpPut("UpdateProduct/id")]
        public async Task<IActionResult> Update(int id , [FromForm] CreateProductDto prod)
        {
            if (ModelState.IsValid)
            {
               var Result =  await _service.update(id, prod);
                if(Result.IsSuccess)
                return Ok(Result);
                return StatusCode(Result.StatusCode);
            }
            return BadRequest();
        }

        [HttpGet("GetById/id")]
        public async Task<IActionResult> GetByID(int id)
        {
            if (ModelState.IsValid)
            {
                var Result = await _service.GetByID(id);
                if (Result.IsSuccess)
                    return Ok(Result);
                return StatusCode(Result.StatusCode);
            }
            return BadRequest();
        }

        [HttpPatch("DeleteProduct/id")]
        public async Task<IActionResult> Delete(int id)
        {
            if(ModelState.IsValid)
            { 
            var Result = await _service.DeleteProduct(id);
            if (Result.IsSuccess)
                return Ok(Result);
            return StatusCode(Result.StatusCode);
        }
            return BadRequest();
        }
        [HttpPatch("RecovryProduct/id")]
        public async Task<IActionResult> RecovryProduct(int id)
        {
            if (ModelState.IsValid)
            {     
            var Result = await _service.RecovryProduct(id);
            if (Result.IsSuccess)
                return Ok(Result);
            return StatusCode(Result.StatusCode);
        }
            return BadRequest();
    }
}
}
