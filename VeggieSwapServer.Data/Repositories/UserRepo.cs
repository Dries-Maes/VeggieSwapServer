using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeggieSwapServer.Data.Entities;

namespace VeggieSwapServer.Data.Repositories
{
    public class UserRepo : GenericRepo<User>, IUserRepo
    {
        public UserRepo(VeggieSwapServerContext context)
            : base(context)
        {
        }

        public async Task<bool> UserExistsAsync(string eMail)
        {
            return await _context.Users.AnyAsync(x => x.Email == eMail.ToLower());
        }

        public virtual async Task<User> GetEntityAsync(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Email == email);
        }

        public async Task<IEnumerable<User>> GetAllEntitiesAsync(bool includeAddress)
        {
            if (includeAddress)
            {
                return await _context.Set<User>().Include(x => x.Address).ToListAsync();
            }
            else
            {
                return await base.GetAllEntitiesAsync();
            }
        }

        public override Task<bool> AddEntityAsync(User entity)
        {
            return base.AddEntityAsync(entity);
        }
    }
}