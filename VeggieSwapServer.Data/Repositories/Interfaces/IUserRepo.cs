using System.Collections.Generic;
using System.Threading.Tasks;
using VeggieSwapServer.Data.Entities;

namespace VeggieSwapServer.Data.Repositories
{
    public interface IUserRepo : IGenericRepo<User>
    {
        Task<IEnumerable<User>> GetAllEntitiesAsync(bool includeAddress);

        Task<User> GetEntityAsync(string email);

        Task<bool> UserExistsAsync(string eMail);

        Task<User> GetUserAsync(int id);
    }
}