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
                    table.ForeignKey(
                        name: "FK_Trades_Users_ProposerId",
                        column: x => x.ProposerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trades_Users_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    TradeId = table.Column<int>(type: "int", nullable: true),
                    Sold = table.Column<bool>(type: "bit", nullable: false),
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
                    { 1, new DateTime(2021, 5, 18, 20, 8, 23, 927, DateTimeKind.Local).AddTicks(9229), "apples.svg", new DateTime(2021, 5, 18, 20, 8, 23, 927, DateTimeKind.Local).AddTicks(9229), "apples" },
                    { 29, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(623), "olives.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(623), "olives" },
                    { 30, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(626), "oranges.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(626), "oranges" },
                    { 31, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(629), "papayas.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(629), "papayas" },
                    { 33, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(635), "pears.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(635), "pears" },
                    { 34, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(638), "peas.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(638), "peas" },
                    { 35, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(641), "pineapples.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(641), "pineapples" },
                    { 36, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(644), "pomegranates.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(644), "pomegranates" },
                    { 37, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(646), "potatoes.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(646), "potatoes" },
                    { 38, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(649), "pumpkins.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(649), "pumpkins" },
                    { 39, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(652), "radish.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(652), "radish" },
                    { 28, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(549), "mushrooms.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(549), "mushrooms" },
                    { 40, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(655), "radishes.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(655), "radishes" },
                    { 42, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(661), "salad.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(661), "salad" },
                    { 43, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(664), "salads.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(664), "salads" },
                    { 44, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(667), "scallions.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(667), "scallions" },
                    { 45, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(669), "spinach.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(669), "spinach" },
                    { 46, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(672), "star-fruits.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(672), "star-fruits" },
                    { 47, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(675), "strawberries.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(675), "strawberries" },
                    { 48, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(678), "sweet-potatoes.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(678), "sweet-potatoes" },
                    { 49, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(681), "tomatoes.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(681), "tomatoes" },
                    { 50, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(683), "watermelons.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(683), "watermelons" },
                    { 51, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(686), "v-coin.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(686), "v-coin" },
                    { 41, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(658), "raspberries.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(658), "raspberries" },
                    { 27, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(546), "melons.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(546), "melons" },
                    { 32, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(632), "peaches.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(632), "peaches" },
                    { 25, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(540), "mangos.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(540), "mangos" },
                    { 2, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(454), "artichokes.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(454), "artichokes" },
                    { 3, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(469), "asparaguses.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(469), "asparaguses" },
                    { 4, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(473), "bananas.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(473), "bananas" },
                    { 5, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(476), "bell-peppers.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(476), "bell-peppers" },
                    { 6, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(479), "blueberries.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(479), "blueberries" },
                    { 7, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(482), "bok-choy.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(482), "bok-choy" },
                    { 26, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(542), "mangosteens.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(542), "mangosteens" },
                    { 9, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(489), "brussels-sprouts.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(489), "brussels-sprouts" },
                    { 10, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(492), "carrots.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(492), "carrots" },
                    { 11, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(495), "cherries.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(495), "cherries" },
                    { 12, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(498), "chilis.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(498), "chilis" },
                    { 13, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(502), "coconuts.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(502), "coconuts" },
                    { 8, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(486), "broccoli.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(486), "broccoli" },
                    { 15, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(508), "corn.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(508), "corn" },
                    { 16, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(511), "cucumbers.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(511), "cucumbers" }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreatedAt", "ImageUrl", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 17, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(514), "dragon-fruits.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(514), "dragon-fruits" },
                    { 18, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(517), "durians.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(517), "durians" },
                    { 19, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(520), "eggplants.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(520), "eggplants" },
                    { 20, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(523), "garlic.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(523), "garlic" },
                    { 21, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(526), "grapes.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(526), "grapes" },
                    { 22, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(529), "guavas.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(529), "guavas" },
                    { 23, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(533), "kiwis.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(533), "kiwis" },
                    { 24, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(536), "lemons.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(536), "lemons" },
                    { 14, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(504), "coriander.svg", new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(504), "coriander" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "ImageUrl", "IsAdmin", "LastName", "ModifiedAt", "PasswordHash", "PasswordSalt" },
                values: new object[,]
                {
                    { 11, new DateTime(2021, 5, 18, 20, 8, 23, 922, DateTimeKind.Local).AddTicks(8552), "VerhofstadDeZeemlap@europeesemailadres.com", "Verhofstad", "https://robohash.org/Zeemlap", false, "Zeemlap", new DateTime(2021, 5, 18, 20, 8, 23, 922, DateTimeKind.Local).AddTicks(8552), new byte[] { 31, 148, 213, 107, 247, 60, 230, 64, 118, 149, 9, 31, 201, 181, 149, 62, 20, 29, 237, 30, 209, 214, 215, 106, 136, 255, 93, 228, 229, 31, 242, 144, 1, 103, 32, 229, 178, 102, 20, 136, 76, 6, 152, 167, 88, 5, 90, 38, 118, 214, 92, 10, 244, 180, 26, 229, 64, 215, 127, 193, 180, 62, 221, 17 }, new byte[] { 94, 188, 112, 201, 220, 80, 215, 18, 115, 227, 178, 233, 1, 81, 154, 126, 248, 237, 247, 227, 37, 208, 232, 203, 171, 123, 169, 241, 94, 38, 115, 127, 20, 13, 167, 209, 92, 86, 129, 119, 166, 9, 247, 48, 57, 244, 208, 38, 255, 76, 27, 201, 84, 35, 185, 81, 11, 66, 29, 138, 29, 214, 212, 2, 203, 69, 255, 67, 126, 215, 241, 85, 90, 127, 95, 125, 138, 20, 50, 162, 243, 179, 124, 172, 90, 107, 3, 124, 219, 6, 45, 46, 30, 0, 71, 21, 93, 171, 255, 56, 20, 162, 56, 145, 54, 34, 93, 42, 118, 36, 195, 147, 201, 199, 161, 111, 188, 105, 169, 171, 48, 184, 202, 119, 55, 66, 171, 250 } },
                    { 10, new DateTime(2021, 5, 18, 20, 8, 23, 922, DateTimeKind.Local).AddTicks(8537), "Luc@mail.com", "Luc", "https://robohash.org/Luc", false, "DeHaantje", new DateTime(2021, 5, 18, 20, 8, 23, 922, DateTimeKind.Local).AddTicks(8537), new byte[] { 31, 148, 213, 107, 247, 60, 230, 64, 118, 149, 9, 31, 201, 181, 149, 62, 20, 29, 237, 30, 209, 214, 215, 106, 136, 255, 93, 228, 229, 31, 242, 144, 1, 103, 32, 229, 178, 102, 20, 136, 76, 6, 152, 167, 88, 5, 90, 38, 118, 214, 92, 10, 244, 180, 26, 229, 64, 215, 127, 193, 180, 62, 221, 17 }, new byte[] { 94, 188, 112, 201, 220, 80, 215, 18, 115, 227, 178, 233, 1, 81, 154, 126, 248, 237, 247, 227, 37, 208, 232, 203, 171, 123, 169, 241, 94, 38, 115, 127, 20, 13, 167, 209, 92, 86, 129, 119, 166, 9, 247, 48, 57, 244, 208, 38, 255, 76, 27, 201, 84, 35, 185, 81, 11, 66, 29, 138, 29, 214, 212, 2, 203, 69, 255, 67, 126, 215, 241, 85, 90, 127, 95, 125, 138, 20, 50, 162, 243, 179, 124, 172, 90, 107, 3, 124, 219, 6, 45, 46, 30, 0, 71, 21, 93, 171, 255, 56, 20, 162, 56, 145, 54, 34, 93, 42, 118, 36, 195, 147, 201, 199, 161, 111, 188, 105, 169, 171, 48, 184, 202, 119, 55, 66, 171, 250 } },
                    { 9, new DateTime(2021, 5, 18, 20, 8, 23, 922, DateTimeKind.Local).AddTicks(8521), "Mihiel@mail.com", "Mihiel", "https://robohash.org/Mihiel", false, "Mihoen", new DateTime(2021, 5, 18, 20, 8, 23, 922, DateTimeKind.Local).AddTicks(8521), new byte[] { 31, 148, 213, 107, 247, 60, 230, 64, 118, 149, 9, 31, 201, 181, 149, 62, 20, 29, 237, 30, 209, 214, 215, 106, 136, 255, 93, 228, 229, 31, 242, 144, 1, 103, 32, 229, 178, 102, 20, 136, 76, 6, 152, 167, 88, 5, 90, 38, 118, 214, 92, 10, 244, 180, 26, 229, 64, 215, 127, 193, 180, 62, 221, 17 }, new byte[] { 94, 188, 112, 201, 220, 80, 215, 18, 115, 227, 178, 233, 1, 81, 154, 126, 248, 237, 247, 227, 37, 208, 232, 203, 171, 123, 169, 241, 94, 38, 115, 127, 20, 13, 167, 209, 92, 86, 129, 119, 166, 9, 247, 48, 57, 244, 208, 38, 255, 76, 27, 201, 84, 35, 185, 81, 11, 66, 29, 138, 29, 214, 212, 2, 203, 69, 255, 67, 126, 215, 241, 85, 90, 127, 95, 125, 138, 20, 50, 162, 243, 179, 124, 172, 90, 107, 3, 124, 219, 6, 45, 46, 30, 0, 71, 21, 93, 171, 255, 56, 20, 162, 56, 145, 54, 34, 93, 42, 118, 36, 195, 147, 201, 199, 161, 111, 188, 105, 169, 171, 48, 184, 202, 119, 55, 66, 171, 250 } },
                    { 8, new DateTime(2021, 5, 18, 20, 8, 23, 922, DateTimeKind.Local).AddTicks(8505), "Andreas@mail.com", "Andreas", "https://robohash.org/Andreas", false, "VanGrieken", new DateTime(2021, 5, 18, 20, 8, 23, 922, DateTimeKind.Local).AddTicks(8505), new byte[] { 31, 148, 213, 107, 247, 60, 230, 64, 118, 149, 9, 31, 201, 181, 149, 62, 20, 29, 237, 30, 209, 214, 215, 106, 136, 255, 93, 228, 229, 31, 242, 144, 1, 103, 32, 229, 178, 102, 20, 136, 76, 6, 152, 167, 88, 5, 90, 38, 118, 214, 92, 10, 244, 180, 26, 229, 64, 215, 127, 193, 180, 62, 221, 17 }, new byte[] { 94, 188, 112, 201, 220, 80, 215, 18, 115, 227, 178, 233, 1, 81, 154, 126, 248, 237, 247, 227, 37, 208, 232, 203, 171, 123, 169, 241, 94, 38, 115, 127, 20, 13, 167, 209, 92, 86, 129, 119, 166, 9, 247, 48, 57, 244, 208, 38, 255, 76, 27, 201, 84, 35, 185, 81, 11, 66, 29, 138, 29, 214, 212, 2, 203, 69, 255, 67, 126, 215, 241, 85, 90, 127, 95, 125, 138, 20, 50, 162, 243, 179, 124, 172, 90, 107, 3, 124, 219, 6, 45, 46, 30, 0, 71, 21, 93, 171, 255, 56, 20, 162, 56, 145, 54, 34, 93, 42, 118, 36, 195, 147, 201, 199, 161, 111, 188, 105, 169, 171, 48, 184, 202, 119, 55, 66, 171, 250 } },
                    { 7, new DateTime(2021, 5, 18, 20, 8, 23, 922, DateTimeKind.Local).AddTicks(8485), "Dirk@mail.com", "Dirk", "https://robohash.org/Dirk", false, "Visser", new DateTime(2021, 5, 18, 20, 8, 23, 922, DateTimeKind.Local).AddTicks(8485), new byte[] { 31, 148, 213, 107, 247, 60, 230, 64, 118, 149, 9, 31, 201, 181, 149, 62, 20, 29, 237, 30, 209, 214, 215, 106, 136, 255, 93, 228, 229, 31, 242, 144, 1, 103, 32, 229, 178, 102, 20, 136, 76, 6, 152, 167, 88, 5, 90, 38, 118, 214, 92, 10, 244, 180, 26, 229, 64, 215, 127, 193, 180, 62, 221, 17 }, new byte[] { 94, 188, 112, 201, 220, 80, 215, 18, 115, 227, 178, 233, 1, 81, 154, 126, 248, 237, 247, 227, 37, 208, 232, 203, 171, 123, 169, 241, 94, 38, 115, 127, 20, 13, 167, 209, 92, 86, 129, 119, 166, 9, 247, 48, 57, 244, 208, 38, 255, 76, 27, 201, 84, 35, 185, 81, 11, 66, 29, 138, 29, 214, 212, 2, 203, 69, 255, 67, 126, 215, 241, 85, 90, 127, 95, 125, 138, 20, 50, 162, 243, 179, 124, 172, 90, 107, 3, 124, 219, 6, 45, 46, 30, 0, 71, 21, 93, 171, 255, 56, 20, 162, 56, 145, 54, 34, 93, 42, 118, 36, 195, 147, 201, 199, 161, 111, 188, 105, 169, 171, 48, 184, 202, 119, 55, 66, 171, 250 } },
                    { 1, new DateTime(2021, 5, 18, 20, 8, 23, 918, DateTimeKind.Local).AddTicks(1202), "Pieter@mail.com", "Pieter", "https://robohash.org/Pieter", true, "Corp", new DateTime(2021, 5, 18, 20, 8, 23, 918, DateTimeKind.Local).AddTicks(1202), new byte[] { 31, 148, 213, 107, 247, 60, 230, 64, 118, 149, 9, 31, 201, 181, 149, 62, 20, 29, 237, 30, 209, 214, 215, 106, 136, 255, 93, 228, 229, 31, 242, 144, 1, 103, 32, 229, 178, 102, 20, 136, 76, 6, 152, 167, 88, 5, 90, 38, 118, 214, 92, 10, 244, 180, 26, 229, 64, 215, 127, 193, 180, 62, 221, 17 }, new byte[] { 94, 188, 112, 201, 220, 80, 215, 18, 115, 227, 178, 233, 1, 81, 154, 126, 248, 237, 247, 227, 37, 208, 232, 203, 171, 123, 169, 241, 94, 38, 115, 127, 20, 13, 167, 209, 92, 86, 129, 119, 166, 9, 247, 48, 57, 244, 208, 38, 255, 76, 27, 201, 84, 35, 185, 81, 11, 66, 29, 138, 29, 214, 212, 2, 203, 69, 255, 67, 126, 215, 241, 85, 90, 127, 95, 125, 138, 20, 50, 162, 243, 179, 124, 172, 90, 107, 3, 124, 219, 6, 45, 46, 30, 0, 71, 21, 93, 171, 255, 56, 20, 162, 56, 145, 54, 34, 93, 42, 118, 36, 195, 147, 201, 199, 161, 111, 188, 105, 169, 171, 48, 184, 202, 119, 55, 66, 171, 250 } },
                    { 5, new DateTime(2021, 5, 18, 20, 8, 23, 922, DateTimeKind.Local).AddTicks(8289), "BartjeWevertje@mail.com", "BartjeWevertje", "https://robohash.org/BartjeWevertje", false, "Wevertje", new DateTime(2021, 5, 18, 20, 8, 23, 922, DateTimeKind.Local).AddTicks(8289), new byte[] { 31, 148, 213, 107, 247, 60, 230, 64, 118, 149, 9, 31, 201, 181, 149, 62, 20, 29, 237, 30, 209, 214, 215, 106, 136, 255, 93, 228, 229, 31, 242, 144, 1, 103, 32, 229, 178, 102, 20, 136, 76, 6, 152, 167, 88, 5, 90, 38, 118, 214, 92, 10, 244, 180, 26, 229, 64, 215, 127, 193, 180, 62, 221, 17 }, new byte[] { 94, 188, 112, 201, 220, 80, 215, 18, 115, 227, 178, 233, 1, 81, 154, 126, 248, 237, 247, 227, 37, 208, 232, 203, 171, 123, 169, 241, 94, 38, 115, 127, 20, 13, 167, 209, 92, 86, 129, 119, 166, 9, 247, 48, 57, 244, 208, 38, 255, 76, 27, 201, 84, 35, 185, 81, 11, 66, 29, 138, 29, 214, 212, 2, 203, 69, 255, 67, 126, 215, 241, 85, 90, 127, 95, 125, 138, 20, 50, 162, 243, 179, 124, 172, 90, 107, 3, 124, 219, 6, 45, 46, 30, 0, 71, 21, 93, 171, 255, 56, 20, 162, 56, 145, 54, 34, 93, 42, 118, 36, 195, 147, 201, 199, 161, 111, 188, 105, 169, 171, 48, 184, 202, 119, 55, 66, 171, 250 } },
                    { 4, new DateTime(2021, 5, 18, 20, 8, 23, 922, DateTimeKind.Local).AddTicks(8272), "Dries@mail.com", "Dries", "https://robohash.org/Dries", true, "Maes", new DateTime(2021, 5, 18, 20, 8, 23, 922, DateTimeKind.Local).AddTicks(8272), new byte[] { 31, 148, 213, 107, 247, 60, 230, 64, 118, 149, 9, 31, 201, 181, 149, 62, 20, 29, 237, 30, 209, 214, 215, 106, 136, 255, 93, 228, 229, 31, 242, 144, 1, 103, 32, 229, 178, 102, 20, 136, 76, 6, 152, 167, 88, 5, 90, 38, 118, 214, 92, 10, 244, 180, 26, 229, 64, 215, 127, 193, 180, 62, 221, 17 }, new byte[] { 94, 188, 112, 201, 220, 80, 215, 18, 115, 227, 178, 233, 1, 81, 154, 126, 248, 237, 247, 227, 37, 208, 232, 203, 171, 123, 169, 241, 94, 38, 115, 127, 20, 13, 167, 209, 92, 86, 129, 119, 166, 9, 247, 48, 57, 244, 208, 38, 255, 76, 27, 201, 84, 35, 185, 81, 11, 66, 29, 138, 29, 214, 212, 2, 203, 69, 255, 67, 126, 215, 241, 85, 90, 127, 95, 125, 138, 20, 50, 162, 243, 179, 124, 172, 90, 107, 3, 124, 219, 6, 45, 46, 30, 0, 71, 21, 93, 171, 255, 56, 20, 162, 56, 145, 54, 34, 93, 42, 118, 36, 195, 147, 201, 199, 161, 111, 188, 105, 169, 171, 48, 184, 202, 119, 55, 66, 171, 250 } },
                    { 3, new DateTime(2021, 5, 18, 20, 8, 23, 922, DateTimeKind.Local).AddTicks(8243), "Kobe@mail.com", "Kobe", "https://robohash.org/Kobe", true, "Delo", new DateTime(2021, 5, 18, 20, 8, 23, 922, DateTimeKind.Local).AddTicks(8243), new byte[] { 31, 148, 213, 107, 247, 60, 230, 64, 118, 149, 9, 31, 201, 181, 149, 62, 20, 29, 237, 30, 209, 214, 215, 106, 136, 255, 93, 228, 229, 31, 242, 144, 1, 103, 32, 229, 178, 102, 20, 136, 76, 6, 152, 167, 88, 5, 90, 38, 118, 214, 92, 10, 244, 180, 26, 229, 64, 215, 127, 193, 180, 62, 221, 17 }, new byte[] { 94, 188, 112, 201, 220, 80, 215, 18, 115, 227, 178, 233, 1, 81, 154, 126, 248, 237, 247, 227, 37, 208, 232, 203, 171, 123, 169, 241, 94, 38, 115, 127, 20, 13, 167, 209, 92, 86, 129, 119, 166, 9, 247, 48, 57, 244, 208, 38, 255, 76, 27, 201, 84, 35, 185, 81, 11, 66, 29, 138, 29, 214, 212, 2, 203, 69, 255, 67, 126, 215, 241, 85, 90, 127, 95, 125, 138, 20, 50, 162, 243, 179, 124, 172, 90, 107, 3, 124, 219, 6, 45, 46, 30, 0, 71, 21, 93, 171, 255, 56, 20, 162, 56, 145, 54, 34, 93, 42, 118, 36, 195, 147, 201, 199, 161, 111, 188, 105, 169, 171, 48, 184, 202, 119, 55, 66, 171, 250 } },
                    { 2, new DateTime(2021, 5, 18, 20, 8, 23, 922, DateTimeKind.Local).AddTicks(8024), "Nick@mail.com", "Nick", "https://robohash.org/Nick", true, "Vr", new DateTime(2021, 5, 18, 20, 8, 23, 922, DateTimeKind.Local).AddTicks(8024), new byte[] { 31, 148, 213, 107, 247, 60, 230, 64, 118, 149, 9, 31, 201, 181, 149, 62, 20, 29, 237, 30, 209, 214, 215, 106, 136, 255, 93, 228, 229, 31, 242, 144, 1, 103, 32, 229, 178, 102, 20, 136, 76, 6, 152, 167, 88, 5, 90, 38, 118, 214, 92, 10, 244, 180, 26, 229, 64, 215, 127, 193, 180, 62, 221, 17 }, new byte[] { 94, 188, 112, 201, 220, 80, 215, 18, 115, 227, 178, 233, 1, 81, 154, 126, 248, 237, 247, 227, 37, 208, 232, 203, 171, 123, 169, 241, 94, 38, 115, 127, 20, 13, 167, 209, 92, 86, 129, 119, 166, 9, 247, 48, 57, 244, 208, 38, 255, 76, 27, 201, 84, 35, 185, 81, 11, 66, 29, 138, 29, 214, 212, 2, 203, 69, 255, 67, 126, 215, 241, 85, 90, 127, 95, 125, 138, 20, 50, 162, 243, 179, 124, 172, 90, 107, 3, 124, 219, 6, 45, 46, 30, 0, 71, 21, 93, 171, 255, 56, 20, 162, 56, 145, 54, 34, 93, 42, 118, 36, 195, 147, 201, 199, 161, 111, 188, 105, 169, 171, 48, 184, 202, 119, 55, 66, 171, 250 } },
                    { 12, new DateTime(2021, 5, 18, 20, 8, 23, 922, DateTimeKind.Local).AddTicks(8568), "Driesdentweedenmaarnidezelfden@mail.com", "Dries", "https://robohash.org/Dries2", false, "VanKorteNekke", new DateTime(2021, 5, 18, 20, 8, 23, 922, DateTimeKind.Local).AddTicks(8568), new byte[] { 31, 148, 213, 107, 247, 60, 230, 64, 118, 149, 9, 31, 201, 181, 149, 62, 20, 29, 237, 30, 209, 214, 215, 106, 136, 255, 93, 228, 229, 31, 242, 144, 1, 103, 32, 229, 178, 102, 20, 136, 76, 6, 152, 167, 88, 5, 90, 38, 118, 214, 92, 10, 244, 180, 26, 229, 64, 215, 127, 193, 180, 62, 221, 17 }, new byte[] { 94, 188, 112, 201, 220, 80, 215, 18, 115, 227, 178, 233, 1, 81, 154, 126, 248, 237, 247, 227, 37, 208, 232, 203, 171, 123, 169, 241, 94, 38, 115, 127, 20, 13, 167, 209, 92, 86, 129, 119, 166, 9, 247, 48, 57, 244, 208, 38, 255, 76, 27, 201, 84, 35, 185, 81, 11, 66, 29, 138, 29, 214, 212, 2, 203, 69, 255, 67, 126, 215, 241, 85, 90, 127, 95, 125, 138, 20, 50, 162, 243, 179, 124, 172, 90, 107, 3, 124, 219, 6, 45, 46, 30, 0, 71, 21, 93, 171, 255, 56, 20, 162, 56, 145, 54, 34, 93, 42, 118, 36, 195, 147, 201, 199, 161, 111, 188, 105, 169, 171, 48, 184, 202, 119, 55, 66, 171, 250 } },
                    { 6, new DateTime(2021, 5, 18, 20, 8, 23, 922, DateTimeKind.Local).AddTicks(8306), "Stofzuiger@mail.com", "Stofzuiger", "https://robohash.org/Stofzuiger", false, "Zuiger", new DateTime(2021, 5, 18, 20, 8, 23, 922, DateTimeKind.Local).AddTicks(8306), new byte[] { 31, 148, 213, 107, 247, 60, 230, 64, 118, 149, 9, 31, 201, 181, 149, 62, 20, 29, 237, 30, 209, 214, 215, 106, 136, 255, 93, 228, 229, 31, 242, 144, 1, 103, 32, 229, 178, 102, 20, 136, 76, 6, 152, 167, 88, 5, 90, 38, 118, 214, 92, 10, 244, 180, 26, 229, 64, 215, 127, 193, 180, 62, 221, 17 }, new byte[] { 94, 188, 112, 201, 220, 80, 215, 18, 115, 227, 178, 233, 1, 81, 154, 126, 248, 237, 247, 227, 37, 208, 232, 203, 171, 123, 169, 241, 94, 38, 115, 127, 20, 13, 167, 209, 92, 86, 129, 119, 166, 9, 247, 48, 57, 244, 208, 38, 255, 76, 27, 201, 84, 35, 185, 81, 11, 66, 29, 138, 29, 214, 212, 2, 203, 69, 255, 67, 126, 215, 241, 85, 90, 127, 95, 125, 138, 20, 50, 162, 243, 179, 124, 172, 90, 107, 3, 124, 219, 6, 45, 46, 30, 0, 71, 21, 93, 171, 255, 56, 20, 162, 56, 145, 54, 34, 93, 42, 118, 36, 195, 147, 201, 199, 161, 111, 188, 105, 169, 171, 48, 184, 202, 119, 55, 66, 171, 250 } },
                    { 13, new DateTime(2021, 5, 18, 20, 8, 23, 922, DateTimeKind.Local).AddTicks(8584), "Joyce@mail.com", "Joyce", "https://robohash.org/Tomatenplukker", false, "Tomatenplukker", new DateTime(2021, 5, 18, 20, 8, 23, 922, DateTimeKind.Local).AddTicks(8584), new byte[] { 31, 148, 213, 107, 247, 60, 230, 64, 118, 149, 9, 31, 201, 181, 149, 62, 20, 29, 237, 30, 209, 214, 215, 106, 136, 255, 93, 228, 229, 31, 242, 144, 1, 103, 32, 229, 178, 102, 20, 136, 76, 6, 152, 167, 88, 5, 90, 38, 118, 214, 92, 10, 244, 180, 26, 229, 64, 215, 127, 193, 180, 62, 221, 17 }, new byte[] { 94, 188, 112, 201, 220, 80, 215, 18, 115, 227, 178, 233, 1, 81, 154, 126, 248, 237, 247, 227, 37, 208, 232, 203, 171, 123, 169, 241, 94, 38, 115, 127, 20, 13, 167, 209, 92, 86, 129, 119, 166, 9, 247, 48, 57, 244, 208, 38, 255, 76, 27, 201, 84, 35, 185, 81, 11, 66, 29, 138, 29, 214, 212, 2, 203, 69, 255, 67, 126, 215, 241, 85, 90, 127, 95, 125, 138, 20, 50, 162, 243, 179, 124, 172, 90, 107, 3, 124, 219, 6, 45, 46, 30, 0, 71, 21, 93, 171, 255, 56, 20, 162, 56, 145, 54, 34, 93, 42, 118, 36, 195, 147, 201, 199, 161, 111, 188, 105, 169, 171, 48, 184, 202, 119, 55, 66, 171, 250 } }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "PostalCode", "StreetName", "StreetNumber", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 18, 20, 8, 23, 924, DateTimeKind.Local).AddTicks(9337), new DateTime(2021, 5, 18, 20, 8, 23, 924, DateTimeKind.Local).AddTicks(9337), 9000, "Anti-Veggiestraat", 89, 1 },
                    { 7, new DateTime(2021, 5, 18, 20, 8, 23, 925, DateTimeKind.Local).AddTicks(2204), new DateTime(2021, 5, 18, 20, 8, 23, 925, DateTimeKind.Local).AddTicks(2204), 9050, "Greenpeacestraat", 1, 7 },
                    { 2, new DateTime(2021, 5, 18, 20, 8, 23, 925, DateTimeKind.Local).AddTicks(2171), new DateTime(2021, 5, 18, 20, 8, 23, 925, DateTimeKind.Local).AddTicks(2171), 9000, "Pieterstreaat", 45, 2 },
                    { 13, new DateTime(2021, 5, 18, 20, 8, 23, 925, DateTimeKind.Local).AddTicks(2224), new DateTime(2021, 5, 18, 20, 8, 23, 925, DateTimeKind.Local).AddTicks(2224), 9020, "Worstenbroodjesstraat", 4, 13 },
                    { 3, new DateTime(2021, 5, 18, 20, 8, 23, 925, DateTimeKind.Local).AddTicks(2190), new DateTime(2021, 5, 18, 20, 8, 23, 925, DateTimeKind.Local).AddTicks(2190), 9000, "Nickstraat", 74, 3 },
                    { 12, new DateTime(2021, 5, 18, 20, 8, 23, 925, DateTimeKind.Local).AddTicks(2221), new DateTime(2021, 5, 18, 20, 8, 23, 925, DateTimeKind.Local).AddTicks(2221), 1000, "Blacklivesmatterstraat", 78, 12 },
                    { 11, new DateTime(2021, 5, 18, 20, 8, 23, 925, DateTimeKind.Local).AddTicks(2218), new DateTime(2021, 5, 18, 20, 8, 23, 925, DateTimeKind.Local).AddTicks(2218), 9500, "Kalfslapjesstraat", 32, 11 },
                    { 4, new DateTime(2021, 5, 18, 20, 8, 23, 925, DateTimeKind.Local).AddTicks(2194), new DateTime(2021, 5, 18, 20, 8, 23, 925, DateTimeKind.Local).AddTicks(2194), 1000, "Driesstraat", 66, 4 },
                    { 9, new DateTime(2021, 5, 18, 20, 8, 23, 925, DateTimeKind.Local).AddTicks(2212), new DateTime(2021, 5, 18, 20, 8, 23, 925, DateTimeKind.Local).AddTicks(2212), 2000, "Greenlivesmattertoostraat", 420, 9 },
                    { 8, new DateTime(2021, 5, 18, 20, 8, 23, 925, DateTimeKind.Local).AddTicks(2208), new DateTime(2021, 5, 18, 20, 8, 23, 925, DateTimeKind.Local).AddTicks(2208), 1000, "Kotsvisstraat", 96, 8 },
                    { 5, new DateTime(2021, 5, 18, 20, 8, 23, 925, DateTimeKind.Local).AddTicks(2198), new DateTime(2021, 5, 18, 20, 8, 23, 925, DateTimeKind.Local).AddTicks(2198), 2000, "Kobestraat", 85, 5 },
                    { 10, new DateTime(2021, 5, 18, 20, 8, 23, 925, DateTimeKind.Local).AddTicks(2215), new DateTime(2021, 5, 18, 20, 8, 23, 925, DateTimeKind.Local).AddTicks(2215), 9070, "Geenpolitiekinhetprojectstraat", 200, 10 },
                    { 6, new DateTime(2021, 5, 18, 20, 8, 23, 925, DateTimeKind.Local).AddTicks(2201), new DateTime(2021, 5, 18, 20, 8, 23, 925, DateTimeKind.Local).AddTicks(2201), 1000, "Lookbroodjesstraat", 43, 6 }
                });

            migrationBuilder.InsertData(
                table: "TradeItems",
                columns: new[] { "Id", "Amount", "CreatedAt", "ModifiedAt", "ResourceId", "Sold", "TradeId", "UserId" },
                values: new object[,]
                {
                    { 2, 10, new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(4365), new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(4365), 11, false, null, 8 },
                    { 8, 75, new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5084), new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5084), 8, false, null, 8 },
                    { 9, 201, new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5087), new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5087), 9, false, null, 9 },
                    { 1, 2, new DateTime(2021, 5, 18, 20, 8, 23, 929, DateTimeKind.Local).AddTicks(9772), new DateTime(2021, 5, 18, 20, 8, 23, 929, DateTimeKind.Local).AddTicks(9772), 51, false, null, 10 },
                    { 22, 69, new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5138), new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5138), 27, false, null, 9 },
                    { 13, 69, new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5099), new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5099), 19, false, null, 10 },
                    { 11, 20, new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5093), new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5093), 17, false, null, 11 },
                    { 19, 17, new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5124), new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5124), 7, false, null, 12 },
                    { 3, 50, new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(4395), new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(4395), 32, false, null, 13 },
                    { 10, 634, new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5090), new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5090), 10, false, null, 9 },
                    { 12, 75, new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5096), new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5096), 26, false, null, 13 },
                    { 26, 10, new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5153), new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5153), 39, false, null, 7 },
                    { 7, 42, new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5081), new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5081), 17, false, null, 7 },
                    { 25, 20, new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5148), new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5148), 48, false, null, 6 },
                    { 21, 78, new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5133), new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5133), 23, false, null, 6 },
                    { 6, 30, new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5077), new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5077), 6, false, null, 6 },
                    { 20, 30, new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5128), new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5128), 36, false, null, 7 }
                });

            migrationBuilder.InsertData(
                table: "Trades",
                columns: new[] { "Id", "Completed", "CreatedAt", "ModifiedAt", "ProposerId", "ReceiverId" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(5811), new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(5811), 2, 1 },
                    { 5, false, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(8029), new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(8029), 1, 5 },
                    { 4, false, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(8026), new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(8026), 5, 2 },
                    { 3, false, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(8022), new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(8022), 4, 2 },
                    { 2, false, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(8008), new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(8008), 3, 1 },
                    { 6, false, new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(8033), new DateTime(2021, 5, 18, 20, 8, 23, 928, DateTimeKind.Local).AddTicks(8033), 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "UserId", "VAmount" },
                values: new object[,]
                {
                    { 7, new DateTime(2021, 5, 18, 20, 8, 23, 926, DateTimeKind.Local).AddTicks(1514), new DateTime(2021, 5, 18, 20, 8, 23, 926, DateTimeKind.Local).AddTicks(1514), 7, 12m },
                    { 1, new DateTime(2021, 5, 18, 20, 8, 23, 925, DateTimeKind.Local).AddTicks(9410), new DateTime(2021, 5, 18, 20, 8, 23, 925, DateTimeKind.Local).AddTicks(9410), 1, 200m },
                    { 12, new DateTime(2021, 5, 18, 20, 8, 23, 926, DateTimeKind.Local).AddTicks(1530), new DateTime(2021, 5, 18, 20, 8, 23, 926, DateTimeKind.Local).AddTicks(1530), 12, 57m },
                    { 2, new DateTime(2021, 5, 18, 20, 8, 23, 926, DateTimeKind.Local).AddTicks(1249), new DateTime(2021, 5, 18, 20, 8, 23, 926, DateTimeKind.Local).AddTicks(1249), 2, 347m },
                    { 11, new DateTime(2021, 5, 18, 20, 8, 23, 926, DateTimeKind.Local).AddTicks(1526), new DateTime(2021, 5, 18, 20, 8, 23, 926, DateTimeKind.Local).AddTicks(1526), 11, 269m },
                    { 4, new DateTime(2021, 5, 18, 20, 8, 23, 926, DateTimeKind.Local).AddTicks(1400), new DateTime(2021, 5, 18, 20, 8, 23, 926, DateTimeKind.Local).AddTicks(1400), 4, 42m }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "UserId", "VAmount" },
                values: new object[,]
                {
                    { 10, new DateTime(2021, 5, 18, 20, 8, 23, 926, DateTimeKind.Local).AddTicks(1523), new DateTime(2021, 5, 18, 20, 8, 23, 926, DateTimeKind.Local).AddTicks(1523), 10, 124m },
                    { 9, new DateTime(2021, 5, 18, 20, 8, 23, 926, DateTimeKind.Local).AddTicks(1520), new DateTime(2021, 5, 18, 20, 8, 23, 926, DateTimeKind.Local).AddTicks(1520), 9, 357m },
                    { 5, new DateTime(2021, 5, 18, 20, 8, 23, 926, DateTimeKind.Local).AddTicks(1404), new DateTime(2021, 5, 18, 20, 8, 23, 926, DateTimeKind.Local).AddTicks(1404), 5, 753m },
                    { 8, new DateTime(2021, 5, 18, 20, 8, 23, 926, DateTimeKind.Local).AddTicks(1517), new DateTime(2021, 5, 18, 20, 8, 23, 926, DateTimeKind.Local).AddTicks(1517), 8, 654m },
                    { 6, new DateTime(2021, 5, 18, 20, 8, 23, 926, DateTimeKind.Local).AddTicks(1510), new DateTime(2021, 5, 18, 20, 8, 23, 926, DateTimeKind.Local).AddTicks(1510), 6, 36m },
                    { 3, new DateTime(2021, 5, 18, 20, 8, 23, 926, DateTimeKind.Local).AddTicks(1396), new DateTime(2021, 5, 18, 20, 8, 23, 926, DateTimeKind.Local).AddTicks(1396), 3, 65m },
                    { 13, new DateTime(2021, 5, 18, 20, 8, 23, 926, DateTimeKind.Local).AddTicks(1533), new DateTime(2021, 5, 18, 20, 8, 23, 926, DateTimeKind.Local).AddTicks(1533), 13, 204m }
                });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "CreatedAt", "EuroAmount", "ModifiedAt", "VAmount", "WalletId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 18, 20, 8, 23, 931, DateTimeKind.Local).AddTicks(6809), 6.9m, new DateTime(2021, 5, 18, 20, 8, 23, 931, DateTimeKind.Local).AddTicks(6809), 69m, 1 },
                    { 7, new DateTime(2021, 5, 18, 20, 8, 23, 931, DateTimeKind.Local).AddTicks(9932), 9.8m, new DateTime(2021, 5, 18, 20, 8, 23, 931, DateTimeKind.Local).AddTicks(9932), 98m, 9 },
                    { 8, new DateTime(2021, 5, 18, 20, 8, 23, 931, DateTimeKind.Local).AddTicks(9935), 5m, new DateTime(2021, 5, 18, 20, 8, 23, 931, DateTimeKind.Local).AddTicks(9935), 50m, 7 },
                    { 4, new DateTime(2021, 5, 18, 20, 8, 23, 931, DateTimeKind.Local).AddTicks(9689), 10m, new DateTime(2021, 5, 18, 20, 8, 23, 931, DateTimeKind.Local).AddTicks(9689), 100m, 6 },
                    { 3, new DateTime(2021, 5, 18, 20, 8, 23, 931, DateTimeKind.Local).AddTicks(9685), 42m, new DateTime(2021, 5, 18, 20, 8, 23, 931, DateTimeKind.Local).AddTicks(9685), 420m, 5 },
                    { 10, new DateTime(2021, 5, 18, 20, 8, 23, 931, DateTimeKind.Local).AddTicks(9945), 2m, new DateTime(2021, 5, 18, 20, 8, 23, 931, DateTimeKind.Local).AddTicks(9945), 20m, 4 },
                    { 6, new DateTime(2021, 5, 18, 20, 8, 23, 931, DateTimeKind.Local).AddTicks(9927), 7.8m, new DateTime(2021, 5, 18, 20, 8, 23, 931, DateTimeKind.Local).AddTicks(9927), 78m, 10 },
                    { 5, new DateTime(2021, 5, 18, 20, 8, 23, 931, DateTimeKind.Local).AddTicks(9692), 3.6m, new DateTime(2021, 5, 18, 20, 8, 23, 931, DateTimeKind.Local).AddTicks(9692), 36m, 12 },
                    { 2, new DateTime(2021, 5, 18, 20, 8, 23, 931, DateTimeKind.Local).AddTicks(9668), 2m, new DateTime(2021, 5, 18, 20, 8, 23, 931, DateTimeKind.Local).AddTicks(9668), 20m, 1 },
                    { 9, new DateTime(2021, 5, 18, 20, 8, 23, 931, DateTimeKind.Local).AddTicks(9940), 13m, new DateTime(2021, 5, 18, 20, 8, 23, 931, DateTimeKind.Local).AddTicks(9940), 130m, 3 }
                });

            migrationBuilder.InsertData(
                table: "TradeItems",
                columns: new[] { "Id", "Amount", "CreatedAt", "ModifiedAt", "ResourceId", "Sold", "TradeId", "UserId" },
                values: new object[,]
                {
                    { 4, 69, new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(4399), new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(4399), 24, false, 3, 4 },
                    { 17, 10, new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5116), new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5116), 1, false, 6, 3 },
                    { 18, 9, new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5120), new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5120), 6, true, 2, 1 },
                    { 16, 75, new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5111), new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5111), 7, false, 4, 5 },
                    { 5, 45, new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5064), new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5064), 45, false, 5, 5 },
                    { 14, 25, new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5102), new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5102), 49, true, 2, 3 },
                    { 24, 47, new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5145), new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5145), 47, true, 1, 2 },
                    { 23, 180, new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5142), new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5142), 37, true, 1, 1 },
                    { 15, 35, new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5107), new DateTime(2021, 5, 18, 20, 8, 23, 930, DateTimeKind.Local).AddTicks(5107), 50, false, 3, 4 }
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
