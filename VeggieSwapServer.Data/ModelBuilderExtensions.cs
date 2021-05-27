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
                    new User { Id = 1, FirstName = "Pieter", LastName = "Slaapkop", IsAdmin = true, Email = "Pieter@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "Pieter" },
                    new User { Id = 2, FirstName = "Nick", LastName = "Angularlover", IsAdmin = true, Email = "Nick@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "Nick" },
                    new User { Id = 3, FirstName = "Kobe", LastName = "Neut", IsAdmin = true, Email = "Kobe@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "Kobe" },
                    new User { Id = 4, FirstName = "Dries", LastName = "Promailer", IsAdmin = true, Email = "Dries@mail.be", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "Dries" },
                    new User { Id = 5, FirstName = "Seba", LastName = "Alwayszen", IsAdmin = false, Email = "Seba@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "BartjeWevertje" },
                    new User { Id = 6, FirstName = "Emma", LastName = "Kipdorp", IsAdmin = false, Email = "Emma@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "Stofzuiger" },
                    new User { Id = 7, FirstName = "Ward", LastName = "Motormouth", IsAdmin = false, Email = "Ward@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "Dirk" },
                    new User { Id = 8, FirstName = "Andreas", LastName = "VanGrieken", IsAdmin = false, Email = "Andreas@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "Andreas" },
                    new User { Id = 9, FirstName = "Michiel", LastName = "Demogod", IsAdmin = false, Email = "Michiel@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "g283?set=set4" },
                    new User { Id = 10, FirstName = "Diederik", LastName = "Featurefixer", IsAdmin = false, Email = "Diederik@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "Luc" },
                    new User { Id = 11, FirstName = "Jens", LastName = "Spinning", IsAdmin = false, Email = "Jens@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "Zeemlap" },
                    new User { Id = 12, FirstName = "Simon", LastName = "Lidllover", IsAdmin = false, Email = "Simon@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "Dries2" },
                    new User { Id = 13, FirstName = "Joyce", LastName = "Recruiter", IsAdmin = false, Email = "Joyce@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "75" },
                    new User { Id = 14, FirstName = "Marieke", LastName = "Van Leren Broeke", IsAdmin = false, Email = "Marieke@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "T1" },
                    new User { Id = 15, FirstName = "Anke", LastName = "Kleurenkenner", IsAdmin = false, Email = "Anke@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "27" },
                    new User { Id = 16, FirstName = "Emma", LastName = "Schoonkind", IsAdmin = false, Email = "Emma@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "45" },
                    new User { Id = 17, FirstName = "Sien", LastName = "Rommeltje", IsAdmin = false, Email = "Sien@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "57" },
                    new User { Id = 18, FirstName = "Joke", LastName = "LidlAnnoying", IsAdmin = false, Email = "Joke@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "24" },
                    new User { Id = 19, FirstName = "Karolien", LastName = "Vdabpolitie", IsAdmin = false, Email = "Karolien@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "78" },
                    new User { Id = 20, FirstName = "Hoon", LastName = "Tomatenplukker", IsAdmin = false, Email = "Hoon@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "99" },
                    new User { Id = 21, FirstName = "Michaël", LastName = "Wanderer", IsAdmin = false, Email = "Michaël@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "25" },
                    new User { Id = 22, FirstName = "Brent", LastName = "Tomatentrucker", IsAdmin = false, Email = "Brent@mail.com", PasswordSalt = hmac.Key, PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1234")), ImageUrl = "29" }

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
                    StreetName = "Vrbaan",
                    StreetNumber = 45,
                    PostalCode = 3000,
                    UserId = 2
                },
                new Address
                {
                    Id = 3,
                    StreetName = "Balletjesintomatensausstraat",
                    StreetNumber = 74,
                    PostalCode = 4000,
                    UserId = 3
                },
                new Address
                {
                    Id = 4,
                    StreetName = "Vleesbroodstraat",
                    StreetNumber = 66,
                    PostalCode = 1000,
                    UserId = 4
                },
                new Address
                {
                    Id = 5,
                    StreetName = "Boerenworststraat",
                    StreetNumber = 85,
                    PostalCode = 9000,
                    UserId = 5
                },
                new Address
                {
                    Id = 6,
                    StreetName = "Spekmeteierenstraat",
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
                    StreetName = "Kotsvisplein",
                    StreetNumber = 96,
                    PostalCode = 1000,
                    UserId = 8
                },
                new Address
                {
                    Id = 9,
                    StreetName = "Greenlivesmattertooweg",
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
                    PostalCode = 7000,
                    UserId = 13
                },
                new Address
                {
                    Id = 14,
                    StreetName = "Jurgenzitverstoptachterhetlamgodsstraat",
                    StreetNumber = 24,
                    PostalCode = 9000,
                    UserId = 14
                },
                new Address
                {
                    Id = 15,
                    StreetName = "Bloedworststraat",
                    StreetNumber = 78,
                    PostalCode = 1081,
                    UserId = 15
                },
                new Address
                {
                    Id = 16,
                    StreetName = "Gemarineerderunderlendedreef",
                    StreetNumber = 36,
                    PostalCode = 1180,
                    UserId = 16
                },
                new Address
                {
                    Id = 17,
                    StreetName = "Ribbetjesstraat",
                    StreetNumber = 14,
                    PostalCode = 1500,
                    UserId = 17
                },
                new Address
                {
                    Id = 18,
                    StreetName = "Bickyburgerstraat",
                    StreetNumber = 15,
                    PostalCode = 2070,
                    UserId = 18
                },
                new Address
                {
                    Id = 19,
                    StreetName = "Lookbroodjesstraat",
                    StreetNumber = 11,
                    PostalCode = 2323,
                    UserId = 19
                },
                new Address
                {
                    Id = 20,
                    StreetName = "Worstenbroodjesstraat",
                    StreetNumber = 79,
                    PostalCode = 2890,
                    UserId = 20
                },
                new Address
                {
                    Id = 21,
                    StreetName = "Huisgemaaktekalfsbitterballetjesstraat",
                    StreetNumber = 100,
                    PostalCode = 3020,
                    UserId = 21
                },
                new Address
                {
                    Id = 22,
                    StreetName = "Kalfsrib-eyelaan",
                    StreetNumber = 107,
                    PostalCode = 3110,
                    UserId = 22
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
                },
                new Wallet
                {
                    VAmount = 20,
                    Id = 14,
                    UserId = 14
                },
                new Wallet
                {
                    VAmount = 47,
                    Id = 15,
                    UserId = 15
                },
                new Wallet
                {
                    VAmount = 28,
                    Id = 16,
                    UserId = 16
                },
                new Wallet
                {
                    VAmount = 104,
                    Id = 17,
                    UserId = 17
                },
                new Wallet
                {
                    VAmount = 65,
                    Id = 18,
                    UserId = 18
                },
                new Wallet
                {
                    VAmount = 78,
                    Id = 19,
                    UserId = 19
                },
                new Wallet
                {
                    VAmount = 56,
                    Id = 20,
                    UserId = 20
                },
                new Wallet
                {
                    VAmount = 78,
                    Id = 21,
                    UserId = 21
                },
                new Wallet
                {
                    VAmount = 9,
                    Id = 22,
                    UserId = 22
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
                new TradeItem { Id = 1, UserId = 1, ResourceId = 1, Amount = 47 },
                new TradeItem { Id = 2, UserId = 1, ResourceId = 3, Amount = 36 },
                new TradeItem { Id = 3, UserId = 1, ResourceId = 5, Amount = 12 },
                new TradeItem { Id = 4, UserId = 1, ResourceId = 7, Amount = 99 },

                new TradeItem { Id = 5, UserId = 2, ResourceId = 51, Amount = 41 },
                new TradeItem { Id = 6, UserId = 2, ResourceId = 34, Amount = 30 },
                new TradeItem { Id = 7, UserId = 2, ResourceId = 46, Amount = 40 },
                new TradeItem { Id = 8, UserId = 2, ResourceId = 32, Amount = 5 },
                new TradeItem { Id = 9, UserId = 2, ResourceId = 39, Amount = 25 },
                new TradeItem { Id = 10, UserId = 2, ResourceId = 15, Amount = 32 },

                new TradeItem { Id = 11, UserId = 3, ResourceId = 51, Amount = 47 },
                new TradeItem { Id = 12, UserId = 3, ResourceId = 4, Amount = 20 },
                new TradeItem { Id = 13, UserId = 3, ResourceId = 8, Amount = 17 },
                new TradeItem { Id = 14, UserId = 3, ResourceId = 13, Amount = 49 },
                new TradeItem { Id = 15, UserId = 3, ResourceId = 6, Amount = 30 },
                new TradeItem { Id = 16, UserId = 3, ResourceId = 31, Amount = 17 },

                new TradeItem { Id = 17, UserId = 4, ResourceId = 21, Amount = 89 },
                new TradeItem { Id = 18, UserId = 4, ResourceId = 44, Amount = 36 },
                new TradeItem { Id = 19, UserId = 4, ResourceId = 51, Amount = 50 },

                new TradeItem { Id = 20, UserId = 5, ResourceId = 7, Amount = 47 },
                new TradeItem { Id = 21, UserId = 5, ResourceId = 51, Amount = 63 },
                new TradeItem { Id = 22, UserId = 5, ResourceId = 17, Amount = 39 },
                new TradeItem { Id = 23, UserId = 5, ResourceId = 46, Amount = 38 },
                new TradeItem { Id = 24, UserId = 5, ResourceId = 32, Amount = 78 },

                new TradeItem { Id = 25, UserId = 6, ResourceId = 39, Amount = 5 },
                new TradeItem { Id = 26, UserId = 6, ResourceId = 15, Amount = 10 },
                new TradeItem { Id = 27, UserId = 6, ResourceId = 51, Amount = 12 },
                new TradeItem { Id = 28, UserId = 6, ResourceId = 4, Amount = 10 },

                new TradeItem { Id = 29, UserId = 7, ResourceId = 8, Amount = 19 },
                new TradeItem { Id = 30, UserId = 7, ResourceId = 13, Amount = 23 },
                new TradeItem { Id = 31, UserId = 7, ResourceId = 6, Amount = 36 },
                new TradeItem { Id = 32, UserId = 7, ResourceId = 51, Amount = 38 },

                new TradeItem { Id = 33, UserId = 8, ResourceId = 6, Amount = 78 },
                new TradeItem { Id = 34, UserId = 8, ResourceId = 51, Amount = 53 },

                new TradeItem { Id = 35, UserId = 9, ResourceId = 51, Amount = 26 },
                new TradeItem { Id = 36, UserId = 9, ResourceId = 14, Amount = 17 },
                new TradeItem { Id = 37, UserId = 9, ResourceId = 36, Amount = 69 },

                new TradeItem { Id = 38, UserId = 10, ResourceId = 17, Amount = 34 },
                new TradeItem { Id = 39, UserId = 10, ResourceId = 19, Amount = 53 },

                new TradeItem { Id = 40, UserId = 11, ResourceId = 51, Amount = 33 },
                new TradeItem { Id = 41, UserId = 11, ResourceId = 1, Amount = 17 },
                new TradeItem { Id = 42, UserId = 11, ResourceId = 3, Amount = 3 },
                new TradeItem { Id = 43, UserId = 11, ResourceId = 7, Amount = 28 },

                new TradeItem { Id = 44, UserId = 12, ResourceId = 18, Amount = 78 },
                new TradeItem { Id = 45, UserId = 12, ResourceId = 29, Amount = 12 },
                new TradeItem { Id = 46, UserId = 12, ResourceId = 47, Amount = 25 },
                new TradeItem { Id = 47, UserId = 12, ResourceId = 8, Amount = 34 },
                new TradeItem { Id = 48, UserId = 12, ResourceId = 9, Amount = 17 },
                new TradeItem { Id = 49, UserId = 12, ResourceId = 12, Amount = 21 },

                new TradeItem { Id = 50, UserId = 13, ResourceId = 51, Amount = 17 },
                new TradeItem { Id = 51, UserId = 13, ResourceId = 47, Amount = 17 },
                new TradeItem { Id = 52, UserId = 13, ResourceId = 48, Amount = 22 },
                new TradeItem { Id = 53, UserId = 13, ResourceId = 35, Amount = 33 },
                new TradeItem { Id = 54, UserId = 13, ResourceId = 12, Amount = 19 },
                new TradeItem { Id = 55, UserId = 13, ResourceId = 7, Amount = 9 },
                new TradeItem { Id = 56, UserId = 13, ResourceId = 8, Amount = 35 },
                new TradeItem { Id = 57, UserId = 13, ResourceId = 29, Amount = 13 },
                new TradeItem { Id = 58, UserId = 13, ResourceId = 38, Amount = 8 },
                new TradeItem { Id = 59, UserId = 13, ResourceId = 41, Amount = 17 },

                new TradeItem { Id = 60, UserId = 14, ResourceId = 1, Amount = 19 },
                new TradeItem { Id = 61, UserId = 14, ResourceId = 8, Amount = 47 },
                new TradeItem { Id = 62, UserId = 14, ResourceId = 11, Amount = 39 },
                new TradeItem { Id = 63, UserId = 14, ResourceId = 9, Amount = 77 },
                new TradeItem { Id = 64, UserId = 14, ResourceId = 12, Amount = 88 },
                new TradeItem { Id = 65, UserId = 14, ResourceId = 17, Amount = 24 },

                new TradeItem { Id = 66, UserId = 15, ResourceId = 18, Amount = 78 },
                new TradeItem { Id = 67, UserId = 15, ResourceId = 21, Amount = 19 },
                new TradeItem { Id = 68, UserId = 15, ResourceId = 22, Amount = 157 },
                new TradeItem { Id = 69, UserId = 15, ResourceId = 29, Amount = 153 },
                new TradeItem { Id = 70, UserId = 15, ResourceId = 51, Amount = 8 },
                new TradeItem { Id = 71, UserId = 15, ResourceId = 3, Amount = 1 },

                new TradeItem { Id = 72, UserId = 16, ResourceId = 39, Amount = 24 },
                new TradeItem { Id = 73, UserId = 16, ResourceId = 38, Amount = 35 },
                new TradeItem { Id = 74, UserId = 16, ResourceId = 36, Amount = 78 },

                new TradeItem { Id = 75, UserId = 17, ResourceId = 3, Amount = 113 },
                new TradeItem { Id = 76, UserId = 17, ResourceId = 5, Amount = 80 },
                new TradeItem { Id = 77, UserId = 17, ResourceId = 6, Amount = 17 },

                new TradeItem { Id = 78, UserId = 19, ResourceId = 51, Amount = 99 },
                new TradeItem { Id = 79, UserId = 19, ResourceId = 44, Amount = 90 },

                new TradeItem { Id = 80, UserId = 20, ResourceId = 17, Amount = 7 },
                new TradeItem { Id = 81, UserId = 20, ResourceId = 18, Amount = 13 },

                new TradeItem { Id = 82, UserId = 21, ResourceId = 23, Amount = 52 },

                new TradeItem { Id = 83, UserId = 22, ResourceId = 26, Amount = 8 }
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