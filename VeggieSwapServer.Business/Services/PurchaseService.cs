using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VeggieSwapServer.Business.Models;
using VeggieSwapServer.Data.Entities;
using VeggieSwapServer.Data.Repositories;

namespace VeggieSwapServer.Business.Services
{
    public class PurchaseService : GenericService<Purchase>
    {
        public PurchaseService(IGenericRepo<Purchase> _genericRepo, IMapper mapper)
            : base(_genericRepo, mapper)
        {
        }

        //public async Task<PurchaseModel> MapPurchase(int id)
        //{
        //    Purchase PurchaseModel = await GetEntityAsync(id);
        //    PurchaseModel mappedModel = _mapper.Map<PurchaseModel>(PurchaseModel);
        //    return mappedModel;
        //}

        public override object Map(Purchase entity)
        {
            var test = _mapper.Map<PurchaseModel>(entity);
            var test2 = test;
            return test2;
        }
    }
}