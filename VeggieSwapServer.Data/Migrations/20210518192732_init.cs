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
                name: "TradeItemProposal",
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
                    table.PrimaryKey("PK_TradeItemProposal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TradeItemProposal_TradeItems_TradeItemId",
                        column: x => x.TradeItemId,
                        principalTable: "TradeItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TradeItemProposal_Trades_TradeId",
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
                    { 1, new DateTime(2021, 5, 18, 21, 27, 31, 601, DateTimeKind.Local).AddTicks(9603), "apples.svg", new DateTime(2021, 5, 18, 21, 27, 31, 601, DateTimeKind.Local).AddTicks(9603), "apples" },
                    { 29, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(608), "olives.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(608), "olives" },
                    { 30, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(610), "oranges.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(610), "oranges" },
                    { 31, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(612), "papayas.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(612), "papayas" },
                    { 33, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(617), "pears.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(617), "pears" },
                    { 34, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(619), "peas.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(619), "peas" },
                    { 35, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(622), "pineapples.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(622), "pineapples" },
                    { 36, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(624), "pomegranates.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(624), "pomegranates" },
                    { 37, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(626), "potatoes.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(626), "potatoes" },
                    { 38, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(629), "pumpkins.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(629), "pumpkins" },
                    { 39, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(631), "radish.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(631), "radish" },
                    { 28, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(605), "mushrooms.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(605), "mushrooms" },
                    { 40, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(634), "radishes.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(634), "radishes" },
                    { 42, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(638), "salad.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(638), "salad" },
                    { 43, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(641), "salads.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(641), "salads" },
                    { 44, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(643), "scallions.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(643), "scallions" },
                    { 45, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(646), "spinach.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(646), "spinach" },
                    { 46, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(648), "star-fruits.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(648), "star-fruits" },
                    { 47, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(650), "strawberries.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(650), "strawberries" },
                    { 48, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(653), "sweet-potatoes.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(653), "sweet-potatoes" },
                    { 49, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(655), "tomatoes.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(655), "tomatoes" },
                    { 50, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(657), "watermelons.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(657), "watermelons" },
                    { 51, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(660), "v-coin.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(660), "v-coin" },
                    { 41, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(636), "raspberries.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(636), "raspberries" },
                    { 27, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(603), "melons.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(603), "melons" },
                    { 32, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(614), "peaches.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(614), "peaches" },
                    { 25, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(598), "mangos.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(598), "mangos" },
                    { 2, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(533), "artichokes.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(533), "artichokes" },
                    { 3, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(544), "asparaguses.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(544), "asparaguses" },
                    { 4, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(548), "bananas.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(548), "bananas" },
                    { 5, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(550), "bell-peppers.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(550), "bell-peppers" },
                    { 6, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(552), "blueberries.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(552), "blueberries" },
                    { 7, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(555), "bok-choy.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(555), "bok-choy" },
                    { 26, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(600), "mangosteens.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(600), "mangosteens" },
                    { 9, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(560), "brussels-sprouts.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(560), "brussels-sprouts" },
                    { 10, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(562), "carrots.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(562), "carrots" },
                    { 11, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(565), "cherries.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(565), "cherries" },
                    { 12, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(567), "chilis.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(567), "chilis" },
                    { 13, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(570), "coconuts.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(570), "coconuts" },
                    { 8, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(558), "broccoli.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(558), "broccoli" },
                    { 15, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(575), "corn.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(575), "corn" },
                    { 16, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(577), "cucumbers.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(577), "cucumbers" }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreatedAt", "ImageUrl", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 17, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(579), "dragon-fruits.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(579), "dragon-fruits" },
                    { 18, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(582), "durians.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(582), "durians" },
                    { 19, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(584), "eggplants.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(584), "eggplants" },
                    { 20, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(586), "garlic.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(586), "garlic" },
                    { 21, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(589), "grapes.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(589), "grapes" },
                    { 22, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(591), "guavas.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(591), "guavas" },
                    { 23, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(593), "kiwis.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(593), "kiwis" },
                    { 24, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(596), "lemons.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(596), "lemons" },
                    { 14, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(572), "coriander.svg", new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(572), "coriander" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "ImageUrl", "IsAdmin", "LastName", "ModifiedAt", "PasswordHash", "PasswordSalt" },
                values: new object[,]
                {
                    { 11, new DateTime(2021, 5, 18, 21, 27, 31, 598, DateTimeKind.Local).AddTicks(1522), "VerhofstadDeZeemlap@europeesemailadres.com", "Verhofstad", "https://robohash.org/Zeemlap", false, "Zeemlap", new DateTime(2021, 5, 18, 21, 27, 31, 598, DateTimeKind.Local).AddTicks(1522), new byte[] { 196, 54, 44, 226, 216, 41, 197, 7, 245, 45, 62, 87, 35, 166, 73, 153, 100, 176, 215, 167, 149, 186, 180, 205, 15, 180, 157, 40, 187, 239, 131, 24, 12, 51, 32, 21, 145, 88, 145, 99, 159, 47, 218, 196, 252, 183, 172, 92, 165, 211, 179, 22, 201, 26, 219, 72, 1, 116, 60, 218, 235, 73, 218, 92 }, new byte[] { 70, 199, 222, 191, 231, 112, 31, 78, 64, 127, 49, 83, 40, 94, 247, 17, 72, 101, 23, 16, 175, 181, 23, 251, 222, 238, 190, 213, 25, 127, 45, 93, 88, 77, 109, 104, 11, 253, 31, 22, 145, 227, 132, 26, 95, 55, 46, 246, 253, 168, 14, 83, 247, 82, 104, 154, 87, 164, 221, 158, 179, 16, 46, 3, 156, 52, 255, 141, 249, 230, 181, 73, 218, 51, 155, 76, 154, 38, 99, 150, 58, 250, 145, 180, 95, 29, 141, 83, 151, 186, 113, 121, 11, 35, 198, 9, 144, 163, 194, 9, 29, 155, 53, 40, 214, 74, 123, 100, 69, 27, 59, 130, 8, 35, 86, 238, 4, 146, 71, 58, 69, 114, 248, 171, 73, 140, 229, 102 } },
                    { 10, new DateTime(2021, 5, 18, 21, 27, 31, 598, DateTimeKind.Local).AddTicks(1507), "Luc@mail.com", "Luc", "https://robohash.org/Luc", false, "DeHaantje", new DateTime(2021, 5, 18, 21, 27, 31, 598, DateTimeKind.Local).AddTicks(1507), new byte[] { 196, 54, 44, 226, 216, 41, 197, 7, 245, 45, 62, 87, 35, 166, 73, 153, 100, 176, 215, 167, 149, 186, 180, 205, 15, 180, 157, 40, 187, 239, 131, 24, 12, 51, 32, 21, 145, 88, 145, 99, 159, 47, 218, 196, 252, 183, 172, 92, 165, 211, 179, 22, 201, 26, 219, 72, 1, 116, 60, 218, 235, 73, 218, 92 }, new byte[] { 70, 199, 222, 191, 231, 112, 31, 78, 64, 127, 49, 83, 40, 94, 247, 17, 72, 101, 23, 16, 175, 181, 23, 251, 222, 238, 190, 213, 25, 127, 45, 93, 88, 77, 109, 104, 11, 253, 31, 22, 145, 227, 132, 26, 95, 55, 46, 246, 253, 168, 14, 83, 247, 82, 104, 154, 87, 164, 221, 158, 179, 16, 46, 3, 156, 52, 255, 141, 249, 230, 181, 73, 218, 51, 155, 76, 154, 38, 99, 150, 58, 250, 145, 180, 95, 29, 141, 83, 151, 186, 113, 121, 11, 35, 198, 9, 144, 163, 194, 9, 29, 155, 53, 40, 214, 74, 123, 100, 69, 27, 59, 130, 8, 35, 86, 238, 4, 146, 71, 58, 69, 114, 248, 171, 73, 140, 229, 102 } },
                    { 9, new DateTime(2021, 5, 18, 21, 27, 31, 598, DateTimeKind.Local).AddTicks(1493), "Mihiel@mail.com", "Mihiel", "https://robohash.org/Mihiel", false, "Mihoen", new DateTime(2021, 5, 18, 21, 27, 31, 598, DateTimeKind.Local).AddTicks(1493), new byte[] { 196, 54, 44, 226, 216, 41, 197, 7, 245, 45, 62, 87, 35, 166, 73, 153, 100, 176, 215, 167, 149, 186, 180, 205, 15, 180, 157, 40, 187, 239, 131, 24, 12, 51, 32, 21, 145, 88, 145, 99, 159, 47, 218, 196, 252, 183, 172, 92, 165, 211, 179, 22, 201, 26, 219, 72, 1, 116, 60, 218, 235, 73, 218, 92 }, new byte[] { 70, 199, 222, 191, 231, 112, 31, 78, 64, 127, 49, 83, 40, 94, 247, 17, 72, 101, 23, 16, 175, 181, 23, 251, 222, 238, 190, 213, 25, 127, 45, 93, 88, 77, 109, 104, 11, 253, 31, 22, 145, 227, 132, 26, 95, 55, 46, 246, 253, 168, 14, 83, 247, 82, 104, 154, 87, 164, 221, 158, 179, 16, 46, 3, 156, 52, 255, 141, 249, 230, 181, 73, 218, 51, 155, 76, 154, 38, 99, 150, 58, 250, 145, 180, 95, 29, 141, 83, 151, 186, 113, 121, 11, 35, 198, 9, 144, 163, 194, 9, 29, 155, 53, 40, 214, 74, 123, 100, 69, 27, 59, 130, 8, 35, 86, 238, 4, 146, 71, 58, 69, 114, 248, 171, 73, 140, 229, 102 } },
                    { 8, new DateTime(2021, 5, 18, 21, 27, 31, 598, DateTimeKind.Local).AddTicks(1478), "Andreas@mail.com", "Andreas", "https://robohash.org/Andreas", false, "VanGrieken", new DateTime(2021, 5, 18, 21, 27, 31, 598, DateTimeKind.Local).AddTicks(1478), new byte[] { 196, 54, 44, 226, 216, 41, 197, 7, 245, 45, 62, 87, 35, 166, 73, 153, 100, 176, 215, 167, 149, 186, 180, 205, 15, 180, 157, 40, 187, 239, 131, 24, 12, 51, 32, 21, 145, 88, 145, 99, 159, 47, 218, 196, 252, 183, 172, 92, 165, 211, 179, 22, 201, 26, 219, 72, 1, 116, 60, 218, 235, 73, 218, 92 }, new byte[] { 70, 199, 222, 191, 231, 112, 31, 78, 64, 127, 49, 83, 40, 94, 247, 17, 72, 101, 23, 16, 175, 181, 23, 251, 222, 238, 190, 213, 25, 127, 45, 93, 88, 77, 109, 104, 11, 253, 31, 22, 145, 227, 132, 26, 95, 55, 46, 246, 253, 168, 14, 83, 247, 82, 104, 154, 87, 164, 221, 158, 179, 16, 46, 3, 156, 52, 255, 141, 249, 230, 181, 73, 218, 51, 155, 76, 154, 38, 99, 150, 58, 250, 145, 180, 95, 29, 141, 83, 151, 186, 113, 121, 11, 35, 198, 9, 144, 163, 194, 9, 29, 155, 53, 40, 214, 74, 123, 100, 69, 27, 59, 130, 8, 35, 86, 238, 4, 146, 71, 58, 69, 114, 248, 171, 73, 140, 229, 102 } },
                    { 7, new DateTime(2021, 5, 18, 21, 27, 31, 598, DateTimeKind.Local).AddTicks(1464), "Dirk@mail.com", "Dirk", "https://robohash.org/Dirk", false, "Visser", new DateTime(2021, 5, 18, 21, 27, 31, 598, DateTimeKind.Local).AddTicks(1464), new byte[] { 196, 54, 44, 226, 216, 41, 197, 7, 245, 45, 62, 87, 35, 166, 73, 153, 100, 176, 215, 167, 149, 186, 180, 205, 15, 180, 157, 40, 187, 239, 131, 24, 12, 51, 32, 21, 145, 88, 145, 99, 159, 47, 218, 196, 252, 183, 172, 92, 165, 211, 179, 22, 201, 26, 219, 72, 1, 116, 60, 218, 235, 73, 218, 92 }, new byte[] { 70, 199, 222, 191, 231, 112, 31, 78, 64, 127, 49, 83, 40, 94, 247, 17, 72, 101, 23, 16, 175, 181, 23, 251, 222, 238, 190, 213, 25, 127, 45, 93, 88, 77, 109, 104, 11, 253, 31, 22, 145, 227, 132, 26, 95, 55, 46, 246, 253, 168, 14, 83, 247, 82, 104, 154, 87, 164, 221, 158, 179, 16, 46, 3, 156, 52, 255, 141, 249, 230, 181, 73, 218, 51, 155, 76, 154, 38, 99, 150, 58, 250, 145, 180, 95, 29, 141, 83, 151, 186, 113, 121, 11, 35, 198, 9, 144, 163, 194, 9, 29, 155, 53, 40, 214, 74, 123, 100, 69, 27, 59, 130, 8, 35, 86, 238, 4, 146, 71, 58, 69, 114, 248, 171, 73, 140, 229, 102 } },
                    { 1, new DateTime(2021, 5, 18, 21, 27, 31, 594, DateTimeKind.Local).AddTicks(8137), "Pieter@mail.com", "Pieter", "https://robohash.org/Pieter", true, "Corp", new DateTime(2021, 5, 18, 21, 27, 31, 594, DateTimeKind.Local).AddTicks(8137), new byte[] { 196, 54, 44, 226, 216, 41, 197, 7, 245, 45, 62, 87, 35, 166, 73, 153, 100, 176, 215, 167, 149, 186, 180, 205, 15, 180, 157, 40, 187, 239, 131, 24, 12, 51, 32, 21, 145, 88, 145, 99, 159, 47, 218, 196, 252, 183, 172, 92, 165, 211, 179, 22, 201, 26, 219, 72, 1, 116, 60, 218, 235, 73, 218, 92 }, new byte[] { 70, 199, 222, 191, 231, 112, 31, 78, 64, 127, 49, 83, 40, 94, 247, 17, 72, 101, 23, 16, 175, 181, 23, 251, 222, 238, 190, 213, 25, 127, 45, 93, 88, 77, 109, 104, 11, 253, 31, 22, 145, 227, 132, 26, 95, 55, 46, 246, 253, 168, 14, 83, 247, 82, 104, 154, 87, 164, 221, 158, 179, 16, 46, 3, 156, 52, 255, 141, 249, 230, 181, 73, 218, 51, 155, 76, 154, 38, 99, 150, 58, 250, 145, 180, 95, 29, 141, 83, 151, 186, 113, 121, 11, 35, 198, 9, 144, 163, 194, 9, 29, 155, 53, 40, 214, 74, 123, 100, 69, 27, 59, 130, 8, 35, 86, 238, 4, 146, 71, 58, 69, 114, 248, 171, 73, 140, 229, 102 } },
                    { 5, new DateTime(2021, 5, 18, 21, 27, 31, 598, DateTimeKind.Local).AddTicks(1435), "BartjeWevertje@mail.com", "BartjeWevertje", "https://robohash.org/BartjeWevertje", false, "Wevertje", new DateTime(2021, 5, 18, 21, 27, 31, 598, DateTimeKind.Local).AddTicks(1435), new byte[] { 196, 54, 44, 226, 216, 41, 197, 7, 245, 45, 62, 87, 35, 166, 73, 153, 100, 176, 215, 167, 149, 186, 180, 205, 15, 180, 157, 40, 187, 239, 131, 24, 12, 51, 32, 21, 145, 88, 145, 99, 159, 47, 218, 196, 252, 183, 172, 92, 165, 211, 179, 22, 201, 26, 219, 72, 1, 116, 60, 218, 235, 73, 218, 92 }, new byte[] { 70, 199, 222, 191, 231, 112, 31, 78, 64, 127, 49, 83, 40, 94, 247, 17, 72, 101, 23, 16, 175, 181, 23, 251, 222, 238, 190, 213, 25, 127, 45, 93, 88, 77, 109, 104, 11, 253, 31, 22, 145, 227, 132, 26, 95, 55, 46, 246, 253, 168, 14, 83, 247, 82, 104, 154, 87, 164, 221, 158, 179, 16, 46, 3, 156, 52, 255, 141, 249, 230, 181, 73, 218, 51, 155, 76, 154, 38, 99, 150, 58, 250, 145, 180, 95, 29, 141, 83, 151, 186, 113, 121, 11, 35, 198, 9, 144, 163, 194, 9, 29, 155, 53, 40, 214, 74, 123, 100, 69, 27, 59, 130, 8, 35, 86, 238, 4, 146, 71, 58, 69, 114, 248, 171, 73, 140, 229, 102 } },
                    { 4, new DateTime(2021, 5, 18, 21, 27, 31, 598, DateTimeKind.Local).AddTicks(1418), "Dries@mail.com", "Dries", "https://robohash.org/Dries", true, "Maes", new DateTime(2021, 5, 18, 21, 27, 31, 598, DateTimeKind.Local).AddTicks(1418), new byte[] { 196, 54, 44, 226, 216, 41, 197, 7, 245, 45, 62, 87, 35, 166, 73, 153, 100, 176, 215, 167, 149, 186, 180, 205, 15, 180, 157, 40, 187, 239, 131, 24, 12, 51, 32, 21, 145, 88, 145, 99, 159, 47, 218, 196, 252, 183, 172, 92, 165, 211, 179, 22, 201, 26, 219, 72, 1, 116, 60, 218, 235, 73, 218, 92 }, new byte[] { 70, 199, 222, 191, 231, 112, 31, 78, 64, 127, 49, 83, 40, 94, 247, 17, 72, 101, 23, 16, 175, 181, 23, 251, 222, 238, 190, 213, 25, 127, 45, 93, 88, 77, 109, 104, 11, 253, 31, 22, 145, 227, 132, 26, 95, 55, 46, 246, 253, 168, 14, 83, 247, 82, 104, 154, 87, 164, 221, 158, 179, 16, 46, 3, 156, 52, 255, 141, 249, 230, 181, 73, 218, 51, 155, 76, 154, 38, 99, 150, 58, 250, 145, 180, 95, 29, 141, 83, 151, 186, 113, 121, 11, 35, 198, 9, 144, 163, 194, 9, 29, 155, 53, 40, 214, 74, 123, 100, 69, 27, 59, 130, 8, 35, 86, 238, 4, 146, 71, 58, 69, 114, 248, 171, 73, 140, 229, 102 } },
                    { 3, new DateTime(2021, 5, 18, 21, 27, 31, 598, DateTimeKind.Local).AddTicks(1392), "Kobe@mail.com", "Kobe", "https://robohash.org/Kobe", true, "Delo", new DateTime(2021, 5, 18, 21, 27, 31, 598, DateTimeKind.Local).AddTicks(1392), new byte[] { 196, 54, 44, 226, 216, 41, 197, 7, 245, 45, 62, 87, 35, 166, 73, 153, 100, 176, 215, 167, 149, 186, 180, 205, 15, 180, 157, 40, 187, 239, 131, 24, 12, 51, 32, 21, 145, 88, 145, 99, 159, 47, 218, 196, 252, 183, 172, 92, 165, 211, 179, 22, 201, 26, 219, 72, 1, 116, 60, 218, 235, 73, 218, 92 }, new byte[] { 70, 199, 222, 191, 231, 112, 31, 78, 64, 127, 49, 83, 40, 94, 247, 17, 72, 101, 23, 16, 175, 181, 23, 251, 222, 238, 190, 213, 25, 127, 45, 93, 88, 77, 109, 104, 11, 253, 31, 22, 145, 227, 132, 26, 95, 55, 46, 246, 253, 168, 14, 83, 247, 82, 104, 154, 87, 164, 221, 158, 179, 16, 46, 3, 156, 52, 255, 141, 249, 230, 181, 73, 218, 51, 155, 76, 154, 38, 99, 150, 58, 250, 145, 180, 95, 29, 141, 83, 151, 186, 113, 121, 11, 35, 198, 9, 144, 163, 194, 9, 29, 155, 53, 40, 214, 74, 123, 100, 69, 27, 59, 130, 8, 35, 86, 238, 4, 146, 71, 58, 69, 114, 248, 171, 73, 140, 229, 102 } },
                    { 2, new DateTime(2021, 5, 18, 21, 27, 31, 598, DateTimeKind.Local).AddTicks(1184), "Nick@mail.com", "Nick", "https://robohash.org/Nick", true, "Vr", new DateTime(2021, 5, 18, 21, 27, 31, 598, DateTimeKind.Local).AddTicks(1184), new byte[] { 196, 54, 44, 226, 216, 41, 197, 7, 245, 45, 62, 87, 35, 166, 73, 153, 100, 176, 215, 167, 149, 186, 180, 205, 15, 180, 157, 40, 187, 239, 131, 24, 12, 51, 32, 21, 145, 88, 145, 99, 159, 47, 218, 196, 252, 183, 172, 92, 165, 211, 179, 22, 201, 26, 219, 72, 1, 116, 60, 218, 235, 73, 218, 92 }, new byte[] { 70, 199, 222, 191, 231, 112, 31, 78, 64, 127, 49, 83, 40, 94, 247, 17, 72, 101, 23, 16, 175, 181, 23, 251, 222, 238, 190, 213, 25, 127, 45, 93, 88, 77, 109, 104, 11, 253, 31, 22, 145, 227, 132, 26, 95, 55, 46, 246, 253, 168, 14, 83, 247, 82, 104, 154, 87, 164, 221, 158, 179, 16, 46, 3, 156, 52, 255, 141, 249, 230, 181, 73, 218, 51, 155, 76, 154, 38, 99, 150, 58, 250, 145, 180, 95, 29, 141, 83, 151, 186, 113, 121, 11, 35, 198, 9, 144, 163, 194, 9, 29, 155, 53, 40, 214, 74, 123, 100, 69, 27, 59, 130, 8, 35, 86, 238, 4, 146, 71, 58, 69, 114, 248, 171, 73, 140, 229, 102 } },
                    { 12, new DateTime(2021, 5, 18, 21, 27, 31, 598, DateTimeKind.Local).AddTicks(1536), "Driesdentweedenmaarnidezelfden@mail.com", "Dries", "https://robohash.org/Dries2", false, "VanKorteNekke", new DateTime(2021, 5, 18, 21, 27, 31, 598, DateTimeKind.Local).AddTicks(1536), new byte[] { 196, 54, 44, 226, 216, 41, 197, 7, 245, 45, 62, 87, 35, 166, 73, 153, 100, 176, 215, 167, 149, 186, 180, 205, 15, 180, 157, 40, 187, 239, 131, 24, 12, 51, 32, 21, 145, 88, 145, 99, 159, 47, 218, 196, 252, 183, 172, 92, 165, 211, 179, 22, 201, 26, 219, 72, 1, 116, 60, 218, 235, 73, 218, 92 }, new byte[] { 70, 199, 222, 191, 231, 112, 31, 78, 64, 127, 49, 83, 40, 94, 247, 17, 72, 101, 23, 16, 175, 181, 23, 251, 222, 238, 190, 213, 25, 127, 45, 93, 88, 77, 109, 104, 11, 253, 31, 22, 145, 227, 132, 26, 95, 55, 46, 246, 253, 168, 14, 83, 247, 82, 104, 154, 87, 164, 221, 158, 179, 16, 46, 3, 156, 52, 255, 141, 249, 230, 181, 73, 218, 51, 155, 76, 154, 38, 99, 150, 58, 250, 145, 180, 95, 29, 141, 83, 151, 186, 113, 121, 11, 35, 198, 9, 144, 163, 194, 9, 29, 155, 53, 40, 214, 74, 123, 100, 69, 27, 59, 130, 8, 35, 86, 238, 4, 146, 71, 58, 69, 114, 248, 171, 73, 140, 229, 102 } },
                    { 6, new DateTime(2021, 5, 18, 21, 27, 31, 598, DateTimeKind.Local).AddTicks(1449), "Stofzuiger@mail.com", "Stofzuiger", "https://robohash.org/Stofzuiger", false, "Zuiger", new DateTime(2021, 5, 18, 21, 27, 31, 598, DateTimeKind.Local).AddTicks(1449), new byte[] { 196, 54, 44, 226, 216, 41, 197, 7, 245, 45, 62, 87, 35, 166, 73, 153, 100, 176, 215, 167, 149, 186, 180, 205, 15, 180, 157, 40, 187, 239, 131, 24, 12, 51, 32, 21, 145, 88, 145, 99, 159, 47, 218, 196, 252, 183, 172, 92, 165, 211, 179, 22, 201, 26, 219, 72, 1, 116, 60, 218, 235, 73, 218, 92 }, new byte[] { 70, 199, 222, 191, 231, 112, 31, 78, 64, 127, 49, 83, 40, 94, 247, 17, 72, 101, 23, 16, 175, 181, 23, 251, 222, 238, 190, 213, 25, 127, 45, 93, 88, 77, 109, 104, 11, 253, 31, 22, 145, 227, 132, 26, 95, 55, 46, 246, 253, 168, 14, 83, 247, 82, 104, 154, 87, 164, 221, 158, 179, 16, 46, 3, 156, 52, 255, 141, 249, 230, 181, 73, 218, 51, 155, 76, 154, 38, 99, 150, 58, 250, 145, 180, 95, 29, 141, 83, 151, 186, 113, 121, 11, 35, 198, 9, 144, 163, 194, 9, 29, 155, 53, 40, 214, 74, 123, 100, 69, 27, 59, 130, 8, 35, 86, 238, 4, 146, 71, 58, 69, 114, 248, 171, 73, 140, 229, 102 } },
                    { 13, new DateTime(2021, 5, 18, 21, 27, 31, 598, DateTimeKind.Local).AddTicks(1551), "Joyce@mail.com", "Joyce", "https://robohash.org/Tomatenplukker", false, "Tomatenplukker", new DateTime(2021, 5, 18, 21, 27, 31, 598, DateTimeKind.Local).AddTicks(1551), new byte[] { 196, 54, 44, 226, 216, 41, 197, 7, 245, 45, 62, 87, 35, 166, 73, 153, 100, 176, 215, 167, 149, 186, 180, 205, 15, 180, 157, 40, 187, 239, 131, 24, 12, 51, 32, 21, 145, 88, 145, 99, 159, 47, 218, 196, 252, 183, 172, 92, 165, 211, 179, 22, 201, 26, 219, 72, 1, 116, 60, 218, 235, 73, 218, 92 }, new byte[] { 70, 199, 222, 191, 231, 112, 31, 78, 64, 127, 49, 83, 40, 94, 247, 17, 72, 101, 23, 16, 175, 181, 23, 251, 222, 238, 190, 213, 25, 127, 45, 93, 88, 77, 109, 104, 11, 253, 31, 22, 145, 227, 132, 26, 95, 55, 46, 246, 253, 168, 14, 83, 247, 82, 104, 154, 87, 164, 221, 158, 179, 16, 46, 3, 156, 52, 255, 141, 249, 230, 181, 73, 218, 51, 155, 76, 154, 38, 99, 150, 58, 250, 145, 180, 95, 29, 141, 83, 151, 186, 113, 121, 11, 35, 198, 9, 144, 163, 194, 9, 29, 155, 53, 40, 214, 74, 123, 100, 69, 27, 59, 130, 8, 35, 86, 238, 4, 146, 71, 58, 69, 114, 248, 171, 73, 140, 229, 102 } }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "PostalCode", "StreetName", "StreetNumber", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(356), new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(356), 9000, "Anti-Veggiestraat", 89, 1 },
                    { 4, new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(2101), new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(2101), 1000, "Driesstraat", 66, 4 },
                    { 6, new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(2105), new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(2105), 1000, "Lookbroodjesstraat", 43, 6 },
                    { 5, new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(2103), new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(2103), 2000, "Kobestraat", 85, 5 },
                    { 10, new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(2116), new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(2116), 9070, "Geenpolitiekinhetprojectstraat", 200, 10 },
                    { 8, new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(2110), new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(2110), 1000, "Kotsvisstraat", 96, 8 },
                    { 11, new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(2118), new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(2118), 9500, "Kalfslapjesstraat", 32, 11 },
                    { 3, new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(2098), new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(2098), 9000, "Nickstraat", 74, 3 },
                    { 12, new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(2120), new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(2120), 1000, "Blacklivesmatterstraat", 78, 12 },
                    { 2, new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(2084), new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(2084), 9000, "Pieterstreaat", 45, 2 },
                    { 13, new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(2123), new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(2123), 9020, "Worstenbroodjesstraat", 4, 13 },
                    { 7, new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(2108), new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(2108), 9050, "Greenpeacestraat", 1, 7 },
                    { 9, new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(2113), new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(2113), 2000, "Greenlivesmattertoostraat", 420, 9 }
                });

            migrationBuilder.InsertData(
                table: "TradeItems",
                columns: new[] { "Id", "Amount", "CreatedAt", "ModifiedAt", "ResourceId", "UserId" },
                values: new object[,]
                {
                    { 2, 10, new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4095), new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4095), 11, 8 },
                    { 26, 10, new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4163), new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4163), 39, 7 },
                    { 7, 42, new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4118), new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4118), 17, 7 },
                    { 20, 30, new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4149), new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4149), 36, 7 },
                    { 10, 634, new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4125), new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4125), 10, 9 },
                    { 9, 201, new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4123), new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4123), 9, 9 },
                    { 22, 69, new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4154), new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4154), 27, 9 },
                    { 1, 2, new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(2781), new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(2781), 51, 10 },
                    { 13, 69, new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4132), new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4132), 19, 10 },
                    { 11, 20, new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4128), new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4128), 17, 11 },
                    { 19, 17, new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4147), new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4147), 7, 12 },
                    { 3, 50, new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4107), new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4107), 32, 13 },
                    { 8, 75, new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4121), new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4121), 8, 8 },
                    { 12, 75, new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4130), new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4130), 26, 13 },
                    { 25, 20, new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4161), new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4161), 48, 6 },
                    { 6, 30, new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4116), new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4116), 6, 6 },
                    { 18, 9, new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4144), new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4144), 6, 1 },
                    { 23, 180, new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4156), new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4156), 37, 1 },
                    { 24, 47, new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4158), new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4158), 47, 2 },
                    { 14, 25, new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4135), new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4135), 49, 3 },
                    { 21, 78, new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4151), new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4151), 23, 6 },
                    { 4, 69, new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4110), new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4110), 24, 4 },
                    { 15, 35, new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4137), new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4137), 50, 4 },
                    { 17, 10, new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4142), new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4142), 1, 3 },
                    { 5, 45, new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4113), new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4113), 45, 5 },
                    { 16, 75, new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4140), new DateTime(2021, 5, 18, 21, 27, 31, 603, DateTimeKind.Local).AddTicks(4140), 7, 5 }
                });

            migrationBuilder.InsertData(
                table: "Trades",
                columns: new[] { "Id", "Completed", "CreatedAt", "ModifiedAt", "ProposerId", "ReceiverId" },
                values: new object[,]
                {
                    { 4, false, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(5983), new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(5983), 5, 2 },
                    { 3, false, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(5980), new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(5980), 4, 2 },
                    { 5, false, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(5986), new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(5986), 1, 5 }
                });

            migrationBuilder.InsertData(
                table: "Trades",
                columns: new[] { "Id", "Completed", "CreatedAt", "ModifiedAt", "ProposerId", "ReceiverId" },
                values: new object[,]
                {
                    { 6, false, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(5989), new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(5989), 3, 1 },
                    { 2, false, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(5968), new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(5968), 3, 1 },
                    { 1, true, new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(4662), new DateTime(2021, 5, 18, 21, 27, 31, 602, DateTimeKind.Local).AddTicks(4662), 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "UserId", "VAmount" },
                values: new object[,]
                {
                    { 6, new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(8883), new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(8883), 6, 36m },
                    { 5, new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(8881), new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(8881), 5, 753m },
                    { 12, new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(8898), new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(8898), 12, 57m },
                    { 1, new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(7818), new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(7818), 1, 200m },
                    { 11, new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(8896), new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(8896), 11, 269m },
                    { 10, new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(8894), new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(8894), 10, 124m },
                    { 4, new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(8878), new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(8878), 4, 42m },
                    { 9, new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(8891), new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(8891), 9, 357m },
                    { 3, new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(8875), new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(8875), 3, 65m },
                    { 7, new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(8886), new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(8886), 7, 12m },
                    { 8, new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(8889), new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(8889), 8, 654m },
                    { 2, new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(8862), new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(8862), 2, 347m },
                    { 13, new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(8901), new DateTime(2021, 5, 18, 21, 27, 31, 600, DateTimeKind.Local).AddTicks(8901), 13, 204m }
                });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "CreatedAt", "EuroAmount", "ModifiedAt", "VAmount", "WalletId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(259), 6.9m, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(259), 69m, 1 },
                    { 4, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(1786), 10m, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(1786), 100m, 6 },
                    { 3, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(1782), 42m, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(1782), 420m, 5 },
                    { 7, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(1794), 9.8m, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(1794), 98m, 9 },
                    { 6, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(1791), 7.8m, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(1791), 78m, 10 },
                    { 10, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(1802), 2m, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(1802), 20m, 4 },
                    { 8, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(1796), 5m, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(1796), 50m, 7 },
                    { 9, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(1799), 13m, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(1799), 130m, 3 },
                    { 5, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(1789), 3.6m, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(1789), 36m, 12 },
                    { 2, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(1768), 2m, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(1768), 20m, 1 }
                });

            migrationBuilder.InsertData(
                table: "TradeItemProposal",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "ProposedAmount", "TradeId", "TradeItemId" },
                values: new object[,]
                {
                    { 19, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9399), new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9399), 23, 4, 19 },
                    { 13, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9384), new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9384), 17, 3, 13 },
                    { 2, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9347), new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9347), 6, 2, 2 },
                    { 22, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9406), new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9406), 26, 2, 22 },
                    { 10, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9377), new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9377), 14, 5, 10 },
                    { 9, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9375), new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9375), 13, 4, 9 },
                    { 8, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9372), new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9372), 12, 3, 8 },
                    { 11, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9380), new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9380), 15, 1, 11 },
                    { 1, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(8057), new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(8057), 5, 1, 1 },
                    { 7, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9370), new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9370), 11, 2, 7 },
                    { 3, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9358), new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9358), 7, 3, 3 },
                    { 21, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9403), new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9403), 25, 1, 21 },
                    { 6, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9367), new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9367), 10, 1, 6 },
                    { 16, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9391), new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9391), 20, 1, 16 },
                    { 5, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9365), new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9365), 9, 5, 5 },
                    { 15, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9389), new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9389), 19, 5, 15 },
                    { 14, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9387), new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9387), 18, 4, 14 },
                    { 4, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9362), new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9362), 8, 4, 4 },
                    { 23, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9408), new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9408), 27, 3, 23 },
                    { 18, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9396), new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9396), 22, 3, 18 },
                    { 17, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9394), new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9394), 21, 2, 17 },
                    { 20, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9401), new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9401), 24, 5, 20 },
                    { 12, new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9382), new DateTime(2021, 5, 18, 21, 27, 31, 604, DateTimeKind.Local).AddTicks(9382), 16, 2, 12 }
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
                name: "IX_TradeItemProposal_TradeId",
                table: "TradeItemProposal",
                column: "TradeId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeItemProposal_TradeItemId",
                table: "TradeItemProposal",
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
                name: "TradeItemProposal");

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
