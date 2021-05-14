using AutoMapper;
using VeggieSwapServer.Business.Models;
using VeggieSwapServer.Data.Entities;
using VeggieSwapServer.Data.Repositories;

namespace VeggieSwapServer.Business.Services
{
    public class UserService : GenericService<User, UserModel>
    {
        public UserService(IGenericRepo<User> genericRepo, IMapper mapper)
            : base(genericRepo, mapper)
        {
        }
    }
}