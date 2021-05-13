using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeggieSwapServer.Business;
using VeggieSwapServer.Business.Models;
using VeggieSwapServer.Business.Services;

namespace VeggieSwapServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseController : ControllerBase
    {
        private PurchaseService _PurchaseService;
        private IMapper _mapper;

        public PurchaseController(PurchaseService PurchaseService, IMapper mapper)
        {
            _PurchaseService = PurchaseService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<object>> GetPurchasesAsync()
        {
            var test = await _PurchaseService.GetAllEntitiesAsync();
            return test;
        }

        //[HttpPost]
        //public async Task AddPurchase(Purchase Purchase)
        //{
        //    await _PurchaseService.AddEntityAsync(Purchase);
        //}

        [HttpGet("/{id}")]
        public async Task<ActionResult<PurchaseModel>> GetMemberAsync(int id)
        {
            //Purchase PurchaseModel = await _PurchaseService.GetEntityAsync(id);
            //return Ok(member);
            //PurchaseModel mappedModel = _mapper.Map<PurchaseModel>(PurchaseModel);
            //

            //return  Ok(await _PurchaseService.MapPurchase(id));
            var test = await _PurchaseService.GetEntityAsync(id);
            return Ok(test);
        }
    }
}