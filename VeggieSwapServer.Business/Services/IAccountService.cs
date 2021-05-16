using System.Threading.Tasks;
using VeggieSwapServer.Business.DTO;

namespace VeggieSwapServer.Business.Services
{
    public interface IAccountService
    {
        Task<UserTokenDTO> LoginAsync(string eMail, string password);

        Task<UserTokenDTO> RegisterAsync(RegisterDTO dto);
    }
}