using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeggieSwapServer.Business.Models;
using VeggieSwapServer.Business.Services;

namespace VeggieSwapServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WalletController : ControllerBase
    {
        private WalletService _walletService;

        public WalletController(WalletService walletService)
        {
            _walletService = walletService;
        }

        [HttpGet]
        public async Task<IEnumerable<object>> GetMembersAsync()
        {
            return await _walletService.GetAllEntitiesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WalletModel>> GetMemberAsync(int id)
        {
            return Ok(await _walletService.GetEntityAsync(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WalletModel>> DeleteMemberAsync(int id)
        {
            return Ok(await _walletService.DeleteEntityAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> PostMemberAsync(WalletModel model)
        {
            return Ok(await _walletService.AddEntityAsync(model));
        }

        [HttpPut]
        public async Task<ActionResult> PutMemberAsync(WalletModel model)
        {
            return Ok(await _walletService.UpdateEntityAsync(model));
        }
    }
}