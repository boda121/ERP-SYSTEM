using AutoMapper;
using ERP.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace ERP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenericController<TEntity, TReadDto, TCreateDto> : ControllerBase
     where TEntity : class
    {
        protected readonly IService_Layer<TEntity,TCreateDto> _context;
        protected readonly IMapper _mapper;
        public GenericController(IService_Layer<TEntity,TCreateDto> context, IMapper mapper)
        {
            this._context = context;
           this._mapper = mapper;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            if (ModelState.IsValid)
            {
                var data = await _context.getall();
                if (!data.IsSuccess)
                    return StatusCode(data.StatusCode);
                return Ok(data);

            }
                return BadRequest();
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (ModelState.IsValid)
            {
                var data = await _context.GetById(id);
                if(data.IsSuccess)
                return Ok(data);
                return StatusCode(data.StatusCode);
            }
            return BadRequest();
        }

        [HttpPost("Add")]
       // [Authorize]
        public async Task<IActionResult> Add(TCreateDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = await _context.add(dto);
                if (!result.IsSuccess)
                    return StatusCode(result.StatusCode);
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, TCreateDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = await _context.Update(id, dto);
                if (result.IsSuccess)
                return Ok(result);
                return StatusCode(result.StatusCode);
            }
            return BadRequest();
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {

                var Result = await _context.Delete(id);
                if (!Result.IsSuccess)
                    return StatusCode(Result.StatusCode);
                return Ok(Result);
            }
            return BadRequest();
        }
        [HttpDelete("Recovry/{id}")]
        public async Task<IActionResult> Recovry(int id)
        {
            if (ModelState.IsValid)
            {
                var Result = await _context.Recovry(id);
                if (!Result.IsSuccess)
                    return StatusCode(Result.StatusCode);
                return Ok(Result);
            }
            return BadRequest();
        }

    }
}