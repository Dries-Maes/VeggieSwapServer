using System.Collections.Generic;
using System.Threading.Tasks;
using VeggieSwapServer.Business.DTO;
using VeggieSwapServer.Data.Entities;

namespace VeggieSwapServer.Business.Services
{
    public interface ITradeItemService : IGenericService<TradeItem, TradeItemDto>
    {
        Task<object> AddTradeItemsAsync(ResourceDto addedTradeItem, int id);

        Task<IEnumerable<ResourceDto>> GetAllResourcesAsync();

        Task<IEnumerable<TradeItemDto>> GetTradeItemDetailListDtoAsync(int Id);

        Task UpdateTradeItems(IEnumerable<TradeItemDto> tradeItems);
    }
}