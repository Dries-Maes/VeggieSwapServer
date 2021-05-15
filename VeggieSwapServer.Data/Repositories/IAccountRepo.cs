using System.Threading.Tasks;
using VeggieSwapServer.Data.Entities;

namespace VeggieSwapServer.Data.Repositories
{
    public interface IAccountRepo
    {
        Task<bool> AddUserAsync(User user);
        Task<User> GetUserByNameAsync(string name);
        Task<bool> UserExistsAsync(string userName);
    }
}