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
        private UserRepo _userRepo;

        public TradeItemService(IGenericRepo<TradeItem> genericRepo, IMapper mapper, UserRepo userRepo)
            : base(genericRepo, mapper)
        {
            _userRepo = userRepo;
        }

        public async override Task<IEnumerable<TradeItemDTO>> GetAllEntitiesAsync()
        {
            IEnumerable<TradeItem> tradeItems = await _genericRepo.GetAllEntitiesAsync();

            var result = new List<TradeItemDTO>();
            foreach (var tradeItem in tradeItems)
            {
                User user = await _userRepo.GetEntityAsync(tradeItem.UserId);
                result.Add(_mapper.Map<TradeItemDTO>((tradeItem, user)));
            }
            return result;
        }
    }
}