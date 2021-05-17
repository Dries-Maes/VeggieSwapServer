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
        private IGenericRepo<TradeItem> _genericRepo;
        private IMapper _mapper;

        public TradeItemService(IGenericRepo<TradeItem> genericRepo, UserRepo userRepo, IMapper mapper)

        {
            _userRepo = userRepo;
            _genericRepo = genericRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TradeItemDto>> GetAllEntitiesAsync()
        {
            //To Do: replace this method with a automapper function
            IEnumerable<TradeItem> tradeItems = await _genericRepo.GetAllEntitiesAsync();
            IEnumerable<User> Users = await _userRepo.GetAllEntitiesAsync();
            var result = new List<TradeItemDto>();
            foreach (var tradeItem in tradeItems)
            {
                User user = Users.FirstOrDefault(x => x.Id == tradeItem.Id);
                var item = new TradeItemDto
                {
                    UserFirstName = user.FirstName,
                    UserLastName = user.LastName,
                    Id = tradeItem.Id,
                    Amount = tradeItem.Amount,
                    ResourceId = tradeItem.Resource.Id,
                    ResourceName = tradeItem.Resource.Name,
                    ResourceImageUrl = tradeItem.Resource.ImageUrl,
                    UserId = tradeItem.UserId
                };
                result.Add(item);
            }
            return result;
        }
    }
}