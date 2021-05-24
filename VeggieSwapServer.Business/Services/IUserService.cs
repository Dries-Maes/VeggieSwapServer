using System.Collections.Generic;
using System.Threading.Tasks;
using VeggieSwapServer.Business.Models;

namespace VeggieSwapServer.Business.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllEntitiesAsync(bool includeAddress);
    }
}