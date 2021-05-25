using VeggieSwapServer.Data.Entities;

namespace VeggieSwapServer.Business.Services
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}