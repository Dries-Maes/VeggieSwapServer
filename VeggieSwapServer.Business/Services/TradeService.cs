using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VeggieSwapServer.Business.Models;
using VeggieSwapServer.Data.Entities;
using VeggieSwapServer.Data.Repositories;

namespace VeggieSwapServer.Business.Services
{
    public class TradeService : GenericService<Trade>
    {
        public TradeService(IGenericRepo<Trade> _genericRepo, IMapper mapper)
            : base(_genericRepo, mapper)
        {
        }

        //public async Task<TradeModel> MapTrade(int id)
        //{
        //    Trade TradeModel = await GetEntityAsync(id);
        //    TradeModel mappedModel = _mapper.Map<TradeModel>(TradeModel);
        //    return mappedModel;
        //}

        public override object Map(Trade entity)
        {
            var test = _mapper.Map<TradeModel>(entity);
            var test2 = test;
            return test2;
        }
    }
}