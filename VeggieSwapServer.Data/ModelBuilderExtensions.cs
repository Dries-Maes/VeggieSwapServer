using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeggieSwapServer.Data.Entities;

namespace VeggieSwapServer.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            SeedUsers(modelBuilder);
            SeedAddresses(modelBuilder);
            SeedWallets(modelBuilder);
            SeedResources(modelBuilder);
            SeedTrades(modelBuilder);
            SeedTradeItems(modelBuilder);
            SeedPurchases(modelBuilder);
        }

        private static void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(x =>
            {
                x.HasData(new User
                {
                    Id = 1,
                    FirstName = "Kobe",
                    LastName = "Delo",
                    IsAdmin = true,
                    Email = "kobe@mail.com",
                    ImageUrl = "https://robohash.org/Kobe"
                });
            });
        }

        private static void SeedAddresses(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(x =>
            {
                x.HasData(new Address
                {
                    Id = 1,
                    StreetName = "Anti-Veggiestraat",
                    StreetNumber = 89,
                    PostalCode = 9000,
                    UserId = 1
                });
            }
            );
        }

        private static void SeedWallets(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Wallet>(x =>
            {
                x.HasData(new Wallet
                {
                    VAmount = 200,
                    Id = 1,
                    UserId = 1
                });
            }
            );
        }

        private static void SeedResources(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>(x =>
            {
                x.HasData(new Resource
                {
                    Id = 1,
                    Name = "Artichokes",
                    ImageUrl = "artichokes.svg"
                });
            }
            );
        }

        private static void SeedTrades(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trade>(x =>
            {
                x.HasData(new Trade
                {
                    Id = 1
                });
            }
            );
        }

        private static void SeedTradeItems(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TradeItem>(x =>
            {
                x.HasData(new TradeItem
                {
                    Id = 1,
                    UserId = 1,
                    ResourceId = 1,
                    TradeId = 1,
                    Amount = 25
                });
            }
            );
        }

        private static void SeedPurchases(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Purchase>(x =>
            {
                x.HasData(new Purchase
                {
                    Id = 1,
                    WalletId = 1,
                    VAmount = 69,
                    EuroAmount = 6.9m
                });
            }
            );
        }
    }
}