using Microsoft.EntityFrameworkCore;
using VeggieSwapServer.Data.Entities;

namespace VeggieSwapServer.Data
{
    public class VeggieSwapServerContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Trade> Trades { get; set; }

        public DbSet<TradeItem> TradeItems { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Wallet> Wallets { get; set; }

        public VeggieSwapServerContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(s => s.Address)
                .WithOne(ad => ad.User);
        }
    }
}