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
        protected IMapper _mapper;

        public GenericService(IGenericRepo<T> genericRepo, IMapper mapper)
        {
            _genericRepo = genericRepo;
            _mapper = mapper;
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

        public virtual async Task<IEnumerable<object>> GetAllEntitiesAsync()
        {
            var entities = await _genericRepo.GetAllEntitiesAsync();
            var mappedEntities = Map(entities);
            //var mappedEntities = _mapper.Map<IEnumerable<AddressModel>>(entities);
            //return (IEnumerable<T>)mappedEntities;
            return mappedEntities;
        }

        public virtual async Task<object> GetEntityAsync(int id)
        {
            var entity = await _genericRepo.GetEntityAsync(id);
            var mappedEntity = Map(entity);

            //var mappedEntity = _mapper.Map<T>(entity);

            return mappedEntity;
        }

        public virtual object Map(T entity)
        {
            return _mapper.Map<object>(entity);
        }

        public virtual IEnumerable<object> Map(IEnumerable<T> entities)
        {
            return _mapper.Map<IEnumerable<object>>(entities);
        }
    }
}