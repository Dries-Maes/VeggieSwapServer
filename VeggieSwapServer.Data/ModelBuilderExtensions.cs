using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

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
            SeedTradeItemProposals(modelBuilder);
        }

        private static void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(x =>
            {
                using var hmac = new HMACSHA512();
                x.HasData(
                    new User { Id = 1, FirstName = "Pieter", LastName = "Corp", IsAdmin = true, Email = "Pieter@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "https://robohash.org/Pieter" },
                    new User { Id = 2, FirstName = "Nick", LastName = "Vr", IsAdmin = true, Email = "Nick@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "https://robohash.org/Nick" },
                    new User { Id = 3, FirstName = "Kobe", LastName = "Delo", IsAdmin = true, Email = "Kobe@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "https://robohash.org/Kobe" },
                    new User { Id = 4, FirstName = "Dries", LastName = "Maes", IsAdmin = true, Email = "Dries@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "https://robohash.org/Dries" },
                    new User { Id = 5, FirstName = "BartjeWevertje", LastName = "Wevertje", IsAdmin = false, Email = "BartjeWevertje@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "https://robohash.org/BartjeWevertje" },
                    new User { Id = 6, FirstName = "Stofzuiger", LastName = "Zuiger", IsAdmin = false, Email = "Stofzuiger@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "https://robohash.org/Stofzuiger" },
                    new User { Id = 7, FirstName = "Dirk", LastName = "Visser", IsAdmin = false, Email = "Dirk@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "https://robohash.org/Dirk" },
                    new User { Id = 8, FirstName = "Andreas", LastName = "VanGrieken", IsAdmin = false, Email = "Andreas@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "https://robohash.org/Andreas" },
                    new User { Id = 9, FirstName = "Mihiel", LastName = "Mihoen", IsAdmin = false, Email = "Mihiel@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "https://robohash.org/Mihiel" },
                    new User { Id = 10, FirstName = "Luc", LastName = "DeHaantje", IsAdmin = false, Email = "Luc@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "https://robohash.org/Luc" },
                    new User { Id = 11, FirstName = "Verhofstad", LastName = "Zeemlap", IsAdmin = false, Email = "VerhofstadDeZeemlap@europeesemailadres.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "https://robohash.org/Zeemlap" },
                    new User { Id = 12, FirstName = "Dries", LastName = "VanKorteNekke", IsAdmin = false, Email = "Driesdentweedenmaarnidezelfden@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "https://robohash.org/Dries2" },
                    new User { Id = 13, FirstName = "Joyce", LastName = "Tomatenplukker", IsAdmin = false, Email = "Joyce@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "https://robohash.org/Tomatenplukker" }
                    );
            });
        }

        private static void SeedAddresses(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(x =>
            {
                x.HasData(
                new Address
                {
                    Id = 1,
                    StreetName = "Anti-Veggiestraat",
                    StreetNumber = 89,
                    PostalCode = 9000,
                    UserId = 1
                },
                new Address
                {
                    Id = 2,
                    StreetName = "Pieterstreaat",
                    StreetNumber = 45,
                    PostalCode = 9000,
                    UserId = 2
                },
                new Address
                {
                    Id = 3,
                    StreetName = "Nickstraat",
                    StreetNumber = 74,
                    PostalCode = 9000,
                    UserId = 3
                },
                new Address
                {
                    Id = 4,
                    StreetName = "Driesstraat",
                    StreetNumber = 66,
                    PostalCode = 1000,
                    UserId = 4
                },
                new Address
                {
                    Id = 5,
                    StreetName = "Kobestraat",
                    StreetNumber = 85,
                    PostalCode = 2000,
                    UserId = 5
                },
                new Address
                {
                    Id = 6,
                    StreetName = "Lookbroodjesstraat",
                    StreetNumber = 43,
                    PostalCode = 1000,
                    UserId = 6
                },
                new Address
                {
                    Id = 7,
                    StreetName = "Greenpeacestraat",
                    StreetNumber = 1,
                    PostalCode = 9050,
                    UserId = 7
                },
                new Address
                {
                    Id = 8,
                    StreetName = "Kotsvisstraat",
                    StreetNumber = 96,
                    PostalCode = 1000,
                    UserId = 8
                },
                new Address
                {
                    Id = 9,
                    StreetName = "Greenlivesmattertoostraat",
                    StreetNumber = 420,
                    PostalCode = 2000,
                    UserId = 9
                },
                new Address
                {
                    Id = 10,
                    StreetName = "Geenpolitiekinhetprojectstraat",
                    StreetNumber = 200,
                    PostalCode = 9070,
                    UserId = 10
                },
                new Address
                {
                    Id = 11,
                    StreetName = "Kalfslapjesstraat",
                    StreetNumber = 32,
                    PostalCode = 9500,
                    UserId = 11
                },
                new Address
                {
                    Id = 12,
                    StreetName = "Blacklivesmatterstraat",
                    StreetNumber = 78,
                    PostalCode = 1000,
                    UserId = 12
                },
                new Address
                {
                    Id = 13,
                    StreetName = "Worstenbroodjesstraat",
                    StreetNumber = 4,
                    PostalCode = 9020,
                    UserId = 13
                }

                );
            }
            );
        }

        private static void SeedWallets(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Wallet>(x =>
            {
                x.HasData(
                new Wallet
                {
                    VAmount = 200,
                    Id = 1,
                    UserId = 1
                },
                new Wallet
                {
                    VAmount = 347,
                    Id = 2,
                    UserId = 2
                },
                new Wallet
                {
                    VAmount = 65,
                    Id = 3,
                    UserId = 3
                },
                new Wallet
                {
                    VAmount = 42,
                    Id = 4,
                    UserId = 4
                },
                new Wallet
                {
                    VAmount = 753,
                    Id = 5,
                    UserId = 5
                },
                new Wallet
                {
                    VAmount = 36,
                    Id = 6,
                    UserId = 6
                },
                new Wallet
                {
                    VAmount = 12,
                    Id = 7,
                    UserId = 7
                },
                new Wallet
                {
                    VAmount = 654,
                    Id = 8,
                    UserId = 8
                },
                new Wallet
                {
                    VAmount = 357,
                    Id = 9,
                    UserId = 9
                },
                new Wallet
                {
                    VAmount = 124,
                    Id = 10,
                    UserId = 10
                },
                new Wallet
                {
                    VAmount = 269,
                    Id = 11,
                    UserId = 11
                },
                new Wallet
                {
                    VAmount = 57,
                    Id = 12,
                    UserId = 12
                },
                new Wallet
                {
                    VAmount = 204,
                    Id = 13,
                    UserId = 13
                }
                );
            }
            );
        }

        private static void SeedResources(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>(x =>
            {
                x.HasData(
                    new Resource { Id = 1, Name = "apples", ImageUrl = "apples.svg" },
                    new Resource { Id = 2, Name = "artichokes", ImageUrl = "artichokes.svg" },
                    new Resource { Id = 3, Name = "asparagus", ImageUrl = "asparagus.svg" },
                    new Resource { Id = 4, Name = "bananas", ImageUrl = "bananas.svg" },
                    new Resource { Id = 5, Name = "bell-peppers", ImageUrl = "bell-peppers.svg" },
                    new Resource { Id = 6, Name = "blueberries", ImageUrl = "blueberries.svg" },
                    new Resource { Id = 7, Name = "bok-choy", ImageUrl = "bok-choy.svg" },
                    new Resource { Id = 8, Name = "broccoli", ImageUrl = "broccoli.svg" },
                    new Resource { Id = 9, Name = "brussels-sprouts", ImageUrl = "brussels-sprouts.svg" },
                    new Resource { Id = 10, Name = "carrots", ImageUrl = "carrots.svg" },
                    new Resource { Id = 11, Name = "cherries", ImageUrl = "cherries.svg" },
                    new Resource { Id = 12, Name = "chilis", ImageUrl = "chilis.svg" },
                    new Resource { Id = 13, Name = "coconuts", ImageUrl = "coconuts.svg" },
                    new Resource { Id = 14, Name = "coriander", ImageUrl = "coriander.svg" },
                    new Resource { Id = 15, Name = "corn", ImageUrl = "corn.svg" },
                    new Resource { Id = 16, Name = "cucumbers", ImageUrl = "cucumbers.svg" },
                    new Resource { Id = 17, Name = "dragon-fruits", ImageUrl = "dragon-fruits.svg" },
                    new Resource { Id = 18, Name = "durians", ImageUrl = "durians.svg" },
                    new Resource { Id = 19, Name = "eggplants", ImageUrl = "eggplants.svg" },
                    new Resource { Id = 20, Name = "garlic", ImageUrl = "garlic.svg" },
                    new Resource { Id = 21, Name = "grapes", ImageUrl = "grapes.svg" },
                    new Resource { Id = 22, Name = "guavas", ImageUrl = "guavas.svg" },
                    new Resource { Id = 23, Name = "kiwis", ImageUrl = "kiwis.svg" },
                    new Resource { Id = 24, Name = "lemons", ImageUrl = "lemons.svg" },
                    new Resource { Id = 25, Name = "mangos", ImageUrl = "mangos.svg" },
                    new Resource { Id = 26, Name = "mangosteens", ImageUrl = "mangosteens.svg" },
                    new Resource { Id = 27, Name = "melons", ImageUrl = "melons.svg" },
                    new Resource { Id = 28, Name = "mushrooms", ImageUrl = "mushrooms.svg" },
                    new Resource { Id = 29, Name = "olives", ImageUrl = "olives.svg" },
                    new Resource { Id = 30, Name = "oranges", ImageUrl = "oranges.svg" },
                    new Resource { Id = 31, Name = "papayas", ImageUrl = "papayas.svg" },
                    new Resource { Id = 32, Name = "peaches", ImageUrl = "peaches.svg" },
                    new Resource { Id = 33, Name = "pears", ImageUrl = "pears.svg" },
                    new Resource { Id = 34, Name = "peas", ImageUrl = "peas.svg" },
                    new Resource { Id = 35, Name = "pineapples", ImageUrl = "pineapples.svg" },
                    new Resource { Id = 36, Name = "pomegranates", ImageUrl = "pomegranates.svg" },
                    new Resource { Id = 37, Name = "potatoes", ImageUrl = "potatoes.svg" },
                    new Resource { Id = 38, Name = "pumpkins", ImageUrl = "pumpkins.svg" },
                    new Resource { Id = 39, Name = "radish", ImageUrl = "radish.svg" },
                    new Resource { Id = 40, Name = "radishes", ImageUrl = "radishes.svg" },
                    new Resource { Id = 41, Name = "raspberries", ImageUrl = "raspberries.svg" },
                    new Resource { Id = 42, Name = "salad", ImageUrl = "salad.svg" },
                    new Resource { Id = 43, Name = "salads", ImageUrl = "salads.svg" },
                    new Resource { Id = 44, Name = "scallions", ImageUrl = "scallions.svg" },
                    new Resource { Id = 45, Name = "spinach", ImageUrl = "spinach.svg" },
                    new Resource { Id = 46, Name = "star-fruits", ImageUrl = "star-fruits.svg" },
                    new Resource { Id = 47, Name = "strawberries", ImageUrl = "strawberries.svg" },
                    new Resource { Id = 48, Name = "sweet-potatoes", ImageUrl = "sweet-potatoes.svg" },
                    new Resource { Id = 49, Name = "tomatoes", ImageUrl = "tomatoes.svg" },
                    new Resource { Id = 50, Name = "watermelons", ImageUrl = "watermelons.svg" },
                    new Resource { Id = 51, Name = "v-coin", ImageUrl = "v-coin.svg" }
                  );
            }
            );
        }

        private static void SeedTrades(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trade>(x =>
            {
                x.HasData(
                new Trade { Id = 1, ReceiverId = 1, ProposerId = 2, Completed = false, ActiveUserId = 1 },
                new Trade { Id = 2, ReceiverId = 2, ProposerId = 3, Completed = false, ActiveUserId = 3 },
                new Trade { Id = 3, ReceiverId = 8, ProposerId = 6, Completed = false, ActiveUserId = 6 },
                new Trade { Id = 4, ReceiverId = 8, ProposerId = 1, Completed = false, ActiveUserId = 1 },
                new Trade { Id = 5, ReceiverId = 7, ProposerId = 4, Completed = false, ActiveUserId = 7 },
                new Trade { Id = 6, ReceiverId = 2, ProposerId = 7, Completed = false, ActiveUserId = 7 }

                );
            }
            );
        }

        private static void SeedTradeItems(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TradeItem>(x =>
            {
                x.HasData(
                new TradeItem { Id = 1, UserId = 1, ResourceId = 1, Amount = 50 },
                new TradeItem { Id = 2, UserId = 1, ResourceId = 3, Amount = 50 },
                new TradeItem { Id = 3, UserId = 1, ResourceId = 5, Amount = 50 },
                new TradeItem { Id = 4, UserId = 1, ResourceId = 7, Amount = 50 },

                new TradeItem { Id = 5, UserId = 2, ResourceId = 51, Amount = 50 },
                new TradeItem { Id = 6, UserId = 2, ResourceId = 34, Amount = 50 },
                new TradeItem { Id = 7, UserId = 2, ResourceId = 46, Amount = 50 },
                new TradeItem { Id = 8, UserId = 2, ResourceId = 32, Amount = 50 },
                new TradeItem { Id = 9, UserId = 2, ResourceId = 39, Amount = 50 },
                new TradeItem { Id = 10, UserId = 2, ResourceId = 15, Amount = 50 },

                new TradeItem { Id = 11, UserId = 3, ResourceId = 51, Amount = 50 },
                new TradeItem { Id = 12, UserId = 3, ResourceId = 4, Amount = 50 },
                new TradeItem { Id = 13, UserId = 3, ResourceId = 8, Amount = 50 },
                new TradeItem { Id = 14, UserId = 3, ResourceId = 13, Amount = 50 },
                new TradeItem { Id = 15, UserId = 3, ResourceId = 6, Amount = 50 },
                new TradeItem { Id = 16, UserId = 3, ResourceId = 31, Amount = 50 },

                new TradeItem { Id = 17, UserId = 4, ResourceId = 21, Amount = 50 },
                new TradeItem { Id = 18, UserId = 4, ResourceId = 44, Amount = 50 },
                new TradeItem { Id = 19, UserId = 4, ResourceId = 51, Amount = 50 },

                new TradeItem { Id = 20, UserId = 5, ResourceId = 7, Amount = 50 },
                new TradeItem { Id = 21, UserId = 5, ResourceId = 51, Amount = 50 },
                new TradeItem { Id = 22, UserId = 5, ResourceId = 51, Amount = 50 },
                new TradeItem { Id = 23, UserId = 5, ResourceId = 46, Amount = 50 },
                new TradeItem { Id = 24, UserId = 5, ResourceId = 32, Amount = 50 },

                new TradeItem { Id = 25, UserId = 6, ResourceId = 39, Amount = 50 },
                new TradeItem { Id = 26, UserId = 6, ResourceId = 15, Amount = 50 },
                new TradeItem { Id = 27, UserId = 6, ResourceId = 51, Amount = 50 },
                new TradeItem { Id = 28, UserId = 6, ResourceId = 4, Amount = 50 },


                new TradeItem { Id = 29, UserId = 7, ResourceId = 8, Amount = 50 },
                new TradeItem { Id = 30, UserId = 7, ResourceId = 13, Amount = 50 },
                new TradeItem { Id = 31, UserId = 7, ResourceId = 6, Amount = 50 },
                new TradeItem { Id = 32, UserId = 7, ResourceId = 51, Amount = 50 },

                new TradeItem { Id = 33, UserId = 8, ResourceId = 6, Amount = 50 },
                new TradeItem { Id = 34, UserId = 8, ResourceId = 51, Amount = 50 }

                );
            }
            );
        }


        private static void SeedTradeItemProposals(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TradeItemProposal>(x =>
            {
                x.HasData(
                new TradeItemProposal { Id = 1, TradeItemId = 1, ProposedAmount = 5, TradeId = 1 },
                new TradeItemProposal { Id = 2, TradeItemId = 2, ProposedAmount = 15, TradeId = 1 },
                new TradeItemProposal { Id = 3, TradeItemId = 3, ProposedAmount = 5, TradeId = 1 },
                new TradeItemProposal { Id = 4, TradeItemId = 5, ProposedAmount = 5, TradeId = 1 },

                new TradeItemProposal { Id = 5, TradeItemId = 6, ProposedAmount = 5, TradeId = 2 },
                new TradeItemProposal { Id = 6, TradeItemId = 7, ProposedAmount = 15, TradeId = 2 },
                new TradeItemProposal { Id = 7, TradeItemId = 13, ProposedAmount = 5, TradeId = 2 },
                new TradeItemProposal { Id = 8, TradeItemId = 14, ProposedAmount = 15, TradeId = 2 },

                new TradeItemProposal { Id = 9, TradeItemId = 33, ProposedAmount = 5, TradeId = 3 },
                new TradeItemProposal { Id = 10, TradeItemId = 28, ProposedAmount = 15, TradeId = 3 },

                new TradeItemProposal { Id = 11, TradeItemId = 34, ProposedAmount = 5, TradeId = 4 },
                new TradeItemProposal { Id = 12, TradeItemId = 1, ProposedAmount = 15, TradeId = 4 },
                new TradeItemProposal { Id = 13, TradeItemId = 2, ProposedAmount = 5, TradeId = 4 },
                new TradeItemProposal { Id = 14, TradeItemId = 3, ProposedAmount = 15, TradeId = 4 },
                new TradeItemProposal { Id = 15, TradeItemId = 4, ProposedAmount = 5, TradeId = 4 },

                new TradeItemProposal { Id = 16, TradeItemId = 32, ProposedAmount = 3, TradeId = 5 },
                new TradeItemProposal { Id = 17, TradeItemId = 17, ProposedAmount = 5, TradeId = 5 },
                new TradeItemProposal { Id = 18, TradeItemId = 18, ProposedAmount = 15, TradeId = 5 },

                new TradeItemProposal { Id = 19, TradeItemId = 5, ProposedAmount = 1, TradeId = 6 },
                new TradeItemProposal { Id = 20, TradeItemId = 30, ProposedAmount = 15, TradeId = 6 }
                );
            }
            );
        }

        private static void SeedPurchases(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Purchase>(x =>
            {
                x.HasData(
                new Purchase { Id = 1, WalletId = 1, VAmount = 69, EuroAmount = 6.9m },
                new Purchase { Id = 2, WalletId = 1, VAmount = 20, EuroAmount = 2m },
                new Purchase { Id = 3, WalletId = 5, VAmount = 420, EuroAmount = 42m },
                new Purchase { Id = 4, WalletId = 6, VAmount = 100, EuroAmount = 10m },
                new Purchase { Id = 5, WalletId = 12, VAmount = 36, EuroAmount = 3.6m },
                new Purchase { Id = 6, WalletId = 10, VAmount = 78, EuroAmount = 7.8m },
                new Purchase { Id = 7, WalletId = 9, VAmount = 98, EuroAmount = 9.8m },
                new Purchase { Id = 8, WalletId = 7, VAmount = 50, EuroAmount = 5m },
                new Purchase { Id = 9, WalletId = 3, VAmount = 130, EuroAmount = 13m },
                new Purchase { Id = 10, WalletId = 4, VAmount = 20, EuroAmount = 2m }
                );
            }
            );
        }
    }
}