using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeggieSwapServer.Business.Models;
using VeggieSwapServer.Data.Entities;
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

        public virtual async Task<bool> AddEntityAsync(T entity)
        {
            return await _genericRepo.AddEntityAsync(entity);
        }

        public virtual async Task<bool> AddEntitiesAsync(IEnumerable<T> entities)
        {
            return await _genericRepo.AddEntitiesAsync(entities);
        }

        public virtual async Task<bool> UpdateEntitiesAsync(IEnumerable<T> entities)
        {
            return await _genericRepo.UpdateEntitiesAsync(entities);
        }

        public virtual async Task<bool> DeleteEntityAsync(int id)
        {
            return await _genericRepo.DeleteEntityAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAllEntitiesAsync()
        {
            var entities = await _genericRepo.GetAllEntitiesAsync();
            //var mappedEntities = _mapper.Map<IEnumerable<AddressModel>>(entities);
            //return (IEnumerable<T>)mappedEntities;
            return null;
        }

        public virtual async Task<T> GetEntityAsync(int id)
        {
            
            var entity = await _genericRepo.GetEntityAsync(id);
            
            //var mappedEntity = _mapper.Map<T>(entity);

            return entity;
        }
    }
}