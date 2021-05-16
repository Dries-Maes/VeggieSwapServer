using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeggieSwapServer.Business.Models;
using VeggieSwapServer.Data.Entities;
using VeggieSwapServer.Data.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace VeggieSwapServer.Business.Services
{
    public class UserService : GenericService<User, UserModel>
    {
        internal IUserRepo _userRepo;

        public UserService(IGenericRepo<User> genericRepo, IMapper mapper, IUserRepo userRepo)
            : base(genericRepo, mapper)
        {
            _userRepo = userRepo;
        }

        public virtual async Task<IEnumerable<UserModel>> GetAllEntitiesAsync(bool includeAddress)
        {
            if (includeAddress)
            {
                return _mapper.Map<IEnumerable<UserModel>>(await _userRepo.GetAllEntitiesAsync(true));
            }
            else
            {
                return await base.GetAllEntitiesAsync();
            }
        }
    }
}