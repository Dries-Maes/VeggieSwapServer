using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VeggieSwapServer.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    StreetName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StreetNumber = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TradeItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ResourceId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    TradeId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TradeItems_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TradeItems_Trades_TradeId",
                        column: x => x.TradeId,
                        principalTable: "Trades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TradeItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    VAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wallets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WalletId = table.Column<int>(type: "int", nullable: false),
                    VAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EuroAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_Wallets_WalletId",
                        column: x => x.WalletId,
                        principalTable: "Wallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreatedAt", "ImageUrl", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 18, 15, 55, 38, 891, DateTimeKind.Local).AddTicks(8776), "apples.svg", new DateTime(2021, 5, 18, 15, 55, 38, 891, DateTimeKind.Local).AddTicks(8776), "apples" },
                    { 29, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(87), "olives.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(87), "olives" },
                    { 30, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(89), "oranges.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(89), "oranges" },
                    { 31, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(92), "papayas.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(92), "papayas" },
                    { 32, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(95), "peaches.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(95), "peaches" },
                    { 33, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(98), "pears.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(98), "pears" },
                    { 34, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(100), "peas.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(100), "peas" },
                    { 35, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(103), "pineapples.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(103), "pineapples" },
                    { 36, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(106), "pomegranates.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(106), "pomegranates" },
                    { 37, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(109), "potatoes.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(109), "potatoes" },
                    { 38, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(111), "pumpkins.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(111), "pumpkins" },
                    { 28, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(84), "mushrooms.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(84), "mushrooms" },
                    { 39, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(114), "radish.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(114), "radish" },
                    { 41, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(120), "raspberries.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(120), "raspberries" },
                    { 43, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(126), "salads.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(126), "salads" },
                    { 44, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(128), "scallions.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(128), "scallions" },
                    { 45, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(131), "spinach.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(131), "spinach" },
                    { 46, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(134), "star-fruits.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(134), "star-fruits" },
                    { 47, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(137), "strawberries.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(137), "strawberries" },
                    { 48, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(140), "sweet-potatoes.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(140), "sweet-potatoes" },
                    { 49, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(143), "tomatoes.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(143), "tomatoes" },
                    { 50, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(146), "watermelons.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(146), "watermelons" },
                    { 51, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(149), "v-coin.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(149), "v-coin" },
                    { 40, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(118), "radishes.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(118), "radishes" },
                    { 27, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(81), "melons.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(81), "melons" },
                    { 42, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(123), "salad.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(123), "salad" },
                    { 25, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(75), "mangos.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(75), "mangos" },
                    { 26, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(78), "mangosteens.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(78), "mangosteens" },
                    { 2, new DateTime(2021, 5, 18, 15, 55, 38, 891, DateTimeKind.Local).AddTicks(9992), "artichokes.svg", new DateTime(2021, 5, 18, 15, 55, 38, 891, DateTimeKind.Local).AddTicks(9992), "artichokes" },
                    { 3, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(11), "asparaguses.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(11), "asparaguses" },
                    { 4, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(15), "bananas.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(15), "bananas" },
                    { 5, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(17), "bell-peppers.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(17), "bell-peppers" },
                    { 6, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(20), "blueberries.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(20), "blueberries" },
                    { 7, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(24), "bok-choy.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(24), "bok-choy" },
                    { 8, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(27), "broccoli.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(27), "broccoli" },
                    { 9, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(30), "brussels-sprouts.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(30), "brussels-sprouts" },
                    { 11, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(36), "cherries.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(36), "cherries" },
                    { 12, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(39), "chilis.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(39), "chilis" },
                    { 10, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(33), "carrots.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(33), "carrots" },
                    { 14, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(44), "coriander.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(44), "coriander" },
                    { 24, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(73), "lemons.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(73), "lemons" },
                    { 23, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(70), "kiwis.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(70), "kiwis" }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreatedAt", "ImageUrl", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 13, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(42), "coconuts.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(42), "coconuts" },
                    { 21, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(64), "grapes.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(64), "grapes" },
                    { 20, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(61), "garlic.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(61), "garlic" },
                    { 19, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(58), "eggplants.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(58), "eggplants" },
                    { 22, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(67), "guavas.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(67), "guavas" },
                    { 17, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(53), "dragon-fruits.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(53), "dragon-fruits" },
                    { 16, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(50), "cucumbers.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(50), "cucumbers" },
                    { 15, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(47), "corn.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(47), "corn" },
                    { 18, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(55), "durians.svg", new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(55), "durians" }
                });

            migrationBuilder.InsertData(
                table: "Trades",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt" },
                values: new object[,]
                {
                    { 12, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(6437), new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(6437) },
                    { 19, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(6457), new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(6457) },
                    { 18, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(6454), new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(6454) },
                    { 17, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(6451), new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(6451) },
                    { 16, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(6449), new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(6449) },
                    { 15, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(6446), new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(6446) },
                    { 14, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(6443), new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(6443) },
                    { 13, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(6441), new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(6441) },
                    { 11, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(6435), new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(6435) },
                    { 4, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(6415), new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(6415) },
                    { 9, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(6429), new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(6429) },
                    { 8, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(6427), new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(6427) },
                    { 7, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(6424), new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(6424) },
                    { 6, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(6421), new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(6421) },
                    { 5, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(6418), new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(6418) },
                    { 3, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(6413), new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(6413) },
                    { 2, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(6409), new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(6409) },
                    { 1, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(6377), new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(6377) },
                    { 10, new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(6432), new DateTime(2021, 5, 18, 15, 55, 38, 892, DateTimeKind.Local).AddTicks(6432) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "ImageUrl", "IsAdmin", "LastName", "ModifiedAt", "PasswordHash", "PasswordSalt" },
                values: new object[,]
                {
                    { 11, new DateTime(2021, 5, 18, 15, 55, 38, 886, DateTimeKind.Local).AddTicks(8138), "VerhofstadDeZeemlap@europeesemailadres.com", "Verhofstad", "https://robohash.org/Zeemlap", false, "Zeemlap", new DateTime(2021, 5, 18, 15, 55, 38, 886, DateTimeKind.Local).AddTicks(8138), new byte[] { 77, 194, 166, 27, 170, 163, 13, 247, 238, 164, 255, 84, 45, 232, 135, 161, 157, 60, 69, 218, 37, 57, 183, 198, 251, 143, 71, 29, 158, 108, 22, 203, 166, 243, 53, 63, 177, 208, 251, 182, 41, 227, 6, 149, 114, 198, 169, 177, 203, 69, 134, 86, 232, 165, 20, 160, 230, 43, 133, 33, 202, 34, 90, 39 }, new byte[] { 28, 156, 34, 199, 227, 145, 199, 132, 30, 11, 9, 108, 114, 156, 122, 219, 95, 130, 112, 84, 29, 192, 73, 152, 0, 17, 151, 33, 12, 198, 90, 13, 15, 141, 99, 210, 14, 184, 100, 27, 63, 7, 216, 249, 28, 153, 83, 171, 211, 97, 206, 132, 47, 114, 51, 176, 1, 1, 24, 239, 178, 2, 89, 213, 163, 247, 234, 7, 87, 135, 77, 188, 133, 221, 255, 239, 213, 105, 131, 134, 208, 238, 55, 235, 197, 206, 226, 243, 25, 69, 93, 99, 108, 100, 143, 197, 233, 175, 158, 82, 135, 136, 20, 90, 184, 133, 131, 188, 201, 45, 78, 96, 25, 100, 221, 197, 57, 247, 148, 88, 143, 128, 81, 84, 102, 6, 216, 165 } },
                    { 10, new DateTime(2021, 5, 18, 15, 55, 38, 886, DateTimeKind.Local).AddTicks(8119), "Luc@mail.com", "Luc", "https://robohash.org/Luc", false, "DeHaantje", new DateTime(2021, 5, 18, 15, 55, 38, 886, DateTimeKind.Local).AddTicks(8119), new byte[] { 77, 194, 166, 27, 170, 163, 13, 247, 238, 164, 255, 84, 45, 232, 135, 161, 157, 60, 69, 218, 37, 57, 183, 198, 251, 143, 71, 29, 158, 108, 22, 203, 166, 243, 53, 63, 177, 208, 251, 182, 41, 227, 6, 149, 114, 198, 169, 177, 203, 69, 134, 86, 232, 165, 20, 160, 230, 43, 133, 33, 202, 34, 90, 39 }, new byte[] { 28, 156, 34, 199, 227, 145, 199, 132, 30, 11, 9, 108, 114, 156, 122, 219, 95, 130, 112, 84, 29, 192, 73, 152, 0, 17, 151, 33, 12, 198, 90, 13, 15, 141, 99, 210, 14, 184, 100, 27, 63, 7, 216, 249, 28, 153, 83, 171, 211, 97, 206, 132, 47, 114, 51, 176, 1, 1, 24, 239, 178, 2, 89, 213, 163, 247, 234, 7, 87, 135, 77, 188, 133, 221, 255, 239, 213, 105, 131, 134, 208, 238, 55, 235, 197, 206, 226, 243, 25, 69, 93, 99, 108, 100, 143, 197, 233, 175, 158, 82, 135, 136, 20, 90, 184, 133, 131, 188, 201, 45, 78, 96, 25, 100, 221, 197, 57, 247, 148, 88, 143, 128, 81, 84, 102, 6, 216, 165 } },
                    { 9, new DateTime(2021, 5, 18, 15, 55, 38, 886, DateTimeKind.Local).AddTicks(8099), "Mihiel@mail.com", "Mihiel", "https://robohash.org/Mihiel", false, "Mihoen", new DateTime(2021, 5, 18, 15, 55, 38, 886, DateTimeKind.Local).AddTicks(8099), new byte[] { 77, 194, 166, 27, 170, 163, 13, 247, 238, 164, 255, 84, 45, 232, 135, 161, 157, 60, 69, 218, 37, 57, 183, 198, 251, 143, 71, 29, 158, 108, 22, 203, 166, 243, 53, 63, 177, 208, 251, 182, 41, 227, 6, 149, 114, 198, 169, 177, 203, 69, 134, 86, 232, 165, 20, 160, 230, 43, 133, 33, 202, 34, 90, 39 }, new byte[] { 28, 156, 34, 199, 227, 145, 199, 132, 30, 11, 9, 108, 114, 156, 122, 219, 95, 130, 112, 84, 29, 192, 73, 152, 0, 17, 151, 33, 12, 198, 90, 13, 15, 141, 99, 210, 14, 184, 100, 27, 63, 7, 216, 249, 28, 153, 83, 171, 211, 97, 206, 132, 47, 114, 51, 176, 1, 1, 24, 239, 178, 2, 89, 213, 163, 247, 234, 7, 87, 135, 77, 188, 133, 221, 255, 239, 213, 105, 131, 134, 208, 238, 55, 235, 197, 206, 226, 243, 25, 69, 93, 99, 108, 100, 143, 197, 233, 175, 158, 82, 135, 136, 20, 90, 184, 133, 131, 188, 201, 45, 78, 96, 25, 100, 221, 197, 57, 247, 148, 88, 143, 128, 81, 84, 102, 6, 216, 165 } },
                    { 8, new DateTime(2021, 5, 18, 15, 55, 38, 886, DateTimeKind.Local).AddTicks(8078), "Andreas@mail.com", "Andreas", "https://robohash.org/Andreas", false, "VanGrieken", new DateTime(2021, 5, 18, 15, 55, 38, 886, DateTimeKind.Local).AddTicks(8078), new byte[] { 77, 194, 166, 27, 170, 163, 13, 247, 238, 164, 255, 84, 45, 232, 135, 161, 157, 60, 69, 218, 37, 57, 183, 198, 251, 143, 71, 29, 158, 108, 22, 203, 166, 243, 53, 63, 177, 208, 251, 182, 41, 227, 6, 149, 114, 198, 169, 177, 203, 69, 134, 86, 232, 165, 20, 160, 230, 43, 133, 33, 202, 34, 90, 39 }, new byte[] { 28, 156, 34, 199, 227, 145, 199, 132, 30, 11, 9, 108, 114, 156, 122, 219, 95, 130, 112, 84, 29, 192, 73, 152, 0, 17, 151, 33, 12, 198, 90, 13, 15, 141, 99, 210, 14, 184, 100, 27, 63, 7, 216, 249, 28, 153, 83, 171, 211, 97, 206, 132, 47, 114, 51, 176, 1, 1, 24, 239, 178, 2, 89, 213, 163, 247, 234, 7, 87, 135, 77, 188, 133, 221, 255, 239, 213, 105, 131, 134, 208, 238, 55, 235, 197, 206, 226, 243, 25, 69, 93, 99, 108, 100, 143, 197, 233, 175, 158, 82, 135, 136, 20, 90, 184, 133, 131, 188, 201, 45, 78, 96, 25, 100, 221, 197, 57, 247, 148, 88, 143, 128, 81, 84, 102, 6, 216, 165 } },
                    { 7, new DateTime(2021, 5, 18, 15, 55, 38, 886, DateTimeKind.Local).AddTicks(8059), "Dirk@mail.com", "Dirk", "https://robohash.org/Dirk", false, "Visser", new DateTime(2021, 5, 18, 15, 55, 38, 886, DateTimeKind.Local).AddTicks(8059), new byte[] { 77, 194, 166, 27, 170, 163, 13, 247, 238, 164, 255, 84, 45, 232, 135, 161, 157, 60, 69, 218, 37, 57, 183, 198, 251, 143, 71, 29, 158, 108, 22, 203, 166, 243, 53, 63, 177, 208, 251, 182, 41, 227, 6, 149, 114, 198, 169, 177, 203, 69, 134, 86, 232, 165, 20, 160, 230, 43, 133, 33, 202, 34, 90, 39 }, new byte[] { 28, 156, 34, 199, 227, 145, 199, 132, 30, 11, 9, 108, 114, 156, 122, 219, 95, 130, 112, 84, 29, 192, 73, 152, 0, 17, 151, 33, 12, 198, 90, 13, 15, 141, 99, 210, 14, 184, 100, 27, 63, 7, 216, 249, 28, 153, 83, 171, 211, 97, 206, 132, 47, 114, 51, 176, 1, 1, 24, 239, 178, 2, 89, 213, 163, 247, 234, 7, 87, 135, 77, 188, 133, 221, 255, 239, 213, 105, 131, 134, 208, 238, 55, 235, 197, 206, 226, 243, 25, 69, 93, 99, 108, 100, 143, 197, 233, 175, 158, 82, 135, 136, 20, 90, 184, 133, 131, 188, 201, 45, 78, 96, 25, 100, 221, 197, 57, 247, 148, 88, 143, 128, 81, 84, 102, 6, 216, 165 } },
                    { 2, new DateTime(2021, 5, 18, 15, 55, 38, 886, DateTimeKind.Local).AddTicks(7464), "Nick@mail.com", "Nick", "https://robohash.org/Nick", true, "Vr", new DateTime(2021, 5, 18, 15, 55, 38, 886, DateTimeKind.Local).AddTicks(7464), new byte[] { 77, 194, 166, 27, 170, 163, 13, 247, 238, 164, 255, 84, 45, 232, 135, 161, 157, 60, 69, 218, 37, 57, 183, 198, 251, 143, 71, 29, 158, 108, 22, 203, 166, 243, 53, 63, 177, 208, 251, 182, 41, 227, 6, 149, 114, 198, 169, 177, 203, 69, 134, 86, 232, 165, 20, 160, 230, 43, 133, 33, 202, 34, 90, 39 }, new byte[] { 28, 156, 34, 199, 227, 145, 199, 132, 30, 11, 9, 108, 114, 156, 122, 219, 95, 130, 112, 84, 29, 192, 73, 152, 0, 17, 151, 33, 12, 198, 90, 13, 15, 141, 99, 210, 14, 184, 100, 27, 63, 7, 216, 249, 28, 153, 83, 171, 211, 97, 206, 132, 47, 114, 51, 176, 1, 1, 24, 239, 178, 2, 89, 213, 163, 247, 234, 7, 87, 135, 77, 188, 133, 221, 255, 239, 213, 105, 131, 134, 208, 238, 55, 235, 197, 206, 226, 243, 25, 69, 93, 99, 108, 100, 143, 197, 233, 175, 158, 82, 135, 136, 20, 90, 184, 133, 131, 188, 201, 45, 78, 96, 25, 100, 221, 197, 57, 247, 148, 88, 143, 128, 81, 84, 102, 6, 216, 165 } },
                    { 5, new DateTime(2021, 5, 18, 15, 55, 38, 886, DateTimeKind.Local).AddTicks(8018), "BartjeWevertje@mail.com", "BartjeWevertje", "https://robohash.org/BartjeWevertje", false, "Wevertje", new DateTime(2021, 5, 18, 15, 55, 38, 886, DateTimeKind.Local).AddTicks(8018), new byte[] { 77, 194, 166, 27, 170, 163, 13, 247, 238, 164, 255, 84, 45, 232, 135, 161, 157, 60, 69, 218, 37, 57, 183, 198, 251, 143, 71, 29, 158, 108, 22, 203, 166, 243, 53, 63, 177, 208, 251, 182, 41, 227, 6, 149, 114, 198, 169, 177, 203, 69, 134, 86, 232, 165, 20, 160, 230, 43, 133, 33, 202, 34, 90, 39 }, new byte[] { 28, 156, 34, 199, 227, 145, 199, 132, 30, 11, 9, 108, 114, 156, 122, 219, 95, 130, 112, 84, 29, 192, 73, 152, 0, 17, 151, 33, 12, 198, 90, 13, 15, 141, 99, 210, 14, 184, 100, 27, 63, 7, 216, 249, 28, 153, 83, 171, 211, 97, 206, 132, 47, 114, 51, 176, 1, 1, 24, 239, 178, 2, 89, 213, 163, 247, 234, 7, 87, 135, 77, 188, 133, 221, 255, 239, 213, 105, 131, 134, 208, 238, 55, 235, 197, 206, 226, 243, 25, 69, 93, 99, 108, 100, 143, 197, 233, 175, 158, 82, 135, 136, 20, 90, 184, 133, 131, 188, 201, 45, 78, 96, 25, 100, 221, 197, 57, 247, 148, 88, 143, 128, 81, 84, 102, 6, 216, 165 } },
                    { 4, new DateTime(2021, 5, 18, 15, 55, 38, 886, DateTimeKind.Local).AddTicks(7995), "Dries@mail.com", "Dries", "https://robohash.org/Dries", true, "Maes", new DateTime(2021, 5, 18, 15, 55, 38, 886, DateTimeKind.Local).AddTicks(7995), new byte[] { 77, 194, 166, 27, 170, 163, 13, 247, 238, 164, 255, 84, 45, 232, 135, 161, 157, 60, 69, 218, 37, 57, 183, 198, 251, 143, 71, 29, 158, 108, 22, 203, 166, 243, 53, 63, 177, 208, 251, 182, 41, 227, 6, 149, 114, 198, 169, 177, 203, 69, 134, 86, 232, 165, 20, 160, 230, 43, 133, 33, 202, 34, 90, 39 }, new byte[] { 28, 156, 34, 199, 227, 145, 199, 132, 30, 11, 9, 108, 114, 156, 122, 219, 95, 130, 112, 84, 29, 192, 73, 152, 0, 17, 151, 33, 12, 198, 90, 13, 15, 141, 99, 210, 14, 184, 100, 27, 63, 7, 216, 249, 28, 153, 83, 171, 211, 97, 206, 132, 47, 114, 51, 176, 1, 1, 24, 239, 178, 2, 89, 213, 163, 247, 234, 7, 87, 135, 77, 188, 133, 221, 255, 239, 213, 105, 131, 134, 208, 238, 55, 235, 197, 206, 226, 243, 25, 69, 93, 99, 108, 100, 143, 197, 233, 175, 158, 82, 135, 136, 20, 90, 184, 133, 131, 188, 201, 45, 78, 96, 25, 100, 221, 197, 57, 247, 148, 88, 143, 128, 81, 84, 102, 6, 216, 165 } },
                    { 3, new DateTime(2021, 5, 18, 15, 55, 38, 886, DateTimeKind.Local).AddTicks(7962), "Kobe@mail.com", "Kobe", "https://robohash.org/Kobe", true, "Delo", new DateTime(2021, 5, 18, 15, 55, 38, 886, DateTimeKind.Local).AddTicks(7962), new byte[] { 77, 194, 166, 27, 170, 163, 13, 247, 238, 164, 255, 84, 45, 232, 135, 161, 157, 60, 69, 218, 37, 57, 183, 198, 251, 143, 71, 29, 158, 108, 22, 203, 166, 243, 53, 63, 177, 208, 251, 182, 41, 227, 6, 149, 114, 198, 169, 177, 203, 69, 134, 86, 232, 165, 20, 160, 230, 43, 133, 33, 202, 34, 90, 39 }, new byte[] { 28, 156, 34, 199, 227, 145, 199, 132, 30, 11, 9, 108, 114, 156, 122, 219, 95, 130, 112, 84, 29, 192, 73, 152, 0, 17, 151, 33, 12, 198, 90, 13, 15, 141, 99, 210, 14, 184, 100, 27, 63, 7, 216, 249, 28, 153, 83, 171, 211, 97, 206, 132, 47, 114, 51, 176, 1, 1, 24, 239, 178, 2, 89, 213, 163, 247, 234, 7, 87, 135, 77, 188, 133, 221, 255, 239, 213, 105, 131, 134, 208, 238, 55, 235, 197, 206, 226, 243, 25, 69, 93, 99, 108, 100, 143, 197, 233, 175, 158, 82, 135, 136, 20, 90, 184, 133, 131, 188, 201, 45, 78, 96, 25, 100, 221, 197, 57, 247, 148, 88, 143, 128, 81, 84, 102, 6, 216, 165 } },
                    { 1, new DateTime(2021, 5, 18, 15, 55, 38, 882, DateTimeKind.Local).AddTicks(8282), "Pieter@mail.com", "Pieter", "https://robohash.org/Pieter", true, "Corp", new DateTime(2021, 5, 18, 15, 55, 38, 882, DateTimeKind.Local).AddTicks(8282), new byte[] { 77, 194, 166, 27, 170, 163, 13, 247, 238, 164, 255, 84, 45, 232, 135, 161, 157, 60, 69, 218, 37, 57, 183, 198, 251, 143, 71, 29, 158, 108, 22, 203, 166, 243, 53, 63, 177, 208, 251, 182, 41, 227, 6, 149, 114, 198, 169, 177, 203, 69, 134, 86, 232, 165, 20, 160, 230, 43, 133, 33, 202, 34, 90, 39 }, new byte[] { 28, 156, 34, 199, 227, 145, 199, 132, 30, 11, 9, 108, 114, 156, 122, 219, 95, 130, 112, 84, 29, 192, 73, 152, 0, 17, 151, 33, 12, 198, 90, 13, 15, 141, 99, 210, 14, 184, 100, 27, 63, 7, 216, 249, 28, 153, 83, 171, 211, 97, 206, 132, 47, 114, 51, 176, 1, 1, 24, 239, 178, 2, 89, 213, 163, 247, 234, 7, 87, 135, 77, 188, 133, 221, 255, 239, 213, 105, 131, 134, 208, 238, 55, 235, 197, 206, 226, 243, 25, 69, 93, 99, 108, 100, 143, 197, 233, 175, 158, 82, 135, 136, 20, 90, 184, 133, 131, 188, 201, 45, 78, 96, 25, 100, 221, 197, 57, 247, 148, 88, 143, 128, 81, 84, 102, 6, 216, 165 } },
                    { 12, new DateTime(2021, 5, 18, 15, 55, 38, 886, DateTimeKind.Local).AddTicks(8158), "Driesdentweedenmaarnidezelfden@mail.com", "Dries", "https://robohash.org/Dries2", false, "VanKorteNekke", new DateTime(2021, 5, 18, 15, 55, 38, 886, DateTimeKind.Local).AddTicks(8158), new byte[] { 77, 194, 166, 27, 170, 163, 13, 247, 238, 164, 255, 84, 45, 232, 135, 161, 157, 60, 69, 218, 37, 57, 183, 198, 251, 143, 71, 29, 158, 108, 22, 203, 166, 243, 53, 63, 177, 208, 251, 182, 41, 227, 6, 149, 114, 198, 169, 177, 203, 69, 134, 86, 232, 165, 20, 160, 230, 43, 133, 33, 202, 34, 90, 39 }, new byte[] { 28, 156, 34, 199, 227, 145, 199, 132, 30, 11, 9, 108, 114, 156, 122, 219, 95, 130, 112, 84, 29, 192, 73, 152, 0, 17, 151, 33, 12, 198, 90, 13, 15, 141, 99, 210, 14, 184, 100, 27, 63, 7, 216, 249, 28, 153, 83, 171, 211, 97, 206, 132, 47, 114, 51, 176, 1, 1, 24, 239, 178, 2, 89, 213, 163, 247, 234, 7, 87, 135, 77, 188, 133, 221, 255, 239, 213, 105, 131, 134, 208, 238, 55, 235, 197, 206, 226, 243, 25, 69, 93, 99, 108, 100, 143, 197, 233, 175, 158, 82, 135, 136, 20, 90, 184, 133, 131, 188, 201, 45, 78, 96, 25, 100, 221, 197, 57, 247, 148, 88, 143, 128, 81, 84, 102, 6, 216, 165 } },
                    { 6, new DateTime(2021, 5, 18, 15, 55, 38, 886, DateTimeKind.Local).AddTicks(8039), "Stofzuiger@mail.com", "Stofzuiger", "https://robohash.org/Stofzuiger", false, "Zuiger", new DateTime(2021, 5, 18, 15, 55, 38, 886, DateTimeKind.Local).AddTicks(8039), new byte[] { 77, 194, 166, 27, 170, 163, 13, 247, 238, 164, 255, 84, 45, 232, 135, 161, 157, 60, 69, 218, 37, 57, 183, 198, 251, 143, 71, 29, 158, 108, 22, 203, 166, 243, 53, 63, 177, 208, 251, 182, 41, 227, 6, 149, 114, 198, 169, 177, 203, 69, 134, 86, 232, 165, 20, 160, 230, 43, 133, 33, 202, 34, 90, 39 }, new byte[] { 28, 156, 34, 199, 227, 145, 199, 132, 30, 11, 9, 108, 114, 156, 122, 219, 95, 130, 112, 84, 29, 192, 73, 152, 0, 17, 151, 33, 12, 198, 90, 13, 15, 141, 99, 210, 14, 184, 100, 27, 63, 7, 216, 249, 28, 153, 83, 171, 211, 97, 206, 132, 47, 114, 51, 176, 1, 1, 24, 239, 178, 2, 89, 213, 163, 247, 234, 7, 87, 135, 77, 188, 133, 221, 255, 239, 213, 105, 131, 134, 208, 238, 55, 235, 197, 206, 226, 243, 25, 69, 93, 99, 108, 100, 143, 197, 233, 175, 158, 82, 135, 136, 20, 90, 184, 133, 131, 188, 201, 45, 78, 96, 25, 100, 221, 197, 57, 247, 148, 88, 143, 128, 81, 84, 102, 6, 216, 165 } },
                    { 13, new DateTime(2021, 5, 18, 15, 55, 38, 886, DateTimeKind.Local).AddTicks(8177), "Joyce@mail.com", "Joyce", "https://robohash.org/Tomatenplukker", false, "Tomatenplukker", new DateTime(2021, 5, 18, 15, 55, 38, 886, DateTimeKind.Local).AddTicks(8177), new byte[] { 77, 194, 166, 27, 170, 163, 13, 247, 238, 164, 255, 84, 45, 232, 135, 161, 157, 60, 69, 218, 37, 57, 183, 198, 251, 143, 71, 29, 158, 108, 22, 203, 166, 243, 53, 63, 177, 208, 251, 182, 41, 227, 6, 149, 114, 198, 169, 177, 203, 69, 134, 86, 232, 165, 20, 160, 230, 43, 133, 33, 202, 34, 90, 39 }, new byte[] { 28, 156, 34, 199, 227, 145, 199, 132, 30, 11, 9, 108, 114, 156, 122, 219, 95, 130, 112, 84, 29, 192, 73, 152, 0, 17, 151, 33, 12, 198, 90, 13, 15, 141, 99, 210, 14, 184, 100, 27, 63, 7, 216, 249, 28, 153, 83, 171, 211, 97, 206, 132, 47, 114, 51, 176, 1, 1, 24, 239, 178, 2, 89, 213, 163, 247, 234, 7, 87, 135, 77, 188, 133, 221, 255, 239, 213, 105, 131, 134, 208, 238, 55, 235, 197, 206, 226, 243, 25, 69, 93, 99, 108, 100, 143, 197, 233, 175, 158, 82, 135, 136, 20, 90, 184, 133, 131, 188, 201, 45, 78, 96, 25, 100, 221, 197, 57, 247, 148, 88, 143, 128, 81, 84, 102, 6, 216, 165 } }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "PostalCode", "StreetName", "StreetNumber", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 18, 15, 55, 38, 889, DateTimeKind.Local).AddTicks(2991), new DateTime(2021, 5, 18, 15, 55, 38, 889, DateTimeKind.Local).AddTicks(2991), 9000, "Anti-Veggiestraat", 89, 1 },
                    { 8, new DateTime(2021, 5, 18, 15, 55, 38, 889, DateTimeKind.Local).AddTicks(5248), new DateTime(2021, 5, 18, 15, 55, 38, 889, DateTimeKind.Local).AddTicks(5248), 1000, "Kotsvisstraat", 96, 8 },
                    { 6, new DateTime(2021, 5, 18, 15, 55, 38, 889, DateTimeKind.Local).AddTicks(5242), new DateTime(2021, 5, 18, 15, 55, 38, 889, DateTimeKind.Local).AddTicks(5242), 1000, "Lookbroodjesstraat", 43, 6 },
                    { 9, new DateTime(2021, 5, 18, 15, 55, 38, 889, DateTimeKind.Local).AddTicks(5251), new DateTime(2021, 5, 18, 15, 55, 38, 889, DateTimeKind.Local).AddTicks(5251), 2000, "Greenlivesmattertoostraat", 420, 9 },
                    { 5, new DateTime(2021, 5, 18, 15, 55, 38, 889, DateTimeKind.Local).AddTicks(5239), new DateTime(2021, 5, 18, 15, 55, 38, 889, DateTimeKind.Local).AddTicks(5239), 2000, "Kobestraat", 85, 5 },
                    { 4, new DateTime(2021, 5, 18, 15, 55, 38, 889, DateTimeKind.Local).AddTicks(5236), new DateTime(2021, 5, 18, 15, 55, 38, 889, DateTimeKind.Local).AddTicks(5236), 1000, "Driesstraat", 66, 4 },
                    { 11, new DateTime(2021, 5, 18, 15, 55, 38, 889, DateTimeKind.Local).AddTicks(5258), new DateTime(2021, 5, 18, 15, 55, 38, 889, DateTimeKind.Local).AddTicks(5258), 9500, "Kalfslapjesstraat", 32, 11 },
                    { 10, new DateTime(2021, 5, 18, 15, 55, 38, 889, DateTimeKind.Local).AddTicks(5254), new DateTime(2021, 5, 18, 15, 55, 38, 889, DateTimeKind.Local).AddTicks(5254), 9070, "Geenpolitiekinhetprojectstraat", 200, 10 },
                    { 7, new DateTime(2021, 5, 18, 15, 55, 38, 889, DateTimeKind.Local).AddTicks(5245), new DateTime(2021, 5, 18, 15, 55, 38, 889, DateTimeKind.Local).AddTicks(5245), 9050, "Greenpeacestraat", 1, 7 },
                    { 12, new DateTime(2021, 5, 18, 15, 55, 38, 889, DateTimeKind.Local).AddTicks(5261), new DateTime(2021, 5, 18, 15, 55, 38, 889, DateTimeKind.Local).AddTicks(5261), 1000, "Blacklivesmatterstraat", 78, 12 },
                    { 13, new DateTime(2021, 5, 18, 15, 55, 38, 889, DateTimeKind.Local).AddTicks(5264), new DateTime(2021, 5, 18, 15, 55, 38, 889, DateTimeKind.Local).AddTicks(5264), 9020, "Worstenbroodjesstraat", 4, 13 },
                    { 2, new DateTime(2021, 5, 18, 15, 55, 38, 889, DateTimeKind.Local).AddTicks(5190), new DateTime(2021, 5, 18, 15, 55, 38, 889, DateTimeKind.Local).AddTicks(5190), 9000, "Pieterstreaat", 45, 2 },
                    { 3, new DateTime(2021, 5, 18, 15, 55, 38, 889, DateTimeKind.Local).AddTicks(5233), new DateTime(2021, 5, 18, 15, 55, 38, 889, DateTimeKind.Local).AddTicks(5233), 9000, "Nickstraat", 74, 3 }
                });

            migrationBuilder.InsertData(
                table: "TradeItems",
                columns: new[] { "Id", "Amount", "CreatedAt", "ModifiedAt", "ResourceId", "TradeId", "UserId" },
                values: new object[,]
                {
                    { 26, 10, new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8720), new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8720), 39, 13, 7 },
                    { 3, 50, new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8652), new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8652), 32, 3, 13 },
                    { 2, 10, new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8580), new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8580), 11, 2, 8 },
                    { 8, 75, new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8668), new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8668), 8, 8, 8 },
                    { 9, 201, new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8671), new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8671), 9, 9, 9 },
                    { 10, 634, new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8674), new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8674), 10, 10, 9 },
                    { 22, 69, new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8708), new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8708), 27, 9, 9 },
                    { 20, 30, new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8702), new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8702), 36, 1, 7 },
                    { 1, 2, new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(6478), new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(6478), 51, 1, 10 },
                    { 13, 69, new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8682), new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8682), 19, 1, 10 },
                    { 19, 17, new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8699), new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8699), 7, 5, 12 },
                    { 11, 20, new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8677), new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8677), 17, 11, 11 },
                    { 7, 42, new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8665), new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8665), 17, 7, 7 },
                    { 4, 69, new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8656), new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8656), 24, 4, 4 },
                    { 17, 10, new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8694), new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8694), 1, 1, 3 },
                    { 12, 75, new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8680), new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8680), 26, 12, 13 },
                    { 24, 47, new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8714), new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8714), 47, 7, 2 },
                    { 15, 35, new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8688), new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8688), 50, 1, 4 },
                    { 16, 75, new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8691), new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8691), 7, 8, 5 },
                    { 5, 45, new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8660), new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8660), 45, 5, 5 },
                    { 23, 180, new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8711), new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8711), 37, 13, 1 },
                    { 6, 30, new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8662), new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8662), 6, 6, 6 },
                    { 21, 78, new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8705), new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8705), 23, 7, 6 },
                    { 18, 9, new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8697), new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8697), 6, 9, 1 },
                    { 25, 20, new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8717), new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8717), 48, 18, 6 },
                    { 14, 25, new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8685), new DateTime(2021, 5, 18, 15, 55, 38, 893, DateTimeKind.Local).AddTicks(8685), 49, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "UserId", "VAmount" },
                values: new object[,]
                {
                    { 2, new DateTime(2021, 5, 18, 15, 55, 38, 890, DateTimeKind.Local).AddTicks(4479), new DateTime(2021, 5, 18, 15, 55, 38, 890, DateTimeKind.Local).AddTicks(4479), 2, 347m },
                    { 1, new DateTime(2021, 5, 18, 15, 55, 38, 890, DateTimeKind.Local).AddTicks(3242), new DateTime(2021, 5, 18, 15, 55, 38, 890, DateTimeKind.Local).AddTicks(3242), 1, 200m },
                    { 11, new DateTime(2021, 5, 18, 15, 55, 38, 890, DateTimeKind.Local).AddTicks(4521), new DateTime(2021, 5, 18, 15, 55, 38, 890, DateTimeKind.Local).AddTicks(4521), 11, 269m }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "UserId", "VAmount" },
                values: new object[,]
                {
                    { 12, new DateTime(2021, 5, 18, 15, 55, 38, 890, DateTimeKind.Local).AddTicks(4523), new DateTime(2021, 5, 18, 15, 55, 38, 890, DateTimeKind.Local).AddTicks(4523), 12, 57m },
                    { 6, new DateTime(2021, 5, 18, 15, 55, 38, 890, DateTimeKind.Local).AddTicks(4506), new DateTime(2021, 5, 18, 15, 55, 38, 890, DateTimeKind.Local).AddTicks(4506), 6, 36m },
                    { 3, new DateTime(2021, 5, 18, 15, 55, 38, 890, DateTimeKind.Local).AddTicks(4495), new DateTime(2021, 5, 18, 15, 55, 38, 890, DateTimeKind.Local).AddTicks(4495), 3, 65m },
                    { 9, new DateTime(2021, 5, 18, 15, 55, 38, 890, DateTimeKind.Local).AddTicks(4515), new DateTime(2021, 5, 18, 15, 55, 38, 890, DateTimeKind.Local).AddTicks(4515), 9, 357m },
                    { 4, new DateTime(2021, 5, 18, 15, 55, 38, 890, DateTimeKind.Local).AddTicks(4500), new DateTime(2021, 5, 18, 15, 55, 38, 890, DateTimeKind.Local).AddTicks(4500), 4, 42m },
                    { 8, new DateTime(2021, 5, 18, 15, 55, 38, 890, DateTimeKind.Local).AddTicks(4512), new DateTime(2021, 5, 18, 15, 55, 38, 890, DateTimeKind.Local).AddTicks(4512), 8, 654m },
                    { 5, new DateTime(2021, 5, 18, 15, 55, 38, 890, DateTimeKind.Local).AddTicks(4503), new DateTime(2021, 5, 18, 15, 55, 38, 890, DateTimeKind.Local).AddTicks(4503), 5, 753m },
                    { 7, new DateTime(2021, 5, 18, 15, 55, 38, 890, DateTimeKind.Local).AddTicks(4509), new DateTime(2021, 5, 18, 15, 55, 38, 890, DateTimeKind.Local).AddTicks(4509), 7, 12m },
                    { 10, new DateTime(2021, 5, 18, 15, 55, 38, 890, DateTimeKind.Local).AddTicks(4517), new DateTime(2021, 5, 18, 15, 55, 38, 890, DateTimeKind.Local).AddTicks(4517), 10, 124m },
                    { 13, new DateTime(2021, 5, 18, 15, 55, 38, 890, DateTimeKind.Local).AddTicks(4527), new DateTime(2021, 5, 18, 15, 55, 38, 890, DateTimeKind.Local).AddTicks(4527), 13, 204m }
                });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "CreatedAt", "EuroAmount", "ModifiedAt", "VAmount", "WalletId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 18, 15, 55, 38, 894, DateTimeKind.Local).AddTicks(6432), 6.9m, new DateTime(2021, 5, 18, 15, 55, 38, 894, DateTimeKind.Local).AddTicks(6432), 69m, 1 },
                    { 2, new DateTime(2021, 5, 18, 15, 55, 38, 894, DateTimeKind.Local).AddTicks(8285), 2m, new DateTime(2021, 5, 18, 15, 55, 38, 894, DateTimeKind.Local).AddTicks(8285), 20m, 1 },
                    { 9, new DateTime(2021, 5, 18, 15, 55, 38, 894, DateTimeKind.Local).AddTicks(8323), 13m, new DateTime(2021, 5, 18, 15, 55, 38, 894, DateTimeKind.Local).AddTicks(8323), 130m, 3 },
                    { 10, new DateTime(2021, 5, 18, 15, 55, 38, 894, DateTimeKind.Local).AddTicks(8326), 2m, new DateTime(2021, 5, 18, 15, 55, 38, 894, DateTimeKind.Local).AddTicks(8326), 20m, 4 },
                    { 3, new DateTime(2021, 5, 18, 15, 55, 38, 894, DateTimeKind.Local).AddTicks(8303), 42m, new DateTime(2021, 5, 18, 15, 55, 38, 894, DateTimeKind.Local).AddTicks(8303), 420m, 5 },
                    { 4, new DateTime(2021, 5, 18, 15, 55, 38, 894, DateTimeKind.Local).AddTicks(8306), 10m, new DateTime(2021, 5, 18, 15, 55, 38, 894, DateTimeKind.Local).AddTicks(8306), 100m, 6 },
                    { 8, new DateTime(2021, 5, 18, 15, 55, 38, 894, DateTimeKind.Local).AddTicks(8319), 5m, new DateTime(2021, 5, 18, 15, 55, 38, 894, DateTimeKind.Local).AddTicks(8319), 50m, 7 },
                    { 7, new DateTime(2021, 5, 18, 15, 55, 38, 894, DateTimeKind.Local).AddTicks(8316), 9.8m, new DateTime(2021, 5, 18, 15, 55, 38, 894, DateTimeKind.Local).AddTicks(8316), 98m, 9 },
                    { 6, new DateTime(2021, 5, 18, 15, 55, 38, 894, DateTimeKind.Local).AddTicks(8313), 7.8m, new DateTime(2021, 5, 18, 15, 55, 38, 894, DateTimeKind.Local).AddTicks(8313), 78m, 10 },
                    { 5, new DateTime(2021, 5, 18, 15, 55, 38, 894, DateTimeKind.Local).AddTicks(8310), 3.6m, new DateTime(2021, 5, 18, 15, 55, 38, 894, DateTimeKind.Local).AddTicks(8310), 36m, 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_WalletId",
                table: "Purchases",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeItems_ResourceId",
                table: "TradeItems",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeItems_TradeId",
                table: "TradeItems",
                column: "TradeId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeItems_UserId",
                table: "TradeItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_UserId",
                table: "Wallets",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "TradeItems");

            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Trades");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
