using AutoMapper;
using VeggieSwapServer.Business.Models;
using VeggieSwapServer.Data.Entities;
using VeggieSwapServer.Data.Repositories;

namespace VeggieSwapServer.Business.Services
{
    public class WalletService : GenericService<Wallet, WalletModel>
    {
        public WalletService(IGenericRepo<Wallet> genericRepo, IMapper mapper)
            : base(genericRepo, mapper)
        {
        }
    }
}