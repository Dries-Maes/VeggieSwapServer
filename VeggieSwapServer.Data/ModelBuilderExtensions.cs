using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
                using var hmac = new HMACSHA512();
                x.HasData(
                    new User { Id = 1, FirstName = "	Pieter	", LastName = "Corp", IsAdmin = true, Email = "	Pieter@mail.com	", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")),   , ImageUrl = "https://robohash.org/Pieter" },
                    new User { Id = 2, FirstName = "	Nick	", LastName = "Vr", IsAdmin = true, Email = "	Nick@mail.com	", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")),   , ImageUrl = "https://robohash.org/Nick" },
                    new User { Id = 3, FirstName = "	Kobe 	", LastName = "Delo", IsAdmin = true, Email = "	Kobe@mail.com	", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")),   , ImageUrl = "https://robohash.org/Kobe" },
                    new User { Id = 4, FirstName = "	Dries	", LastName = "Maes", IsAdmin = true, Email = "	Dries@mail.com	", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")),   , ImageUrl = "https://robohash.org/Dries" },
                    new User { Id = 5, FirstName = "	BartjeWevertje	", LastName = "Wevertje", IsAdmin = false, Email = "	BartjeWevertje@mail.com	", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")),   , ImageUrl = "https://robohash.org/BartjeWevertje" },
                    new User { Id = 6, FirstName = "	Stofzuiger	", LastName = "Zuiger", IsAdmin = false, Email = "	Stofzuiger@mail.com	", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")),   , ImageUrl = "https://robohash.org/Stofzuiger" },
                    new User { Id = 7, FirstName = "	Dirk 	", LastName = "Visser", IsAdmin = false, Email = "	Dirk@mail.com	", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")),   , ImageUrl = "https://robohash.org/Dirk" },
                    new User { Id = 8, FirstName = "	Andreas	", LastName = "VanGrieken", IsAdmin = false, Email = "	Andreas@mail.com	", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")),   , ImageUrl = "https://robohash.org/Andreas" },
                    new User { Id = 9, FirstName = "	Mihiel	", LastName = "Mihoen", IsAdmin = false, Email = "	Mihiel@mail.com	", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")),   , ImageUrl = "https://robohash.org/Mihiel" },
                    new User { Id = 10, FirstName = "	Luc	", LastName = "DeHaantje", IsAdmin = false, Email = "	Luc@mail.com	", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")),   , ImageUrl = "https://robohash.org/Luc" },
                    new User { Id = 11, FirstName = "	Verhofstad	", LastName = "Zeemlap", IsAdmin = false, Email = "	Verhofstad@mail.com	", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")),   , ImageUrl = "https://robohash.org/Zeemlap" },
                    new User { Id = 12, FirstName = "	Dries	", LastName = "VanKorteNekke", IsAdmin = false, Email = "	Dries@mail.com	", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")),   , ImageUrl = "https://robohash.org/Dries2" },
                    new User { Id = 13, FirstName = "	Joyce	", LastName = "Tomatenplukker", IsAdmin = false, Email = "	Joyce@mail.com	", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")),   , ImageUrl = "https://robohash.org/Tomatenplukker" }
                    );
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
                x.HasData(

                       new Resource { Name = "apples", ImageUrl = "apples.svg" },
                       new Resource { Name = "artichokes", ImageUrl = "artichokes.svg" },
                       new Resource { Name = "asparaguses", ImageUrl = "asparaguses.svg" },
                       new Resource { Name = "bananas", ImageUrl = "bananas.svg" },
                       new Resource { Name = "bell-peppers", ImageUrl = "bell-peppers.svg" },
                       new Resource { Name = "blueberries", ImageUrl = "blueberries.svg" },
                       new Resource { Name = "bok-choy", ImageUrl = "bok-choy.svg" },
                       new Resource { Name = "broccoli", ImageUrl = "broccoli.svg" },
                       new Resource { Name = "brussels-sprouts", ImageUrl = "brussels-sprouts.svg" },
                       new Resource { Name = "carrots", ImageUrl = "carrots.svg" },
                       new Resource { Name = "cherries", ImageUrl = "cherries.svg" },
                       new Resource { Name = "chilis", ImageUrl = "chilis.svg" },
                       new Resource { Name = "coconuts", ImageUrl = "coconuts.svg" },
                       new Resource { Name = "coriander", ImageUrl = "coriander.svg" },
                       new Resource { Name = "corn", ImageUrl = "corn.svg" },
                       new Resource { Name = "cucumbers", ImageUrl = "cucumbers.svg" },
                       new Resource { Name = "dragon-fruits", ImageUrl = "dragon-fruits.svg" },
                       new Resource { Name = "durians", ImageUrl = "durians.svg" },
                       new Resource { Name = "eggplants", ImageUrl = "eggplants.svg" },
                       new Resource { Name = "garlic", ImageUrl = "garlic.svg" },
                       new Resource { Name = "grapes", ImageUrl = "grapes.svg" },
                       new Resource { Name = "guavas", ImageUrl = "guavas.svg" },
                       new Resource { Name = "kiwis", ImageUrl = "kiwis.svg" },
                       new Resource { Name = "lemons", ImageUrl = "lemons.svg" },
                       new Resource { Name = "mangos", ImageUrl = "mangos.svg" },
                       new Resource { Name = "mangosteens", ImageUrl = "mangosteens.svg" },
                       new Resource { Name = "melons", ImageUrl = "melons.svg" },
                       new Resource { Name = "mushrooms", ImageUrl = "mushrooms.svg" },
                       new Resource { Name = "olives", ImageUrl = "olives.svg" },
                       new Resource { Name = "oranges", ImageUrl = "oranges.svg" },
                       new Resource { Name = "papayas", ImageUrl = "papayas.svg" },
                       new Resource { Name = "peaches", ImageUrl = "peaches.svg" },
                       new Resource { Name = "pears", ImageUrl = "pears.svg" },
                       new Resource { Name = "peas", ImageUrl = "peas.svg" },
                       new Resource { Name = "pineapples", ImageUrl = "pineapples.svg" },
                       new Resource { Name = "pomegranates", ImageUrl = "pomegranates.svg" },
                       new Resource { Name = "potatoes", ImageUrl = "potatoes.svg" },
                       new Resource { Name = "pumpkins", ImageUrl = "pumpkins.svg" },
                       new Resource { Name = "radish", ImageUrl = "radish.svg" },
                       new Resource { Name = "radishes", ImageUrl = "radishes.svg" },
                       new Resource { Name = "raspberries", ImageUrl = "raspberries.svg" },
                       new Resource { Name = "salad", ImageUrl = "salad.svg" },
                       new Resource { Name = "salads", ImageUrl = "salads.svg" },
                       new Resource { Name = "scallions", ImageUrl = "scallions.svg" },
                       new Resource { Name = "spinach", ImageUrl = "spinach.svg" },
                       new Resource { Name = "star-fruits", ImageUrl = "star-fruits.svg" },
                       new Resource { Name = "strawberries", ImageUrl = "strawberries.svg" },
                       new Resource { Name = "sweet-potatoes", ImageUrl = "sweet-potatoes.svg" },
                       new Resource { Name = "tomatoes", ImageUrl = "tomatoes.svg" },
                       new Resource { Name = "watermelons", ImageUrl = "watermelons.svg" },
                       new Resource { Name = "tomatoes", ImageUrl = "tomatoes.svg" },
                       new Resource { Name = "watermelons", ImageUrl = "watermelons.svg" }

                    );
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