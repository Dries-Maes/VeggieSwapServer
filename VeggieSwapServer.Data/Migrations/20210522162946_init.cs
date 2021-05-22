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
                name: "TradeItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ResourceId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_TradeItems_Users_UserId",
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
                    ActiveUserId = table.Column<int>(type: "int", nullable: false),
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
                name: "TradeItemProposals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TradeItemId = table.Column<int>(type: "int", nullable: false),
                    TradeId = table.Column<int>(type: "int", nullable: false),
                    ProposedAmount = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeItemProposals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TradeItemProposals_TradeItems_TradeItemId",
                        column: x => x.TradeItemId,
                        principalTable: "TradeItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TradeItemProposals_Trades_TradeId",
                        column: x => x.TradeId,
                        principalTable: "Trades",
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
                    { 1, new DateTime(2021, 5, 22, 18, 29, 45, 729, DateTimeKind.Local).AddTicks(9357), "apples.svg", new DateTime(2021, 5, 22, 18, 29, 45, 729, DateTimeKind.Local).AddTicks(9357), "apples" },
                    { 29, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(430), "olives.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(430), "olives" },
                    { 30, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(433), "oranges.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(433), "oranges" },
                    { 31, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(435), "papayas.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(435), "papayas" },
                    { 33, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(481), "pears.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(481), "pears" },
                    { 34, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(484), "peas.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(484), "peas" },
                    { 35, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(487), "pineapples.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(487), "pineapples" },
                    { 36, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(490), "pomegranates.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(490), "pomegranates" },
                    { 37, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(492), "potatoes.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(492), "potatoes" },
                    { 38, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(494), "pumpkins.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(494), "pumpkins" },
                    { 39, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(497), "radish.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(497), "radish" },
                    { 28, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(428), "mushrooms.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(428), "mushrooms" },
                    { 40, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(499), "radishes.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(499), "radishes" },
                    { 42, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(504), "salad.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(504), "salad" },
                    { 43, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(507), "salads.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(507), "salads" },
                    { 44, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(509), "scallions.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(509), "scallions" },
                    { 45, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(512), "spinach.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(512), "spinach" },
                    { 46, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(514), "star-fruits.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(514), "star-fruits" },
                    { 47, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(517), "strawberries.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(517), "strawberries" },
                    { 48, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(519), "sweet-potatoes.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(519), "sweet-potatoes" },
                    { 49, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(522), "tomatoes.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(522), "tomatoes" },
                    { 50, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(524), "watermelons.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(524), "watermelons" },
                    { 51, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(527), "v-coin.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(527), "v-coin" },
                    { 41, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(502), "raspberries.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(502), "raspberries" },
                    { 27, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(425), "melons.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(425), "melons" },
                    { 32, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(438), "peaches.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(438), "peaches" },
                    { 25, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(420), "mangos.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(420), "mangos" },
                    { 2, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(350), "artichokes.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(350), "artichokes" },
                    { 3, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(363), "asparagus.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(363), "asparagus" },
                    { 4, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(367), "bananas.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(367), "bananas" },
                    { 5, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(369), "bell-peppers.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(369), "bell-peppers" },
                    { 6, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(372), "blueberries.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(372), "blueberries" },
                    { 7, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(375), "bok-choy.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(375), "bok-choy" },
                    { 26, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(423), "mangosteens.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(423), "mangosteens" },
                    { 9, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(380), "brussels-sprouts.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(380), "brussels-sprouts" },
                    { 10, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(382), "carrots.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(382), "carrots" },
                    { 11, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(385), "cherries.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(385), "cherries" },
                    { 12, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(388), "chilis.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(388), "chilis" },
                    { 13, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(390), "coconuts.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(390), "coconuts" },
                    { 8, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(377), "broccoli.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(377), "broccoli" },
                    { 15, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(395), "corn.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(395), "corn" },
                    { 16, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(398), "cucumbers.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(398), "cucumbers" }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreatedAt", "ImageUrl", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 17, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(400), "dragon-fruits.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(400), "dragon-fruits" },
                    { 18, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(403), "durians.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(403), "durians" },
                    { 19, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(405), "eggplants.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(405), "eggplants" },
                    { 20, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(408), "garlic.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(408), "garlic" },
                    { 21, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(410), "grapes.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(410), "grapes" },
                    { 22, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(413), "guavas.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(413), "guavas" },
                    { 23, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(415), "kiwis.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(415), "kiwis" },
                    { 24, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(418), "lemons.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(418), "lemons" },
                    { 14, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(393), "coriander.svg", new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(393), "coriander" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "ImageUrl", "IsAdmin", "LastName", "ModifiedAt", "PasswordHash", "PasswordSalt" },
                values: new object[,]
                {
                    { 11, new DateTime(2021, 5, 22, 18, 29, 45, 726, DateTimeKind.Local).AddTicks(438), "VerhofstadDeZeemlap@europeesemailadres.com", "Verhofstad", "https://robohash.org/Zeemlap", false, "Zeemlap", new DateTime(2021, 5, 22, 18, 29, 45, 726, DateTimeKind.Local).AddTicks(438), new byte[] { 26, 95, 200, 139, 190, 116, 107, 149, 149, 39, 34, 31, 9, 15, 1, 148, 160, 83, 180, 186, 101, 196, 57, 250, 127, 197, 32, 40, 243, 110, 233, 125, 232, 112, 91, 52, 142, 82, 244, 182, 155, 127, 108, 52, 252, 94, 43, 55, 249, 246, 56, 110, 245, 122, 102, 254, 49, 28, 245, 144, 80, 143, 144, 83 }, new byte[] { 33, 53, 86, 143, 119, 242, 218, 38, 225, 137, 26, 4, 228, 9, 134, 185, 201, 168, 142, 224, 81, 156, 169, 190, 227, 205, 203, 130, 221, 61, 210, 144, 229, 219, 20, 106, 27, 64, 118, 88, 12, 75, 16, 169, 239, 147, 130, 214, 45, 168, 126, 191, 199, 110, 178, 186, 133, 108, 97, 170, 236, 224, 154, 23, 0, 220, 62, 183, 23, 207, 140, 143, 27, 237, 227, 59, 58, 85, 11, 230, 172, 121, 160, 3, 87, 148, 247, 21, 95, 18, 242, 81, 248, 34, 182, 27, 10, 205, 130, 190, 200, 157, 181, 15, 224, 114, 190, 249, 122, 196, 68, 136, 123, 191, 13, 167, 102, 181, 67, 150, 95, 26, 58, 223, 211, 190, 208, 106 } },
                    { 10, new DateTime(2021, 5, 22, 18, 29, 45, 726, DateTimeKind.Local).AddTicks(423), "Luc@mail.com", "Luc", "https://robohash.org/Luc", false, "DeHaantje", new DateTime(2021, 5, 22, 18, 29, 45, 726, DateTimeKind.Local).AddTicks(423), new byte[] { 26, 95, 200, 139, 190, 116, 107, 149, 149, 39, 34, 31, 9, 15, 1, 148, 160, 83, 180, 186, 101, 196, 57, 250, 127, 197, 32, 40, 243, 110, 233, 125, 232, 112, 91, 52, 142, 82, 244, 182, 155, 127, 108, 52, 252, 94, 43, 55, 249, 246, 56, 110, 245, 122, 102, 254, 49, 28, 245, 144, 80, 143, 144, 83 }, new byte[] { 33, 53, 86, 143, 119, 242, 218, 38, 225, 137, 26, 4, 228, 9, 134, 185, 201, 168, 142, 224, 81, 156, 169, 190, 227, 205, 203, 130, 221, 61, 210, 144, 229, 219, 20, 106, 27, 64, 118, 88, 12, 75, 16, 169, 239, 147, 130, 214, 45, 168, 126, 191, 199, 110, 178, 186, 133, 108, 97, 170, 236, 224, 154, 23, 0, 220, 62, 183, 23, 207, 140, 143, 27, 237, 227, 59, 58, 85, 11, 230, 172, 121, 160, 3, 87, 148, 247, 21, 95, 18, 242, 81, 248, 34, 182, 27, 10, 205, 130, 190, 200, 157, 181, 15, 224, 114, 190, 249, 122, 196, 68, 136, 123, 191, 13, 167, 102, 181, 67, 150, 95, 26, 58, 223, 211, 190, 208, 106 } },
                    { 9, new DateTime(2021, 5, 22, 18, 29, 45, 726, DateTimeKind.Local).AddTicks(407), "Mihiel@mail.com", "Mihiel", "https://robohash.org/Mihiel", false, "Mihoen", new DateTime(2021, 5, 22, 18, 29, 45, 726, DateTimeKind.Local).AddTicks(407), new byte[] { 26, 95, 200, 139, 190, 116, 107, 149, 149, 39, 34, 31, 9, 15, 1, 148, 160, 83, 180, 186, 101, 196, 57, 250, 127, 197, 32, 40, 243, 110, 233, 125, 232, 112, 91, 52, 142, 82, 244, 182, 155, 127, 108, 52, 252, 94, 43, 55, 249, 246, 56, 110, 245, 122, 102, 254, 49, 28, 245, 144, 80, 143, 144, 83 }, new byte[] { 33, 53, 86, 143, 119, 242, 218, 38, 225, 137, 26, 4, 228, 9, 134, 185, 201, 168, 142, 224, 81, 156, 169, 190, 227, 205, 203, 130, 221, 61, 210, 144, 229, 219, 20, 106, 27, 64, 118, 88, 12, 75, 16, 169, 239, 147, 130, 214, 45, 168, 126, 191, 199, 110, 178, 186, 133, 108, 97, 170, 236, 224, 154, 23, 0, 220, 62, 183, 23, 207, 140, 143, 27, 237, 227, 59, 58, 85, 11, 230, 172, 121, 160, 3, 87, 148, 247, 21, 95, 18, 242, 81, 248, 34, 182, 27, 10, 205, 130, 190, 200, 157, 181, 15, 224, 114, 190, 249, 122, 196, 68, 136, 123, 191, 13, 167, 102, 181, 67, 150, 95, 26, 58, 223, 211, 190, 208, 106 } },
                    { 8, new DateTime(2021, 5, 22, 18, 29, 45, 726, DateTimeKind.Local).AddTicks(390), "Andreas@mail.com", "Andreas", "https://robohash.org/Andreas", false, "VanGrieken", new DateTime(2021, 5, 22, 18, 29, 45, 726, DateTimeKind.Local).AddTicks(390), new byte[] { 26, 95, 200, 139, 190, 116, 107, 149, 149, 39, 34, 31, 9, 15, 1, 148, 160, 83, 180, 186, 101, 196, 57, 250, 127, 197, 32, 40, 243, 110, 233, 125, 232, 112, 91, 52, 142, 82, 244, 182, 155, 127, 108, 52, 252, 94, 43, 55, 249, 246, 56, 110, 245, 122, 102, 254, 49, 28, 245, 144, 80, 143, 144, 83 }, new byte[] { 33, 53, 86, 143, 119, 242, 218, 38, 225, 137, 26, 4, 228, 9, 134, 185, 201, 168, 142, 224, 81, 156, 169, 190, 227, 205, 203, 130, 221, 61, 210, 144, 229, 219, 20, 106, 27, 64, 118, 88, 12, 75, 16, 169, 239, 147, 130, 214, 45, 168, 126, 191, 199, 110, 178, 186, 133, 108, 97, 170, 236, 224, 154, 23, 0, 220, 62, 183, 23, 207, 140, 143, 27, 237, 227, 59, 58, 85, 11, 230, 172, 121, 160, 3, 87, 148, 247, 21, 95, 18, 242, 81, 248, 34, 182, 27, 10, 205, 130, 190, 200, 157, 181, 15, 224, 114, 190, 249, 122, 196, 68, 136, 123, 191, 13, 167, 102, 181, 67, 150, 95, 26, 58, 223, 211, 190, 208, 106 } },
                    { 7, new DateTime(2021, 5, 22, 18, 29, 45, 726, DateTimeKind.Local).AddTicks(372), "Dirk@mail.com", "Dirk", "https://robohash.org/Dirk", false, "Visser", new DateTime(2021, 5, 22, 18, 29, 45, 726, DateTimeKind.Local).AddTicks(372), new byte[] { 26, 95, 200, 139, 190, 116, 107, 149, 149, 39, 34, 31, 9, 15, 1, 148, 160, 83, 180, 186, 101, 196, 57, 250, 127, 197, 32, 40, 243, 110, 233, 125, 232, 112, 91, 52, 142, 82, 244, 182, 155, 127, 108, 52, 252, 94, 43, 55, 249, 246, 56, 110, 245, 122, 102, 254, 49, 28, 245, 144, 80, 143, 144, 83 }, new byte[] { 33, 53, 86, 143, 119, 242, 218, 38, 225, 137, 26, 4, 228, 9, 134, 185, 201, 168, 142, 224, 81, 156, 169, 190, 227, 205, 203, 130, 221, 61, 210, 144, 229, 219, 20, 106, 27, 64, 118, 88, 12, 75, 16, 169, 239, 147, 130, 214, 45, 168, 126, 191, 199, 110, 178, 186, 133, 108, 97, 170, 236, 224, 154, 23, 0, 220, 62, 183, 23, 207, 140, 143, 27, 237, 227, 59, 58, 85, 11, 230, 172, 121, 160, 3, 87, 148, 247, 21, 95, 18, 242, 81, 248, 34, 182, 27, 10, 205, 130, 190, 200, 157, 181, 15, 224, 114, 190, 249, 122, 196, 68, 136, 123, 191, 13, 167, 102, 181, 67, 150, 95, 26, 58, 223, 211, 190, 208, 106 } },
                    { 1, new DateTime(2021, 5, 22, 18, 29, 45, 722, DateTimeKind.Local).AddTicks(5993), "Pieter@mail.com", "Pieter", "https://robohash.org/Pieter", true, "Corp", new DateTime(2021, 5, 22, 18, 29, 45, 722, DateTimeKind.Local).AddTicks(5993), new byte[] { 26, 95, 200, 139, 190, 116, 107, 149, 149, 39, 34, 31, 9, 15, 1, 148, 160, 83, 180, 186, 101, 196, 57, 250, 127, 197, 32, 40, 243, 110, 233, 125, 232, 112, 91, 52, 142, 82, 244, 182, 155, 127, 108, 52, 252, 94, 43, 55, 249, 246, 56, 110, 245, 122, 102, 254, 49, 28, 245, 144, 80, 143, 144, 83 }, new byte[] { 33, 53, 86, 143, 119, 242, 218, 38, 225, 137, 26, 4, 228, 9, 134, 185, 201, 168, 142, 224, 81, 156, 169, 190, 227, 205, 203, 130, 221, 61, 210, 144, 229, 219, 20, 106, 27, 64, 118, 88, 12, 75, 16, 169, 239, 147, 130, 214, 45, 168, 126, 191, 199, 110, 178, 186, 133, 108, 97, 170, 236, 224, 154, 23, 0, 220, 62, 183, 23, 207, 140, 143, 27, 237, 227, 59, 58, 85, 11, 230, 172, 121, 160, 3, 87, 148, 247, 21, 95, 18, 242, 81, 248, 34, 182, 27, 10, 205, 130, 190, 200, 157, 181, 15, 224, 114, 190, 249, 122, 196, 68, 136, 123, 191, 13, 167, 102, 181, 67, 150, 95, 26, 58, 223, 211, 190, 208, 106 } },
                    { 5, new DateTime(2021, 5, 22, 18, 29, 45, 726, DateTimeKind.Local).AddTicks(288), "BartjeWevertje@mail.com", "BartjeWevertje", "https://robohash.org/BartjeWevertje", false, "Wevertje", new DateTime(2021, 5, 22, 18, 29, 45, 726, DateTimeKind.Local).AddTicks(288), new byte[] { 26, 95, 200, 139, 190, 116, 107, 149, 149, 39, 34, 31, 9, 15, 1, 148, 160, 83, 180, 186, 101, 196, 57, 250, 127, 197, 32, 40, 243, 110, 233, 125, 232, 112, 91, 52, 142, 82, 244, 182, 155, 127, 108, 52, 252, 94, 43, 55, 249, 246, 56, 110, 245, 122, 102, 254, 49, 28, 245, 144, 80, 143, 144, 83 }, new byte[] { 33, 53, 86, 143, 119, 242, 218, 38, 225, 137, 26, 4, 228, 9, 134, 185, 201, 168, 142, 224, 81, 156, 169, 190, 227, 205, 203, 130, 221, 61, 210, 144, 229, 219, 20, 106, 27, 64, 118, 88, 12, 75, 16, 169, 239, 147, 130, 214, 45, 168, 126, 191, 199, 110, 178, 186, 133, 108, 97, 170, 236, 224, 154, 23, 0, 220, 62, 183, 23, 207, 140, 143, 27, 237, 227, 59, 58, 85, 11, 230, 172, 121, 160, 3, 87, 148, 247, 21, 95, 18, 242, 81, 248, 34, 182, 27, 10, 205, 130, 190, 200, 157, 181, 15, 224, 114, 190, 249, 122, 196, 68, 136, 123, 191, 13, 167, 102, 181, 67, 150, 95, 26, 58, 223, 211, 190, 208, 106 } },
                    { 4, new DateTime(2021, 5, 22, 18, 29, 45, 726, DateTimeKind.Local).AddTicks(272), "Dries@mail.com", "Dries", "https://robohash.org/Dries", true, "Maes", new DateTime(2021, 5, 22, 18, 29, 45, 726, DateTimeKind.Local).AddTicks(272), new byte[] { 26, 95, 200, 139, 190, 116, 107, 149, 149, 39, 34, 31, 9, 15, 1, 148, 160, 83, 180, 186, 101, 196, 57, 250, 127, 197, 32, 40, 243, 110, 233, 125, 232, 112, 91, 52, 142, 82, 244, 182, 155, 127, 108, 52, 252, 94, 43, 55, 249, 246, 56, 110, 245, 122, 102, 254, 49, 28, 245, 144, 80, 143, 144, 83 }, new byte[] { 33, 53, 86, 143, 119, 242, 218, 38, 225, 137, 26, 4, 228, 9, 134, 185, 201, 168, 142, 224, 81, 156, 169, 190, 227, 205, 203, 130, 221, 61, 210, 144, 229, 219, 20, 106, 27, 64, 118, 88, 12, 75, 16, 169, 239, 147, 130, 214, 45, 168, 126, 191, 199, 110, 178, 186, 133, 108, 97, 170, 236, 224, 154, 23, 0, 220, 62, 183, 23, 207, 140, 143, 27, 237, 227, 59, 58, 85, 11, 230, 172, 121, 160, 3, 87, 148, 247, 21, 95, 18, 242, 81, 248, 34, 182, 27, 10, 205, 130, 190, 200, 157, 181, 15, 224, 114, 190, 249, 122, 196, 68, 136, 123, 191, 13, 167, 102, 181, 67, 150, 95, 26, 58, 223, 211, 190, 208, 106 } },
                    { 3, new DateTime(2021, 5, 22, 18, 29, 45, 726, DateTimeKind.Local).AddTicks(245), "Kobe@mail.com", "Kobe", "https://robohash.org/Kobe", true, "Delo", new DateTime(2021, 5, 22, 18, 29, 45, 726, DateTimeKind.Local).AddTicks(245), new byte[] { 26, 95, 200, 139, 190, 116, 107, 149, 149, 39, 34, 31, 9, 15, 1, 148, 160, 83, 180, 186, 101, 196, 57, 250, 127, 197, 32, 40, 243, 110, 233, 125, 232, 112, 91, 52, 142, 82, 244, 182, 155, 127, 108, 52, 252, 94, 43, 55, 249, 246, 56, 110, 245, 122, 102, 254, 49, 28, 245, 144, 80, 143, 144, 83 }, new byte[] { 33, 53, 86, 143, 119, 242, 218, 38, 225, 137, 26, 4, 228, 9, 134, 185, 201, 168, 142, 224, 81, 156, 169, 190, 227, 205, 203, 130, 221, 61, 210, 144, 229, 219, 20, 106, 27, 64, 118, 88, 12, 75, 16, 169, 239, 147, 130, 214, 45, 168, 126, 191, 199, 110, 178, 186, 133, 108, 97, 170, 236, 224, 154, 23, 0, 220, 62, 183, 23, 207, 140, 143, 27, 237, 227, 59, 58, 85, 11, 230, 172, 121, 160, 3, 87, 148, 247, 21, 95, 18, 242, 81, 248, 34, 182, 27, 10, 205, 130, 190, 200, 157, 181, 15, 224, 114, 190, 249, 122, 196, 68, 136, 123, 191, 13, 167, 102, 181, 67, 150, 95, 26, 58, 223, 211, 190, 208, 106 } },
                    { 2, new DateTime(2021, 5, 22, 18, 29, 45, 726, DateTimeKind.Local).AddTicks(33), "Nick@mail.com", "Nick", "https://robohash.org/Nick", true, "Vr", new DateTime(2021, 5, 22, 18, 29, 45, 726, DateTimeKind.Local).AddTicks(33), new byte[] { 26, 95, 200, 139, 190, 116, 107, 149, 149, 39, 34, 31, 9, 15, 1, 148, 160, 83, 180, 186, 101, 196, 57, 250, 127, 197, 32, 40, 243, 110, 233, 125, 232, 112, 91, 52, 142, 82, 244, 182, 155, 127, 108, 52, 252, 94, 43, 55, 249, 246, 56, 110, 245, 122, 102, 254, 49, 28, 245, 144, 80, 143, 144, 83 }, new byte[] { 33, 53, 86, 143, 119, 242, 218, 38, 225, 137, 26, 4, 228, 9, 134, 185, 201, 168, 142, 224, 81, 156, 169, 190, 227, 205, 203, 130, 221, 61, 210, 144, 229, 219, 20, 106, 27, 64, 118, 88, 12, 75, 16, 169, 239, 147, 130, 214, 45, 168, 126, 191, 199, 110, 178, 186, 133, 108, 97, 170, 236, 224, 154, 23, 0, 220, 62, 183, 23, 207, 140, 143, 27, 237, 227, 59, 58, 85, 11, 230, 172, 121, 160, 3, 87, 148, 247, 21, 95, 18, 242, 81, 248, 34, 182, 27, 10, 205, 130, 190, 200, 157, 181, 15, 224, 114, 190, 249, 122, 196, 68, 136, 123, 191, 13, 167, 102, 181, 67, 150, 95, 26, 58, 223, 211, 190, 208, 106 } },
                    { 12, new DateTime(2021, 5, 22, 18, 29, 45, 726, DateTimeKind.Local).AddTicks(454), "Driesdentweedenmaarnidezelfden@mail.com", "Dries", "https://robohash.org/Dries2", false, "VanKorteNekke", new DateTime(2021, 5, 22, 18, 29, 45, 726, DateTimeKind.Local).AddTicks(454), new byte[] { 26, 95, 200, 139, 190, 116, 107, 149, 149, 39, 34, 31, 9, 15, 1, 148, 160, 83, 180, 186, 101, 196, 57, 250, 127, 197, 32, 40, 243, 110, 233, 125, 232, 112, 91, 52, 142, 82, 244, 182, 155, 127, 108, 52, 252, 94, 43, 55, 249, 246, 56, 110, 245, 122, 102, 254, 49, 28, 245, 144, 80, 143, 144, 83 }, new byte[] { 33, 53, 86, 143, 119, 242, 218, 38, 225, 137, 26, 4, 228, 9, 134, 185, 201, 168, 142, 224, 81, 156, 169, 190, 227, 205, 203, 130, 221, 61, 210, 144, 229, 219, 20, 106, 27, 64, 118, 88, 12, 75, 16, 169, 239, 147, 130, 214, 45, 168, 126, 191, 199, 110, 178, 186, 133, 108, 97, 170, 236, 224, 154, 23, 0, 220, 62, 183, 23, 207, 140, 143, 27, 237, 227, 59, 58, 85, 11, 230, 172, 121, 160, 3, 87, 148, 247, 21, 95, 18, 242, 81, 248, 34, 182, 27, 10, 205, 130, 190, 200, 157, 181, 15, 224, 114, 190, 249, 122, 196, 68, 136, 123, 191, 13, 167, 102, 181, 67, 150, 95, 26, 58, 223, 211, 190, 208, 106 } },
                    { 6, new DateTime(2021, 5, 22, 18, 29, 45, 726, DateTimeKind.Local).AddTicks(304), "Stofzuiger@mail.com", "Stofzuiger", "https://robohash.org/Stofzuiger", false, "Zuiger", new DateTime(2021, 5, 22, 18, 29, 45, 726, DateTimeKind.Local).AddTicks(304), new byte[] { 26, 95, 200, 139, 190, 116, 107, 149, 149, 39, 34, 31, 9, 15, 1, 148, 160, 83, 180, 186, 101, 196, 57, 250, 127, 197, 32, 40, 243, 110, 233, 125, 232, 112, 91, 52, 142, 82, 244, 182, 155, 127, 108, 52, 252, 94, 43, 55, 249, 246, 56, 110, 245, 122, 102, 254, 49, 28, 245, 144, 80, 143, 144, 83 }, new byte[] { 33, 53, 86, 143, 119, 242, 218, 38, 225, 137, 26, 4, 228, 9, 134, 185, 201, 168, 142, 224, 81, 156, 169, 190, 227, 205, 203, 130, 221, 61, 210, 144, 229, 219, 20, 106, 27, 64, 118, 88, 12, 75, 16, 169, 239, 147, 130, 214, 45, 168, 126, 191, 199, 110, 178, 186, 133, 108, 97, 170, 236, 224, 154, 23, 0, 220, 62, 183, 23, 207, 140, 143, 27, 237, 227, 59, 58, 85, 11, 230, 172, 121, 160, 3, 87, 148, 247, 21, 95, 18, 242, 81, 248, 34, 182, 27, 10, 205, 130, 190, 200, 157, 181, 15, 224, 114, 190, 249, 122, 196, 68, 136, 123, 191, 13, 167, 102, 181, 67, 150, 95, 26, 58, 223, 211, 190, 208, 106 } },
                    { 13, new DateTime(2021, 5, 22, 18, 29, 45, 726, DateTimeKind.Local).AddTicks(469), "Joyce@mail.com", "Joyce", "https://robohash.org/Tomatenplukker", false, "Tomatenplukker", new DateTime(2021, 5, 22, 18, 29, 45, 726, DateTimeKind.Local).AddTicks(469), new byte[] { 26, 95, 200, 139, 190, 116, 107, 149, 149, 39, 34, 31, 9, 15, 1, 148, 160, 83, 180, 186, 101, 196, 57, 250, 127, 197, 32, 40, 243, 110, 233, 125, 232, 112, 91, 52, 142, 82, 244, 182, 155, 127, 108, 52, 252, 94, 43, 55, 249, 246, 56, 110, 245, 122, 102, 254, 49, 28, 245, 144, 80, 143, 144, 83 }, new byte[] { 33, 53, 86, 143, 119, 242, 218, 38, 225, 137, 26, 4, 228, 9, 134, 185, 201, 168, 142, 224, 81, 156, 169, 190, 227, 205, 203, 130, 221, 61, 210, 144, 229, 219, 20, 106, 27, 64, 118, 88, 12, 75, 16, 169, 239, 147, 130, 214, 45, 168, 126, 191, 199, 110, 178, 186, 133, 108, 97, 170, 236, 224, 154, 23, 0, 220, 62, 183, 23, 207, 140, 143, 27, 237, 227, 59, 58, 85, 11, 230, 172, 121, 160, 3, 87, 148, 247, 21, 95, 18, 242, 81, 248, 34, 182, 27, 10, 205, 130, 190, 200, 157, 181, 15, 224, 114, 190, 249, 122, 196, 68, 136, 123, 191, 13, 167, 102, 181, 67, 150, 95, 26, 58, 223, 211, 190, 208, 106 } }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "PostalCode", "StreetName", "StreetNumber", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 22, 18, 29, 45, 727, DateTimeKind.Local).AddTicks(8764), new DateTime(2021, 5, 22, 18, 29, 45, 727, DateTimeKind.Local).AddTicks(8764), 9000, "Anti-Veggiestraat", 89, 1 },
                    { 4, new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(583), new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(583), 1000, "Driesstraat", 66, 4 },
                    { 13, new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(607), new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(607), 9020, "Worstenbroodjesstraat", 4, 13 },
                    { 6, new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(588), new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(588), 1000, "Lookbroodjesstraat", 43, 6 },
                    { 3, new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(580), new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(580), 9000, "Nickstraat", 74, 3 },
                    { 8, new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(594), new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(594), 1000, "Kotsvisstraat", 96, 8 },
                    { 7, new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(591), new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(591), 9050, "Greenpeacestraat", 1, 7 },
                    { 5, new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(586), new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(586), 2000, "Kobestraat", 85, 5 },
                    { 12, new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(605), new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(605), 1000, "Blacklivesmatterstraat", 78, 12 },
                    { 11, new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(602), new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(602), 9500, "Kalfslapjesstraat", 32, 11 },
                    { 10, new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(599), new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(599), 9070, "Geenpolitiekinhetprojectstraat", 200, 10 },
                    { 9, new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(597), new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(597), 2000, "Greenlivesmattertoostraat", 420, 9 },
                    { 2, new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(565), new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(565), 9000, "Pieterstreaat", 45, 2 }
                });

            migrationBuilder.InsertData(
                table: "TradeItems",
                columns: new[] { "Id", "Amount", "CreatedAt", "ModifiedAt", "ResourceId", "UserId" },
                values: new object[,]
                {
                    { 21, 50, new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7901), new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7901), 51, 5 },
                    { 23, 50, new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7906), new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7906), 46, 5 },
                    { 24, 50, new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7909), new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7909), 32, 5 },
                    { 25, 50, new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7911), new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7911), 39, 6 },
                    { 27, 50, new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7916), new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7916), 51, 6 },
                    { 28, 50, new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7919), new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7919), 4, 6 },
                    { 20, 50, new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7899), new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7899), 7, 5 },
                    { 29, 50, new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7921), new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7921), 8, 7 },
                    { 30, 50, new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7924), new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7924), 13, 7 },
                    { 31, 50, new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7926), new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7926), 6, 7 },
                    { 32, 50, new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7929), new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7929), 51, 7 },
                    { 34, 50, new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7934), new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7934), 51, 8 },
                    { 26, 50, new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7914), new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7914), 15, 6 },
                    { 33, 50, new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7931), new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7931), 6, 8 },
                    { 22, 50, new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7904), new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7904), 51, 5 },
                    { 8, 50, new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7869), new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7869), 32, 2 },
                    { 3, 50, new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7855), new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7855), 5, 1 },
                    { 5, 50, new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7861), new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7861), 51, 2 },
                    { 6, 50, new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7864), new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7864), 34, 2 },
                    { 7, 50, new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7866), new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7866), 46, 2 },
                    { 19, 50, new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7896), new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7896), 51, 4 },
                    { 9, 50, new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7871), new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7871), 39, 2 },
                    { 2, 50, new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7842), new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7842), 3, 1 },
                    { 11, 50, new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7877), new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7877), 51, 3 },
                    { 10, 50, new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7874), new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7874), 15, 2 },
                    { 13, 50, new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7882), new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7882), 8, 3 },
                    { 18, 50, new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7894), new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7894), 44, 4 },
                    { 17, 50, new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7891), new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7891), 21, 4 },
                    { 12, 50, new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7879), new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7879), 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "TradeItems",
                columns: new[] { "Id", "Amount", "CreatedAt", "ModifiedAt", "ResourceId", "UserId" },
                values: new object[,]
                {
                    { 15, 50, new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7887), new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7887), 6, 3 },
                    { 14, 50, new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7884), new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7884), 13, 3 },
                    { 16, 50, new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7889), new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7889), 31, 3 },
                    { 1, 50, new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(6417), new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(6417), 1, 1 },
                    { 4, 50, new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7858), new DateTime(2021, 5, 22, 18, 29, 45, 731, DateTimeKind.Local).AddTicks(7858), 7, 1 }
                });

            migrationBuilder.InsertData(
                table: "Trades",
                columns: new[] { "Id", "ActiveUserId", "Completed", "CreatedAt", "ModifiedAt", "ProposerId", "ReceiverId" },
                values: new object[,]
                {
                    { 5, 7, false, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(7398), new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(7398), 4, 7 },
                    { 3, 6, false, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(7391), new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(7391), 6, 8 },
                    { 4, 1, false, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(7395), new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(7395), 1, 8 },
                    { 1, 1, false, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(5344), new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(5344), 2, 1 },
                    { 2, 3, false, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(7377), new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(7377), 3, 2 },
                    { 6, 7, false, new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(7401), new DateTime(2021, 5, 22, 18, 29, 45, 730, DateTimeKind.Local).AddTicks(7401), 7, 2 }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "UserId", "VAmount" },
                values: new object[,]
                {
                    { 9, new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(7712), new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(7712), 9, 357m },
                    { 12, new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(7797), new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(7797), 12, 57m },
                    { 10, new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(7791), new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(7791), 10, 124m },
                    { 11, new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(7795), new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(7795), 11, 269m },
                    { 4, new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(7698), new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(7698), 4, 42m },
                    { 1, new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(6575), new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(6575), 1, 200m },
                    { 7, new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(7707), new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(7707), 7, 12m },
                    { 6, new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(7704), new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(7704), 6, 36m },
                    { 2, new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(7681), new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(7681), 2, 347m },
                    { 5, new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(7702), new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(7702), 5, 753m },
                    { 3, new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(7695), new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(7695), 3, 65m },
                    { 8, new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(7709), new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(7709), 8, 654m },
                    { 13, new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(7799), new DateTime(2021, 5, 22, 18, 29, 45, 728, DateTimeKind.Local).AddTicks(7799), 13, 204m }
                });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "CreatedAt", "EuroAmount", "ModifiedAt", "VAmount", "WalletId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 22, 18, 29, 45, 732, DateTimeKind.Local).AddTicks(4381), 6.9m, new DateTime(2021, 5, 22, 18, 29, 45, 732, DateTimeKind.Local).AddTicks(4381), 69m, 1 },
                    { 7, new DateTime(2021, 5, 22, 18, 29, 45, 732, DateTimeKind.Local).AddTicks(6118), 9.8m, new DateTime(2021, 5, 22, 18, 29, 45, 732, DateTimeKind.Local).AddTicks(6118), 98m, 9 },
                    { 8, new DateTime(2021, 5, 22, 18, 29, 45, 732, DateTimeKind.Local).AddTicks(6121), 5m, new DateTime(2021, 5, 22, 18, 29, 45, 732, DateTimeKind.Local).AddTicks(6121), 50m, 7 },
                    { 6, new DateTime(2021, 5, 22, 18, 29, 45, 732, DateTimeKind.Local).AddTicks(6115), 7.8m, new DateTime(2021, 5, 22, 18, 29, 45, 732, DateTimeKind.Local).AddTicks(6115), 78m, 10 },
                    { 4, new DateTime(2021, 5, 22, 18, 29, 45, 732, DateTimeKind.Local).AddTicks(6109), 10m, new DateTime(2021, 5, 22, 18, 29, 45, 732, DateTimeKind.Local).AddTicks(6109), 100m, 6 },
                    { 3, new DateTime(2021, 5, 22, 18, 29, 45, 732, DateTimeKind.Local).AddTicks(6106), 42m, new DateTime(2021, 5, 22, 18, 29, 45, 732, DateTimeKind.Local).AddTicks(6106), 420m, 5 },
                    { 10, new DateTime(2021, 5, 22, 18, 29, 45, 732, DateTimeKind.Local).AddTicks(6126), 2m, new DateTime(2021, 5, 22, 18, 29, 45, 732, DateTimeKind.Local).AddTicks(6126), 20m, 4 },
                    { 9, new DateTime(2021, 5, 22, 18, 29, 45, 732, DateTimeKind.Local).AddTicks(6123), 13m, new DateTime(2021, 5, 22, 18, 29, 45, 732, DateTimeKind.Local).AddTicks(6123), 130m, 3 },
                    { 5, new DateTime(2021, 5, 22, 18, 29, 45, 732, DateTimeKind.Local).AddTicks(6112), 3.6m, new DateTime(2021, 5, 22, 18, 29, 45, 732, DateTimeKind.Local).AddTicks(6112), 36m, 12 },
                    { 2, new DateTime(2021, 5, 22, 18, 29, 45, 732, DateTimeKind.Local).AddTicks(6092), 2m, new DateTime(2021, 5, 22, 18, 29, 45, 732, DateTimeKind.Local).AddTicks(6092), 20m, 1 }
                });

            migrationBuilder.InsertData(
                table: "TradeItemProposals",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "ProposedAmount", "TradeId", "TradeItemId" },
                values: new object[,]
                {
                    { 8, new DateTime(2021, 5, 22, 18, 29, 45, 733, DateTimeKind.Local).AddTicks(3683), new DateTime(2021, 5, 22, 18, 29, 45, 733, DateTimeKind.Local).AddTicks(3683), 15, 2, 14 },
                    { 11, new DateTime(2021, 5, 22, 18, 29, 45, 733, DateTimeKind.Local).AddTicks(3691), new DateTime(2021, 5, 22, 18, 29, 45, 733, DateTimeKind.Local).AddTicks(3691), 5, 4, 34 },
                    { 9, new DateTime(2021, 5, 22, 18, 29, 45, 733, DateTimeKind.Local).AddTicks(3686), new DateTime(2021, 5, 22, 18, 29, 45, 733, DateTimeKind.Local).AddTicks(3686), 5, 3, 33 },
                    { 15, new DateTime(2021, 5, 22, 18, 29, 45, 733, DateTimeKind.Local).AddTicks(3701), new DateTime(2021, 5, 22, 18, 29, 45, 733, DateTimeKind.Local).AddTicks(3701), 5, 4, 4 },
                    { 14, new DateTime(2021, 5, 22, 18, 29, 45, 733, DateTimeKind.Local).AddTicks(3698), new DateTime(2021, 5, 22, 18, 29, 45, 733, DateTimeKind.Local).AddTicks(3698), 15, 4, 3 },
                    { 13, new DateTime(2021, 5, 22, 18, 29, 45, 733, DateTimeKind.Local).AddTicks(3696), new DateTime(2021, 5, 22, 18, 29, 45, 733, DateTimeKind.Local).AddTicks(3696), 5, 4, 2 },
                    { 12, new DateTime(2021, 5, 22, 18, 29, 45, 733, DateTimeKind.Local).AddTicks(3693), new DateTime(2021, 5, 22, 18, 29, 45, 733, DateTimeKind.Local).AddTicks(3693), 15, 4, 1 },
                    { 10, new DateTime(2021, 5, 22, 18, 29, 45, 733, DateTimeKind.Local).AddTicks(3688), new DateTime(2021, 5, 22, 18, 29, 45, 733, DateTimeKind.Local).AddTicks(3688), 15, 3, 28 },
                    { 7, new DateTime(2021, 5, 22, 18, 29, 45, 733, DateTimeKind.Local).AddTicks(3681), new DateTime(2021, 5, 22, 18, 29, 45, 733, DateTimeKind.Local).AddTicks(3681), 5, 2, 13 },
                    { 1, new DateTime(2021, 5, 22, 18, 29, 45, 733, DateTimeKind.Local).AddTicks(2256), new DateTime(2021, 5, 22, 18, 29, 45, 733, DateTimeKind.Local).AddTicks(2256), 5, 1, 1 },
                    { 20, new DateTime(2021, 5, 22, 18, 29, 45, 733, DateTimeKind.Local).AddTicks(3713), new DateTime(2021, 5, 22, 18, 29, 45, 733, DateTimeKind.Local).AddTicks(3713), 15, 6, 30 },
                    { 19, new DateTime(2021, 5, 22, 18, 29, 45, 733, DateTimeKind.Local).AddTicks(3711), new DateTime(2021, 5, 22, 18, 29, 45, 733, DateTimeKind.Local).AddTicks(3711), 1, 6, 5 },
                    { 18, new DateTime(2021, 5, 22, 18, 29, 45, 733, DateTimeKind.Local).AddTicks(3708), new DateTime(2021, 5, 22, 18, 29, 45, 733, DateTimeKind.Local).AddTicks(3708), 15, 5, 18 },
                    { 2, new DateTime(2021, 5, 22, 18, 29, 45, 733, DateTimeKind.Local).AddTicks(3656), new DateTime(2021, 5, 22, 18, 29, 45, 733, DateTimeKind.Local).AddTicks(3656), 15, 1, 2 },
                    { 3, new DateTime(2021, 5, 22, 18, 29, 45, 733, DateTimeKind.Local).AddTicks(3670), new DateTime(2021, 5, 22, 18, 29, 45, 733, DateTimeKind.Local).AddTicks(3670), 5, 1, 3 },
                    { 4, new DateTime(2021, 5, 22, 18, 29, 45, 733, DateTimeKind.Local).AddTicks(3673), new DateTime(2021, 5, 22, 18, 29, 45, 733, DateTimeKind.Local).AddTicks(3673), 5, 1, 5 },
                    { 5, new DateTime(2021, 5, 22, 18, 29, 45, 733, DateTimeKind.Local).AddTicks(3675), new DateTime(2021, 5, 22, 18, 29, 45, 733, DateTimeKind.Local).AddTicks(3675), 5, 2, 6 },
                    { 6, new DateTime(2021, 5, 22, 18, 29, 45, 733, DateTimeKind.Local).AddTicks(3678), new DateTime(2021, 5, 22, 18, 29, 45, 733, DateTimeKind.Local).AddTicks(3678), 15, 2, 7 },
                    { 16, new DateTime(2021, 5, 22, 18, 29, 45, 733, DateTimeKind.Local).AddTicks(3703), new DateTime(2021, 5, 22, 18, 29, 45, 733, DateTimeKind.Local).AddTicks(3703), 3, 5, 32 },
                    { 17, new DateTime(2021, 5, 22, 18, 29, 45, 733, DateTimeKind.Local).AddTicks(3706), new DateTime(2021, 5, 22, 18, 29, 45, 733, DateTimeKind.Local).AddTicks(3706), 5, 5, 17 }
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
                name: "IX_TradeItemProposals_TradeId",
                table: "TradeItemProposals",
                column: "TradeId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeItemProposals_TradeItemId",
                table: "TradeItemProposals",
                column: "TradeItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeItems_ResourceId",
                table: "TradeItems",
                column: "ResourceId");

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
                name: "TradeItemProposals");

            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropTable(
                name: "TradeItems");

            migrationBuilder.DropTable(
                name: "Trades");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
