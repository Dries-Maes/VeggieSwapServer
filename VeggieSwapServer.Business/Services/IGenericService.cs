using System.Collections.Generic;
using System.Threading.Tasks;

namespace VeggieSwapServer.Business
{
    public interface IGenericService<T>
    {
        Task<bool> AddEntitiesAsync(IEnumerable<T> entities);

        Task<bool> AddEntityAsync(T entity);

        Task<bool> DeleteEntityAsync(int id);

        Task<IEnumerable<object>> GetAllEntitiesAsync();

        Task<object> GetEntityAsync(int id);

        Task<bool> UpdateEntitiesAsync(IEnumerable<T> entities);

        object Map(T entity);

        IEnumerable<object> Map(IEnumerable<T> entities);
    }
}