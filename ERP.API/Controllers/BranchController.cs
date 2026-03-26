using AutoMapper;
using ERP.Core.DTOs;
using ERP.Core.Interfaces;
using ERP.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BranchController : GenericController<Branch, BranchDto, BranchDto>
    {
        public BranchController(IService_Layer<Branch> context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
