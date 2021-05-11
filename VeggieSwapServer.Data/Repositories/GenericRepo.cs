using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VeggieSwapServer.Data.Repositories
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private VeggieSwapServerContext _context;

        public GenericRepo(VeggieSwapServerContext context)
        {
            _context = context;
        }

        public virtual async Task<bool> AddItemAsync(T item)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();

            return true;
        }

        public virtual async Task<bool> AddItemsAsync(IEnumerable<T> items)
        {
            await _context.AddRangeAsync(items);
            await _context.SaveChangesAsync();

            return true;
        }

        public virtual async Task<bool> UpdateItemsAsync(IEnumerable<T> items)
        {
            _context.UpdateRange(items);
            await _context.SaveChangesAsync();

            return true;
        }

        public virtual async Task<bool> DeleteItemAsync(int id)
        {
            var item = await GetItemAsync(id);
            _context.Remove(item);

            return true;
        }

        public virtual async Task<List<T>> GetAllItemsAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetItemAsync(int id)
        {
            return await _context.FindAsync<T>(id);
        }
    }
}