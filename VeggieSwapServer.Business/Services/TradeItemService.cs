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

        public TradeItemService(TradeItemRepo genericRepo, UserRepo userRepo)

        {
            _userRepo = userRepo;
            _tradeItemRepo = genericRepo;
        }

        public async Task<IEnumerable<TradeItemDto>> GetAllEntitiesAsync()
        {
            IEnumerable<TradeItem> tradeItems = await _tradeItemRepo.GetAllEntitiesAsync();
            return await MapTradeItems(tradeItems);
        }

        private async Task<List<TradeItemDto>> MapTradeItems(IEnumerable<TradeItem> tradeItems)
        {
            //To Do: replace this method with a automapper function
            IEnumerable<User> Users = await _userRepo.GetAllEntitiesAsync();
            var result = new List<TradeItemDto>();
            foreach (var tradeItem in tradeItems)
            {
                User user = Users.FirstOrDefault(x => x.Id == tradeItem.UserId);
                var item = new TradeItemDto
                {
                    UserFirstName = user.FirstName,
                    UserLastName = user.LastName,
                    Id = tradeItem.Id,
                    Amount = tradeItem.Amount,
                    ResourceId = tradeItem.Resource.Id,
                    ResourceName = tradeItem.Resource.Name,
                    ResourceImageUrl = tradeItem.Resource.ImageUrl,
                    UserId = tradeItem.UserId,
                };
                result.Add(item);
            }

            return result;
        }
    }
}