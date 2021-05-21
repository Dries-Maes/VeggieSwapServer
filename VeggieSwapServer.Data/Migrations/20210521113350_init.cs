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
                    { 1, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(5811), "apples.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(5811), "apples" },
                    { 29, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7115), "olives.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7115), "olives" },
                    { 30, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7118), "oranges.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7118), "oranges" },
                    { 31, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7121), "papayas.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7121), "papayas" },
                    { 33, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7127), "pears.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7127), "pears" },
                    { 34, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7129), "peas.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7129), "peas" },
                    { 35, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7132), "pineapples.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7132), "pineapples" },
                    { 36, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7135), "pomegranates.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7135), "pomegranates" },
                    { 37, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7138), "potatoes.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7138), "potatoes" },
                    { 38, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7141), "pumpkins.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7141), "pumpkins" },
                    { 39, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7144), "radish.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7144), "radish" },
                    { 28, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7112), "mushrooms.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7112), "mushrooms" },
                    { 40, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7146), "radishes.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7146), "radishes" },
                    { 42, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7152), "salad.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7152), "salad" },
                    { 43, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7155), "salads.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7155), "salads" },
                    { 44, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7158), "scallions.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7158), "scallions" },
                    { 45, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7161), "spinach.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7161), "spinach" },
                    { 46, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7164), "star-fruits.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7164), "star-fruits" },
                    { 47, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7166), "strawberries.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7166), "strawberries" },
                    { 48, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7169), "sweet-potatoes.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7169), "sweet-potatoes" },
                    { 49, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7172), "tomatoes.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7172), "tomatoes" },
                    { 50, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7175), "watermelons.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7175), "watermelons" },
                    { 51, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7178), "v-coin.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7178), "v-coin" },
                    { 41, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7149), "raspberries.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7149), "raspberries" },
                    { 27, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7110), "melons.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7110), "melons" },
                    { 32, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7124), "peaches.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7124), "peaches" },
                    { 25, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7104), "mangos.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7104), "mangos" },
                    { 2, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7025), "artichokes.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7025), "artichokes" },
                    { 3, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7039), "asparagus.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7039), "asparagus" },
                    { 4, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7044), "bananas.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7044), "bananas" },
                    { 5, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7047), "bell-peppers.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7047), "bell-peppers" },
                    { 6, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7050), "blueberries.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7050), "blueberries" },
                    { 7, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7053), "bok-choy.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7053), "bok-choy" },
                    { 26, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7107), "mangosteens.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7107), "mangosteens" },
                    { 9, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7058), "brussels-sprouts.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7058), "brussels-sprouts" },
                    { 10, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7061), "carrots.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7061), "carrots" },
                    { 11, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7064), "cherries.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7064), "cherries" },
                    { 12, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7067), "chilis.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7067), "chilis" },
                    { 13, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7070), "coconuts.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7070), "coconuts" },
                    { 8, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7056), "broccoli.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7056), "broccoli" },
                    { 15, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7076), "corn.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7076), "corn" },
                    { 16, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7079), "cucumbers.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7079), "cucumbers" }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreatedAt", "ImageUrl", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 17, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7081), "dragon-fruits.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7081), "dragon-fruits" },
                    { 18, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7084), "durians.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7084), "durians" },
                    { 19, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7087), "eggplants.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7087), "eggplants" },
                    { 20, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7090), "garlic.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7090), "garlic" },
                    { 21, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7093), "grapes.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7093), "grapes" },
                    { 22, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7095), "guavas.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7095), "guavas" },
                    { 23, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7098), "kiwis.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7098), "kiwis" },
                    { 24, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7101), "lemons.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7101), "lemons" },
                    { 14, new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7073), "coriander.svg", new DateTime(2021, 5, 21, 13, 33, 50, 163, DateTimeKind.Local).AddTicks(7073), "coriander" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "ImageUrl", "IsAdmin", "LastName", "ModifiedAt", "PasswordHash", "PasswordSalt" },
                values: new object[,]
                {
                    { 11, new DateTime(2021, 5, 21, 13, 33, 50, 158, DateTimeKind.Local).AddTicks(3685), "VerhofstadDeZeemlap@europeesemailadres.com", "Verhofstad", "https://robohash.org/Zeemlap", false, "Zeemlap", new DateTime(2021, 5, 21, 13, 33, 50, 158, DateTimeKind.Local).AddTicks(3685), new byte[] { 221, 41, 155, 154, 189, 85, 90, 39, 98, 191, 187, 219, 42, 16, 114, 69, 153, 222, 254, 177, 212, 214, 89, 97, 180, 170, 112, 98, 21, 184, 40, 198, 210, 110, 158, 71, 223, 50, 113, 133, 241, 78, 226, 193, 96, 140, 33, 9, 218, 216, 144, 9, 135, 161, 201, 162, 96, 22, 231, 231, 217, 102, 134, 160 }, new byte[] { 169, 112, 135, 212, 33, 9, 42, 59, 163, 133, 13, 41, 247, 15, 235, 100, 60, 162, 33, 15, 246, 191, 144, 103, 212, 174, 0, 226, 243, 160, 234, 249, 187, 173, 182, 103, 245, 172, 184, 175, 103, 71, 206, 135, 92, 171, 32, 97, 17, 143, 7, 223, 196, 138, 250, 218, 241, 171, 87, 111, 168, 118, 89, 61, 163, 137, 172, 141, 236, 186, 28, 145, 50, 195, 185, 64, 235, 144, 124, 11, 61, 252, 85, 28, 232, 31, 48, 95, 164, 227, 166, 178, 201, 54, 109, 96, 227, 53, 192, 192, 130, 190, 130, 246, 163, 167, 136, 215, 190, 16, 143, 230, 212, 18, 227, 56, 135, 175, 36, 121, 226, 44, 50, 239, 134, 81, 37, 24 } },
                    { 10, new DateTime(2021, 5, 21, 13, 33, 50, 158, DateTimeKind.Local).AddTicks(3602), "Luc@mail.com", "Luc", "https://robohash.org/Luc", false, "DeHaantje", new DateTime(2021, 5, 21, 13, 33, 50, 158, DateTimeKind.Local).AddTicks(3602), new byte[] { 221, 41, 155, 154, 189, 85, 90, 39, 98, 191, 187, 219, 42, 16, 114, 69, 153, 222, 254, 177, 212, 214, 89, 97, 180, 170, 112, 98, 21, 184, 40, 198, 210, 110, 158, 71, 223, 50, 113, 133, 241, 78, 226, 193, 96, 140, 33, 9, 218, 216, 144, 9, 135, 161, 201, 162, 96, 22, 231, 231, 217, 102, 134, 160 }, new byte[] { 169, 112, 135, 212, 33, 9, 42, 59, 163, 133, 13, 41, 247, 15, 235, 100, 60, 162, 33, 15, 246, 191, 144, 103, 212, 174, 0, 226, 243, 160, 234, 249, 187, 173, 182, 103, 245, 172, 184, 175, 103, 71, 206, 135, 92, 171, 32, 97, 17, 143, 7, 223, 196, 138, 250, 218, 241, 171, 87, 111, 168, 118, 89, 61, 163, 137, 172, 141, 236, 186, 28, 145, 50, 195, 185, 64, 235, 144, 124, 11, 61, 252, 85, 28, 232, 31, 48, 95, 164, 227, 166, 178, 201, 54, 109, 96, 227, 53, 192, 192, 130, 190, 130, 246, 163, 167, 136, 215, 190, 16, 143, 230, 212, 18, 227, 56, 135, 175, 36, 121, 226, 44, 50, 239, 134, 81, 37, 24 } },
                    { 9, new DateTime(2021, 5, 21, 13, 33, 50, 158, DateTimeKind.Local).AddTicks(3586), "Mihiel@mail.com", "Mihiel", "https://robohash.org/Mihiel", false, "Mihoen", new DateTime(2021, 5, 21, 13, 33, 50, 158, DateTimeKind.Local).AddTicks(3586), new byte[] { 221, 41, 155, 154, 189, 85, 90, 39, 98, 191, 187, 219, 42, 16, 114, 69, 153, 222, 254, 177, 212, 214, 89, 97, 180, 170, 112, 98, 21, 184, 40, 198, 210, 110, 158, 71, 223, 50, 113, 133, 241, 78, 226, 193, 96, 140, 33, 9, 218, 216, 144, 9, 135, 161, 201, 162, 96, 22, 231, 231, 217, 102, 134, 160 }, new byte[] { 169, 112, 135, 212, 33, 9, 42, 59, 163, 133, 13, 41, 247, 15, 235, 100, 60, 162, 33, 15, 246, 191, 144, 103, 212, 174, 0, 226, 243, 160, 234, 249, 187, 173, 182, 103, 245, 172, 184, 175, 103, 71, 206, 135, 92, 171, 32, 97, 17, 143, 7, 223, 196, 138, 250, 218, 241, 171, 87, 111, 168, 118, 89, 61, 163, 137, 172, 141, 236, 186, 28, 145, 50, 195, 185, 64, 235, 144, 124, 11, 61, 252, 85, 28, 232, 31, 48, 95, 164, 227, 166, 178, 201, 54, 109, 96, 227, 53, 192, 192, 130, 190, 130, 246, 163, 167, 136, 215, 190, 16, 143, 230, 212, 18, 227, 56, 135, 175, 36, 121, 226, 44, 50, 239, 134, 81, 37, 24 } },
                    { 8, new DateTime(2021, 5, 21, 13, 33, 50, 158, DateTimeKind.Local).AddTicks(3569), "Andreas@mail.com", "Andreas", "https://robohash.org/Andreas", false, "VanGrieken", new DateTime(2021, 5, 21, 13, 33, 50, 158, DateTimeKind.Local).AddTicks(3569), new byte[] { 221, 41, 155, 154, 189, 85, 90, 39, 98, 191, 187, 219, 42, 16, 114, 69, 153, 222, 254, 177, 212, 214, 89, 97, 180, 170, 112, 98, 21, 184, 40, 198, 210, 110, 158, 71, 223, 50, 113, 133, 241, 78, 226, 193, 96, 140, 33, 9, 218, 216, 144, 9, 135, 161, 201, 162, 96, 22, 231, 231, 217, 102, 134, 160 }, new byte[] { 169, 112, 135, 212, 33, 9, 42, 59, 163, 133, 13, 41, 247, 15, 235, 100, 60, 162, 33, 15, 246, 191, 144, 103, 212, 174, 0, 226, 243, 160, 234, 249, 187, 173, 182, 103, 245, 172, 184, 175, 103, 71, 206, 135, 92, 171, 32, 97, 17, 143, 7, 223, 196, 138, 250, 218, 241, 171, 87, 111, 168, 118, 89, 61, 163, 137, 172, 141, 236, 186, 28, 145, 50, 195, 185, 64, 235, 144, 124, 11, 61, 252, 85, 28, 232, 31, 48, 95, 164, 227, 166, 178, 201, 54, 109, 96, 227, 53, 192, 192, 130, 190, 130, 246, 163, 167, 136, 215, 190, 16, 143, 230, 212, 18, 227, 56, 135, 175, 36, 121, 226, 44, 50, 239, 134, 81, 37, 24 } },
                    { 7, new DateTime(2021, 5, 21, 13, 33, 50, 158, DateTimeKind.Local).AddTicks(3552), "Dirk@mail.com", "Dirk", "https://robohash.org/Dirk", false, "Visser", new DateTime(2021, 5, 21, 13, 33, 50, 158, DateTimeKind.Local).AddTicks(3552), new byte[] { 221, 41, 155, 154, 189, 85, 90, 39, 98, 191, 187, 219, 42, 16, 114, 69, 153, 222, 254, 177, 212, 214, 89, 97, 180, 170, 112, 98, 21, 184, 40, 198, 210, 110, 158, 71, 223, 50, 113, 133, 241, 78, 226, 193, 96, 140, 33, 9, 218, 216, 144, 9, 135, 161, 201, 162, 96, 22, 231, 231, 217, 102, 134, 160 }, new byte[] { 169, 112, 135, 212, 33, 9, 42, 59, 163, 133, 13, 41, 247, 15, 235, 100, 60, 162, 33, 15, 246, 191, 144, 103, 212, 174, 0, 226, 243, 160, 234, 249, 187, 173, 182, 103, 245, 172, 184, 175, 103, 71, 206, 135, 92, 171, 32, 97, 17, 143, 7, 223, 196, 138, 250, 218, 241, 171, 87, 111, 168, 118, 89, 61, 163, 137, 172, 141, 236, 186, 28, 145, 50, 195, 185, 64, 235, 144, 124, 11, 61, 252, 85, 28, 232, 31, 48, 95, 164, 227, 166, 178, 201, 54, 109, 96, 227, 53, 192, 192, 130, 190, 130, 246, 163, 167, 136, 215, 190, 16, 143, 230, 212, 18, 227, 56, 135, 175, 36, 121, 226, 44, 50, 239, 134, 81, 37, 24 } },
                    { 1, new DateTime(2021, 5, 21, 13, 33, 50, 154, DateTimeKind.Local).AddTicks(8239), "Pieter@mail.com", "Pieter", "https://robohash.org/Pieter", true, "Corp", new DateTime(2021, 5, 21, 13, 33, 50, 154, DateTimeKind.Local).AddTicks(8239), new byte[] { 221, 41, 155, 154, 189, 85, 90, 39, 98, 191, 187, 219, 42, 16, 114, 69, 153, 222, 254, 177, 212, 214, 89, 97, 180, 170, 112, 98, 21, 184, 40, 198, 210, 110, 158, 71, 223, 50, 113, 133, 241, 78, 226, 193, 96, 140, 33, 9, 218, 216, 144, 9, 135, 161, 201, 162, 96, 22, 231, 231, 217, 102, 134, 160 }, new byte[] { 169, 112, 135, 212, 33, 9, 42, 59, 163, 133, 13, 41, 247, 15, 235, 100, 60, 162, 33, 15, 246, 191, 144, 103, 212, 174, 0, 226, 243, 160, 234, 249, 187, 173, 182, 103, 245, 172, 184, 175, 103, 71, 206, 135, 92, 171, 32, 97, 17, 143, 7, 223, 196, 138, 250, 218, 241, 171, 87, 111, 168, 118, 89, 61, 163, 137, 172, 141, 236, 186, 28, 145, 50, 195, 185, 64, 235, 144, 124, 11, 61, 252, 85, 28, 232, 31, 48, 95, 164, 227, 166, 178, 201, 54, 109, 96, 227, 53, 192, 192, 130, 190, 130, 246, 163, 167, 136, 215, 190, 16, 143, 230, 212, 18, 227, 56, 135, 175, 36, 121, 226, 44, 50, 239, 134, 81, 37, 24 } },
                    { 5, new DateTime(2021, 5, 21, 13, 33, 50, 158, DateTimeKind.Local).AddTicks(3377), "BartjeWevertje@mail.com", "BartjeWevertje", "https://robohash.org/BartjeWevertje", false, "Wevertje", new DateTime(2021, 5, 21, 13, 33, 50, 158, DateTimeKind.Local).AddTicks(3377), new byte[] { 221, 41, 155, 154, 189, 85, 90, 39, 98, 191, 187, 219, 42, 16, 114, 69, 153, 222, 254, 177, 212, 214, 89, 97, 180, 170, 112, 98, 21, 184, 40, 198, 210, 110, 158, 71, 223, 50, 113, 133, 241, 78, 226, 193, 96, 140, 33, 9, 218, 216, 144, 9, 135, 161, 201, 162, 96, 22, 231, 231, 217, 102, 134, 160 }, new byte[] { 169, 112, 135, 212, 33, 9, 42, 59, 163, 133, 13, 41, 247, 15, 235, 100, 60, 162, 33, 15, 246, 191, 144, 103, 212, 174, 0, 226, 243, 160, 234, 249, 187, 173, 182, 103, 245, 172, 184, 175, 103, 71, 206, 135, 92, 171, 32, 97, 17, 143, 7, 223, 196, 138, 250, 218, 241, 171, 87, 111, 168, 118, 89, 61, 163, 137, 172, 141, 236, 186, 28, 145, 50, 195, 185, 64, 235, 144, 124, 11, 61, 252, 85, 28, 232, 31, 48, 95, 164, 227, 166, 178, 201, 54, 109, 96, 227, 53, 192, 192, 130, 190, 130, 246, 163, 167, 136, 215, 190, 16, 143, 230, 212, 18, 227, 56, 135, 175, 36, 121, 226, 44, 50, 239, 134, 81, 37, 24 } },
                    { 4, new DateTime(2021, 5, 21, 13, 33, 50, 158, DateTimeKind.Local).AddTicks(3360), "Dries@mail.com", "Dries", "https://robohash.org/Dries", true, "Maes", new DateTime(2021, 5, 21, 13, 33, 50, 158, DateTimeKind.Local).AddTicks(3360), new byte[] { 221, 41, 155, 154, 189, 85, 90, 39, 98, 191, 187, 219, 42, 16, 114, 69, 153, 222, 254, 177, 212, 214, 89, 97, 180, 170, 112, 98, 21, 184, 40, 198, 210, 110, 158, 71, 223, 50, 113, 133, 241, 78, 226, 193, 96, 140, 33, 9, 218, 216, 144, 9, 135, 161, 201, 162, 96, 22, 231, 231, 217, 102, 134, 160 }, new byte[] { 169, 112, 135, 212, 33, 9, 42, 59, 163, 133, 13, 41, 247, 15, 235, 100, 60, 162, 33, 15, 246, 191, 144, 103, 212, 174, 0, 226, 243, 160, 234, 249, 187, 173, 182, 103, 245, 172, 184, 175, 103, 71, 206, 135, 92, 171, 32, 97, 17, 143, 7, 223, 196, 138, 250, 218, 241, 171, 87, 111, 168, 118, 89, 61, 163, 137, 172, 141, 236, 186, 28, 145, 50, 195, 185, 64, 235, 144, 124, 11, 61, 252, 85, 28, 232, 31, 48, 95, 164, 227, 166, 178, 201, 54, 109, 96, 227, 53, 192, 192, 130, 190, 130, 246, 163, 167, 136, 215, 190, 16, 143, 230, 212, 18, 227, 56, 135, 175, 36, 121, 226, 44, 50, 239, 134, 81, 37, 24 } },
                    { 3, new DateTime(2021, 5, 21, 13, 33, 50, 158, DateTimeKind.Local).AddTicks(3333), "Kobe@mail.com", "Kobe", "https://robohash.org/Kobe", true, "Delo", new DateTime(2021, 5, 21, 13, 33, 50, 158, DateTimeKind.Local).AddTicks(3333), new byte[] { 221, 41, 155, 154, 189, 85, 90, 39, 98, 191, 187, 219, 42, 16, 114, 69, 153, 222, 254, 177, 212, 214, 89, 97, 180, 170, 112, 98, 21, 184, 40, 198, 210, 110, 158, 71, 223, 50, 113, 133, 241, 78, 226, 193, 96, 140, 33, 9, 218, 216, 144, 9, 135, 161, 201, 162, 96, 22, 231, 231, 217, 102, 134, 160 }, new byte[] { 169, 112, 135, 212, 33, 9, 42, 59, 163, 133, 13, 41, 247, 15, 235, 100, 60, 162, 33, 15, 246, 191, 144, 103, 212, 174, 0, 226, 243, 160, 234, 249, 187, 173, 182, 103, 245, 172, 184, 175, 103, 71, 206, 135, 92, 171, 32, 97, 17, 143, 7, 223, 196, 138, 250, 218, 241, 171, 87, 111, 168, 118, 89, 61, 163, 137, 172, 141, 236, 186, 28, 145, 50, 195, 185, 64, 235, 144, 124, 11, 61, 252, 85, 28, 232, 31, 48, 95, 164, 227, 166, 178, 201, 54, 109, 96, 227, 53, 192, 192, 130, 190, 130, 246, 163, 167, 136, 215, 190, 16, 143, 230, 212, 18, 227, 56, 135, 175, 36, 121, 226, 44, 50, 239, 134, 81, 37, 24 } },
                    { 2, new DateTime(2021, 5, 21, 13, 33, 50, 158, DateTimeKind.Local).AddTicks(3081), "Nick@mail.com", "Nick", "https://robohash.org/Nick", true, "Vr", new DateTime(2021, 5, 21, 13, 33, 50, 158, DateTimeKind.Local).AddTicks(3081), new byte[] { 221, 41, 155, 154, 189, 85, 90, 39, 98, 191, 187, 219, 42, 16, 114, 69, 153, 222, 254, 177, 212, 214, 89, 97, 180, 170, 112, 98, 21, 184, 40, 198, 210, 110, 158, 71, 223, 50, 113, 133, 241, 78, 226, 193, 96, 140, 33, 9, 218, 216, 144, 9, 135, 161, 201, 162, 96, 22, 231, 231, 217, 102, 134, 160 }, new byte[] { 169, 112, 135, 212, 33, 9, 42, 59, 163, 133, 13, 41, 247, 15, 235, 100, 60, 162, 33, 15, 246, 191, 144, 103, 212, 174, 0, 226, 243, 160, 234, 249, 187, 173, 182, 103, 245, 172, 184, 175, 103, 71, 206, 135, 92, 171, 32, 97, 17, 143, 7, 223, 196, 138, 250, 218, 241, 171, 87, 111, 168, 118, 89, 61, 163, 137, 172, 141, 236, 186, 28, 145, 50, 195, 185, 64, 235, 144, 124, 11, 61, 252, 85, 28, 232, 31, 48, 95, 164, 227, 166, 178, 201, 54, 109, 96, 227, 53, 192, 192, 130, 190, 130, 246, 163, 167, 136, 215, 190, 16, 143, 230, 212, 18, 227, 56, 135, 175, 36, 121, 226, 44, 50, 239, 134, 81, 37, 24 } },
                    { 12, new DateTime(2021, 5, 21, 13, 33, 50, 158, DateTimeKind.Local).AddTicks(3704), "Driesdentweedenmaarnidezelfden@mail.com", "Dries", "https://robohash.org/Dries2", false, "VanKorteNekke", new DateTime(2021, 5, 21, 13, 33, 50, 158, DateTimeKind.Local).AddTicks(3704), new byte[] { 221, 41, 155, 154, 189, 85, 90, 39, 98, 191, 187, 219, 42, 16, 114, 69, 153, 222, 254, 177, 212, 214, 89, 97, 180, 170, 112, 98, 21, 184, 40, 198, 210, 110, 158, 71, 223, 50, 113, 133, 241, 78, 226, 193, 96, 140, 33, 9, 218, 216, 144, 9, 135, 161, 201, 162, 96, 22, 231, 231, 217, 102, 134, 160 }, new byte[] { 169, 112, 135, 212, 33, 9, 42, 59, 163, 133, 13, 41, 247, 15, 235, 100, 60, 162, 33, 15, 246, 191, 144, 103, 212, 174, 0, 226, 243, 160, 234, 249, 187, 173, 182, 103, 245, 172, 184, 175, 103, 71, 206, 135, 92, 171, 32, 97, 17, 143, 7, 223, 196, 138, 250, 218, 241, 171, 87, 111, 168, 118, 89, 61, 163, 137, 172, 141, 236, 186, 28, 145, 50, 195, 185, 64, 235, 144, 124, 11, 61, 252, 85, 28, 232, 31, 48, 95, 164, 227, 166, 178, 201, 54, 109, 96, 227, 53, 192, 192, 130, 190, 130, 246, 163, 167, 136, 215, 190, 16, 143, 230, 212, 18, 227, 56, 135, 175, 36, 121, 226, 44, 50, 239, 134, 81, 37, 24 } },
                    { 6, new DateTime(2021, 5, 21, 13, 33, 50, 158, DateTimeKind.Local).AddTicks(3535), "Stofzuiger@mail.com", "Stofzuiger", "https://robohash.org/Stofzuiger", false, "Zuiger", new DateTime(2021, 5, 21, 13, 33, 50, 158, DateTimeKind.Local).AddTicks(3535), new byte[] { 221, 41, 155, 154, 189, 85, 90, 39, 98, 191, 187, 219, 42, 16, 114, 69, 153, 222, 254, 177, 212, 214, 89, 97, 180, 170, 112, 98, 21, 184, 40, 198, 210, 110, 158, 71, 223, 50, 113, 133, 241, 78, 226, 193, 96, 140, 33, 9, 218, 216, 144, 9, 135, 161, 201, 162, 96, 22, 231, 231, 217, 102, 134, 160 }, new byte[] { 169, 112, 135, 212, 33, 9, 42, 59, 163, 133, 13, 41, 247, 15, 235, 100, 60, 162, 33, 15, 246, 191, 144, 103, 212, 174, 0, 226, 243, 160, 234, 249, 187, 173, 182, 103, 245, 172, 184, 175, 103, 71, 206, 135, 92, 171, 32, 97, 17, 143, 7, 223, 196, 138, 250, 218, 241, 171, 87, 111, 168, 118, 89, 61, 163, 137, 172, 141, 236, 186, 28, 145, 50, 195, 185, 64, 235, 144, 124, 11, 61, 252, 85, 28, 232, 31, 48, 95, 164, 227, 166, 178, 201, 54, 109, 96, 227, 53, 192, 192, 130, 190, 130, 246, 163, 167, 136, 215, 190, 16, 143, 230, 212, 18, 227, 56, 135, 175, 36, 121, 226, 44, 50, 239, 134, 81, 37, 24 } },
                    { 13, new DateTime(2021, 5, 21, 13, 33, 50, 158, DateTimeKind.Local).AddTicks(3720), "Joyce@mail.com", "Joyce", "https://robohash.org/Tomatenplukker", false, "Tomatenplukker", new DateTime(2021, 5, 21, 13, 33, 50, 158, DateTimeKind.Local).AddTicks(3720), new byte[] { 221, 41, 155, 154, 189, 85, 90, 39, 98, 191, 187, 219, 42, 16, 114, 69, 153, 222, 254, 177, 212, 214, 89, 97, 180, 170, 112, 98, 21, 184, 40, 198, 210, 110, 158, 71, 223, 50, 113, 133, 241, 78, 226, 193, 96, 140, 33, 9, 218, 216, 144, 9, 135, 161, 201, 162, 96, 22, 231, 231, 217, 102, 134, 160 }, new byte[] { 169, 112, 135, 212, 33, 9, 42, 59, 163, 133, 13, 41, 247, 15, 235, 100, 60, 162, 33, 15, 246, 191, 144, 103, 212, 174, 0, 226, 243, 160, 234, 249, 187, 173, 182, 103, 245, 172, 184, 175, 103, 71, 206, 135, 92, 171, 32, 97, 17, 143, 7, 223, 196, 138, 250, 218, 241, 171, 87, 111, 168, 118, 89, 61, 163, 137, 172, 141, 236, 186, 28, 145, 50, 195, 185, 64, 235, 144, 124, 11, 61, 252, 85, 28, 232, 31, 48, 95, 164, 227, 166, 178, 201, 54, 109, 96, 227, 53, 192, 192, 130, 190, 130, 246, 163, 167, 136, 215, 190, 16, 143, 230, 212, 18, 227, 56, 135, 175, 36, 121, 226, 44, 50, 239, 134, 81, 37, 24 } }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "PostalCode", "StreetName", "StreetNumber", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 21, 13, 33, 50, 161, DateTimeKind.Local).AddTicks(1167), new DateTime(2021, 5, 21, 13, 33, 50, 161, DateTimeKind.Local).AddTicks(1167), 9000, "Anti-Veggiestraat", 89, 1 },
                    { 4, new DateTime(2021, 5, 21, 13, 33, 50, 161, DateTimeKind.Local).AddTicks(3436), new DateTime(2021, 5, 21, 13, 33, 50, 161, DateTimeKind.Local).AddTicks(3436), 1000, "Driesstraat", 66, 4 },
                    { 13, new DateTime(2021, 5, 21, 13, 33, 50, 161, DateTimeKind.Local).AddTicks(3464), new DateTime(2021, 5, 21, 13, 33, 50, 161, DateTimeKind.Local).AddTicks(3464), 9020, "Worstenbroodjesstraat", 4, 13 },
                    { 6, new DateTime(2021, 5, 21, 13, 33, 50, 161, DateTimeKind.Local).AddTicks(3443), new DateTime(2021, 5, 21, 13, 33, 50, 161, DateTimeKind.Local).AddTicks(3443), 1000, "Lookbroodjesstraat", 43, 6 },
                    { 3, new DateTime(2021, 5, 21, 13, 33, 50, 161, DateTimeKind.Local).AddTicks(3432), new DateTime(2021, 5, 21, 13, 33, 50, 161, DateTimeKind.Local).AddTicks(3432), 9000, "Nickstraat", 74, 3 },
                    { 8, new DateTime(2021, 5, 21, 13, 33, 50, 161, DateTimeKind.Local).AddTicks(3449), new DateTime(2021, 5, 21, 13, 33, 50, 161, DateTimeKind.Local).AddTicks(3449), 1000, "Kotsvisstraat", 96, 8 },
                    { 7, new DateTime(2021, 5, 21, 13, 33, 50, 161, DateTimeKind.Local).AddTicks(3446), new DateTime(2021, 5, 21, 13, 33, 50, 161, DateTimeKind.Local).AddTicks(3446), 9050, "Greenpeacestraat", 1, 7 },
                    { 5, new DateTime(2021, 5, 21, 13, 33, 50, 161, DateTimeKind.Local).AddTicks(3440), new DateTime(2021, 5, 21, 13, 33, 50, 161, DateTimeKind.Local).AddTicks(3440), 2000, "Kobestraat", 85, 5 },
                    { 12, new DateTime(2021, 5, 21, 13, 33, 50, 161, DateTimeKind.Local).AddTicks(3461), new DateTime(2021, 5, 21, 13, 33, 50, 161, DateTimeKind.Local).AddTicks(3461), 1000, "Blacklivesmatterstraat", 78, 12 },
                    { 11, new DateTime(2021, 5, 21, 13, 33, 50, 161, DateTimeKind.Local).AddTicks(3458), new DateTime(2021, 5, 21, 13, 33, 50, 161, DateTimeKind.Local).AddTicks(3458), 9500, "Kalfslapjesstraat", 32, 11 },
                    { 10, new DateTime(2021, 5, 21, 13, 33, 50, 161, DateTimeKind.Local).AddTicks(3455), new DateTime(2021, 5, 21, 13, 33, 50, 161, DateTimeKind.Local).AddTicks(3455), 9070, "Geenpolitiekinhetprojectstraat", 200, 10 },
                    { 9, new DateTime(2021, 5, 21, 13, 33, 50, 161, DateTimeKind.Local).AddTicks(3452), new DateTime(2021, 5, 21, 13, 33, 50, 161, DateTimeKind.Local).AddTicks(3452), 2000, "Greenlivesmattertoostraat", 420, 9 },
                    { 2, new DateTime(2021, 5, 21, 13, 33, 50, 161, DateTimeKind.Local).AddTicks(3418), new DateTime(2021, 5, 21, 13, 33, 50, 161, DateTimeKind.Local).AddTicks(3418), 9000, "Pieterstreaat", 45, 2 }
                });

            migrationBuilder.InsertData(
                table: "TradeItems",
                columns: new[] { "Id", "Amount", "CreatedAt", "ModifiedAt", "ResourceId", "UserId" },
                values: new object[,]
                {
                    { 21, 50, new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4954), new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4954), 51, 5 },
                    { 23, 50, new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4959), new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4959), 46, 5 },
                    { 24, 50, new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4962), new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4962), 32, 5 },
                    { 25, 50, new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4965), new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4965), 39, 6 },
                    { 27, 50, new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4971), new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4971), 51, 6 },
                    { 28, 50, new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4974), new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4974), 4, 6 },
                    { 20, 50, new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4951), new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4951), 7, 5 },
                    { 29, 50, new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4976), new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4976), 8, 7 },
                    { 30, 50, new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4979), new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4979), 13, 7 },
                    { 31, 50, new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4982), new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4982), 6, 7 },
                    { 32, 50, new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4985), new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4985), 51, 7 },
                    { 34, 50, new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4991), new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4991), 51, 8 },
                    { 26, 50, new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4968), new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4968), 15, 6 },
                    { 33, 50, new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4988), new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4988), 6, 8 },
                    { 22, 50, new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4956), new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4956), 51, 5 },
                    { 8, 50, new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4916), new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4916), 32, 2 },
                    { 3, 50, new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4900), new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4900), 5, 1 },
                    { 5, 50, new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4907), new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4907), 51, 2 },
                    { 6, 50, new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4911), new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4911), 34, 2 },
                    { 7, 50, new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4913), new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4913), 46, 2 },
                    { 19, 50, new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4948), new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4948), 51, 4 },
                    { 9, 50, new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4919), new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4919), 39, 2 },
                    { 2, 50, new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4887), new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4887), 3, 1 },
                    { 11, 50, new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4925), new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4925), 51, 3 },
                    { 10, 50, new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4922), new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4922), 15, 2 },
                    { 13, 50, new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4931), new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4931), 8, 3 },
                    { 18, 50, new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4945), new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4945), 44, 4 },
                    { 17, 50, new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4942), new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4942), 21, 4 },
                    { 12, 50, new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4928), new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4928), 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "TradeItems",
                columns: new[] { "Id", "Amount", "CreatedAt", "ModifiedAt", "ResourceId", "UserId" },
                values: new object[,]
                {
                    { 15, 50, new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4936), new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4936), 6, 3 },
                    { 14, 50, new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4934), new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4934), 13, 3 },
                    { 16, 50, new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4939), new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4939), 31, 3 },
                    { 1, 50, new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(3361), new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(3361), 1, 1 },
                    { 4, 50, new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4904), new DateTime(2021, 5, 21, 13, 33, 50, 165, DateTimeKind.Local).AddTicks(4904), 7, 1 }
                });

            migrationBuilder.InsertData(
                table: "Trades",
                columns: new[] { "Id", "ActiveUserId", "Completed", "CreatedAt", "ModifiedAt", "ProposerId", "ReceiverId" },
                values: new object[,]
                {
                    { 5, 7, false, new DateTime(2021, 5, 21, 13, 33, 50, 164, DateTimeKind.Local).AddTicks(3857), new DateTime(2021, 5, 21, 13, 33, 50, 164, DateTimeKind.Local).AddTicks(3857), 4, 7 },
                    { 3, 6, false, new DateTime(2021, 5, 21, 13, 33, 50, 164, DateTimeKind.Local).AddTicks(3850), new DateTime(2021, 5, 21, 13, 33, 50, 164, DateTimeKind.Local).AddTicks(3850), 6, 8 },
                    { 4, 1, false, new DateTime(2021, 5, 21, 13, 33, 50, 164, DateTimeKind.Local).AddTicks(3853), new DateTime(2021, 5, 21, 13, 33, 50, 164, DateTimeKind.Local).AddTicks(3853), 1, 8 },
                    { 1, 1, false, new DateTime(2021, 5, 21, 13, 33, 50, 164, DateTimeKind.Local).AddTicks(1861), new DateTime(2021, 5, 21, 13, 33, 50, 164, DateTimeKind.Local).AddTicks(1861), 2, 1 },
                    { 2, 3, false, new DateTime(2021, 5, 21, 13, 33, 50, 164, DateTimeKind.Local).AddTicks(3837), new DateTime(2021, 5, 21, 13, 33, 50, 164, DateTimeKind.Local).AddTicks(3837), 3, 2 },
                    { 6, 7, false, new DateTime(2021, 5, 21, 13, 33, 50, 164, DateTimeKind.Local).AddTicks(3860), new DateTime(2021, 5, 21, 13, 33, 50, 164, DateTimeKind.Local).AddTicks(3860), 7, 2 }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "UserId", "VAmount" },
                values: new object[,]
                {
                    { 9, new DateTime(2021, 5, 21, 13, 33, 50, 162, DateTimeKind.Local).AddTicks(2514), new DateTime(2021, 5, 21, 13, 33, 50, 162, DateTimeKind.Local).AddTicks(2514), 9, 357m },
                    { 12, new DateTime(2021, 5, 21, 13, 33, 50, 162, DateTimeKind.Local).AddTicks(2523), new DateTime(2021, 5, 21, 13, 33, 50, 162, DateTimeKind.Local).AddTicks(2523), 12, 57m },
                    { 10, new DateTime(2021, 5, 21, 13, 33, 50, 162, DateTimeKind.Local).AddTicks(2517), new DateTime(2021, 5, 21, 13, 33, 50, 162, DateTimeKind.Local).AddTicks(2517), 10, 124m },
                    { 11, new DateTime(2021, 5, 21, 13, 33, 50, 162, DateTimeKind.Local).AddTicks(2520), new DateTime(2021, 5, 21, 13, 33, 50, 162, DateTimeKind.Local).AddTicks(2520), 11, 269m },
                    { 4, new DateTime(2021, 5, 21, 13, 33, 50, 162, DateTimeKind.Local).AddTicks(2498), new DateTime(2021, 5, 21, 13, 33, 50, 162, DateTimeKind.Local).AddTicks(2498), 4, 42m },
                    { 1, new DateTime(2021, 5, 21, 13, 33, 50, 162, DateTimeKind.Local).AddTicks(1303), new DateTime(2021, 5, 21, 13, 33, 50, 162, DateTimeKind.Local).AddTicks(1303), 1, 200m },
                    { 7, new DateTime(2021, 5, 21, 13, 33, 50, 162, DateTimeKind.Local).AddTicks(2508), new DateTime(2021, 5, 21, 13, 33, 50, 162, DateTimeKind.Local).AddTicks(2508), 7, 12m },
                    { 6, new DateTime(2021, 5, 21, 13, 33, 50, 162, DateTimeKind.Local).AddTicks(2505), new DateTime(2021, 5, 21, 13, 33, 50, 162, DateTimeKind.Local).AddTicks(2505), 6, 36m },
                    { 2, new DateTime(2021, 5, 21, 13, 33, 50, 162, DateTimeKind.Local).AddTicks(2481), new DateTime(2021, 5, 21, 13, 33, 50, 162, DateTimeKind.Local).AddTicks(2481), 2, 347m },
                    { 5, new DateTime(2021, 5, 21, 13, 33, 50, 162, DateTimeKind.Local).AddTicks(2501), new DateTime(2021, 5, 21, 13, 33, 50, 162, DateTimeKind.Local).AddTicks(2501), 5, 753m },
                    { 3, new DateTime(2021, 5, 21, 13, 33, 50, 162, DateTimeKind.Local).AddTicks(2495), new DateTime(2021, 5, 21, 13, 33, 50, 162, DateTimeKind.Local).AddTicks(2495), 3, 65m },
                    { 8, new DateTime(2021, 5, 21, 13, 33, 50, 162, DateTimeKind.Local).AddTicks(2511), new DateTime(2021, 5, 21, 13, 33, 50, 162, DateTimeKind.Local).AddTicks(2511), 8, 654m },
                    { 13, new DateTime(2021, 5, 21, 13, 33, 50, 162, DateTimeKind.Local).AddTicks(2526), new DateTime(2021, 5, 21, 13, 33, 50, 162, DateTimeKind.Local).AddTicks(2526), 13, 204m }
                });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "CreatedAt", "EuroAmount", "ModifiedAt", "VAmount", "WalletId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 21, 13, 33, 50, 166, DateTimeKind.Local).AddTicks(3988), 6.9m, new DateTime(2021, 5, 21, 13, 33, 50, 166, DateTimeKind.Local).AddTicks(3988), 69m, 1 },
                    { 7, new DateTime(2021, 5, 21, 13, 33, 50, 167, DateTimeKind.Local).AddTicks(721), 9.8m, new DateTime(2021, 5, 21, 13, 33, 50, 167, DateTimeKind.Local).AddTicks(721), 98m, 9 },
                    { 8, new DateTime(2021, 5, 21, 13, 33, 50, 167, DateTimeKind.Local).AddTicks(724), 5m, new DateTime(2021, 5, 21, 13, 33, 50, 167, DateTimeKind.Local).AddTicks(724), 50m, 7 },
                    { 6, new DateTime(2021, 5, 21, 13, 33, 50, 167, DateTimeKind.Local).AddTicks(718), 7.8m, new DateTime(2021, 5, 21, 13, 33, 50, 167, DateTimeKind.Local).AddTicks(718), 78m, 10 },
                    { 4, new DateTime(2021, 5, 21, 13, 33, 50, 167, DateTimeKind.Local).AddTicks(710), 10m, new DateTime(2021, 5, 21, 13, 33, 50, 167, DateTimeKind.Local).AddTicks(710), 100m, 6 },
                    { 3, new DateTime(2021, 5, 21, 13, 33, 50, 167, DateTimeKind.Local).AddTicks(704), 42m, new DateTime(2021, 5, 21, 13, 33, 50, 167, DateTimeKind.Local).AddTicks(704), 420m, 5 },
                    { 10, new DateTime(2021, 5, 21, 13, 33, 50, 167, DateTimeKind.Local).AddTicks(731), 2m, new DateTime(2021, 5, 21, 13, 33, 50, 167, DateTimeKind.Local).AddTicks(731), 20m, 4 },
                    { 9, new DateTime(2021, 5, 21, 13, 33, 50, 167, DateTimeKind.Local).AddTicks(728), 13m, new DateTime(2021, 5, 21, 13, 33, 50, 167, DateTimeKind.Local).AddTicks(728), 130m, 3 },
                    { 5, new DateTime(2021, 5, 21, 13, 33, 50, 167, DateTimeKind.Local).AddTicks(714), 3.6m, new DateTime(2021, 5, 21, 13, 33, 50, 167, DateTimeKind.Local).AddTicks(714), 36m, 12 },
                    { 2, new DateTime(2021, 5, 21, 13, 33, 50, 167, DateTimeKind.Local).AddTicks(659), 2m, new DateTime(2021, 5, 21, 13, 33, 50, 167, DateTimeKind.Local).AddTicks(659), 20m, 1 }
                });

            migrationBuilder.InsertData(
                table: "TradeItemProposals",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "ProposedAmount", "TradeId", "TradeItemId" },
                values: new object[,]
                {
                    { 8, new DateTime(2021, 5, 21, 13, 33, 50, 168, DateTimeKind.Local).AddTicks(3684), new DateTime(2021, 5, 21, 13, 33, 50, 168, DateTimeKind.Local).AddTicks(3684), 15, 2, 14 },
                    { 11, new DateTime(2021, 5, 21, 13, 33, 50, 168, DateTimeKind.Local).AddTicks(3693), new DateTime(2021, 5, 21, 13, 33, 50, 168, DateTimeKind.Local).AddTicks(3693), 5, 4, 34 },
                    { 9, new DateTime(2021, 5, 21, 13, 33, 50, 168, DateTimeKind.Local).AddTicks(3687), new DateTime(2021, 5, 21, 13, 33, 50, 168, DateTimeKind.Local).AddTicks(3687), 5, 3, 33 },
                    { 15, new DateTime(2021, 5, 21, 13, 33, 50, 168, DateTimeKind.Local).AddTicks(3705), new DateTime(2021, 5, 21, 13, 33, 50, 168, DateTimeKind.Local).AddTicks(3705), 5, 4, 4 },
                    { 14, new DateTime(2021, 5, 21, 13, 33, 50, 168, DateTimeKind.Local).AddTicks(3702), new DateTime(2021, 5, 21, 13, 33, 50, 168, DateTimeKind.Local).AddTicks(3702), 15, 4, 3 },
                    { 13, new DateTime(2021, 5, 21, 13, 33, 50, 168, DateTimeKind.Local).AddTicks(3699), new DateTime(2021, 5, 21, 13, 33, 50, 168, DateTimeKind.Local).AddTicks(3699), 5, 4, 2 },
                    { 12, new DateTime(2021, 5, 21, 13, 33, 50, 168, DateTimeKind.Local).AddTicks(3696), new DateTime(2021, 5, 21, 13, 33, 50, 168, DateTimeKind.Local).AddTicks(3696), 15, 4, 1 },
                    { 10, new DateTime(2021, 5, 21, 13, 33, 50, 168, DateTimeKind.Local).AddTicks(3690), new DateTime(2021, 5, 21, 13, 33, 50, 168, DateTimeKind.Local).AddTicks(3690), 15, 3, 28 },
                    { 7, new DateTime(2021, 5, 21, 13, 33, 50, 168, DateTimeKind.Local).AddTicks(3681), new DateTime(2021, 5, 21, 13, 33, 50, 168, DateTimeKind.Local).AddTicks(3681), 5, 2, 13 },
                    { 1, new DateTime(2021, 5, 21, 13, 33, 50, 168, DateTimeKind.Local).AddTicks(1986), new DateTime(2021, 5, 21, 13, 33, 50, 168, DateTimeKind.Local).AddTicks(1986), 5, 1, 1 },
                    { 20, new DateTime(2021, 5, 21, 13, 33, 50, 168, DateTimeKind.Local).AddTicks(3719), new DateTime(2021, 5, 21, 13, 33, 50, 168, DateTimeKind.Local).AddTicks(3719), 15, 6, 30 },
                    { 19, new DateTime(2021, 5, 21, 13, 33, 50, 168, DateTimeKind.Local).AddTicks(3717), new DateTime(2021, 5, 21, 13, 33, 50, 168, DateTimeKind.Local).AddTicks(3717), 1, 6, 5 },
                    { 18, new DateTime(2021, 5, 21, 13, 33, 50, 168, DateTimeKind.Local).AddTicks(3714), new DateTime(2021, 5, 21, 13, 33, 50, 168, DateTimeKind.Local).AddTicks(3714), 15, 5, 18 },
                    { 2, new DateTime(2021, 5, 21, 13, 33, 50, 168, DateTimeKind.Local).AddTicks(3575), new DateTime(2021, 5, 21, 13, 33, 50, 168, DateTimeKind.Local).AddTicks(3575), 15, 1, 2 },
                    { 3, new DateTime(2021, 5, 21, 13, 33, 50, 168, DateTimeKind.Local).AddTicks(3667), new DateTime(2021, 5, 21, 13, 33, 50, 168, DateTimeKind.Local).AddTicks(3667), 5, 1, 3 },
                    { 4, new DateTime(2021, 5, 21, 13, 33, 50, 168, DateTimeKind.Local).AddTicks(3672), new DateTime(2021, 5, 21, 13, 33, 50, 168, DateTimeKind.Local).AddTicks(3672), 5, 1, 5 },
                    { 5, new DateTime(2021, 5, 21, 13, 33, 50, 168, DateTimeKind.Local).AddTicks(3675), new DateTime(2021, 5, 21, 13, 33, 50, 168, DateTimeKind.Local).AddTicks(3675), 5, 2, 6 },
                    { 6, new DateTime(2021, 5, 21, 13, 33, 50, 168, DateTimeKind.Local).AddTicks(3678), new DateTime(2021, 5, 21, 13, 33, 50, 168, DateTimeKind.Local).AddTicks(3678), 15, 2, 7 },
                    { 16, new DateTime(2021, 5, 21, 13, 33, 50, 168, DateTimeKind.Local).AddTicks(3708), new DateTime(2021, 5, 21, 13, 33, 50, 168, DateTimeKind.Local).AddTicks(3708), 3, 5, 32 },
                    { 17, new DateTime(2021, 5, 21, 13, 33, 50, 168, DateTimeKind.Local).AddTicks(3711), new DateTime(2021, 5, 21, 13, 33, 50, 168, DateTimeKind.Local).AddTicks(3711), 5, 5, 17 }
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
