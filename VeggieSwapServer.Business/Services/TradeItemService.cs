using AutoMapper;
using System;
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
        public TradeItemRepo _tradeItemRepo;
        private IMapper _mapper;
        private IGenericRepo<Resource> _resourceRepo;

        public TradeItemService(TradeItemRepo genericRepo, UserRepo userRepo, IMapper mapper, IGenericRepo<Resource> resourceRepo)

        {
            _resourceRepo = resourceRepo;
            _mapper = mapper;
            _userRepo = userRepo;
            _tradeItemRepo = genericRepo;
        }

        public async Task<IEnumerable<ResourceDto>> GetAllResourcesAsync()
        {
            return _mapper.Map<IEnumerable<ResourceDto>>(await _resourceRepo.GetAllEntitiesAsync());
        }
       

        public async Task<IEnumerable<TradeItemDto>> GetAllEntitiesAsync()
        {
            return await MapTradeItems(await _tradeItemRepo.GetAllEntitiesAsync());
        }

        public async Task<object> AddTradeItemsAsync(IEnumerable<ResourceDto> addedTradeItems, int id)
        {
            var tradeItems = await _tradeItemRepo.GetAllEntitiesAsync();

            foreach (var item in addedTradeItems)
            {
                TradeItem ExistingItem = tradeItems.FirstOrDefault(x => x.Id == id && x.ResourceId == item.Id);
                if (ExistingItem == null)
                {
                    await _tradeItemRepo.AddEntityAsync(

                         new TradeItem
                         {
                             Amount = item.Amount,
                             ResourceId = item.Id,
                             UserId = id,
                         });
                }
                else
                {
                    ExistingItem.Amount = item.Amount;
                    await _tradeItemRepo.UpdateEntityAsync(ExistingItem);
                }
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