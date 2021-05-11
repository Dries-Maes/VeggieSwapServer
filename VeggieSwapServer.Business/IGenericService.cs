using System.Collections.Generic;
using System.Threading.Tasks;

namespace VeggieSwapServer.Business
{
    public interface IGenericService<T>
    {
        Task<bool> AddItemAsync(T item);

        Task<bool> AddItemsAsync(IEnumerable<T> items);

        Task<bool> DeleteItemAsync(int id);

        Task<List<T>> GetAllItemsAsync();

        Task<T> GetItemAsync(int id);

        Task<bool> UpdateItemsAsync(IEnumerable<T> items);
    }
}