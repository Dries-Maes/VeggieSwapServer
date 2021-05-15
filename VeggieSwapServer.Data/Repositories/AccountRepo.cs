
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using VeggieSwapServer.Data.Entities;

namespace VeggieSwapServer.Data.Repositories
{
    public class AccountRepo : IAccountRepo
    {
        private VeggieSwapServerContext _context;

        public AccountRepo(VeggieSwapServerContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmailAsync(string eMail)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Email == eMail);
        }

        public async Task<bool> AddUserAsync(User user)
        {
            user.CreatedAt = DateTime.Now;
            user.ModifiedAt = DateTime.Now;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UserExistsAsync(string eMail)
        {
            return await _context.Users.AnyAsync(x => x.Email == eMail.ToLower());
        }
    }
}
