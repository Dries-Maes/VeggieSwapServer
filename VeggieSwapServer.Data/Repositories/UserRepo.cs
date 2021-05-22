using Microsoft.EntityFrameworkCore;
using System;
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
                return await _context.Set<User>()
                    .Include(x => x.Address)
                    .Include(x => x.TradeItems)
                    .ThenInclude(x => x.Resource)
                    .ToListAsync();
            }
            else
            {
                return await base.GetAllEntitiesAsync();
            }
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await _context.Users.Include(y => y.Address).FirstOrDefaultAsync(x => x.Id == id);
        }

        public override Task<bool> AddEntityAsync(User entity)
        {
            return base.AddEntityAsync(entity);
        }

        public override async Task<bool> UpdateEntityAsync(User entity)
        {
            entity.ModifiedAt = DateTime.Now;
            _context.Update(entity);            
            _context.Entry(entity).Property(p => p.PasswordHash).IsModified = false;
            _context.Entry(entity).Property(p => p.PasswordSalt).IsModified = false;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}