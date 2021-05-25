using System.Collections.Generic;
using System.Threading.Tasks;
using VeggieSwapServer.Business.Models;
using VeggieSwapServer.Data.Entities;

namespace VeggieSwapServer.Business.Services
{
    public interface IUserService : IGenericService<User, UserDto>
    {
        Task<IEnumerable<UserDto>> GetAllEntitiesAsync(bool includeAddress);

        Task<UserDto> GetUserAsync(int id);
    }
}