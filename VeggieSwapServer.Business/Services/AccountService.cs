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
        private readonly IAccountRepo _accountRepo;
        private readonly ITokenService _tokenService;
        private readonly IGenericRepo<User> _userRepo;

        public AccountService(IAccountRepo accountRepo, ITokenService tokenService, IGenericRepo<User> userRepo)
        {
            _userRepo = userRepo;
            _accountRepo = accountRepo;
            _tokenService = tokenService;
        }

        public async Task<UserDto> LoginAsync(string eMail, string password)
        {
            User user = await _accountRepo.GetUserByEmailAsync(eMail);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid Email");
            }

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            if (!hash.SequenceEqual(user.PasswordHash))
            {
                throw new UnauthorizedAccessException("Invalid password Haha");
            }

            return CreateUserDTO(user);
        }

        public async Task<UserDto> RegisterAsync(RegisterDTO dto)
        {
            if (await UserExists(dto.Email))
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

        public async Task<bool> UserExists(string eMail)
        {
            return await _accountRepo.UserExistsAsync(eMail);
        }

        private UserDto CreateUserDTO(User user)
        {
            return new UserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
            };
        }
    }
}