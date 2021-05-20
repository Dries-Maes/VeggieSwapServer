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

        public async Task<IEnumerable<TradeItemOverviewDto>> GetAllEntitiesAsync()
        {
            IEnumerable<TradeItem> tradeItems = await _tradeItemRepo.GetAllEntitiesAsync();
            return await MapTradeItems(tradeItems);
        }

        public async Task<IEnumerable<TradeItemDetailDto>> GetTradeItemDetailListDtoAsync(int Id)
        {
            return _mapper.Map<IEnumerable<TradeItemDetailDto>>(await _tradeItemRepo.GetAllEntitiesAsync(Id));
        }

        private async Task<List<TradeItemOverviewDto>> MapTradeItems(IEnumerable<TradeItem> tradeItems)
        {
            //To Do: replace this method with a automapper function
            IEnumerable<User> Users = await _userRepo.GetAllEntitiesAsync();
            var result = new List<TradeItemOverviewDto>();
            foreach (var tradeItem in tradeItems)
            {
                User user = Users.FirstOrDefault(x => x.Id == tradeItem.UserId);
                var item = _mapper.Map<TradeItemOverviewDto>(tradeItem);
                item.UserFirstName = user.FirstName;
                item.UserLastName = user.LastName;
                result.Add(item);
            }

            return result;
        }
    }
}