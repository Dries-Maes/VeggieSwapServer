using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeggieSwapServer.Business.DTO;
using VeggieSwapServer.Data.Entities;
using VeggieSwapServer.Data.Repositories;

namespace VeggieSwapServer.Business.Services
{
    public class TradeItemService
    {
        private UserRepo _userRepo;
        private TradeItemRepo _tradeItemRepo;
        private IMapper _mapper;

        public TradeItemService(TradeItemRepo genericRepo, UserRepo userRepo, IMapper mapper)

        {
            _mapper = mapper;
            _userRepo = userRepo;
            _tradeItemRepo = genericRepo;
        }

        public async Task<IEnumerable<TradeItemDto>> GetAllEntitiesAsync()
        {
            return await MapTradeItems(await _tradeItemRepo.GetAllEntitiesAsync());
        }

        public async Task<IEnumerable<TradeItemDto>> GetTradeItemDetailListDtoAsync(int Id)
        {
            return await MapTradeItems(await _tradeItemRepo.GetAllEntitiesAsync(Id));
        }

        private async Task<List<TradeItemDto>> MapTradeItems(IEnumerable<TradeItem> tradeItems)
        {
            IEnumerable<User> Users = await _userRepo.GetAllEntitiesAsync();

            var result = new List<TradeItemDto>();
            foreach (var tradeItem in tradeItems)
            {
                User user = Users.FirstOrDefault(x => x.Id == tradeItem.UserId);
                var item = _mapper.Map<TradeItemDto>(tradeItem);
                item.UserFirstName = user.FirstName;
                item.UserLastName = user.LastName;
                result.Add(item);
            }

            return result;
        }
    }
}