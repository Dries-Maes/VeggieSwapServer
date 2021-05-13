using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VeggieSwapServer.Business.Models;
using VeggieSwapServer.Data.Entities;
using VeggieSwapServer.Data.Repositories;

namespace VeggieSwapServer.Business.Services
{
    public class WalletService : GenericService<Wallet>
    {
        public WalletService(IGenericRepo<Wallet> _genericRepo, IMapper mapper)
            : base(_genericRepo, mapper)
        {
        }

        //public async Task<WalletModel> MapWallet(int id)
        //{
        //    Wallet WalletModel = await GetEntityAsync(id);
        //    WalletModel mappedModel = _mapper.Map<WalletModel>(WalletModel);
        //    return mappedModel;
        //}

        public override object Map(Wallet entity)
        {
            var test = _mapper.Map<WalletModel>(entity);
            var test2 = test;
            return test2;
        }
    }
}