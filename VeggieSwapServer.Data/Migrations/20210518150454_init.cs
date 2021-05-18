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
                name: "Trades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProposerId = table.Column<int>(type: "int", nullable: false),
                    ReceiverId = table.Column<int>(type: "int", nullable: false),
                    Completed = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trades", x => x.Id);
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
                name: "TradeItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ResourceId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Sold = table.Column<bool>(type: "bit", nullable: false),
                    TradeId = table.Column<int>(type: "int", nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TradeItems_Users_UserId",
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
                    { 1, new DateTime(2021, 5, 18, 17, 4, 53, 792, DateTimeKind.Local).AddTicks(7776), "apples.svg", new DateTime(2021, 5, 18, 17, 4, 53, 792, DateTimeKind.Local).AddTicks(7776), "apples" },
                    { 29, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2185), "olives.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2185), "olives" },
                    { 30, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2189), "oranges.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2189), "oranges" },
                    { 31, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2193), "papayas.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2193), "papayas" },
                    { 32, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2197), "peaches.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2197), "peaches" },
                    { 33, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2201), "pears.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2201), "pears" },
                    { 34, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2206), "peas.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2206), "peas" },
                    { 35, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2210), "pineapples.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2210), "pineapples" },
                    { 36, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2214), "pomegranates.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2214), "pomegranates" },
                    { 37, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2218), "potatoes.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2218), "potatoes" },
                    { 38, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2222), "pumpkins.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2222), "pumpkins" },
                    { 28, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2182), "mushrooms.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2182), "mushrooms" },
                    { 39, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2230), "radish.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2230), "radish" },
                    { 41, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2249), "raspberries.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2249), "raspberries" },
                    { 43, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2269), "salads.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2269), "salads" },
                    { 44, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2278), "scallions.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2278), "scallions" },
                    { 45, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2307), "spinach.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2307), "spinach" },
                    { 46, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2315), "star-fruits.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2315), "star-fruits" },
                    { 47, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2319), "strawberries.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2319), "strawberries" },
                    { 48, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2323), "sweet-potatoes.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2323), "sweet-potatoes" },
                    { 49, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2333), "tomatoes.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2333), "tomatoes" },
                    { 50, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2342), "watermelons.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2342), "watermelons" },
                    { 51, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2346), "v-coin.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2346), "v-coin" },
                    { 40, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2240), "radishes.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2240), "radishes" },
                    { 27, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2178), "melons.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2178), "melons" },
                    { 42, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2259), "salad.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2259), "salad" },
                    { 25, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2164), "mangos.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2164), "mangos" },
                    { 26, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2174), "mangosteens.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2174), "mangosteens" },
                    { 2, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2000), "artichokes.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2000), "artichokes" },
                    { 3, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2038), "asparaguses.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2038), "asparaguses" },
                    { 4, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2044), "bananas.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2044), "bananas" },
                    { 5, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2049), "bell-peppers.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2049), "bell-peppers" },
                    { 6, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2058), "blueberries.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2058), "blueberries" },
                    { 7, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2063), "bok-choy.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2063), "bok-choy" },
                    { 8, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2068), "broccoli.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2068), "broccoli" },
                    { 9, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2073), "brussels-sprouts.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2073), "brussels-sprouts" },
                    { 11, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2083), "cherries.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2083), "cherries" },
                    { 12, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2088), "chilis.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2088), "chilis" },
                    { 10, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2078), "carrots.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2078), "carrots" },
                    { 14, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2099), "coriander.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2099), "coriander" },
                    { 24, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2155), "lemons.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2155), "lemons" },
                    { 23, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2146), "kiwis.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2146), "kiwis" }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreatedAt", "ImageUrl", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 13, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2094), "coconuts.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2094), "coconuts" },
                    { 21, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2132), "grapes.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2132), "grapes" },
                    { 20, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2128), "garlic.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2128), "garlic" },
                    { 19, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2124), "eggplants.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2124), "eggplants" },
                    { 22, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2138), "guavas.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2138), "guavas" },
                    { 17, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2116), "dragon-fruits.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2116), "dragon-fruits" },
                    { 16, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2110), "cucumbers.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2110), "cucumbers" },
                    { 15, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2104), "corn.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2104), "corn" },
                    { 18, new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2119), "durians.svg", new DateTime(2021, 5, 18, 17, 4, 53, 793, DateTimeKind.Local).AddTicks(2119), "durians" }
                });

            migrationBuilder.InsertData(
                table: "Trades",
                columns: new[] { "Id", "Completed", "CreatedAt", "ModifiedAt", "ProposerId", "ReceiverId" },
                values: new object[,]
                {
                    { 12, false, new DateTime(2021, 5, 18, 17, 4, 53, 794, DateTimeKind.Local).AddTicks(2748), new DateTime(2021, 5, 18, 17, 4, 53, 794, DateTimeKind.Local).AddTicks(2748), 0, 0 },
                    { 19, false, new DateTime(2021, 5, 18, 17, 4, 53, 794, DateTimeKind.Local).AddTicks(2801), new DateTime(2021, 5, 18, 17, 4, 53, 794, DateTimeKind.Local).AddTicks(2801), 0, 0 },
                    { 18, false, new DateTime(2021, 5, 18, 17, 4, 53, 794, DateTimeKind.Local).AddTicks(2793), new DateTime(2021, 5, 18, 17, 4, 53, 794, DateTimeKind.Local).AddTicks(2793), 0, 0 },
                    { 17, false, new DateTime(2021, 5, 18, 17, 4, 53, 794, DateTimeKind.Local).AddTicks(2783), new DateTime(2021, 5, 18, 17, 4, 53, 794, DateTimeKind.Local).AddTicks(2783), 0, 0 },
                    { 16, false, new DateTime(2021, 5, 18, 17, 4, 53, 794, DateTimeKind.Local).AddTicks(2775), new DateTime(2021, 5, 18, 17, 4, 53, 794, DateTimeKind.Local).AddTicks(2775), 0, 0 },
                    { 15, false, new DateTime(2021, 5, 18, 17, 4, 53, 794, DateTimeKind.Local).AddTicks(2765), new DateTime(2021, 5, 18, 17, 4, 53, 794, DateTimeKind.Local).AddTicks(2765), 0, 0 },
                    { 14, false, new DateTime(2021, 5, 18, 17, 4, 53, 794, DateTimeKind.Local).AddTicks(2756), new DateTime(2021, 5, 18, 17, 4, 53, 794, DateTimeKind.Local).AddTicks(2756), 0, 0 },
                    { 13, false, new DateTime(2021, 5, 18, 17, 4, 53, 794, DateTimeKind.Local).AddTicks(2752), new DateTime(2021, 5, 18, 17, 4, 53, 794, DateTimeKind.Local).AddTicks(2752), 0, 0 },
                    { 11, false, new DateTime(2021, 5, 18, 17, 4, 53, 794, DateTimeKind.Local).AddTicks(2743), new DateTime(2021, 5, 18, 17, 4, 53, 794, DateTimeKind.Local).AddTicks(2743), 0, 0 },
                    { 4, false, new DateTime(2021, 5, 18, 17, 4, 53, 794, DateTimeKind.Local).AddTicks(2704), new DateTime(2021, 5, 18, 17, 4, 53, 794, DateTimeKind.Local).AddTicks(2704), 0, 0 },
                    { 9, false, new DateTime(2021, 5, 18, 17, 4, 53, 794, DateTimeKind.Local).AddTicks(2735), new DateTime(2021, 5, 18, 17, 4, 53, 794, DateTimeKind.Local).AddTicks(2735), 0, 0 },
                    { 8, false, new DateTime(2021, 5, 18, 17, 4, 53, 794, DateTimeKind.Local).AddTicks(2731), new DateTime(2021, 5, 18, 17, 4, 53, 794, DateTimeKind.Local).AddTicks(2731), 0, 0 },
                    { 7, false, new DateTime(2021, 5, 18, 17, 4, 53, 794, DateTimeKind.Local).AddTicks(2723), new DateTime(2021, 5, 18, 17, 4, 53, 794, DateTimeKind.Local).AddTicks(2723), 0, 0 },
                    { 6, false, new DateTime(2021, 5, 18, 17, 4, 53, 794, DateTimeKind.Local).AddTicks(2713), new DateTime(2021, 5, 18, 17, 4, 53, 794, DateTimeKind.Local).AddTicks(2713), 0, 0 },
                    { 5, false, new DateTime(2021, 5, 18, 17, 4, 53, 794, DateTimeKind.Local).AddTicks(2708), new DateTime(2021, 5, 18, 17, 4, 53, 794, DateTimeKind.Local).AddTicks(2708), 0, 0 },
                    { 3, false, new DateTime(2021, 5, 18, 17, 4, 53, 794, DateTimeKind.Local).AddTicks(2699), new DateTime(2021, 5, 18, 17, 4, 53, 794, DateTimeKind.Local).AddTicks(2699), 0, 0 },
                    { 2, false, new DateTime(2021, 5, 18, 17, 4, 53, 794, DateTimeKind.Local).AddTicks(2684), new DateTime(2021, 5, 18, 17, 4, 53, 794, DateTimeKind.Local).AddTicks(2684), 0, 0 },
                    { 1, false, new DateTime(2021, 5, 18, 17, 4, 53, 794, DateTimeKind.Local).AddTicks(2611), new DateTime(2021, 5, 18, 17, 4, 53, 794, DateTimeKind.Local).AddTicks(2611), 0, 0 },
                    { 10, false, new DateTime(2021, 5, 18, 17, 4, 53, 794, DateTimeKind.Local).AddTicks(2739), new DateTime(2021, 5, 18, 17, 4, 53, 794, DateTimeKind.Local).AddTicks(2739), 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "ImageUrl", "IsAdmin", "LastName", "ModifiedAt", "PasswordHash", "PasswordSalt" },
                values: new object[,]
                {
                    { 11, new DateTime(2021, 5, 18, 17, 4, 53, 785, DateTimeKind.Local).AddTicks(5858), "VerhofstadDeZeemlap@europeesemailadres.com", "Verhofstad", "https://robohash.org/Zeemlap", false, "Zeemlap", new DateTime(2021, 5, 18, 17, 4, 53, 785, DateTimeKind.Local).AddTicks(5858), new byte[] { 243, 187, 162, 197, 19, 248, 231, 181, 246, 187, 188, 229, 192, 61, 129, 178, 56, 208, 19, 16, 227, 121, 104, 203, 174, 160, 254, 202, 254, 243, 2, 32, 243, 28, 185, 158, 108, 246, 106, 107, 47, 153, 14, 12, 173, 205, 27, 194, 93, 251, 169, 52, 168, 113, 181, 72, 160, 206, 69, 202, 124, 5, 108, 82 }, new byte[] { 53, 241, 191, 119, 238, 219, 26, 60, 85, 200, 127, 164, 69, 25, 219, 238, 47, 54, 72, 230, 178, 149, 0, 42, 7, 217, 173, 49, 8, 133, 140, 2, 98, 126, 28, 148, 95, 187, 96, 79, 158, 205, 60, 143, 153, 22, 69, 48, 134, 202, 206, 161, 30, 164, 122, 142, 52, 219, 133, 113, 60, 190, 162, 27, 171, 109, 143, 85, 235, 1, 25, 103, 101, 185, 72, 42, 182, 145, 163, 42, 241, 199, 111, 210, 191, 61, 160, 85, 105, 53, 104, 43, 199, 221, 93, 41, 193, 220, 112, 144, 183, 18, 142, 121, 220, 171, 143, 79, 69, 247, 134, 127, 116, 253, 221, 28, 64, 175, 241, 230, 109, 47, 80, 183, 90, 246, 79, 102 } },
                    { 10, new DateTime(2021, 5, 18, 17, 4, 53, 785, DateTimeKind.Local).AddTicks(5838), "Luc@mail.com", "Luc", "https://robohash.org/Luc", false, "DeHaantje", new DateTime(2021, 5, 18, 17, 4, 53, 785, DateTimeKind.Local).AddTicks(5838), new byte[] { 243, 187, 162, 197, 19, 248, 231, 181, 246, 187, 188, 229, 192, 61, 129, 178, 56, 208, 19, 16, 227, 121, 104, 203, 174, 160, 254, 202, 254, 243, 2, 32, 243, 28, 185, 158, 108, 246, 106, 107, 47, 153, 14, 12, 173, 205, 27, 194, 93, 251, 169, 52, 168, 113, 181, 72, 160, 206, 69, 202, 124, 5, 108, 82 }, new byte[] { 53, 241, 191, 119, 238, 219, 26, 60, 85, 200, 127, 164, 69, 25, 219, 238, 47, 54, 72, 230, 178, 149, 0, 42, 7, 217, 173, 49, 8, 133, 140, 2, 98, 126, 28, 148, 95, 187, 96, 79, 158, 205, 60, 143, 153, 22, 69, 48, 134, 202, 206, 161, 30, 164, 122, 142, 52, 219, 133, 113, 60, 190, 162, 27, 171, 109, 143, 85, 235, 1, 25, 103, 101, 185, 72, 42, 182, 145, 163, 42, 241, 199, 111, 210, 191, 61, 160, 85, 105, 53, 104, 43, 199, 221, 93, 41, 193, 220, 112, 144, 183, 18, 142, 121, 220, 171, 143, 79, 69, 247, 134, 127, 116, 253, 221, 28, 64, 175, 241, 230, 109, 47, 80, 183, 90, 246, 79, 102 } },
                    { 9, new DateTime(2021, 5, 18, 17, 4, 53, 785, DateTimeKind.Local).AddTicks(5817), "Mihiel@mail.com", "Mihiel", "https://robohash.org/Mihiel", false, "Mihoen", new DateTime(2021, 5, 18, 17, 4, 53, 785, DateTimeKind.Local).AddTicks(5817), new byte[] { 243, 187, 162, 197, 19, 248, 231, 181, 246, 187, 188, 229, 192, 61, 129, 178, 56, 208, 19, 16, 227, 121, 104, 203, 174, 160, 254, 202, 254, 243, 2, 32, 243, 28, 185, 158, 108, 246, 106, 107, 47, 153, 14, 12, 173, 205, 27, 194, 93, 251, 169, 52, 168, 113, 181, 72, 160, 206, 69, 202, 124, 5, 108, 82 }, new byte[] { 53, 241, 191, 119, 238, 219, 26, 60, 85, 200, 127, 164, 69, 25, 219, 238, 47, 54, 72, 230, 178, 149, 0, 42, 7, 217, 173, 49, 8, 133, 140, 2, 98, 126, 28, 148, 95, 187, 96, 79, 158, 205, 60, 143, 153, 22, 69, 48, 134, 202, 206, 161, 30, 164, 122, 142, 52, 219, 133, 113, 60, 190, 162, 27, 171, 109, 143, 85, 235, 1, 25, 103, 101, 185, 72, 42, 182, 145, 163, 42, 241, 199, 111, 210, 191, 61, 160, 85, 105, 53, 104, 43, 199, 221, 93, 41, 193, 220, 112, 144, 183, 18, 142, 121, 220, 171, 143, 79, 69, 247, 134, 127, 116, 253, 221, 28, 64, 175, 241, 230, 109, 47, 80, 183, 90, 246, 79, 102 } },
                    { 8, new DateTime(2021, 5, 18, 17, 4, 53, 785, DateTimeKind.Local).AddTicks(5795), "Andreas@mail.com", "Andreas", "https://robohash.org/Andreas", false, "VanGrieken", new DateTime(2021, 5, 18, 17, 4, 53, 785, DateTimeKind.Local).AddTicks(5795), new byte[] { 243, 187, 162, 197, 19, 248, 231, 181, 246, 187, 188, 229, 192, 61, 129, 178, 56, 208, 19, 16, 227, 121, 104, 203, 174, 160, 254, 202, 254, 243, 2, 32, 243, 28, 185, 158, 108, 246, 106, 107, 47, 153, 14, 12, 173, 205, 27, 194, 93, 251, 169, 52, 168, 113, 181, 72, 160, 206, 69, 202, 124, 5, 108, 82 }, new byte[] { 53, 241, 191, 119, 238, 219, 26, 60, 85, 200, 127, 164, 69, 25, 219, 238, 47, 54, 72, 230, 178, 149, 0, 42, 7, 217, 173, 49, 8, 133, 140, 2, 98, 126, 28, 148, 95, 187, 96, 79, 158, 205, 60, 143, 153, 22, 69, 48, 134, 202, 206, 161, 30, 164, 122, 142, 52, 219, 133, 113, 60, 190, 162, 27, 171, 109, 143, 85, 235, 1, 25, 103, 101, 185, 72, 42, 182, 145, 163, 42, 241, 199, 111, 210, 191, 61, 160, 85, 105, 53, 104, 43, 199, 221, 93, 41, 193, 220, 112, 144, 183, 18, 142, 121, 220, 171, 143, 79, 69, 247, 134, 127, 116, 253, 221, 28, 64, 175, 241, 230, 109, 47, 80, 183, 90, 246, 79, 102 } },
                    { 7, new DateTime(2021, 5, 18, 17, 4, 53, 785, DateTimeKind.Local).AddTicks(5774), "Dirk@mail.com", "Dirk", "https://robohash.org/Dirk", false, "Visser", new DateTime(2021, 5, 18, 17, 4, 53, 785, DateTimeKind.Local).AddTicks(5774), new byte[] { 243, 187, 162, 197, 19, 248, 231, 181, 246, 187, 188, 229, 192, 61, 129, 178, 56, 208, 19, 16, 227, 121, 104, 203, 174, 160, 254, 202, 254, 243, 2, 32, 243, 28, 185, 158, 108, 246, 106, 107, 47, 153, 14, 12, 173, 205, 27, 194, 93, 251, 169, 52, 168, 113, 181, 72, 160, 206, 69, 202, 124, 5, 108, 82 }, new byte[] { 53, 241, 191, 119, 238, 219, 26, 60, 85, 200, 127, 164, 69, 25, 219, 238, 47, 54, 72, 230, 178, 149, 0, 42, 7, 217, 173, 49, 8, 133, 140, 2, 98, 126, 28, 148, 95, 187, 96, 79, 158, 205, 60, 143, 153, 22, 69, 48, 134, 202, 206, 161, 30, 164, 122, 142, 52, 219, 133, 113, 60, 190, 162, 27, 171, 109, 143, 85, 235, 1, 25, 103, 101, 185, 72, 42, 182, 145, 163, 42, 241, 199, 111, 210, 191, 61, 160, 85, 105, 53, 104, 43, 199, 221, 93, 41, 193, 220, 112, 144, 183, 18, 142, 121, 220, 171, 143, 79, 69, 247, 134, 127, 116, 253, 221, 28, 64, 175, 241, 230, 109, 47, 80, 183, 90, 246, 79, 102 } },
                    { 2, new DateTime(2021, 5, 18, 17, 4, 53, 785, DateTimeKind.Local).AddTicks(5268), "Nick@mail.com", "Nick", "https://robohash.org/Nick", true, "Vr", new DateTime(2021, 5, 18, 17, 4, 53, 785, DateTimeKind.Local).AddTicks(5268), new byte[] { 243, 187, 162, 197, 19, 248, 231, 181, 246, 187, 188, 229, 192, 61, 129, 178, 56, 208, 19, 16, 227, 121, 104, 203, 174, 160, 254, 202, 254, 243, 2, 32, 243, 28, 185, 158, 108, 246, 106, 107, 47, 153, 14, 12, 173, 205, 27, 194, 93, 251, 169, 52, 168, 113, 181, 72, 160, 206, 69, 202, 124, 5, 108, 82 }, new byte[] { 53, 241, 191, 119, 238, 219, 26, 60, 85, 200, 127, 164, 69, 25, 219, 238, 47, 54, 72, 230, 178, 149, 0, 42, 7, 217, 173, 49, 8, 133, 140, 2, 98, 126, 28, 148, 95, 187, 96, 79, 158, 205, 60, 143, 153, 22, 69, 48, 134, 202, 206, 161, 30, 164, 122, 142, 52, 219, 133, 113, 60, 190, 162, 27, 171, 109, 143, 85, 235, 1, 25, 103, 101, 185, 72, 42, 182, 145, 163, 42, 241, 199, 111, 210, 191, 61, 160, 85, 105, 53, 104, 43, 199, 221, 93, 41, 193, 220, 112, 144, 183, 18, 142, 121, 220, 171, 143, 79, 69, 247, 134, 127, 116, 253, 221, 28, 64, 175, 241, 230, 109, 47, 80, 183, 90, 246, 79, 102 } },
                    { 5, new DateTime(2021, 5, 18, 17, 4, 53, 785, DateTimeKind.Local).AddTicks(5730), "BartjeWevertje@mail.com", "BartjeWevertje", "https://robohash.org/BartjeWevertje", false, "Wevertje", new DateTime(2021, 5, 18, 17, 4, 53, 785, DateTimeKind.Local).AddTicks(5730), new byte[] { 243, 187, 162, 197, 19, 248, 231, 181, 246, 187, 188, 229, 192, 61, 129, 178, 56, 208, 19, 16, 227, 121, 104, 203, 174, 160, 254, 202, 254, 243, 2, 32, 243, 28, 185, 158, 108, 246, 106, 107, 47, 153, 14, 12, 173, 205, 27, 194, 93, 251, 169, 52, 168, 113, 181, 72, 160, 206, 69, 202, 124, 5, 108, 82 }, new byte[] { 53, 241, 191, 119, 238, 219, 26, 60, 85, 200, 127, 164, 69, 25, 219, 238, 47, 54, 72, 230, 178, 149, 0, 42, 7, 217, 173, 49, 8, 133, 140, 2, 98, 126, 28, 148, 95, 187, 96, 79, 158, 205, 60, 143, 153, 22, 69, 48, 134, 202, 206, 161, 30, 164, 122, 142, 52, 219, 133, 113, 60, 190, 162, 27, 171, 109, 143, 85, 235, 1, 25, 103, 101, 185, 72, 42, 182, 145, 163, 42, 241, 199, 111, 210, 191, 61, 160, 85, 105, 53, 104, 43, 199, 221, 93, 41, 193, 220, 112, 144, 183, 18, 142, 121, 220, 171, 143, 79, 69, 247, 134, 127, 116, 253, 221, 28, 64, 175, 241, 230, 109, 47, 80, 183, 90, 246, 79, 102 } },
                    { 4, new DateTime(2021, 5, 18, 17, 4, 53, 785, DateTimeKind.Local).AddTicks(5709), "Dries@mail.com", "Dries", "https://robohash.org/Dries", true, "Maes", new DateTime(2021, 5, 18, 17, 4, 53, 785, DateTimeKind.Local).AddTicks(5709), new byte[] { 243, 187, 162, 197, 19, 248, 231, 181, 246, 187, 188, 229, 192, 61, 129, 178, 56, 208, 19, 16, 227, 121, 104, 203, 174, 160, 254, 202, 254, 243, 2, 32, 243, 28, 185, 158, 108, 246, 106, 107, 47, 153, 14, 12, 173, 205, 27, 194, 93, 251, 169, 52, 168, 113, 181, 72, 160, 206, 69, 202, 124, 5, 108, 82 }, new byte[] { 53, 241, 191, 119, 238, 219, 26, 60, 85, 200, 127, 164, 69, 25, 219, 238, 47, 54, 72, 230, 178, 149, 0, 42, 7, 217, 173, 49, 8, 133, 140, 2, 98, 126, 28, 148, 95, 187, 96, 79, 158, 205, 60, 143, 153, 22, 69, 48, 134, 202, 206, 161, 30, 164, 122, 142, 52, 219, 133, 113, 60, 190, 162, 27, 171, 109, 143, 85, 235, 1, 25, 103, 101, 185, 72, 42, 182, 145, 163, 42, 241, 199, 111, 210, 191, 61, 160, 85, 105, 53, 104, 43, 199, 221, 93, 41, 193, 220, 112, 144, 183, 18, 142, 121, 220, 171, 143, 79, 69, 247, 134, 127, 116, 253, 221, 28, 64, 175, 241, 230, 109, 47, 80, 183, 90, 246, 79, 102 } },
                    { 3, new DateTime(2021, 5, 18, 17, 4, 53, 785, DateTimeKind.Local).AddTicks(5672), "Kobe@mail.com", "Kobe", "https://robohash.org/Kobe", true, "Delo", new DateTime(2021, 5, 18, 17, 4, 53, 785, DateTimeKind.Local).AddTicks(5672), new byte[] { 243, 187, 162, 197, 19, 248, 231, 181, 246, 187, 188, 229, 192, 61, 129, 178, 56, 208, 19, 16, 227, 121, 104, 203, 174, 160, 254, 202, 254, 243, 2, 32, 243, 28, 185, 158, 108, 246, 106, 107, 47, 153, 14, 12, 173, 205, 27, 194, 93, 251, 169, 52, 168, 113, 181, 72, 160, 206, 69, 202, 124, 5, 108, 82 }, new byte[] { 53, 241, 191, 119, 238, 219, 26, 60, 85, 200, 127, 164, 69, 25, 219, 238, 47, 54, 72, 230, 178, 149, 0, 42, 7, 217, 173, 49, 8, 133, 140, 2, 98, 126, 28, 148, 95, 187, 96, 79, 158, 205, 60, 143, 153, 22, 69, 48, 134, 202, 206, 161, 30, 164, 122, 142, 52, 219, 133, 113, 60, 190, 162, 27, 171, 109, 143, 85, 235, 1, 25, 103, 101, 185, 72, 42, 182, 145, 163, 42, 241, 199, 111, 210, 191, 61, 160, 85, 105, 53, 104, 43, 199, 221, 93, 41, 193, 220, 112, 144, 183, 18, 142, 121, 220, 171, 143, 79, 69, 247, 134, 127, 116, 253, 221, 28, 64, 175, 241, 230, 109, 47, 80, 183, 90, 246, 79, 102 } },
                    { 1, new DateTime(2021, 5, 18, 17, 4, 53, 781, DateTimeKind.Local).AddTicks(1310), "Pieter@mail.com", "Pieter", "https://robohash.org/Pieter", true, "Corp", new DateTime(2021, 5, 18, 17, 4, 53, 781, DateTimeKind.Local).AddTicks(1310), new byte[] { 243, 187, 162, 197, 19, 248, 231, 181, 246, 187, 188, 229, 192, 61, 129, 178, 56, 208, 19, 16, 227, 121, 104, 203, 174, 160, 254, 202, 254, 243, 2, 32, 243, 28, 185, 158, 108, 246, 106, 107, 47, 153, 14, 12, 173, 205, 27, 194, 93, 251, 169, 52, 168, 113, 181, 72, 160, 206, 69, 202, 124, 5, 108, 82 }, new byte[] { 53, 241, 191, 119, 238, 219, 26, 60, 85, 200, 127, 164, 69, 25, 219, 238, 47, 54, 72, 230, 178, 149, 0, 42, 7, 217, 173, 49, 8, 133, 140, 2, 98, 126, 28, 148, 95, 187, 96, 79, 158, 205, 60, 143, 153, 22, 69, 48, 134, 202, 206, 161, 30, 164, 122, 142, 52, 219, 133, 113, 60, 190, 162, 27, 171, 109, 143, 85, 235, 1, 25, 103, 101, 185, 72, 42, 182, 145, 163, 42, 241, 199, 111, 210, 191, 61, 160, 85, 105, 53, 104, 43, 199, 221, 93, 41, 193, 220, 112, 144, 183, 18, 142, 121, 220, 171, 143, 79, 69, 247, 134, 127, 116, 253, 221, 28, 64, 175, 241, 230, 109, 47, 80, 183, 90, 246, 79, 102 } },
                    { 12, new DateTime(2021, 5, 18, 17, 4, 53, 785, DateTimeKind.Local).AddTicks(5991), "Driesdentweedenmaarnidezelfden@mail.com", "Dries", "https://robohash.org/Dries2", false, "VanKorteNekke", new DateTime(2021, 5, 18, 17, 4, 53, 785, DateTimeKind.Local).AddTicks(5991), new byte[] { 243, 187, 162, 197, 19, 248, 231, 181, 246, 187, 188, 229, 192, 61, 129, 178, 56, 208, 19, 16, 227, 121, 104, 203, 174, 160, 254, 202, 254, 243, 2, 32, 243, 28, 185, 158, 108, 246, 106, 107, 47, 153, 14, 12, 173, 205, 27, 194, 93, 251, 169, 52, 168, 113, 181, 72, 160, 206, 69, 202, 124, 5, 108, 82 }, new byte[] { 53, 241, 191, 119, 238, 219, 26, 60, 85, 200, 127, 164, 69, 25, 219, 238, 47, 54, 72, 230, 178, 149, 0, 42, 7, 217, 173, 49, 8, 133, 140, 2, 98, 126, 28, 148, 95, 187, 96, 79, 158, 205, 60, 143, 153, 22, 69, 48, 134, 202, 206, 161, 30, 164, 122, 142, 52, 219, 133, 113, 60, 190, 162, 27, 171, 109, 143, 85, 235, 1, 25, 103, 101, 185, 72, 42, 182, 145, 163, 42, 241, 199, 111, 210, 191, 61, 160, 85, 105, 53, 104, 43, 199, 221, 93, 41, 193, 220, 112, 144, 183, 18, 142, 121, 220, 171, 143, 79, 69, 247, 134, 127, 116, 253, 221, 28, 64, 175, 241, 230, 109, 47, 80, 183, 90, 246, 79, 102 } },
                    { 6, new DateTime(2021, 5, 18, 17, 4, 53, 785, DateTimeKind.Local).AddTicks(5752), "Stofzuiger@mail.com", "Stofzuiger", "https://robohash.org/Stofzuiger", false, "Zuiger", new DateTime(2021, 5, 18, 17, 4, 53, 785, DateTimeKind.Local).AddTicks(5752), new byte[] { 243, 187, 162, 197, 19, 248, 231, 181, 246, 187, 188, 229, 192, 61, 129, 178, 56, 208, 19, 16, 227, 121, 104, 203, 174, 160, 254, 202, 254, 243, 2, 32, 243, 28, 185, 158, 108, 246, 106, 107, 47, 153, 14, 12, 173, 205, 27, 194, 93, 251, 169, 52, 168, 113, 181, 72, 160, 206, 69, 202, 124, 5, 108, 82 }, new byte[] { 53, 241, 191, 119, 238, 219, 26, 60, 85, 200, 127, 164, 69, 25, 219, 238, 47, 54, 72, 230, 178, 149, 0, 42, 7, 217, 173, 49, 8, 133, 140, 2, 98, 126, 28, 148, 95, 187, 96, 79, 158, 205, 60, 143, 153, 22, 69, 48, 134, 202, 206, 161, 30, 164, 122, 142, 52, 219, 133, 113, 60, 190, 162, 27, 171, 109, 143, 85, 235, 1, 25, 103, 101, 185, 72, 42, 182, 145, 163, 42, 241, 199, 111, 210, 191, 61, 160, 85, 105, 53, 104, 43, 199, 221, 93, 41, 193, 220, 112, 144, 183, 18, 142, 121, 220, 171, 143, 79, 69, 247, 134, 127, 116, 253, 221, 28, 64, 175, 241, 230, 109, 47, 80, 183, 90, 246, 79, 102 } },
                    { 13, new DateTime(2021, 5, 18, 17, 4, 53, 785, DateTimeKind.Local).AddTicks(6016), "Joyce@mail.com", "Joyce", "https://robohash.org/Tomatenplukker", false, "Tomatenplukker", new DateTime(2021, 5, 18, 17, 4, 53, 785, DateTimeKind.Local).AddTicks(6016), new byte[] { 243, 187, 162, 197, 19, 248, 231, 181, 246, 187, 188, 229, 192, 61, 129, 178, 56, 208, 19, 16, 227, 121, 104, 203, 174, 160, 254, 202, 254, 243, 2, 32, 243, 28, 185, 158, 108, 246, 106, 107, 47, 153, 14, 12, 173, 205, 27, 194, 93, 251, 169, 52, 168, 113, 181, 72, 160, 206, 69, 202, 124, 5, 108, 82 }, new byte[] { 53, 241, 191, 119, 238, 219, 26, 60, 85, 200, 127, 164, 69, 25, 219, 238, 47, 54, 72, 230, 178, 149, 0, 42, 7, 217, 173, 49, 8, 133, 140, 2, 98, 126, 28, 148, 95, 187, 96, 79, 158, 205, 60, 143, 153, 22, 69, 48, 134, 202, 206, 161, 30, 164, 122, 142, 52, 219, 133, 113, 60, 190, 162, 27, 171, 109, 143, 85, 235, 1, 25, 103, 101, 185, 72, 42, 182, 145, 163, 42, 241, 199, 111, 210, 191, 61, 160, 85, 105, 53, 104, 43, 199, 221, 93, 41, 193, 220, 112, 144, 183, 18, 142, 121, 220, 171, 143, 79, 69, 247, 134, 127, 116, 253, 221, 28, 64, 175, 241, 230, 109, 47, 80, 183, 90, 246, 79, 102 } }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "PostalCode", "StreetName", "StreetNumber", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 18, 17, 4, 53, 789, DateTimeKind.Local).AddTicks(2984), new DateTime(2021, 5, 18, 17, 4, 53, 789, DateTimeKind.Local).AddTicks(2984), 9000, "Anti-Veggiestraat", 89, 1 },
                    { 8, new DateTime(2021, 5, 18, 17, 4, 53, 789, DateTimeKind.Local).AddTicks(5348), new DateTime(2021, 5, 18, 17, 4, 53, 789, DateTimeKind.Local).AddTicks(5348), 1000, "Kotsvisstraat", 96, 8 },
                    { 13, new DateTime(2021, 5, 18, 17, 4, 53, 789, DateTimeKind.Local).AddTicks(5365), new DateTime(2021, 5, 18, 17, 4, 53, 789, DateTimeKind.Local).AddTicks(5365), 9020, "Worstenbroodjesstraat", 4, 13 },
                    { 7, new DateTime(2021, 5, 18, 17, 4, 53, 789, DateTimeKind.Local).AddTicks(5342), new DateTime(2021, 5, 18, 17, 4, 53, 789, DateTimeKind.Local).AddTicks(5342), 9050, "Greenpeacestraat", 1, 7 },
                    { 6, new DateTime(2021, 5, 18, 17, 4, 53, 789, DateTimeKind.Local).AddTicks(5339), new DateTime(2021, 5, 18, 17, 4, 53, 789, DateTimeKind.Local).AddTicks(5339), 1000, "Lookbroodjesstraat", 43, 6 },
                    { 10, new DateTime(2021, 5, 18, 17, 4, 53, 789, DateTimeKind.Local).AddTicks(5355), new DateTime(2021, 5, 18, 17, 4, 53, 789, DateTimeKind.Local).AddTicks(5355), 9070, "Geenpolitiekinhetprojectstraat", 200, 10 },
                    { 11, new DateTime(2021, 5, 18, 17, 4, 53, 789, DateTimeKind.Local).AddTicks(5359), new DateTime(2021, 5, 18, 17, 4, 53, 789, DateTimeKind.Local).AddTicks(5359), 9500, "Kalfslapjesstraat", 32, 11 },
                    { 5, new DateTime(2021, 5, 18, 17, 4, 53, 789, DateTimeKind.Local).AddTicks(5335), new DateTime(2021, 5, 18, 17, 4, 53, 789, DateTimeKind.Local).AddTicks(5335), 2000, "Kobestraat", 85, 5 },
                    { 3, new DateTime(2021, 5, 18, 17, 4, 53, 789, DateTimeKind.Local).AddTicks(5328), new DateTime(2021, 5, 18, 17, 4, 53, 789, DateTimeKind.Local).AddTicks(5328), 9000, "Nickstraat", 74, 3 },
                    { 12, new DateTime(2021, 5, 18, 17, 4, 53, 789, DateTimeKind.Local).AddTicks(5362), new DateTime(2021, 5, 18, 17, 4, 53, 789, DateTimeKind.Local).AddTicks(5362), 1000, "Blacklivesmatterstraat", 78, 12 },
                    { 2, new DateTime(2021, 5, 18, 17, 4, 53, 789, DateTimeKind.Local).AddTicks(5311), new DateTime(2021, 5, 18, 17, 4, 53, 789, DateTimeKind.Local).AddTicks(5311), 9000, "Pieterstreaat", 45, 2 },
                    { 4, new DateTime(2021, 5, 18, 17, 4, 53, 789, DateTimeKind.Local).AddTicks(5332), new DateTime(2021, 5, 18, 17, 4, 53, 789, DateTimeKind.Local).AddTicks(5332), 1000, "Driesstraat", 66, 4 },
                    { 9, new DateTime(2021, 5, 18, 17, 4, 53, 789, DateTimeKind.Local).AddTicks(5352), new DateTime(2021, 5, 18, 17, 4, 53, 789, DateTimeKind.Local).AddTicks(5352), 2000, "Greenlivesmattertoostraat", 420, 9 }
                });

            migrationBuilder.InsertData(
                table: "TradeItems",
                columns: new[] { "Id", "Amount", "CreatedAt", "ModifiedAt", "ResourceId", "Sold", "TradeId", "UserId" },
                values: new object[] { 1, 2, new DateTime(2021, 5, 18, 17, 4, 53, 794, DateTimeKind.Local).AddTicks(7189), new DateTime(2021, 5, 18, 17, 4, 53, 794, DateTimeKind.Local).AddTicks(7189), 51, false, null, 10 });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "UserId", "VAmount" },
                values: new object[,]
                {
                    { 11, new DateTime(2021, 5, 18, 17, 4, 53, 790, DateTimeKind.Local).AddTicks(5055), new DateTime(2021, 5, 18, 17, 4, 53, 790, DateTimeKind.Local).AddTicks(5055), 11, 269m },
                    { 10, new DateTime(2021, 5, 18, 17, 4, 53, 790, DateTimeKind.Local).AddTicks(5051), new DateTime(2021, 5, 18, 17, 4, 53, 790, DateTimeKind.Local).AddTicks(5051), 10, 124m },
                    { 12, new DateTime(2021, 5, 18, 17, 4, 53, 790, DateTimeKind.Local).AddTicks(5057), new DateTime(2021, 5, 18, 17, 4, 53, 790, DateTimeKind.Local).AddTicks(5057), 12, 57m },
                    { 7, new DateTime(2021, 5, 18, 17, 4, 53, 790, DateTimeKind.Local).AddTicks(5042), new DateTime(2021, 5, 18, 17, 4, 53, 790, DateTimeKind.Local).AddTicks(5042), 7, 12m },
                    { 8, new DateTime(2021, 5, 18, 17, 4, 53, 790, DateTimeKind.Local).AddTicks(5045), new DateTime(2021, 5, 18, 17, 4, 53, 790, DateTimeKind.Local).AddTicks(5045), 8, 654m },
                    { 6, new DateTime(2021, 5, 18, 17, 4, 53, 790, DateTimeKind.Local).AddTicks(5039), new DateTime(2021, 5, 18, 17, 4, 53, 790, DateTimeKind.Local).AddTicks(5039), 6, 36m },
                    { 5, new DateTime(2021, 5, 18, 17, 4, 53, 790, DateTimeKind.Local).AddTicks(5036), new DateTime(2021, 5, 18, 17, 4, 53, 790, DateTimeKind.Local).AddTicks(5036), 5, 753m },
                    { 4, new DateTime(2021, 5, 18, 17, 4, 53, 790, DateTimeKind.Local).AddTicks(5032), new DateTime(2021, 5, 18, 17, 4, 53, 790, DateTimeKind.Local).AddTicks(5032), 4, 42m },
                    { 3, new DateTime(2021, 5, 18, 17, 4, 53, 790, DateTimeKind.Local).AddTicks(5029), new DateTime(2021, 5, 18, 17, 4, 53, 790, DateTimeKind.Local).AddTicks(5029), 3, 65m },
                    { 2, new DateTime(2021, 5, 18, 17, 4, 53, 790, DateTimeKind.Local).AddTicks(5011), new DateTime(2021, 5, 18, 17, 4, 53, 790, DateTimeKind.Local).AddTicks(5011), 2, 347m },
                    { 1, new DateTime(2021, 5, 18, 17, 4, 53, 790, DateTimeKind.Local).AddTicks(3684), new DateTime(2021, 5, 18, 17, 4, 53, 790, DateTimeKind.Local).AddTicks(3684), 1, 200m },
                    { 9, new DateTime(2021, 5, 18, 17, 4, 53, 790, DateTimeKind.Local).AddTicks(5048), new DateTime(2021, 5, 18, 17, 4, 53, 790, DateTimeKind.Local).AddTicks(5048), 9, 357m },
                    { 13, new DateTime(2021, 5, 18, 17, 4, 53, 790, DateTimeKind.Local).AddTicks(5060), new DateTime(2021, 5, 18, 17, 4, 53, 790, DateTimeKind.Local).AddTicks(5060), 13, 204m }
                });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "CreatedAt", "EuroAmount", "ModifiedAt", "VAmount", "WalletId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 18, 17, 4, 53, 795, DateTimeKind.Local).AddTicks(8039), 6.9m, new DateTime(2021, 5, 18, 17, 4, 53, 795, DateTimeKind.Local).AddTicks(8039), 69m, 1 },
                    { 2, new DateTime(2021, 5, 18, 17, 4, 53, 796, DateTimeKind.Local).AddTicks(213), 2m, new DateTime(2021, 5, 18, 17, 4, 53, 796, DateTimeKind.Local).AddTicks(213), 20m, 1 },
                    { 9, new DateTime(2021, 5, 18, 17, 4, 53, 796, DateTimeKind.Local).AddTicks(268), 13m, new DateTime(2021, 5, 18, 17, 4, 53, 796, DateTimeKind.Local).AddTicks(268), 130m, 3 },
                    { 10, new DateTime(2021, 5, 18, 17, 4, 53, 796, DateTimeKind.Local).AddTicks(272), 2m, new DateTime(2021, 5, 18, 17, 4, 53, 796, DateTimeKind.Local).AddTicks(272), 20m, 4 },
                    { 3, new DateTime(2021, 5, 18, 17, 4, 53, 796, DateTimeKind.Local).AddTicks(243), 42m, new DateTime(2021, 5, 18, 17, 4, 53, 796, DateTimeKind.Local).AddTicks(243), 420m, 5 },
                    { 4, new DateTime(2021, 5, 18, 17, 4, 53, 796, DateTimeKind.Local).AddTicks(247), 10m, new DateTime(2021, 5, 18, 17, 4, 53, 796, DateTimeKind.Local).AddTicks(247), 100m, 6 },
                    { 8, new DateTime(2021, 5, 18, 17, 4, 53, 796, DateTimeKind.Local).AddTicks(265), 5m, new DateTime(2021, 5, 18, 17, 4, 53, 796, DateTimeKind.Local).AddTicks(265), 50m, 7 },
                    { 7, new DateTime(2021, 5, 18, 17, 4, 53, 796, DateTimeKind.Local).AddTicks(262), 9.8m, new DateTime(2021, 5, 18, 17, 4, 53, 796, DateTimeKind.Local).AddTicks(262), 98m, 9 },
                    { 6, new DateTime(2021, 5, 18, 17, 4, 53, 796, DateTimeKind.Local).AddTicks(259), 7.8m, new DateTime(2021, 5, 18, 17, 4, 53, 796, DateTimeKind.Local).AddTicks(259), 78m, 10 },
                    { 5, new DateTime(2021, 5, 18, 17, 4, 53, 796, DateTimeKind.Local).AddTicks(256), 3.6m, new DateTime(2021, 5, 18, 17, 4, 53, 796, DateTimeKind.Local).AddTicks(256), 36m, 12 }
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
                name: "IX_Trades_ProposerId",
                table: "Trades",
                column: "ProposerId");

            migrationBuilder.CreateIndex(
                name: "IX_Trades_ReceiverId",
                table: "Trades",
                column: "ReceiverId");

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