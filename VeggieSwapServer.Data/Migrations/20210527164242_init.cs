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
                    { 1, new DateTime(2021, 5, 27, 18, 42, 42, 249, DateTimeKind.Local).AddTicks(9388), "apples.svg", new DateTime(2021, 5, 27, 18, 42, 42, 249, DateTimeKind.Local).AddTicks(9388), "apples" },
                    { 29, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(380), "olives.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(380), "olives" },
                    { 30, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(383), "oranges.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(383), "oranges" },
                    { 31, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(385), "papayas.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(385), "papayas" },
                    { 32, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(387), "peaches.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(387), "peaches" },
                    { 33, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(390), "pears.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(390), "pears" },
                    { 34, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(392), "peas.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(392), "peas" },
                    { 35, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(394), "pineapples.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(394), "pineapples" },
                    { 36, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(397), "pomegranates.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(397), "pomegranates" },
                    { 38, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(401), "pumpkins.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(401), "pumpkins" },
                    { 39, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(403), "radish.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(403), "radish" },
                    { 28, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(378), "mushrooms.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(378), "mushrooms" },
                    { 40, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(406), "radishes.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(406), "radishes" },
                    { 42, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(410), "salad.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(410), "salad" },
                    { 43, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(412), "salads.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(412), "salads" },
                    { 44, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(415), "scallions.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(415), "scallions" },
                    { 45, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(417), "spinach.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(417), "spinach" },
                    { 46, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(419), "star-fruits.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(419), "star-fruits" },
                    { 47, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(421), "strawberries.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(421), "strawberries" },
                    { 48, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(424), "sweet-potatoes.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(424), "sweet-potatoes" },
                    { 49, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(426), "tomatoes.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(426), "tomatoes" },
                    { 50, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(428), "watermelons.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(428), "watermelons" },
                    { 51, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(430), "v-coin.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(430), "v-coin" },
                    { 41, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(408), "raspberries.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(408), "raspberries" },
                    { 27, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(376), "melons.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(376), "melons" },
                    { 37, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(399), "potatoes.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(399), "potatoes" },
                    { 25, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(371), "mangos.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(371), "mangos" },
                    { 2, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(305), "artichokes.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(305), "artichokes" },
                    { 26, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(374), "mangosteens.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(374), "mangosteens" },
                    { 4, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(321), "bananas.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(321), "bananas" },
                    { 5, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(324), "bell-peppers.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(324), "bell-peppers" },
                    { 6, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(327), "blueberries.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(327), "blueberries" },
                    { 7, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(329), "bok-choy.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(329), "bok-choy" },
                    { 8, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(331), "broccoli.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(331), "broccoli" },
                    { 9, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(334), "brussels-sprouts.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(334), "brussels-sprouts" },
                    { 10, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(336), "carrots.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(336), "carrots" },
                    { 11, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(339), "cherries.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(339), "cherries" },
                    { 12, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(341), "chilis.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(341), "chilis" },
                    { 13, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(343), "coconuts.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(343), "coconuts" },
                    { 3, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(319), "asparagus.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(319), "asparagus" },
                    { 15, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(348), "corn.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(348), "corn" },
                    { 14, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(346), "coriander.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(346), "coriander" }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreatedAt", "ImageUrl", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 23, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(367), "kiwis.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(367), "kiwis" },
                    { 22, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(364), "guavas.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(364), "guavas" },
                    { 21, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(362), "grapes.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(362), "grapes" },
                    { 20, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(360), "garlic.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(360), "garlic" },
                    { 24, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(369), "lemons.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(369), "lemons" },
                    { 18, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(355), "durians.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(355), "durians" },
                    { 17, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(353), "dragon-fruits.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(353), "dragon-fruits" },
                    { 16, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(351), "cucumbers.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(351), "cucumbers" },
                    { 19, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(358), "eggplants.svg", new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(358), "eggplants" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "ImageUrl", "IsAdmin", "LastName", "ModifiedAt", "PasswordHash", "PasswordSalt" },
                values: new object[,]
                {
                    { 12, new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(8044), "Simon@mail.com", "Simon", "Dries2", false, "Lidllover", new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(8044), new byte[] { 177, 163, 26, 152, 71, 224, 230, 175, 11, 180, 12, 162, 198, 70, 5, 63, 70, 49, 170, 226, 244, 112, 226, 170, 170, 78, 255, 240, 10, 177, 50, 52, 122, 60, 248, 40, 121, 45, 177, 7, 115, 65, 252, 214, 176, 136, 192, 27, 76, 58, 195, 143, 139, 2, 242, 159, 157, 53, 85, 116, 44, 17, 7, 47 }, new byte[] { 52, 181, 106, 30, 62, 90, 202, 6, 204, 19, 74, 72, 246, 129, 115, 201, 248, 255, 62, 250, 131, 213, 92, 87, 132, 21, 132, 174, 240, 99, 22, 234, 217, 148, 21, 127, 90, 25, 36, 26, 210, 154, 44, 209, 165, 211, 45, 134, 223, 72, 166, 154, 38, 59, 94, 54, 133, 83, 72, 134, 35, 91, 145, 24, 126, 206, 182, 184, 209, 75, 86, 213, 169, 83, 199, 212, 125, 162, 194, 115, 137, 121, 196, 86, 48, 130, 158, 71, 69, 226, 50, 16, 174, 54, 254, 18, 184, 3, 231, 177, 170, 32, 193, 91, 223, 116, 255, 191, 8, 208, 87, 111, 21, 113, 13, 126, 232, 204, 33, 191, 34, 132, 66, 124, 53, 120, 193, 19 } },
                    { 19, new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(8135), "Karolien@mail.com", "Karolien", "78", false, "Vdabpolitie", new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(8135), new byte[] { 177, 163, 26, 152, 71, 224, 230, 175, 11, 180, 12, 162, 198, 70, 5, 63, 70, 49, 170, 226, 244, 112, 226, 170, 170, 78, 255, 240, 10, 177, 50, 52, 122, 60, 248, 40, 121, 45, 177, 7, 115, 65, 252, 214, 176, 136, 192, 27, 76, 58, 195, 143, 139, 2, 242, 159, 157, 53, 85, 116, 44, 17, 7, 47 }, new byte[] { 52, 181, 106, 30, 62, 90, 202, 6, 204, 19, 74, 72, 246, 129, 115, 201, 248, 255, 62, 250, 131, 213, 92, 87, 132, 21, 132, 174, 240, 99, 22, 234, 217, 148, 21, 127, 90, 25, 36, 26, 210, 154, 44, 209, 165, 211, 45, 134, 223, 72, 166, 154, 38, 59, 94, 54, 133, 83, 72, 134, 35, 91, 145, 24, 126, 206, 182, 184, 209, 75, 86, 213, 169, 83, 199, 212, 125, 162, 194, 115, 137, 121, 196, 86, 48, 130, 158, 71, 69, 226, 50, 16, 174, 54, 254, 18, 184, 3, 231, 177, 170, 32, 193, 91, 223, 116, 255, 191, 8, 208, 87, 111, 21, 113, 13, 126, 232, 204, 33, 191, 34, 132, 66, 124, 53, 120, 193, 19 } },
                    { 18, new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(8122), "Joke@mail.com", "Joke", "24", false, "LidlAnnoying", new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(8122), new byte[] { 177, 163, 26, 152, 71, 224, 230, 175, 11, 180, 12, 162, 198, 70, 5, 63, 70, 49, 170, 226, 244, 112, 226, 170, 170, 78, 255, 240, 10, 177, 50, 52, 122, 60, 248, 40, 121, 45, 177, 7, 115, 65, 252, 214, 176, 136, 192, 27, 76, 58, 195, 143, 139, 2, 242, 159, 157, 53, 85, 116, 44, 17, 7, 47 }, new byte[] { 52, 181, 106, 30, 62, 90, 202, 6, 204, 19, 74, 72, 246, 129, 115, 201, 248, 255, 62, 250, 131, 213, 92, 87, 132, 21, 132, 174, 240, 99, 22, 234, 217, 148, 21, 127, 90, 25, 36, 26, 210, 154, 44, 209, 165, 211, 45, 134, 223, 72, 166, 154, 38, 59, 94, 54, 133, 83, 72, 134, 35, 91, 145, 24, 126, 206, 182, 184, 209, 75, 86, 213, 169, 83, 199, 212, 125, 162, 194, 115, 137, 121, 196, 86, 48, 130, 158, 71, 69, 226, 50, 16, 174, 54, 254, 18, 184, 3, 231, 177, 170, 32, 193, 91, 223, 116, 255, 191, 8, 208, 87, 111, 21, 113, 13, 126, 232, 204, 33, 191, 34, 132, 66, 124, 53, 120, 193, 19 } },
                    { 17, new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(8109), "Sien@mail.com", "Sien", "57", false, "Rommeltje", new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(8109), new byte[] { 177, 163, 26, 152, 71, 224, 230, 175, 11, 180, 12, 162, 198, 70, 5, 63, 70, 49, 170, 226, 244, 112, 226, 170, 170, 78, 255, 240, 10, 177, 50, 52, 122, 60, 248, 40, 121, 45, 177, 7, 115, 65, 252, 214, 176, 136, 192, 27, 76, 58, 195, 143, 139, 2, 242, 159, 157, 53, 85, 116, 44, 17, 7, 47 }, new byte[] { 52, 181, 106, 30, 62, 90, 202, 6, 204, 19, 74, 72, 246, 129, 115, 201, 248, 255, 62, 250, 131, 213, 92, 87, 132, 21, 132, 174, 240, 99, 22, 234, 217, 148, 21, 127, 90, 25, 36, 26, 210, 154, 44, 209, 165, 211, 45, 134, 223, 72, 166, 154, 38, 59, 94, 54, 133, 83, 72, 134, 35, 91, 145, 24, 126, 206, 182, 184, 209, 75, 86, 213, 169, 83, 199, 212, 125, 162, 194, 115, 137, 121, 196, 86, 48, 130, 158, 71, 69, 226, 50, 16, 174, 54, 254, 18, 184, 3, 231, 177, 170, 32, 193, 91, 223, 116, 255, 191, 8, 208, 87, 111, 21, 113, 13, 126, 232, 204, 33, 191, 34, 132, 66, 124, 53, 120, 193, 19 } },
                    { 16, new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(8096), "Emma@mail.com", "Emma", "45", false, "Schoonkind", new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(8096), new byte[] { 177, 163, 26, 152, 71, 224, 230, 175, 11, 180, 12, 162, 198, 70, 5, 63, 70, 49, 170, 226, 244, 112, 226, 170, 170, 78, 255, 240, 10, 177, 50, 52, 122, 60, 248, 40, 121, 45, 177, 7, 115, 65, 252, 214, 176, 136, 192, 27, 76, 58, 195, 143, 139, 2, 242, 159, 157, 53, 85, 116, 44, 17, 7, 47 }, new byte[] { 52, 181, 106, 30, 62, 90, 202, 6, 204, 19, 74, 72, 246, 129, 115, 201, 248, 255, 62, 250, 131, 213, 92, 87, 132, 21, 132, 174, 240, 99, 22, 234, 217, 148, 21, 127, 90, 25, 36, 26, 210, 154, 44, 209, 165, 211, 45, 134, 223, 72, 166, 154, 38, 59, 94, 54, 133, 83, 72, 134, 35, 91, 145, 24, 126, 206, 182, 184, 209, 75, 86, 213, 169, 83, 199, 212, 125, 162, 194, 115, 137, 121, 196, 86, 48, 130, 158, 71, 69, 226, 50, 16, 174, 54, 254, 18, 184, 3, 231, 177, 170, 32, 193, 91, 223, 116, 255, 191, 8, 208, 87, 111, 21, 113, 13, 126, 232, 204, 33, 191, 34, 132, 66, 124, 53, 120, 193, 19 } },
                    { 15, new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(8083), "Anke@mail.com", "Anke", "27", false, "Kleurenkenner", new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(8083), new byte[] { 177, 163, 26, 152, 71, 224, 230, 175, 11, 180, 12, 162, 198, 70, 5, 63, 70, 49, 170, 226, 244, 112, 226, 170, 170, 78, 255, 240, 10, 177, 50, 52, 122, 60, 248, 40, 121, 45, 177, 7, 115, 65, 252, 214, 176, 136, 192, 27, 76, 58, 195, 143, 139, 2, 242, 159, 157, 53, 85, 116, 44, 17, 7, 47 }, new byte[] { 52, 181, 106, 30, 62, 90, 202, 6, 204, 19, 74, 72, 246, 129, 115, 201, 248, 255, 62, 250, 131, 213, 92, 87, 132, 21, 132, 174, 240, 99, 22, 234, 217, 148, 21, 127, 90, 25, 36, 26, 210, 154, 44, 209, 165, 211, 45, 134, 223, 72, 166, 154, 38, 59, 94, 54, 133, 83, 72, 134, 35, 91, 145, 24, 126, 206, 182, 184, 209, 75, 86, 213, 169, 83, 199, 212, 125, 162, 194, 115, 137, 121, 196, 86, 48, 130, 158, 71, 69, 226, 50, 16, 174, 54, 254, 18, 184, 3, 231, 177, 170, 32, 193, 91, 223, 116, 255, 191, 8, 208, 87, 111, 21, 113, 13, 126, 232, 204, 33, 191, 34, 132, 66, 124, 53, 120, 193, 19 } },
                    { 20, new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(8148), "Hoon@mail.com", "Hoon", "99", false, "Tomatenplukker", new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(8148), new byte[] { 177, 163, 26, 152, 71, 224, 230, 175, 11, 180, 12, 162, 198, 70, 5, 63, 70, 49, 170, 226, 244, 112, 226, 170, 170, 78, 255, 240, 10, 177, 50, 52, 122, 60, 248, 40, 121, 45, 177, 7, 115, 65, 252, 214, 176, 136, 192, 27, 76, 58, 195, 143, 139, 2, 242, 159, 157, 53, 85, 116, 44, 17, 7, 47 }, new byte[] { 52, 181, 106, 30, 62, 90, 202, 6, 204, 19, 74, 72, 246, 129, 115, 201, 248, 255, 62, 250, 131, 213, 92, 87, 132, 21, 132, 174, 240, 99, 22, 234, 217, 148, 21, 127, 90, 25, 36, 26, 210, 154, 44, 209, 165, 211, 45, 134, 223, 72, 166, 154, 38, 59, 94, 54, 133, 83, 72, 134, 35, 91, 145, 24, 126, 206, 182, 184, 209, 75, 86, 213, 169, 83, 199, 212, 125, 162, 194, 115, 137, 121, 196, 86, 48, 130, 158, 71, 69, 226, 50, 16, 174, 54, 254, 18, 184, 3, 231, 177, 170, 32, 193, 91, 223, 116, 255, 191, 8, 208, 87, 111, 21, 113, 13, 126, 232, 204, 33, 191, 34, 132, 66, 124, 53, 120, 193, 19 } },
                    { 14, new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(8070), "Marieke@mail.com", "Marieke", "T1", false, "Van Leren Broeke", new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(8070), new byte[] { 177, 163, 26, 152, 71, 224, 230, 175, 11, 180, 12, 162, 198, 70, 5, 63, 70, 49, 170, 226, 244, 112, 226, 170, 170, 78, 255, 240, 10, 177, 50, 52, 122, 60, 248, 40, 121, 45, 177, 7, 115, 65, 252, 214, 176, 136, 192, 27, 76, 58, 195, 143, 139, 2, 242, 159, 157, 53, 85, 116, 44, 17, 7, 47 }, new byte[] { 52, 181, 106, 30, 62, 90, 202, 6, 204, 19, 74, 72, 246, 129, 115, 201, 248, 255, 62, 250, 131, 213, 92, 87, 132, 21, 132, 174, 240, 99, 22, 234, 217, 148, 21, 127, 90, 25, 36, 26, 210, 154, 44, 209, 165, 211, 45, 134, 223, 72, 166, 154, 38, 59, 94, 54, 133, 83, 72, 134, 35, 91, 145, 24, 126, 206, 182, 184, 209, 75, 86, 213, 169, 83, 199, 212, 125, 162, 194, 115, 137, 121, 196, 86, 48, 130, 158, 71, 69, 226, 50, 16, 174, 54, 254, 18, 184, 3, 231, 177, 170, 32, 193, 91, 223, 116, 255, 191, 8, 208, 87, 111, 21, 113, 13, 126, 232, 204, 33, 191, 34, 132, 66, 124, 53, 120, 193, 19 } },
                    { 13, new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(8057), "Joyce@mail.com", "Joyce", "75", false, "Recruiter", new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(8057), new byte[] { 177, 163, 26, 152, 71, 224, 230, 175, 11, 180, 12, 162, 198, 70, 5, 63, 70, 49, 170, 226, 244, 112, 226, 170, 170, 78, 255, 240, 10, 177, 50, 52, 122, 60, 248, 40, 121, 45, 177, 7, 115, 65, 252, 214, 176, 136, 192, 27, 76, 58, 195, 143, 139, 2, 242, 159, 157, 53, 85, 116, 44, 17, 7, 47 }, new byte[] { 52, 181, 106, 30, 62, 90, 202, 6, 204, 19, 74, 72, 246, 129, 115, 201, 248, 255, 62, 250, 131, 213, 92, 87, 132, 21, 132, 174, 240, 99, 22, 234, 217, 148, 21, 127, 90, 25, 36, 26, 210, 154, 44, 209, 165, 211, 45, 134, 223, 72, 166, 154, 38, 59, 94, 54, 133, 83, 72, 134, 35, 91, 145, 24, 126, 206, 182, 184, 209, 75, 86, 213, 169, 83, 199, 212, 125, 162, 194, 115, 137, 121, 196, 86, 48, 130, 158, 71, 69, 226, 50, 16, 174, 54, 254, 18, 184, 3, 231, 177, 170, 32, 193, 91, 223, 116, 255, 191, 8, 208, 87, 111, 21, 113, 13, 126, 232, 204, 33, 191, 34, 132, 66, 124, 53, 120, 193, 19 } },
                    { 11, new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(8029), "Jens@mail.com", "Jens", "Zeemlap", false, "Spinning", new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(8029), new byte[] { 177, 163, 26, 152, 71, 224, 230, 175, 11, 180, 12, 162, 198, 70, 5, 63, 70, 49, 170, 226, 244, 112, 226, 170, 170, 78, 255, 240, 10, 177, 50, 52, 122, 60, 248, 40, 121, 45, 177, 7, 115, 65, 252, 214, 176, 136, 192, 27, 76, 58, 195, 143, 139, 2, 242, 159, 157, 53, 85, 116, 44, 17, 7, 47 }, new byte[] { 52, 181, 106, 30, 62, 90, 202, 6, 204, 19, 74, 72, 246, 129, 115, 201, 248, 255, 62, 250, 131, 213, 92, 87, 132, 21, 132, 174, 240, 99, 22, 234, 217, 148, 21, 127, 90, 25, 36, 26, 210, 154, 44, 209, 165, 211, 45, 134, 223, 72, 166, 154, 38, 59, 94, 54, 133, 83, 72, 134, 35, 91, 145, 24, 126, 206, 182, 184, 209, 75, 86, 213, 169, 83, 199, 212, 125, 162, 194, 115, 137, 121, 196, 86, 48, 130, 158, 71, 69, 226, 50, 16, 174, 54, 254, 18, 184, 3, 231, 177, 170, 32, 193, 91, 223, 116, 255, 191, 8, 208, 87, 111, 21, 113, 13, 126, 232, 204, 33, 191, 34, 132, 66, 124, 53, 120, 193, 19 } },
                    { 6, new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(7926), "Emma@mail.com", "Emma", "Stofzuiger", false, "Kipdorp", new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(7926), new byte[] { 177, 163, 26, 152, 71, 224, 230, 175, 11, 180, 12, 162, 198, 70, 5, 63, 70, 49, 170, 226, 244, 112, 226, 170, 170, 78, 255, 240, 10, 177, 50, 52, 122, 60, 248, 40, 121, 45, 177, 7, 115, 65, 252, 214, 176, 136, 192, 27, 76, 58, 195, 143, 139, 2, 242, 159, 157, 53, 85, 116, 44, 17, 7, 47 }, new byte[] { 52, 181, 106, 30, 62, 90, 202, 6, 204, 19, 74, 72, 246, 129, 115, 201, 248, 255, 62, 250, 131, 213, 92, 87, 132, 21, 132, 174, 240, 99, 22, 234, 217, 148, 21, 127, 90, 25, 36, 26, 210, 154, 44, 209, 165, 211, 45, 134, 223, 72, 166, 154, 38, 59, 94, 54, 133, 83, 72, 134, 35, 91, 145, 24, 126, 206, 182, 184, 209, 75, 86, 213, 169, 83, 199, 212, 125, 162, 194, 115, 137, 121, 196, 86, 48, 130, 158, 71, 69, 226, 50, 16, 174, 54, 254, 18, 184, 3, 231, 177, 170, 32, 193, 91, 223, 116, 255, 191, 8, 208, 87, 111, 21, 113, 13, 126, 232, 204, 33, 191, 34, 132, 66, 124, 53, 120, 193, 19 } },
                    { 9, new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(7965), "Michiel@mail.com", "Michiel", "g283?set=set4", false, "Demogod", new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(7965), new byte[] { 177, 163, 26, 152, 71, 224, 230, 175, 11, 180, 12, 162, 198, 70, 5, 63, 70, 49, 170, 226, 244, 112, 226, 170, 170, 78, 255, 240, 10, 177, 50, 52, 122, 60, 248, 40, 121, 45, 177, 7, 115, 65, 252, 214, 176, 136, 192, 27, 76, 58, 195, 143, 139, 2, 242, 159, 157, 53, 85, 116, 44, 17, 7, 47 }, new byte[] { 52, 181, 106, 30, 62, 90, 202, 6, 204, 19, 74, 72, 246, 129, 115, 201, 248, 255, 62, 250, 131, 213, 92, 87, 132, 21, 132, 174, 240, 99, 22, 234, 217, 148, 21, 127, 90, 25, 36, 26, 210, 154, 44, 209, 165, 211, 45, 134, 223, 72, 166, 154, 38, 59, 94, 54, 133, 83, 72, 134, 35, 91, 145, 24, 126, 206, 182, 184, 209, 75, 86, 213, 169, 83, 199, 212, 125, 162, 194, 115, 137, 121, 196, 86, 48, 130, 158, 71, 69, 226, 50, 16, 174, 54, 254, 18, 184, 3, 231, 177, 170, 32, 193, 91, 223, 116, 255, 191, 8, 208, 87, 111, 21, 113, 13, 126, 232, 204, 33, 191, 34, 132, 66, 124, 53, 120, 193, 19 } },
                    { 8, new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(7952), "Andreas@mail.com", "Andreas", "Andreas", false, "VanGrieken", new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(7952), new byte[] { 177, 163, 26, 152, 71, 224, 230, 175, 11, 180, 12, 162, 198, 70, 5, 63, 70, 49, 170, 226, 244, 112, 226, 170, 170, 78, 255, 240, 10, 177, 50, 52, 122, 60, 248, 40, 121, 45, 177, 7, 115, 65, 252, 214, 176, 136, 192, 27, 76, 58, 195, 143, 139, 2, 242, 159, 157, 53, 85, 116, 44, 17, 7, 47 }, new byte[] { 52, 181, 106, 30, 62, 90, 202, 6, 204, 19, 74, 72, 246, 129, 115, 201, 248, 255, 62, 250, 131, 213, 92, 87, 132, 21, 132, 174, 240, 99, 22, 234, 217, 148, 21, 127, 90, 25, 36, 26, 210, 154, 44, 209, 165, 211, 45, 134, 223, 72, 166, 154, 38, 59, 94, 54, 133, 83, 72, 134, 35, 91, 145, 24, 126, 206, 182, 184, 209, 75, 86, 213, 169, 83, 199, 212, 125, 162, 194, 115, 137, 121, 196, 86, 48, 130, 158, 71, 69, 226, 50, 16, 174, 54, 254, 18, 184, 3, 231, 177, 170, 32, 193, 91, 223, 116, 255, 191, 8, 208, 87, 111, 21, 113, 13, 126, 232, 204, 33, 191, 34, 132, 66, 124, 53, 120, 193, 19 } },
                    { 7, new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(7939), "Ward@mail.com", "Ward", "Dirk", false, "Motormouth", new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(7939), new byte[] { 177, 163, 26, 152, 71, 224, 230, 175, 11, 180, 12, 162, 198, 70, 5, 63, 70, 49, 170, 226, 244, 112, 226, 170, 170, 78, 255, 240, 10, 177, 50, 52, 122, 60, 248, 40, 121, 45, 177, 7, 115, 65, 252, 214, 176, 136, 192, 27, 76, 58, 195, 143, 139, 2, 242, 159, 157, 53, 85, 116, 44, 17, 7, 47 }, new byte[] { 52, 181, 106, 30, 62, 90, 202, 6, 204, 19, 74, 72, 246, 129, 115, 201, 248, 255, 62, 250, 131, 213, 92, 87, 132, 21, 132, 174, 240, 99, 22, 234, 217, 148, 21, 127, 90, 25, 36, 26, 210, 154, 44, 209, 165, 211, 45, 134, 223, 72, 166, 154, 38, 59, 94, 54, 133, 83, 72, 134, 35, 91, 145, 24, 126, 206, 182, 184, 209, 75, 86, 213, 169, 83, 199, 212, 125, 162, 194, 115, 137, 121, 196, 86, 48, 130, 158, 71, 69, 226, 50, 16, 174, 54, 254, 18, 184, 3, 231, 177, 170, 32, 193, 91, 223, 116, 255, 191, 8, 208, 87, 111, 21, 113, 13, 126, 232, 204, 33, 191, 34, 132, 66, 124, 53, 120, 193, 19 } },
                    { 5, new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(7913), "Seba@mail.com", "Seba", "BartjeWevertje", false, "Alwayszen", new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(7913), new byte[] { 177, 163, 26, 152, 71, 224, 230, 175, 11, 180, 12, 162, 198, 70, 5, 63, 70, 49, 170, 226, 244, 112, 226, 170, 170, 78, 255, 240, 10, 177, 50, 52, 122, 60, 248, 40, 121, 45, 177, 7, 115, 65, 252, 214, 176, 136, 192, 27, 76, 58, 195, 143, 139, 2, 242, 159, 157, 53, 85, 116, 44, 17, 7, 47 }, new byte[] { 52, 181, 106, 30, 62, 90, 202, 6, 204, 19, 74, 72, 246, 129, 115, 201, 248, 255, 62, 250, 131, 213, 92, 87, 132, 21, 132, 174, 240, 99, 22, 234, 217, 148, 21, 127, 90, 25, 36, 26, 210, 154, 44, 209, 165, 211, 45, 134, 223, 72, 166, 154, 38, 59, 94, 54, 133, 83, 72, 134, 35, 91, 145, 24, 126, 206, 182, 184, 209, 75, 86, 213, 169, 83, 199, 212, 125, 162, 194, 115, 137, 121, 196, 86, 48, 130, 158, 71, 69, 226, 50, 16, 174, 54, 254, 18, 184, 3, 231, 177, 170, 32, 193, 91, 223, 116, 255, 191, 8, 208, 87, 111, 21, 113, 13, 126, 232, 204, 33, 191, 34, 132, 66, 124, 53, 120, 193, 19 } },
                    { 4, new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(7900), "Dries@mail.com", "Dries", "Dries", true, "Promailer", new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(7900), new byte[] { 177, 163, 26, 152, 71, 224, 230, 175, 11, 180, 12, 162, 198, 70, 5, 63, 70, 49, 170, 226, 244, 112, 226, 170, 170, 78, 255, 240, 10, 177, 50, 52, 122, 60, 248, 40, 121, 45, 177, 7, 115, 65, 252, 214, 176, 136, 192, 27, 76, 58, 195, 143, 139, 2, 242, 159, 157, 53, 85, 116, 44, 17, 7, 47 }, new byte[] { 52, 181, 106, 30, 62, 90, 202, 6, 204, 19, 74, 72, 246, 129, 115, 201, 248, 255, 62, 250, 131, 213, 92, 87, 132, 21, 132, 174, 240, 99, 22, 234, 217, 148, 21, 127, 90, 25, 36, 26, 210, 154, 44, 209, 165, 211, 45, 134, 223, 72, 166, 154, 38, 59, 94, 54, 133, 83, 72, 134, 35, 91, 145, 24, 126, 206, 182, 184, 209, 75, 86, 213, 169, 83, 199, 212, 125, 162, 194, 115, 137, 121, 196, 86, 48, 130, 158, 71, 69, 226, 50, 16, 174, 54, 254, 18, 184, 3, 231, 177, 170, 32, 193, 91, 223, 116, 255, 191, 8, 208, 87, 111, 21, 113, 13, 126, 232, 204, 33, 191, 34, 132, 66, 124, 53, 120, 193, 19 } },
                    { 3, new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(7878), "Kobe@mail.com", "Kobe", "Kobe", true, "Neut", new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(7878), new byte[] { 177, 163, 26, 152, 71, 224, 230, 175, 11, 180, 12, 162, 198, 70, 5, 63, 70, 49, 170, 226, 244, 112, 226, 170, 170, 78, 255, 240, 10, 177, 50, 52, 122, 60, 248, 40, 121, 45, 177, 7, 115, 65, 252, 214, 176, 136, 192, 27, 76, 58, 195, 143, 139, 2, 242, 159, 157, 53, 85, 116, 44, 17, 7, 47 }, new byte[] { 52, 181, 106, 30, 62, 90, 202, 6, 204, 19, 74, 72, 246, 129, 115, 201, 248, 255, 62, 250, 131, 213, 92, 87, 132, 21, 132, 174, 240, 99, 22, 234, 217, 148, 21, 127, 90, 25, 36, 26, 210, 154, 44, 209, 165, 211, 45, 134, 223, 72, 166, 154, 38, 59, 94, 54, 133, 83, 72, 134, 35, 91, 145, 24, 126, 206, 182, 184, 209, 75, 86, 213, 169, 83, 199, 212, 125, 162, 194, 115, 137, 121, 196, 86, 48, 130, 158, 71, 69, 226, 50, 16, 174, 54, 254, 18, 184, 3, 231, 177, 170, 32, 193, 91, 223, 116, 255, 191, 8, 208, 87, 111, 21, 113, 13, 126, 232, 204, 33, 191, 34, 132, 66, 124, 53, 120, 193, 19 } },
                    { 2, new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(7629), "Nick@mail.com", "Nick", "Nick", true, "Angularlover", new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(7629), new byte[] { 177, 163, 26, 152, 71, 224, 230, 175, 11, 180, 12, 162, 198, 70, 5, 63, 70, 49, 170, 226, 244, 112, 226, 170, 170, 78, 255, 240, 10, 177, 50, 52, 122, 60, 248, 40, 121, 45, 177, 7, 115, 65, 252, 214, 176, 136, 192, 27, 76, 58, 195, 143, 139, 2, 242, 159, 157, 53, 85, 116, 44, 17, 7, 47 }, new byte[] { 52, 181, 106, 30, 62, 90, 202, 6, 204, 19, 74, 72, 246, 129, 115, 201, 248, 255, 62, 250, 131, 213, 92, 87, 132, 21, 132, 174, 240, 99, 22, 234, 217, 148, 21, 127, 90, 25, 36, 26, 210, 154, 44, 209, 165, 211, 45, 134, 223, 72, 166, 154, 38, 59, 94, 54, 133, 83, 72, 134, 35, 91, 145, 24, 126, 206, 182, 184, 209, 75, 86, 213, 169, 83, 199, 212, 125, 162, 194, 115, 137, 121, 196, 86, 48, 130, 158, 71, 69, 226, 50, 16, 174, 54, 254, 18, 184, 3, 231, 177, 170, 32, 193, 91, 223, 116, 255, 191, 8, 208, 87, 111, 21, 113, 13, 126, 232, 204, 33, 191, 34, 132, 66, 124, 53, 120, 193, 19 } },
                    { 1, new DateTime(2021, 5, 27, 18, 42, 42, 242, DateTimeKind.Local).AddTicks(7176), "Pieter@mail.com", "Pieter", "Pieter", true, "Slaapkop", new DateTime(2021, 5, 27, 18, 42, 42, 242, DateTimeKind.Local).AddTicks(7176), new byte[] { 177, 163, 26, 152, 71, 224, 230, 175, 11, 180, 12, 162, 198, 70, 5, 63, 70, 49, 170, 226, 244, 112, 226, 170, 170, 78, 255, 240, 10, 177, 50, 52, 122, 60, 248, 40, 121, 45, 177, 7, 115, 65, 252, 214, 176, 136, 192, 27, 76, 58, 195, 143, 139, 2, 242, 159, 157, 53, 85, 116, 44, 17, 7, 47 }, new byte[] { 52, 181, 106, 30, 62, 90, 202, 6, 204, 19, 74, 72, 246, 129, 115, 201, 248, 255, 62, 250, 131, 213, 92, 87, 132, 21, 132, 174, 240, 99, 22, 234, 217, 148, 21, 127, 90, 25, 36, 26, 210, 154, 44, 209, 165, 211, 45, 134, 223, 72, 166, 154, 38, 59, 94, 54, 133, 83, 72, 134, 35, 91, 145, 24, 126, 206, 182, 184, 209, 75, 86, 213, 169, 83, 199, 212, 125, 162, 194, 115, 137, 121, 196, 86, 48, 130, 158, 71, 69, 226, 50, 16, 174, 54, 254, 18, 184, 3, 231, 177, 170, 32, 193, 91, 223, 116, 255, 191, 8, 208, 87, 111, 21, 113, 13, 126, 232, 204, 33, 191, 34, 132, 66, 124, 53, 120, 193, 19 } },
                    { 21, new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(8161), "Michaël@mail.com", "Michaël", "25", false, "Wanderer", new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(8161), new byte[] { 177, 163, 26, 152, 71, 224, 230, 175, 11, 180, 12, 162, 198, 70, 5, 63, 70, 49, 170, 226, 244, 112, 226, 170, 170, 78, 255, 240, 10, 177, 50, 52, 122, 60, 248, 40, 121, 45, 177, 7, 115, 65, 252, 214, 176, 136, 192, 27, 76, 58, 195, 143, 139, 2, 242, 159, 157, 53, 85, 116, 44, 17, 7, 47 }, new byte[] { 52, 181, 106, 30, 62, 90, 202, 6, 204, 19, 74, 72, 246, 129, 115, 201, 248, 255, 62, 250, 131, 213, 92, 87, 132, 21, 132, 174, 240, 99, 22, 234, 217, 148, 21, 127, 90, 25, 36, 26, 210, 154, 44, 209, 165, 211, 45, 134, 223, 72, 166, 154, 38, 59, 94, 54, 133, 83, 72, 134, 35, 91, 145, 24, 126, 206, 182, 184, 209, 75, 86, 213, 169, 83, 199, 212, 125, 162, 194, 115, 137, 121, 196, 86, 48, 130, 158, 71, 69, 226, 50, 16, 174, 54, 254, 18, 184, 3, 231, 177, 170, 32, 193, 91, 223, 116, 255, 191, 8, 208, 87, 111, 21, 113, 13, 126, 232, 204, 33, 191, 34, 132, 66, 124, 53, 120, 193, 19 } },
                    { 10, new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(7978), "Diederik@mail.com", "Diederik", "Luc", false, "Featurefixer", new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(7978), new byte[] { 177, 163, 26, 152, 71, 224, 230, 175, 11, 180, 12, 162, 198, 70, 5, 63, 70, 49, 170, 226, 244, 112, 226, 170, 170, 78, 255, 240, 10, 177, 50, 52, 122, 60, 248, 40, 121, 45, 177, 7, 115, 65, 252, 214, 176, 136, 192, 27, 76, 58, 195, 143, 139, 2, 242, 159, 157, 53, 85, 116, 44, 17, 7, 47 }, new byte[] { 52, 181, 106, 30, 62, 90, 202, 6, 204, 19, 74, 72, 246, 129, 115, 201, 248, 255, 62, 250, 131, 213, 92, 87, 132, 21, 132, 174, 240, 99, 22, 234, 217, 148, 21, 127, 90, 25, 36, 26, 210, 154, 44, 209, 165, 211, 45, 134, 223, 72, 166, 154, 38, 59, 94, 54, 133, 83, 72, 134, 35, 91, 145, 24, 126, 206, 182, 184, 209, 75, 86, 213, 169, 83, 199, 212, 125, 162, 194, 115, 137, 121, 196, 86, 48, 130, 158, 71, 69, 226, 50, 16, 174, 54, 254, 18, 184, 3, 231, 177, 170, 32, 193, 91, 223, 116, 255, 191, 8, 208, 87, 111, 21, 113, 13, 126, 232, 204, 33, 191, 34, 132, 66, 124, 53, 120, 193, 19 } },
                    { 22, new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(8174), "Brent@mail.com", "Brent", "29", false, "Tomatentrucker", new DateTime(2021, 5, 27, 18, 42, 42, 245, DateTimeKind.Local).AddTicks(8174), new byte[] { 177, 163, 26, 152, 71, 224, 230, 175, 11, 180, 12, 162, 198, 70, 5, 63, 70, 49, 170, 226, 244, 112, 226, 170, 170, 78, 255, 240, 10, 177, 50, 52, 122, 60, 248, 40, 121, 45, 177, 7, 115, 65, 252, 214, 176, 136, 192, 27, 76, 58, 195, 143, 139, 2, 242, 159, 157, 53, 85, 116, 44, 17, 7, 47 }, new byte[] { 52, 181, 106, 30, 62, 90, 202, 6, 204, 19, 74, 72, 246, 129, 115, 201, 248, 255, 62, 250, 131, 213, 92, 87, 132, 21, 132, 174, 240, 99, 22, 234, 217, 148, 21, 127, 90, 25, 36, 26, 210, 154, 44, 209, 165, 211, 45, 134, 223, 72, 166, 154, 38, 59, 94, 54, 133, 83, 72, 134, 35, 91, 145, 24, 126, 206, 182, 184, 209, 75, 86, 213, 169, 83, 199, 212, 125, 162, 194, 115, 137, 121, 196, 86, 48, 130, 158, 71, 69, 226, 50, 16, 174, 54, 254, 18, 184, 3, 231, 177, 170, 32, 193, 91, 223, 116, 255, 191, 8, 208, 87, 111, 21, 113, 13, 126, 232, 204, 33, 191, 34, 132, 66, 124, 53, 120, 193, 19 } }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "PostalCode", "StreetName", "StreetNumber", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(7366), new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(7366), 9000, "Anti-Veggiestraat", 89, 1 },
                    { 10, new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9102), new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9102), 9070, "Geenpolitiekstraat", 200, 10 },
                    { 12, new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9107), new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9107), 1000, "Blacklivesmatterstraat", 78, 12 },
                    { 9, new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9100), new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9100), 2000, "Greenlivesweg", 420, 9 },
                    { 8, new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9097), new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9097), 1000, "Kotsvisplein", 96, 8 },
                    { 13, new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9110), new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9110), 7000, "Worstenbroodjesstraat", 4, 13 },
                    { 7, new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9095), new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9095), 9050, "Greenpeacestraat", 1, 7 },
                    { 14, new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9112), new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9112), 9000, "Jurgenverstopstraat", 24, 14 },
                    { 6, new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9092), new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9092), 1000, "Spekmeteierenstraat", 43, 6 },
                    { 5, new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9090), new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9090), 9000, "Boerenworststraat", 85, 5 },
                    { 15, new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9114), new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9114), 1081, "Bloedworststraat", 78, 15 },
                    { 4, new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9087), new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9087), 1000, "Vleesbroodstraat", 66, 4 },
                    { 16, new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9117), new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9117), 1180, "Runderlendedreef", 36, 16 },
                    { 17, new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9119), new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9119), 1500, "Ribbetjesstraat", 14, 17 },
                    { 3, new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9084), new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9084), 4000, "Balletjesstraat", 74, 3 },
                    { 11, new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9105), new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9105), 9500, "Kalfslapjesstraat", 32, 11 },
                    { 19, new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9124), new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9124), 2323, "Lookbroodjesstraat", 11, 19 },
                    { 20, new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9126), new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9126), 2890, "Worstenbroodjesstraat", 79, 20 },
                    { 18, new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9121), new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9121), 2070, "Bickyburgerstraat", 15, 18 },
                    { 21, new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9128), new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9128), 3020, "Balletjesstraat", 100, 21 },
                    { 2, new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9070), new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9070), 3000, "Vrbaan", 45, 2 },
                    { 22, new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9131), new DateTime(2021, 5, 27, 18, 42, 42, 247, DateTimeKind.Local).AddTicks(9131), 3110, "Kalfsrib-eyelaan", 107, 22 }
                });

            migrationBuilder.InsertData(
                table: "TradeItems",
                columns: new[] { "Id", "Amount", "CreatedAt", "ModifiedAt", "ResourceId", "UserId" },
                values: new object[,]
                {
                    { 82, 52, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2564), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2564), 23, 21 },
                    { 54, 19, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2500), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2500), 12, 13 },
                    { 41, 17, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2470), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2470), 1, 11 },
                    { 53, 33, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2497), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2497), 35, 13 },
                    { 52, 22, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2495), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2495), 48, 13 },
                    { 51, 17, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2493), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2493), 47, 13 },
                    { 50, 17, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2491), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2491), 51, 13 },
                    { 80, 7, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2560), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2560), 17, 20 },
                    { 81, 13, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2562), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2562), 18, 20 },
                    { 49, 21, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2488), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2488), 12, 12 },
                    { 48, 17, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2486), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2486), 9, 12 },
                    { 55, 9, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2502), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2502), 7, 13 },
                    { 47, 34, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2484), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2484), 8, 12 },
                    { 46, 25, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2481), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2481), 47, 12 },
                    { 45, 12, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2479), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2479), 29, 12 },
                    { 42, 3, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2472), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2472), 3, 11 },
                    { 44, 78, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2477), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2477), 18, 12 },
                    { 43, 28, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2474), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2474), 7, 11 },
                    { 76, 80, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2551), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2551), 5, 17 },
                    { 57, 13, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2507), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2507), 29, 13 }
                });

            migrationBuilder.InsertData(
                table: "TradeItems",
                columns: new[] { "Id", "Amount", "CreatedAt", "ModifiedAt", "ResourceId", "UserId" },
                values: new object[,]
                {
                    { 75, 113, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2548), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2548), 3, 17 },
                    { 74, 78, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2546), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2546), 36, 16 },
                    { 73, 35, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2544), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2544), 38, 16 },
                    { 72, 24, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2541), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2541), 39, 16 },
                    { 77, 17, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2553), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2553), 6, 17 },
                    { 71, 1, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2539), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2539), 3, 15 },
                    { 70, 8, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2537), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2537), 51, 15 },
                    { 69, 153, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2535), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2535), 29, 15 },
                    { 68, 157, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2532), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2532), 22, 15 },
                    { 67, 19, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2530), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2530), 21, 15 },
                    { 56, 35, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2504), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2504), 8, 13 },
                    { 66, 78, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2528), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2528), 18, 15 },
                    { 65, 24, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2525), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2525), 17, 14 },
                    { 64, 88, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2523), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2523), 12, 14 },
                    { 83, 8, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2567), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2567), 26, 22 },
                    { 62, 39, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2518), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2518), 11, 14 },
                    { 61, 47, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2516), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2516), 8, 14 },
                    { 60, 19, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2514), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2514), 1, 14 },
                    { 79, 90, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2558), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2558), 44, 19 },
                    { 59, 17, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2511), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2511), 41, 13 },
                    { 58, 8, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2509), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2509), 38, 13 },
                    { 78, 99, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2555), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2555), 51, 19 },
                    { 63, 77, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2520), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2520), 9, 14 },
                    { 40, 33, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2467), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2467), 51, 11 },
                    { 39, 53, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2465), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2465), 19, 10 },
                    { 25, 5, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2432), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2432), 39, 6 },
                    { 24, 78, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2430), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2430), 32, 5 },
                    { 23, 38, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2428), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2428), 46, 5 },
                    { 22, 39, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2425), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2425), 17, 5 },
                    { 21, 63, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2423), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2423), 51, 5 },
                    { 20, 47, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2421), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2421), 7, 5 },
                    { 5, 41, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2386), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2386), 51, 2 },
                    { 19, 50, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2418), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2418), 51, 4 },
                    { 18, 36, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2416), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2416), 44, 4 },
                    { 17, 89, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2414), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2414), 21, 4 },
                    { 6, 30, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2388), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2388), 34, 2 },
                    { 16, 17, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2412), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2412), 31, 3 },
                    { 15, 30, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2409), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2409), 6, 3 },
                    { 7, 40, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2390), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2390), 46, 2 },
                    { 14, 49, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2407), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2407), 13, 3 },
                    { 13, 17, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2405), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2405), 8, 3 },
                    { 12, 20, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2402), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2402), 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "TradeItems",
                columns: new[] { "Id", "Amount", "CreatedAt", "ModifiedAt", "ResourceId", "UserId" },
                values: new object[,]
                {
                    { 11, 47, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2400), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2400), 51, 3 },
                    { 8, 5, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2393), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2393), 32, 2 },
                    { 10, 32, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2398), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2398), 15, 2 },
                    { 26, 10, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2435), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2435), 15, 6 },
                    { 9, 25, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2395), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2395), 39, 2 },
                    { 28, 10, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2439), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2439), 4, 6 },
                    { 33, 78, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2451), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2451), 6, 8 },
                    { 27, 12, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2437), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2437), 51, 6 },
                    { 35, 26, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2456), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2456), 51, 9 },
                    { 3, 12, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2380), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2380), 5, 1 },
                    { 36, 17, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2458), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2458), 14, 9 },
                    { 37, 69, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2461), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2461), 36, 9 },
                    { 34, 53, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2453), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2453), 51, 8 },
                    { 32, 38, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2449), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2449), 51, 7 },
                    { 30, 23, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2444), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2444), 13, 7 },
                    { 29, 19, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2442), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2442), 8, 7 },
                    { 1, 47, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(1075), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(1075), 1, 1 },
                    { 38, 34, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2463), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2463), 17, 10 },
                    { 4, 99, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2383), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2383), 7, 1 },
                    { 31, 36, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2446), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2446), 6, 7 },
                    { 2, 36, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2367), new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(2367), 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Trades",
                columns: new[] { "Id", "ActiveUserId", "Completed", "CreatedAt", "ModifiedAt", "ProposerId", "ReceiverId" },
                values: new object[,]
                {
                    { 2, 3, false, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(5831), new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(5831), 3, 2 },
                    { 4, 1, false, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(5846), new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(5846), 1, 8 },
                    { 6, 7, false, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(5889), new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(5889), 7, 2 },
                    { 1, 1, false, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(4220), new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(4220), 2, 1 },
                    { 5, 7, false, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(5849), new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(5849), 4, 7 },
                    { 3, 6, false, new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(5843), new DateTime(2021, 5, 27, 18, 42, 42, 250, DateTimeKind.Local).AddTicks(5843), 6, 8 }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "UserId", "VAmount" },
                values: new object[,]
                {
                    { 20, new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8348), new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8348), 20, 56m },
                    { 21, new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8350), new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8350), 21, 78m },
                    { 19, new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8346), new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8346), 19, 78m },
                    { 18, new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8343), new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8343), 18, 65m },
                    { 1, new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(7291), new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(7291), 1, 200m },
                    { 4, new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8310), new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8310), 4, 42m },
                    { 2, new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8293), new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8293), 2, 347m },
                    { 16, new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8339), new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8339), 16, 28m },
                    { 15, new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8336), new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8336), 15, 47m },
                    { 3, new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8306), new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8306), 3, 65m },
                    { 10, new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8324), new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8324), 10, 124m },
                    { 14, new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8334), new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8334), 14, 20m },
                    { 5, new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8312), new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8312), 5, 753m },
                    { 13, new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8332), new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8332), 13, 204m },
                    { 6, new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8314), new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8314), 6, 36m }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "UserId", "VAmount" },
                values: new object[,]
                {
                    { 7, new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8317), new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8317), 7, 12m },
                    { 12, new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8329), new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8329), 12, 57m },
                    { 8, new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8320), new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8320), 8, 654m },
                    { 11, new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8327), new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8327), 11, 269m },
                    { 9, new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8322), new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8322), 9, 357m },
                    { 17, new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8341), new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8341), 17, 104m },
                    { 22, new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8352), new DateTime(2021, 5, 27, 18, 42, 42, 248, DateTimeKind.Local).AddTicks(8352), 22, 9m }
                });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "CreatedAt", "EuroAmount", "ModifiedAt", "VAmount", "WalletId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(8609), 6.9m, new DateTime(2021, 5, 27, 18, 42, 42, 252, DateTimeKind.Local).AddTicks(8609), 69m, 1 },
                    { 7, new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(128), 9.8m, new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(128), 98m, 9 },
                    { 8, new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(131), 5m, new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(131), 50m, 7 },
                    { 6, new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(126), 7.8m, new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(126), 78m, 10 },
                    { 4, new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(121), 10m, new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(121), 100m, 6 },
                    { 3, new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(117), 42m, new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(117), 420m, 5 },
                    { 10, new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(136), 2m, new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(136), 20m, 4 },
                    { 9, new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(133), 13m, new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(133), 130m, 3 },
                    { 5, new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(123), 3.6m, new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(123), 36m, 12 },
                    { 2, new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(104), 2m, new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(104), 20m, 1 }
                });

            migrationBuilder.InsertData(
                table: "TradeItemProposals",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "ProposedAmount", "TradeId", "TradeItemId" },
                values: new object[,]
                {
                    { 8, new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(7231), new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(7231), 15, 2, 14 },
                    { 11, new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(7239), new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(7239), 5, 4, 34 },
                    { 9, new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(7234), new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(7234), 5, 3, 33 },
                    { 15, new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(7248), new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(7248), 5, 4, 4 },
                    { 14, new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(7245), new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(7245), 15, 4, 3 },
                    { 13, new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(7243), new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(7243), 5, 4, 2 },
                    { 12, new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(7241), new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(7241), 15, 4, 1 },
                    { 10, new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(7236), new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(7236), 15, 3, 28 },
                    { 7, new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(7229), new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(7229), 5, 2, 13 },
                    { 1, new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(5924), new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(5924), 5, 1, 1 },
                    { 20, new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(7259), new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(7259), 15, 6, 30 },
                    { 19, new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(7257), new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(7257), 1, 6, 5 },
                    { 18, new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(7254), new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(7254), 15, 5, 18 },
                    { 2, new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(7205), new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(7205), 15, 1, 2 },
                    { 3, new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(7218), new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(7218), 5, 1, 3 },
                    { 4, new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(7221), new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(7221), 5, 1, 5 },
                    { 5, new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(7224), new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(7224), 5, 2, 6 },
                    { 6, new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(7227), new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(7227), 15, 2, 7 },
                    { 16, new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(7250), new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(7250), 3, 5, 32 },
                    { 17, new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(7252), new DateTime(2021, 5, 27, 18, 42, 42, 253, DateTimeKind.Local).AddTicks(7252), 5, 5, 17 }
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
