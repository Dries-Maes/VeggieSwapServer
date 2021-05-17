using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VeggieSwapServer.Business.DTO;
using VeggieSwapServer.Data.Entities;
using VeggieSwapServer.Data.Repositories;

namespace VeggieSwapServer.Business.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepo _userRepo;
        private readonly ITokenService _tokenService;

        public AccountService(IUserRepo userRepo, ITokenService tokenService)
        {
            _userRepo = userRepo;

            _tokenService = tokenService;
        }

        public async Task<UserTokenDTO> LoginAsync(string eMail, string password)
        {
            User user = await _userRepo.GetEntityAsync(eMail);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid Email");
            }

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            if (!hash.SequenceEqual(user.PasswordHash))
            {
                throw new UnauthorizedAccessException("Invalid password");
            }

            return CreateUserDTO(user);
        }

        public async Task<UserTokenDTO> RegisterAsync(RegisterDTO dto)
        {
            if (await _userRepo.UserExistsAsync(dto.Email))
            {
                throw new UnauthorizedAccessException("Email already exists, please try again or login");
            }
            using var hmac = new HMACSHA512();

            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password)),
                PasswordSalt = hmac.Key,
            };

            await _userRepo.AddEntityAsync(user);

            return CreateUserDTO(user);
        }

        private UserTokenDTO CreateUserDTO(User user)
        {
            return new UserTokenDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                Token = _tokenService.CreateToken(user),
            };
        }
    }
}