
using Microsoft.EntityFrameworkCore;
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

        public async Task<User> GetUserByNameAsync(string name)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.FirstName == name);
        }

        public async Task<bool> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UserExistsAsync(string userName)
        {
            return await _context.Users.AnyAsync(x => x.FirstName == userName.ToLower());
        }
    }
}
