using AutoMapper;
using VeggieSwapServer.Business.Models;
using VeggieSwapServer.Data.Entities;
using VeggieSwapServer.Data.Repositories;

namespace VeggieSwapServer.Business.Services
{
    public class AddressService : GenericService<Address, AddressModel>
    {
        public AddressService(IGenericRepo<Address> genericRepo, IMapper mapper)
            : base(genericRepo, mapper)
        {
        }
    }
}