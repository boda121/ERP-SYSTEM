using AutoMapper;
using ERP.API.Mapping;
using ERP.Core.DTOs;
using ERP.Core.Interfaces;
using ERP.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : GenericController<Category,CategoryDto,CategoryDto>
    {
       
        public CategoryController(IService_Layer<Category,CategoryDto> context, IMapper mapping) : base(context, mapping)
        {
           
        }
       
    }
}
