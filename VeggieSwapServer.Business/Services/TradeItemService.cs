using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeggieSwapServer.Business.DTO;
using VeggieSwapServer.Data.Entities;
using VeggieSwapServer.Data.Repositories;

namespace VeggieSwapServer.Business.Services
{
    public class TradeItemService : GenericService<TradeItem, TradeItemDTO>
    {
        private TradeItemRepo _tradeItemRepo;

        public TradeItemService(IMapper mapper, TradeItemRepo tradeItemRepo)
            : base(tradeItemRepo, mapper)
        {
            _tradeItemRepo = tradeItemRepo;
        }

        public async override Task<IEnumerable<TradeItemDTO>> GetAllEntitiesAsync()
        {   
            var test = _mapper.Map<IEnumerable<TradeItemDTO>>(await _tradeItemRepo.GetAllEntitiesAsync());
            return test;
        }
    }
}