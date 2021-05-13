using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VeggieSwapServer.Business.Models;
using VeggieSwapServer.Data.Entities;
using VeggieSwapServer.Data.Repositories;

namespace VeggieSwapServer.Business.Services
{
    public class TradeItemService : GenericService<TradeItem>
    {
        public TradeItemService(IGenericRepo<TradeItem> _genericRepo, IMapper mapper)
            : base(_genericRepo, mapper)
        {
        }

        //public async Task<TradeItemModel> MapTradeItem(int id)
        //{
        //    TradeItem TradeItemModel = await GetEntityAsync(id);
        //    TradeItemModel mappedModel = _mapper.Map<TradeItemModel>(TradeItemModel);
        //    return mappedModel;
        //}

        public override object Map(TradeItem entity)
        {
            var test = _mapper.Map<TradeItemModel>(entity);
            var test2 = test;
            return test2;
        }
    }
}