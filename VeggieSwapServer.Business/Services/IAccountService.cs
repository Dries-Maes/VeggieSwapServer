using System.Threading.Tasks;
using VeggieSwapServer.Business.DTO;

namespace VeggieSwapServer.Business.Services
{
    public interface IAccountService
    {
        Task<UserDto> LoginAsync(string eMail, string password);

        Task<UserDto> RegisterAsync(RegisterDTO dto);

        Task<bool> UserExists(string eMail);
    }
}