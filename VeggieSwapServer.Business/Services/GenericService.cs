using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeggieSwapServer.Data.Repositories;

namespace VeggieSwapServer.Business
{
    public class GenericService<Entity, Model>
    {
        private IGenericRepo<Entity> _genericRepo;
        protected IMapper _mapper;

        public GenericService(IGenericRepo<Entity> genericRepo, IMapper mapper)
        {
            _genericRepo = genericRepo;
            _mapper = mapper;
        }

        public virtual async Task<bool> AddEntityAsync(Model model)
        {
            return await _genericRepo.AddEntityAsync(_mapper.Map<Entity>(model));
        }

        public virtual async Task<bool> AddEntitiesAsync(IEnumerable<Model> models)
        {
            return await _genericRepo.AddEntitiesAsync(_mapper.Map<IEnumerable<Entity>>(models));
        }

        public virtual async Task<bool> UpdateEntitiesAsync(IEnumerable<Model> models)
        {
            return await _genericRepo.UpdateEntitiesAsync(_mapper.Map<IEnumerable<Entity>>(models));
        }

        public virtual async Task<bool> UpdateEntityAsync(Model model)
        {
            return await _genericRepo.UpdateEntityAsync(_mapper.Map<Entity>(model));
        }

        public virtual async Task<bool> DeleteEntityAsync(int id)
        {
            return await _genericRepo.DeleteEntityAsync(id);
        }

        public virtual async Task<IEnumerable<Model>> GetAllEntitiesAsync()
        {
            return _mapper.Map<IEnumerable<Model>>(await _genericRepo.GetAllEntitiesAsync());
        }

        public virtual async Task<Model> GetEntityAsync(int id)
        {
            return _mapper.Map<Model>(await _genericRepo.GetEntityAsync(id));
        }
    }
}