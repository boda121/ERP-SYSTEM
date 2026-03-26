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
        protected readonly IService_Layer<TEntity> _context;
        protected readonly IMapper _mapper;
        public GenericController(IService_Layer<TEntity> context, IMapper mapper)
        {
            this._context = context;
           this._mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _context.getall();
            var result = _mapper.Map<List<TReadDto>>(data);

            return Ok(result);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _context.GetById(id);

            var result = _mapper.Map<TReadDto>(data);

            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(TCreateDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _context.add(entity);
            return Ok(dto);
        }

        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, TReadDto dto)
        {
           var res= _mapper.Map<TEntity>(dto);
            await _context.Update(id,res);

            return Ok(dto);
        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {

             var Result =  await _context.Delete(id);
                if (Result == $"{typeof(TEntity).Name} Deleted")
                    return Ok(Result);
                else if (Result == "This item Already Deleted")
                    return BadRequest(Result);
                else if (Result == "Not Found Any Item For This Id")
                    return NotFound(Result);
            }

            return BadRequest("Error");
        }

        [HttpDelete("Recovry/{id}")]
        public async Task<IActionResult> Recovry(int id)
        {
            if (ModelState.IsValid)
            {

                var Result = await _context.Recovry(id);
                if (Result == $"{typeof(TEntity).Name} Recovryd")
                    return Ok(Result);
                else if (Result == "This item Already Recovryd")
                    return BadRequest(Result);
                else if (Result == "Not Found Any Item For This Id")
                    return NotFound(Result);
            }

            return BadRequest("Error");
        }
    }
}