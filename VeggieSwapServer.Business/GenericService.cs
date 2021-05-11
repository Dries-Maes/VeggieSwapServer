using System.Collections.Generic;
using System.Threading.Tasks;
using VeggieSwapServer.Data.Repositories;

namespace VeggieSwapServer.Business
{
    public class GenericService<T> : IGenericService<T>
    {
        private IGenericRepo<T> _genericRepo;

        public GenericService(IGenericRepo<T> genericRepo)
        {
            _genericRepo = genericRepo;
        }

        public virtual async Task<bool> AddItemAsync(T item)
        {
            return await _genericRepo.AddItemAsync(item);
        }

        public virtual async Task<bool> AddItemsAsync(IEnumerable<T> items)
        {
            return await _genericRepo.AddItemsAsync(items);
        }

        public virtual async Task<bool> UpdateItemsAsync(IEnumerable<T> items)
        {
            return await _genericRepo.UpdateItemsAsync(items);
        }

        public virtual async Task<bool> DeleteItemAsync(int id)
        {
            return await _genericRepo.DeleteItemAsync(id);
        }

        public virtual async Task<List<T>> GetAllItemsAsync()
        {
            return await _genericRepo.GetAllItemsAsync();
        }

        public virtual async Task<T> GetItemAsync(int id)
        {
            return await _genericRepo.GetItemAsync(id);
        }
    }
}