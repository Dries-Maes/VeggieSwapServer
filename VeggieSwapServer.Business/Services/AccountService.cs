
using System;
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
        private IAccountRepo _accountRepo;
        private ITokenService _tokenService;

        public AccountService(IAccountRepo accountRepo, ITokenService tokenService)
        {
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

            for (int i = 0; i < hash.Length; i++)
            {                
                if (hash[i] != user.PasswordHash[i])
                {                   
                    throw new UnauthorizedAccessException("Invalid password");
                }
            }

            return new UserDto
            {   
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
            };
        }

        public async Task<UserDto> RegisterAsync(string eMail, string password, string firstName, string lastName)
        {
            using var hmac = new HMACSHA512();

            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = eMail.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                PasswordSalt = hmac.Key,
            };

            await _accountRepo.AddUserAsync(user);

            return new UserDto
            {   
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
            };
        }

        public async Task<bool> UserExists(string eMail)
        {
            return await _accountRepo.UserExistsAsync(eMail);
        }
    }
}
