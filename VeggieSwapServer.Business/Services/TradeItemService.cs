using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeggieSwapServer.Business.DTO;
using VeggieSwapServer.Data.Entities;
using VeggieSwapServer.Data.Repositories;

namespace VeggieSwapServer.Business.Services
{
    public class TradeItemService : GenericService<TradeItem, TradeItemDto>, ITradeItemService
    {
        private IUserRepo _userRepo;
        public ITradeItemRepo _tradeItemRepo;
        private IGenericRepo<Resource> _resourceRepo;

        public TradeItemService(ITradeItemRepo genericRepo, IUserRepo userRepo, IMapper mapper, IGenericRepo<Resource> resourceRepo, ITradeItemRepo tradeItemRepo)
            : base(tradeItemRepo, mapper)
        {
            _resourceRepo = resourceRepo;
            _userRepo = userRepo;
            _tradeItemRepo = genericRepo;
        }

        public async Task<IEnumerable<ResourceDto>> GetAllResourcesAsync()
        {
            return _mapper.Map<IEnumerable<ResourceDto>>(await _resourceRepo.GetAllEntitiesAsync());
        }

        public override async Task<IEnumerable<TradeItemDto>> GetAllEntitiesAsync()
        {
            return await MapTradeItems(await _tradeItemRepo.GetAllEntitiesAsync());
        }

        public async Task<object> AddTradeItemsAsync(ResourceDto addedTradeItem, int id)
        {
            var tradeItems = await _tradeItemRepo.GetAllEntitiesAsync();

            TradeItem ExistingItem = tradeItems.FirstOrDefault(x => x.Id == id && x.ResourceId == addedTradeItem.Id);
            if (ExistingItem == null)
            {
                await _tradeItemRepo.AddEntityAsync(

                     new TradeItem
                     {
                         Amount = addedTradeItem.Amount,
                         ResourceId = addedTradeItem.Id,
                         UserId = id,
                     });
            }
            else
            {
                ExistingItem.Amount = addedTradeItem.Amount;
                await _tradeItemRepo.UpdateEntityAsync(ExistingItem);
            }

            return true;
        }

        public async Task UpdateTradeItems(IEnumerable<TradeItemDto> tradeItems)
        {
            await _tradeItemRepo.UpdateEntitiesAsync(_mapper.Map<IEnumerable<TradeItem>>(tradeItems));
        }

        public async Task<IEnumerable<TradeItemDto>> GetTradeItemDetailListDtoAsync(int Id)
        {
            return await MapTradeItems(await _tradeItemRepo.GetAllTradeItemsByUserIdAsync(Id));
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