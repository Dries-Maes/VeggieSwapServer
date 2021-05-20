using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeggieSwapServer.Business.Models;
using VeggieSwapServer.Data.Entities;
using VeggieSwapServer.Data.Repositories;

namespace VeggieSwapServer.Business.Services
{
    public class UserService : GenericService<User, UserDTO>
    {
        internal IUserRepo _userRepo;

        public UserService(IGenericRepo<User> genericRepo, IMapper mapper, IUserRepo userRepo)
            : base(genericRepo, mapper)
        {
            _userRepo = userRepo;
        }

        public virtual async Task<IEnumerable<UserDTO>> GetAllEntitiesAsync(bool includeAddress)
        {
            if (includeAddress)
            {
                return _mapper.Map<IEnumerable<UserDTO>>(await _userRepo.GetAllEntitiesAsync(true));
            }
            else
            {
                return await base.GetAllEntitiesAsync();
            }
        }

        public async Task<UserDTO> GetUserAsync(int id)
        {
            return _mapper.Map<UserDTO>(await _userRepo.GetUserAsync(id));
        }
    }
}