using AutoMapper;
using ERP.Core.DTOs;
using ERP.Core.Interfaces;
using ERP.Core.Models;
using ERP.Services.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PurchaseController : ControllerBase
    {
        private readonly PurchaseService _purchaseService;
        private readonly IService_Layer<Supplier> _Supplier;
        private readonly IService_Layer<PurchaseInvoice> _Purchase;
        private readonly IMapper _mapper;
        public PurchaseController(PurchaseService purchaseService, IService_Layer<Supplier> Supplier, IService_Layer<PurchaseInvoice> Purchase, IMapper mapper)
        {
            _purchaseService = purchaseService;
            _Supplier = Supplier;
            _Purchase = Purchase;
            _mapper = mapper;
        }


        [HttpPost("AddPurchase")]
        public async Task<IActionResult> AddPurchase(PurchaseInvoiceDto dto)
        {
          await  _purchaseService.CreatePurchaseInvoice(dto);
            return Ok(dto);
            
        }
        [HttpGet("GetAllPurchase")]
        public async Task<IActionResult> GetAllPurchase()
        {
            return Ok(await _Purchase.getall());

        }
        [HttpGet("GetPurchaseByID/{id}")]
        public async Task<IActionResult> GetPurchaseByID(int id)
        {
            return Ok(await _Purchase.GetById(id));

        }
        [HttpGet("GetAllSupplier")]
        public async Task<IActionResult> GetAllSupplier()
        {
            return Ok(await _Supplier.getall());

        }
        [HttpPost("AddSupplier")]
        public async Task<IActionResult> AddSupplier(SupplierDto dto)
        {
            var res = _mapper.Map<Supplier>(dto);
            await _Supplier.add(res);
            return Ok(res);
        }
        [HttpGet("GetSupplierByID/{id}")]
        public async Task<IActionResult> GetSupplierByID(int id)
        {
            return Ok(await _Supplier.GetById(id));

        }
        [HttpPatch("DeleteSupplier/{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            await _Supplier.Delete(id);
            return Ok("Done");
        }
        [HttpDelete("RecovrySupplier/{id}")]
        public async Task<IActionResult> RecovrySupplier(int id)
        {
            await _Supplier.Recovry(id);
            return Ok("Done");
        }
        [HttpDelete("EditSupplier/{id}")]
        public async Task<IActionResult> EditSupplier(int id, SupplierDto dto)
        {
            var res = _mapper.Map<Supplier>(dto);
            await _Supplier.Update(id,res);
            return Ok("Done");
        }
    }
}
