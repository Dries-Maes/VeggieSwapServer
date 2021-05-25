using System.Threading.Tasks;
using VeggieSwapServer.Business.DTO;

namespace VeggieSwapServer.Business.Services
{
    public interface IAccountService
    {
        Task<UserTokenDto> LoginAsync(string eMail, string password);

        Task<UserTokenDto> RegisterAsync(RegisterDto dto);
    }
}