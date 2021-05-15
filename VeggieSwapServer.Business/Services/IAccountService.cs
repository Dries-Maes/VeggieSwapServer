using System.Threading.Tasks;
using VeggieSwapServer.Business.DTO;

namespace VeggieSwapServer.Business.Services
{
    public interface IAccountService
    {
        Task<UserDto> LoginAsync(string name, string password);
        Task<UserDto> RegisterAsync(string userName, string password);
        Task<bool> UserExists(string userName);
    }
}