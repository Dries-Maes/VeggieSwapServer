using AutoMapper;
using VeggieSwapServer.Business.Models;
using VeggieSwapServer.Data.Entities;
using VeggieSwapServer.Data.Repositories;

namespace VeggieSwapServer.Business.Services
{
    public class TradeItemService : GenericService<TradeItem, TradeItemModel>
    {
        public TradeItemService(IGenericRepo<TradeItem> genericRepo, IMapper mapper)
            : base(genericRepo, mapper)
        {
        }
    }
}