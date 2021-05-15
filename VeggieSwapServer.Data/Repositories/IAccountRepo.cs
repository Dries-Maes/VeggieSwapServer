using System.Threading.Tasks;
using VeggieSwapServer.Data.Entities;

namespace VeggieSwapServer.Data.Repositories
{
    public interface IAccountRepo
    {
        Task<bool> AddUserAsync(User user);
        Task<User> GetUserByEmailAsync(string eMail);
        Task<bool> UserExistsAsync(string eMail);
    }
}