using AutoMapper;
using VeggieSwapServer.Business.Models;
using VeggieSwapServer.Data.Entities;
using VeggieSwapServer.Data.Repositories;

namespace VeggieSwapServer.Business.Services
{
    public class PurchaseService : GenericService<Purchase, PurchaseModel>
    {
        public PurchaseService(IGenericRepo<Purchase> genericRepo, IMapper mapper)
            : base(genericRepo, mapper)
        {
        }
    }
}