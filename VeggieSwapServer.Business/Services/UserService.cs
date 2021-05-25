using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeggieSwapServer.Business.Models;
using VeggieSwapServer.Data.Entities;
using VeggieSwapServer.Data.Repositories;

namespace VeggieSwapServer.Business.Services
{
    public class UserService : GenericService<User, UserDto>, IUserService
    {
        internal IUserRepo _userRepo;
        internal IGenericRepo<Address> _addressRepo;

        public UserService(IUserRepo genericRepo, IMapper mapper, IUserRepo userRepo, IGenericRepo<Address> addressRepo)
            : base(genericRepo, mapper)
        {
            _userRepo = userRepo;
            _addressRepo = addressRepo;
        }

        public virtual async Task<IEnumerable<UserDto>> GetAllEntitiesAsync(bool includeAddress)
        {
            if (includeAddress)
            {
                return _mapper.Map<IEnumerable<UserDto>>(await _userRepo.GetAllEntitiesAsync(true));
            }
            else
            {
                return await base.GetAllEntitiesAsync();
            }
        }

        public async Task<UserDto> GetUserAsync(int id)
        {
            return _mapper.Map<UserDto>(await _userRepo.GetUserAsync(id));
        }

        public async override Task<bool> UpdateEntityAsync(UserDto model)
        {
            User user = _mapper.Map<User>(model);
            user.Address = new Address
            {
                Id = model.AddressID,
                PostalCode = model.AddressPostalCode,
                StreetName = model.AddressStreetName,
                StreetNumber = model.AddressStreetNumber
            };
            await _genericRepo.UpdateEntityAsync(user);
            return true;
        }
    }
}