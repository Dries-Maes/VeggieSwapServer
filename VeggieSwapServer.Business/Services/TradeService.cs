using AutoMapper;
using VeggieSwapServer.Business.Models;
using VeggieSwapServer.Data.Entities;
using VeggieSwapServer.Data.Repositories;

namespace VeggieSwapServer.Business.Services
{
    public class TradeService : GenericService<Trade, TradeModel>
    {
        public TradeService(IGenericRepo<Trade> genericRepo, IMapper mapper)
            : base(genericRepo, mapper)
        {
        }
    }
}