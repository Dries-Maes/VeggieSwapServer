using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeggieSwapServer.Data.Entities;

namespace VeggieSwapServer.Data.Repositories
{
    public class GenericRepo<T> : IGenericRepo<T> where T : EntityBase
    {
        private VeggieSwapServerContext _context;

        public GenericRepo(VeggieSwapServerContext context)
        {
            _context = context;
        }

        public virtual async Task<bool> AddEntityAsync(T entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> AddEntitiesAsync(IEnumerable<T> entities)
        {
            await _context.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> UpdateEntitiesAsync(IEnumerable<T> entities)
        {
            _context.UpdateRange(entities);
            await _context.SaveChangesAsync();

            return true;
        }

        public virtual async Task<bool> UpdateEntityAsync(T entity)
        {
            entity.ModifiedAt = DateTime.Now;
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> DeleteEntityAsync(int id)
        {
            _context.Remove(await _context.FindAsync<T>(id));
            await _context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<IEnumerable<T>> GetAllEntitiesAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetEntityAsync(int id)
        {
            return await _context.FindAsync<T>(id);
        }        
    }
}