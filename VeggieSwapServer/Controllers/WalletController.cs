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
    public class WalletController : ControllerBase
    {
        private WalletService _WalletService;
        private IMapper _mapper;

        public WalletController(WalletService WalletService, IMapper mapper)
        {
            _WalletService = WalletService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<object>> GetWalletsAsync()
        {
            var test = await _WalletService.GetAllEntitiesAsync();
            return test;
        }

        //[HttpPost]
        //public async Task AddWallet(Wallet Wallet)
        //{
        //    await _WalletService.AddEntityAsync(Wallet);
        //}

        [HttpGet("/{id}")]
        public async Task<ActionResult<WalletModel>> GetMemberAsync(int id)
        {
            //Wallet WalletModel = await _WalletService.GetEntityAsync(id);
            //return Ok(member);
            //WalletModel mappedModel = _mapper.Map<WalletModel>(WalletModel);
            //

            //return  Ok(await _WalletService.MapWallet(id));
            var test = await _WalletService.GetEntityAsync(id);
            return Ok(test);
        }
    }
}