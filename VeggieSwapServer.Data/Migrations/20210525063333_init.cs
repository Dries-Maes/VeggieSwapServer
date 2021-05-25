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
                    { 1, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(625), "apples.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(625), "apples" },
                    { 29, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1608), "olives.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1608), "olives" },
                    { 30, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1610), "oranges.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1610), "oranges" },
                    { 31, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1612), "papayas.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1612), "papayas" },
                    { 32, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1615), "peaches.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1615), "peaches" },
                    { 33, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1617), "pears.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1617), "pears" },
                    { 34, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1619), "peas.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1619), "peas" },
                    { 35, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1621), "pineapples.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1621), "pineapples" },
                    { 36, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1624), "pomegranates.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1624), "pomegranates" },
                    { 38, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1628), "pumpkins.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1628), "pumpkins" },
                    { 39, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1631), "radish.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1631), "radish" },
                    { 28, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1606), "mushrooms.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1606), "mushrooms" },
                    { 40, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1633), "radishes.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1633), "radishes" },
                    { 42, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1638), "salad.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1638), "salad" },
                    { 43, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1640), "salads.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1640), "salads" },
                    { 44, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1642), "scallions.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1642), "scallions" },
                    { 45, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1644), "spinach.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1644), "spinach" },
                    { 46, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1647), "star-fruits.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1647), "star-fruits" },
                    { 47, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1649), "strawberries.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1649), "strawberries" },
                    { 48, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1651), "sweet-potatoes.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1651), "sweet-potatoes" },
                    { 49, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1654), "tomatoes.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1654), "tomatoes" },
                    { 50, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1656), "watermelons.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1656), "watermelons" },
                    { 51, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1658), "v-coin.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1658), "v-coin" },
                    { 41, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1635), "raspberries.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1635), "raspberries" },
                    { 27, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1603), "melons.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1603), "melons" },
                    { 37, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1626), "potatoes.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1626), "potatoes" },
                    { 25, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1599), "mangos.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1599), "mangos" },
                    { 2, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1536), "artichokes.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1536), "artichokes" },
                    { 26, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1601), "mangosteens.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1601), "mangosteens" },
                    { 4, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1550), "bananas.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1550), "bananas" },
                    { 5, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1553), "bell-peppers.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1553), "bell-peppers" },
                    { 6, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1555), "blueberries.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1555), "blueberries" },
                    { 7, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1557), "bok-choy.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1557), "bok-choy" },
                    { 8, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1560), "broccoli.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1560), "broccoli" },
                    { 9, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1562), "brussels-sprouts.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1562), "brussels-sprouts" },
                    { 10, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1564), "carrots.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1564), "carrots" },
                    { 11, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1567), "cherries.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1567), "cherries" },
                    { 12, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1569), "chilis.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1569), "chilis" },
                    { 13, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1571), "coconuts.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1571), "coconuts" },
                    { 3, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1547), "asparagus.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1547), "asparagus" },
                    { 15, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1576), "corn.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1576), "corn" },
                    { 14, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1574), "coriander.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1574), "coriander" }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreatedAt", "ImageUrl", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 23, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1594), "kiwis.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1594), "kiwis" },
                    { 22, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1592), "guavas.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1592), "guavas" },
                    { 21, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1590), "grapes.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1590), "grapes" },
                    { 20, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1587), "garlic.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1587), "garlic" },
                    { 24, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1596), "lemons.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1596), "lemons" },
                    { 18, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1583), "durians.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1583), "durians" },
                    { 17, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1580), "dragon-fruits.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1580), "dragon-fruits" },
                    { 16, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1578), "cucumbers.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1578), "cucumbers" },
                    { 19, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1585), "eggplants.svg", new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(1585), "eggplants" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "ImageUrl", "IsAdmin", "LastName", "ModifiedAt", "PasswordHash", "PasswordSalt" },
                values: new object[,]
                {
                    { 12, new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(9230), "Simon@mail.com", "Simon", "Dries2", false, "Lidllover", new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(9230), new byte[] { 235, 214, 58, 248, 34, 223, 156, 170, 13, 248, 1, 132, 65, 19, 189, 93, 7, 78, 162, 39, 14, 250, 192, 62, 96, 237, 44, 162, 161, 202, 242, 59, 9, 76, 1, 214, 143, 183, 141, 231, 225, 32, 27, 238, 57, 157, 146, 179, 124, 38, 204, 18, 195, 218, 206, 140, 8, 174, 5, 69, 76, 143, 192, 177 }, new byte[] { 93, 17, 223, 123, 85, 116, 217, 5, 107, 87, 130, 193, 5, 80, 126, 159, 56, 177, 253, 228, 123, 54, 52, 138, 234, 193, 91, 58, 207, 240, 156, 179, 197, 138, 106, 100, 121, 206, 77, 247, 129, 242, 56, 88, 119, 195, 53, 172, 86, 173, 135, 30, 7, 44, 201, 221, 195, 161, 130, 206, 151, 135, 116, 21, 62, 84, 219, 94, 109, 143, 210, 9, 11, 44, 195, 71, 120, 97, 77, 128, 1, 7, 100, 33, 24, 44, 124, 64, 245, 111, 130, 142, 62, 207, 238, 197, 72, 227, 124, 64, 102, 166, 185, 197, 194, 200, 29, 118, 17, 134, 39, 222, 184, 226, 77, 202, 157, 84, 94, 81, 182, 25, 220, 2, 24, 42, 165, 239 } },
                    { 19, new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(9324), "Karolien@mail.com", "Karolien", "78", false, "Vdabpolitie", new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(9324), new byte[] { 235, 214, 58, 248, 34, 223, 156, 170, 13, 248, 1, 132, 65, 19, 189, 93, 7, 78, 162, 39, 14, 250, 192, 62, 96, 237, 44, 162, 161, 202, 242, 59, 9, 76, 1, 214, 143, 183, 141, 231, 225, 32, 27, 238, 57, 157, 146, 179, 124, 38, 204, 18, 195, 218, 206, 140, 8, 174, 5, 69, 76, 143, 192, 177 }, new byte[] { 93, 17, 223, 123, 85, 116, 217, 5, 107, 87, 130, 193, 5, 80, 126, 159, 56, 177, 253, 228, 123, 54, 52, 138, 234, 193, 91, 58, 207, 240, 156, 179, 197, 138, 106, 100, 121, 206, 77, 247, 129, 242, 56, 88, 119, 195, 53, 172, 86, 173, 135, 30, 7, 44, 201, 221, 195, 161, 130, 206, 151, 135, 116, 21, 62, 84, 219, 94, 109, 143, 210, 9, 11, 44, 195, 71, 120, 97, 77, 128, 1, 7, 100, 33, 24, 44, 124, 64, 245, 111, 130, 142, 62, 207, 238, 197, 72, 227, 124, 64, 102, 166, 185, 197, 194, 200, 29, 118, 17, 134, 39, 222, 184, 226, 77, 202, 157, 84, 94, 81, 182, 25, 220, 2, 24, 42, 165, 239 } },
                    { 18, new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(9311), "Joke@mail.com", "Joke", "24", false, "LidlAnnoying", new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(9311), new byte[] { 235, 214, 58, 248, 34, 223, 156, 170, 13, 248, 1, 132, 65, 19, 189, 93, 7, 78, 162, 39, 14, 250, 192, 62, 96, 237, 44, 162, 161, 202, 242, 59, 9, 76, 1, 214, 143, 183, 141, 231, 225, 32, 27, 238, 57, 157, 146, 179, 124, 38, 204, 18, 195, 218, 206, 140, 8, 174, 5, 69, 76, 143, 192, 177 }, new byte[] { 93, 17, 223, 123, 85, 116, 217, 5, 107, 87, 130, 193, 5, 80, 126, 159, 56, 177, 253, 228, 123, 54, 52, 138, 234, 193, 91, 58, 207, 240, 156, 179, 197, 138, 106, 100, 121, 206, 77, 247, 129, 242, 56, 88, 119, 195, 53, 172, 86, 173, 135, 30, 7, 44, 201, 221, 195, 161, 130, 206, 151, 135, 116, 21, 62, 84, 219, 94, 109, 143, 210, 9, 11, 44, 195, 71, 120, 97, 77, 128, 1, 7, 100, 33, 24, 44, 124, 64, 245, 111, 130, 142, 62, 207, 238, 197, 72, 227, 124, 64, 102, 166, 185, 197, 194, 200, 29, 118, 17, 134, 39, 222, 184, 226, 77, 202, 157, 84, 94, 81, 182, 25, 220, 2, 24, 42, 165, 239 } },
                    { 17, new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(9297), "Sien@mail.com", "Sien", "57", false, "Rommeltje", new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(9297), new byte[] { 235, 214, 58, 248, 34, 223, 156, 170, 13, 248, 1, 132, 65, 19, 189, 93, 7, 78, 162, 39, 14, 250, 192, 62, 96, 237, 44, 162, 161, 202, 242, 59, 9, 76, 1, 214, 143, 183, 141, 231, 225, 32, 27, 238, 57, 157, 146, 179, 124, 38, 204, 18, 195, 218, 206, 140, 8, 174, 5, 69, 76, 143, 192, 177 }, new byte[] { 93, 17, 223, 123, 85, 116, 217, 5, 107, 87, 130, 193, 5, 80, 126, 159, 56, 177, 253, 228, 123, 54, 52, 138, 234, 193, 91, 58, 207, 240, 156, 179, 197, 138, 106, 100, 121, 206, 77, 247, 129, 242, 56, 88, 119, 195, 53, 172, 86, 173, 135, 30, 7, 44, 201, 221, 195, 161, 130, 206, 151, 135, 116, 21, 62, 84, 219, 94, 109, 143, 210, 9, 11, 44, 195, 71, 120, 97, 77, 128, 1, 7, 100, 33, 24, 44, 124, 64, 245, 111, 130, 142, 62, 207, 238, 197, 72, 227, 124, 64, 102, 166, 185, 197, 194, 200, 29, 118, 17, 134, 39, 222, 184, 226, 77, 202, 157, 84, 94, 81, 182, 25, 220, 2, 24, 42, 165, 239 } },
                    { 16, new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(9284), "Emma@mail.com", "Emma", "45", false, "Schoonkind", new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(9284), new byte[] { 235, 214, 58, 248, 34, 223, 156, 170, 13, 248, 1, 132, 65, 19, 189, 93, 7, 78, 162, 39, 14, 250, 192, 62, 96, 237, 44, 162, 161, 202, 242, 59, 9, 76, 1, 214, 143, 183, 141, 231, 225, 32, 27, 238, 57, 157, 146, 179, 124, 38, 204, 18, 195, 218, 206, 140, 8, 174, 5, 69, 76, 143, 192, 177 }, new byte[] { 93, 17, 223, 123, 85, 116, 217, 5, 107, 87, 130, 193, 5, 80, 126, 159, 56, 177, 253, 228, 123, 54, 52, 138, 234, 193, 91, 58, 207, 240, 156, 179, 197, 138, 106, 100, 121, 206, 77, 247, 129, 242, 56, 88, 119, 195, 53, 172, 86, 173, 135, 30, 7, 44, 201, 221, 195, 161, 130, 206, 151, 135, 116, 21, 62, 84, 219, 94, 109, 143, 210, 9, 11, 44, 195, 71, 120, 97, 77, 128, 1, 7, 100, 33, 24, 44, 124, 64, 245, 111, 130, 142, 62, 207, 238, 197, 72, 227, 124, 64, 102, 166, 185, 197, 194, 200, 29, 118, 17, 134, 39, 222, 184, 226, 77, 202, 157, 84, 94, 81, 182, 25, 220, 2, 24, 42, 165, 239 } },
                    { 15, new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(9271), "Anke@mail.com", "Anke", "27", false, "Kleurenkenner", new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(9271), new byte[] { 235, 214, 58, 248, 34, 223, 156, 170, 13, 248, 1, 132, 65, 19, 189, 93, 7, 78, 162, 39, 14, 250, 192, 62, 96, 237, 44, 162, 161, 202, 242, 59, 9, 76, 1, 214, 143, 183, 141, 231, 225, 32, 27, 238, 57, 157, 146, 179, 124, 38, 204, 18, 195, 218, 206, 140, 8, 174, 5, 69, 76, 143, 192, 177 }, new byte[] { 93, 17, 223, 123, 85, 116, 217, 5, 107, 87, 130, 193, 5, 80, 126, 159, 56, 177, 253, 228, 123, 54, 52, 138, 234, 193, 91, 58, 207, 240, 156, 179, 197, 138, 106, 100, 121, 206, 77, 247, 129, 242, 56, 88, 119, 195, 53, 172, 86, 173, 135, 30, 7, 44, 201, 221, 195, 161, 130, 206, 151, 135, 116, 21, 62, 84, 219, 94, 109, 143, 210, 9, 11, 44, 195, 71, 120, 97, 77, 128, 1, 7, 100, 33, 24, 44, 124, 64, 245, 111, 130, 142, 62, 207, 238, 197, 72, 227, 124, 64, 102, 166, 185, 197, 194, 200, 29, 118, 17, 134, 39, 222, 184, 226, 77, 202, 157, 84, 94, 81, 182, 25, 220, 2, 24, 42, 165, 239 } },
                    { 20, new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(9337), "Hoon@mail.com", "Hoon", "99", false, "Tomatenplukker", new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(9337), new byte[] { 235, 214, 58, 248, 34, 223, 156, 170, 13, 248, 1, 132, 65, 19, 189, 93, 7, 78, 162, 39, 14, 250, 192, 62, 96, 237, 44, 162, 161, 202, 242, 59, 9, 76, 1, 214, 143, 183, 141, 231, 225, 32, 27, 238, 57, 157, 146, 179, 124, 38, 204, 18, 195, 218, 206, 140, 8, 174, 5, 69, 76, 143, 192, 177 }, new byte[] { 93, 17, 223, 123, 85, 116, 217, 5, 107, 87, 130, 193, 5, 80, 126, 159, 56, 177, 253, 228, 123, 54, 52, 138, 234, 193, 91, 58, 207, 240, 156, 179, 197, 138, 106, 100, 121, 206, 77, 247, 129, 242, 56, 88, 119, 195, 53, 172, 86, 173, 135, 30, 7, 44, 201, 221, 195, 161, 130, 206, 151, 135, 116, 21, 62, 84, 219, 94, 109, 143, 210, 9, 11, 44, 195, 71, 120, 97, 77, 128, 1, 7, 100, 33, 24, 44, 124, 64, 245, 111, 130, 142, 62, 207, 238, 197, 72, 227, 124, 64, 102, 166, 185, 197, 194, 200, 29, 118, 17, 134, 39, 222, 184, 226, 77, 202, 157, 84, 94, 81, 182, 25, 220, 2, 24, 42, 165, 239 } },
                    { 14, new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(9258), "Marieke@mail.com", "Marieke", "T1", false, "Van Leren Broeke", new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(9258), new byte[] { 235, 214, 58, 248, 34, 223, 156, 170, 13, 248, 1, 132, 65, 19, 189, 93, 7, 78, 162, 39, 14, 250, 192, 62, 96, 237, 44, 162, 161, 202, 242, 59, 9, 76, 1, 214, 143, 183, 141, 231, 225, 32, 27, 238, 57, 157, 146, 179, 124, 38, 204, 18, 195, 218, 206, 140, 8, 174, 5, 69, 76, 143, 192, 177 }, new byte[] { 93, 17, 223, 123, 85, 116, 217, 5, 107, 87, 130, 193, 5, 80, 126, 159, 56, 177, 253, 228, 123, 54, 52, 138, 234, 193, 91, 58, 207, 240, 156, 179, 197, 138, 106, 100, 121, 206, 77, 247, 129, 242, 56, 88, 119, 195, 53, 172, 86, 173, 135, 30, 7, 44, 201, 221, 195, 161, 130, 206, 151, 135, 116, 21, 62, 84, 219, 94, 109, 143, 210, 9, 11, 44, 195, 71, 120, 97, 77, 128, 1, 7, 100, 33, 24, 44, 124, 64, 245, 111, 130, 142, 62, 207, 238, 197, 72, 227, 124, 64, 102, 166, 185, 197, 194, 200, 29, 118, 17, 134, 39, 222, 184, 226, 77, 202, 157, 84, 94, 81, 182, 25, 220, 2, 24, 42, 165, 239 } },
                    { 13, new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(9243), "Joyce@mail.com", "Joyce", "75", false, "Recruiter", new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(9243), new byte[] { 235, 214, 58, 248, 34, 223, 156, 170, 13, 248, 1, 132, 65, 19, 189, 93, 7, 78, 162, 39, 14, 250, 192, 62, 96, 237, 44, 162, 161, 202, 242, 59, 9, 76, 1, 214, 143, 183, 141, 231, 225, 32, 27, 238, 57, 157, 146, 179, 124, 38, 204, 18, 195, 218, 206, 140, 8, 174, 5, 69, 76, 143, 192, 177 }, new byte[] { 93, 17, 223, 123, 85, 116, 217, 5, 107, 87, 130, 193, 5, 80, 126, 159, 56, 177, 253, 228, 123, 54, 52, 138, 234, 193, 91, 58, 207, 240, 156, 179, 197, 138, 106, 100, 121, 206, 77, 247, 129, 242, 56, 88, 119, 195, 53, 172, 86, 173, 135, 30, 7, 44, 201, 221, 195, 161, 130, 206, 151, 135, 116, 21, 62, 84, 219, 94, 109, 143, 210, 9, 11, 44, 195, 71, 120, 97, 77, 128, 1, 7, 100, 33, 24, 44, 124, 64, 245, 111, 130, 142, 62, 207, 238, 197, 72, 227, 124, 64, 102, 166, 185, 197, 194, 200, 29, 118, 17, 134, 39, 222, 184, 226, 77, 202, 157, 84, 94, 81, 182, 25, 220, 2, 24, 42, 165, 239 } },
                    { 11, new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(9217), "Jens@mail.com", "Jens", "Zeemlap", false, "Spinning", new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(9217), new byte[] { 235, 214, 58, 248, 34, 223, 156, 170, 13, 248, 1, 132, 65, 19, 189, 93, 7, 78, 162, 39, 14, 250, 192, 62, 96, 237, 44, 162, 161, 202, 242, 59, 9, 76, 1, 214, 143, 183, 141, 231, 225, 32, 27, 238, 57, 157, 146, 179, 124, 38, 204, 18, 195, 218, 206, 140, 8, 174, 5, 69, 76, 143, 192, 177 }, new byte[] { 93, 17, 223, 123, 85, 116, 217, 5, 107, 87, 130, 193, 5, 80, 126, 159, 56, 177, 253, 228, 123, 54, 52, 138, 234, 193, 91, 58, 207, 240, 156, 179, 197, 138, 106, 100, 121, 206, 77, 247, 129, 242, 56, 88, 119, 195, 53, 172, 86, 173, 135, 30, 7, 44, 201, 221, 195, 161, 130, 206, 151, 135, 116, 21, 62, 84, 219, 94, 109, 143, 210, 9, 11, 44, 195, 71, 120, 97, 77, 128, 1, 7, 100, 33, 24, 44, 124, 64, 245, 111, 130, 142, 62, 207, 238, 197, 72, 227, 124, 64, 102, 166, 185, 197, 194, 200, 29, 118, 17, 134, 39, 222, 184, 226, 77, 202, 157, 84, 94, 81, 182, 25, 220, 2, 24, 42, 165, 239 } },
                    { 6, new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(9099), "Emma@mail.com", "Emma", "Stofzuiger", false, "Kipdorp", new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(9099), new byte[] { 235, 214, 58, 248, 34, 223, 156, 170, 13, 248, 1, 132, 65, 19, 189, 93, 7, 78, 162, 39, 14, 250, 192, 62, 96, 237, 44, 162, 161, 202, 242, 59, 9, 76, 1, 214, 143, 183, 141, 231, 225, 32, 27, 238, 57, 157, 146, 179, 124, 38, 204, 18, 195, 218, 206, 140, 8, 174, 5, 69, 76, 143, 192, 177 }, new byte[] { 93, 17, 223, 123, 85, 116, 217, 5, 107, 87, 130, 193, 5, 80, 126, 159, 56, 177, 253, 228, 123, 54, 52, 138, 234, 193, 91, 58, 207, 240, 156, 179, 197, 138, 106, 100, 121, 206, 77, 247, 129, 242, 56, 88, 119, 195, 53, 172, 86, 173, 135, 30, 7, 44, 201, 221, 195, 161, 130, 206, 151, 135, 116, 21, 62, 84, 219, 94, 109, 143, 210, 9, 11, 44, 195, 71, 120, 97, 77, 128, 1, 7, 100, 33, 24, 44, 124, 64, 245, 111, 130, 142, 62, 207, 238, 197, 72, 227, 124, 64, 102, 166, 185, 197, 194, 200, 29, 118, 17, 134, 39, 222, 184, 226, 77, 202, 157, 84, 94, 81, 182, 25, 220, 2, 24, 42, 165, 239 } },
                    { 9, new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(9187), "Michiel@mail.com", "Michiel", "g283?set=set4", false, "Demogod", new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(9187), new byte[] { 235, 214, 58, 248, 34, 223, 156, 170, 13, 248, 1, 132, 65, 19, 189, 93, 7, 78, 162, 39, 14, 250, 192, 62, 96, 237, 44, 162, 161, 202, 242, 59, 9, 76, 1, 214, 143, 183, 141, 231, 225, 32, 27, 238, 57, 157, 146, 179, 124, 38, 204, 18, 195, 218, 206, 140, 8, 174, 5, 69, 76, 143, 192, 177 }, new byte[] { 93, 17, 223, 123, 85, 116, 217, 5, 107, 87, 130, 193, 5, 80, 126, 159, 56, 177, 253, 228, 123, 54, 52, 138, 234, 193, 91, 58, 207, 240, 156, 179, 197, 138, 106, 100, 121, 206, 77, 247, 129, 242, 56, 88, 119, 195, 53, 172, 86, 173, 135, 30, 7, 44, 201, 221, 195, 161, 130, 206, 151, 135, 116, 21, 62, 84, 219, 94, 109, 143, 210, 9, 11, 44, 195, 71, 120, 97, 77, 128, 1, 7, 100, 33, 24, 44, 124, 64, 245, 111, 130, 142, 62, 207, 238, 197, 72, 227, 124, 64, 102, 166, 185, 197, 194, 200, 29, 118, 17, 134, 39, 222, 184, 226, 77, 202, 157, 84, 94, 81, 182, 25, 220, 2, 24, 42, 165, 239 } },
                    { 8, new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(9126), "Andreas@mail.com", "Andreas", "Andreas", false, "VanGrieken", new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(9126), new byte[] { 235, 214, 58, 248, 34, 223, 156, 170, 13, 248, 1, 132, 65, 19, 189, 93, 7, 78, 162, 39, 14, 250, 192, 62, 96, 237, 44, 162, 161, 202, 242, 59, 9, 76, 1, 214, 143, 183, 141, 231, 225, 32, 27, 238, 57, 157, 146, 179, 124, 38, 204, 18, 195, 218, 206, 140, 8, 174, 5, 69, 76, 143, 192, 177 }, new byte[] { 93, 17, 223, 123, 85, 116, 217, 5, 107, 87, 130, 193, 5, 80, 126, 159, 56, 177, 253, 228, 123, 54, 52, 138, 234, 193, 91, 58, 207, 240, 156, 179, 197, 138, 106, 100, 121, 206, 77, 247, 129, 242, 56, 88, 119, 195, 53, 172, 86, 173, 135, 30, 7, 44, 201, 221, 195, 161, 130, 206, 151, 135, 116, 21, 62, 84, 219, 94, 109, 143, 210, 9, 11, 44, 195, 71, 120, 97, 77, 128, 1, 7, 100, 33, 24, 44, 124, 64, 245, 111, 130, 142, 62, 207, 238, 197, 72, 227, 124, 64, 102, 166, 185, 197, 194, 200, 29, 118, 17, 134, 39, 222, 184, 226, 77, 202, 157, 84, 94, 81, 182, 25, 220, 2, 24, 42, 165, 239 } },
                    { 7, new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(9113), "Ward@mail.com", "Ward", "Dirk", false, "Motormouth", new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(9113), new byte[] { 235, 214, 58, 248, 34, 223, 156, 170, 13, 248, 1, 132, 65, 19, 189, 93, 7, 78, 162, 39, 14, 250, 192, 62, 96, 237, 44, 162, 161, 202, 242, 59, 9, 76, 1, 214, 143, 183, 141, 231, 225, 32, 27, 238, 57, 157, 146, 179, 124, 38, 204, 18, 195, 218, 206, 140, 8, 174, 5, 69, 76, 143, 192, 177 }, new byte[] { 93, 17, 223, 123, 85, 116, 217, 5, 107, 87, 130, 193, 5, 80, 126, 159, 56, 177, 253, 228, 123, 54, 52, 138, 234, 193, 91, 58, 207, 240, 156, 179, 197, 138, 106, 100, 121, 206, 77, 247, 129, 242, 56, 88, 119, 195, 53, 172, 86, 173, 135, 30, 7, 44, 201, 221, 195, 161, 130, 206, 151, 135, 116, 21, 62, 84, 219, 94, 109, 143, 210, 9, 11, 44, 195, 71, 120, 97, 77, 128, 1, 7, 100, 33, 24, 44, 124, 64, 245, 111, 130, 142, 62, 207, 238, 197, 72, 227, 124, 64, 102, 166, 185, 197, 194, 200, 29, 118, 17, 134, 39, 222, 184, 226, 77, 202, 157, 84, 94, 81, 182, 25, 220, 2, 24, 42, 165, 239 } },
                    { 5, new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(9085), "Seba@mail.com", "Seba", "BartjeWevertje", false, "Alwayszen", new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(9085), new byte[] { 235, 214, 58, 248, 34, 223, 156, 170, 13, 248, 1, 132, 65, 19, 189, 93, 7, 78, 162, 39, 14, 250, 192, 62, 96, 237, 44, 162, 161, 202, 242, 59, 9, 76, 1, 214, 143, 183, 141, 231, 225, 32, 27, 238, 57, 157, 146, 179, 124, 38, 204, 18, 195, 218, 206, 140, 8, 174, 5, 69, 76, 143, 192, 177 }, new byte[] { 93, 17, 223, 123, 85, 116, 217, 5, 107, 87, 130, 193, 5, 80, 126, 159, 56, 177, 253, 228, 123, 54, 52, 138, 234, 193, 91, 58, 207, 240, 156, 179, 197, 138, 106, 100, 121, 206, 77, 247, 129, 242, 56, 88, 119, 195, 53, 172, 86, 173, 135, 30, 7, 44, 201, 221, 195, 161, 130, 206, 151, 135, 116, 21, 62, 84, 219, 94, 109, 143, 210, 9, 11, 44, 195, 71, 120, 97, 77, 128, 1, 7, 100, 33, 24, 44, 124, 64, 245, 111, 130, 142, 62, 207, 238, 197, 72, 227, 124, 64, 102, 166, 185, 197, 194, 200, 29, 118, 17, 134, 39, 222, 184, 226, 77, 202, 157, 84, 94, 81, 182, 25, 220, 2, 24, 42, 165, 239 } },
                    { 4, new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(9070), "Drieswilgraageenlangemail@mail.be", "Dries", "Dries", true, "Promailer", new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(9070), new byte[] { 235, 214, 58, 248, 34, 223, 156, 170, 13, 248, 1, 132, 65, 19, 189, 93, 7, 78, 162, 39, 14, 250, 192, 62, 96, 237, 44, 162, 161, 202, 242, 59, 9, 76, 1, 214, 143, 183, 141, 231, 225, 32, 27, 238, 57, 157, 146, 179, 124, 38, 204, 18, 195, 218, 206, 140, 8, 174, 5, 69, 76, 143, 192, 177 }, new byte[] { 93, 17, 223, 123, 85, 116, 217, 5, 107, 87, 130, 193, 5, 80, 126, 159, 56, 177, 253, 228, 123, 54, 52, 138, 234, 193, 91, 58, 207, 240, 156, 179, 197, 138, 106, 100, 121, 206, 77, 247, 129, 242, 56, 88, 119, 195, 53, 172, 86, 173, 135, 30, 7, 44, 201, 221, 195, 161, 130, 206, 151, 135, 116, 21, 62, 84, 219, 94, 109, 143, 210, 9, 11, 44, 195, 71, 120, 97, 77, 128, 1, 7, 100, 33, 24, 44, 124, 64, 245, 111, 130, 142, 62, 207, 238, 197, 72, 227, 124, 64, 102, 166, 185, 197, 194, 200, 29, 118, 17, 134, 39, 222, 184, 226, 77, 202, 157, 84, 94, 81, 182, 25, 220, 2, 24, 42, 165, 239 } },
                    { 3, new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(9048), "Kobe@mail.com", "Kobe", "Kobe", true, "Neut", new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(9048), new byte[] { 235, 214, 58, 248, 34, 223, 156, 170, 13, 248, 1, 132, 65, 19, 189, 93, 7, 78, 162, 39, 14, 250, 192, 62, 96, 237, 44, 162, 161, 202, 242, 59, 9, 76, 1, 214, 143, 183, 141, 231, 225, 32, 27, 238, 57, 157, 146, 179, 124, 38, 204, 18, 195, 218, 206, 140, 8, 174, 5, 69, 76, 143, 192, 177 }, new byte[] { 93, 17, 223, 123, 85, 116, 217, 5, 107, 87, 130, 193, 5, 80, 126, 159, 56, 177, 253, 228, 123, 54, 52, 138, 234, 193, 91, 58, 207, 240, 156, 179, 197, 138, 106, 100, 121, 206, 77, 247, 129, 242, 56, 88, 119, 195, 53, 172, 86, 173, 135, 30, 7, 44, 201, 221, 195, 161, 130, 206, 151, 135, 116, 21, 62, 84, 219, 94, 109, 143, 210, 9, 11, 44, 195, 71, 120, 97, 77, 128, 1, 7, 100, 33, 24, 44, 124, 64, 245, 111, 130, 142, 62, 207, 238, 197, 72, 227, 124, 64, 102, 166, 185, 197, 194, 200, 29, 118, 17, 134, 39, 222, 184, 226, 77, 202, 157, 84, 94, 81, 182, 25, 220, 2, 24, 42, 165, 239 } },
                    { 2, new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(8825), "Nick@mail.com", "Nick", "Nick", true, "Angularlover", new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(8825), new byte[] { 235, 214, 58, 248, 34, 223, 156, 170, 13, 248, 1, 132, 65, 19, 189, 93, 7, 78, 162, 39, 14, 250, 192, 62, 96, 237, 44, 162, 161, 202, 242, 59, 9, 76, 1, 214, 143, 183, 141, 231, 225, 32, 27, 238, 57, 157, 146, 179, 124, 38, 204, 18, 195, 218, 206, 140, 8, 174, 5, 69, 76, 143, 192, 177 }, new byte[] { 93, 17, 223, 123, 85, 116, 217, 5, 107, 87, 130, 193, 5, 80, 126, 159, 56, 177, 253, 228, 123, 54, 52, 138, 234, 193, 91, 58, 207, 240, 156, 179, 197, 138, 106, 100, 121, 206, 77, 247, 129, 242, 56, 88, 119, 195, 53, 172, 86, 173, 135, 30, 7, 44, 201, 221, 195, 161, 130, 206, 151, 135, 116, 21, 62, 84, 219, 94, 109, 143, 210, 9, 11, 44, 195, 71, 120, 97, 77, 128, 1, 7, 100, 33, 24, 44, 124, 64, 245, 111, 130, 142, 62, 207, 238, 197, 72, 227, 124, 64, 102, 166, 185, 197, 194, 200, 29, 118, 17, 134, 39, 222, 184, 226, 77, 202, 157, 84, 94, 81, 182, 25, 220, 2, 24, 42, 165, 239 } },
                    { 1, new DateTime(2021, 5, 25, 8, 33, 33, 393, DateTimeKind.Local).AddTicks(3819), "Pieter@mail.com", "Pieter", "Pieter", true, "Slaapkop", new DateTime(2021, 5, 25, 8, 33, 33, 393, DateTimeKind.Local).AddTicks(3819), new byte[] { 235, 214, 58, 248, 34, 223, 156, 170, 13, 248, 1, 132, 65, 19, 189, 93, 7, 78, 162, 39, 14, 250, 192, 62, 96, 237, 44, 162, 161, 202, 242, 59, 9, 76, 1, 214, 143, 183, 141, 231, 225, 32, 27, 238, 57, 157, 146, 179, 124, 38, 204, 18, 195, 218, 206, 140, 8, 174, 5, 69, 76, 143, 192, 177 }, new byte[] { 93, 17, 223, 123, 85, 116, 217, 5, 107, 87, 130, 193, 5, 80, 126, 159, 56, 177, 253, 228, 123, 54, 52, 138, 234, 193, 91, 58, 207, 240, 156, 179, 197, 138, 106, 100, 121, 206, 77, 247, 129, 242, 56, 88, 119, 195, 53, 172, 86, 173, 135, 30, 7, 44, 201, 221, 195, 161, 130, 206, 151, 135, 116, 21, 62, 84, 219, 94, 109, 143, 210, 9, 11, 44, 195, 71, 120, 97, 77, 128, 1, 7, 100, 33, 24, 44, 124, 64, 245, 111, 130, 142, 62, 207, 238, 197, 72, 227, 124, 64, 102, 166, 185, 197, 194, 200, 29, 118, 17, 134, 39, 222, 184, 226, 77, 202, 157, 84, 94, 81, 182, 25, 220, 2, 24, 42, 165, 239 } },
                    { 21, new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(9350), "Michaël@mail.com", "Michaël", "25", false, "Wanderer", new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(9350), new byte[] { 235, 214, 58, 248, 34, 223, 156, 170, 13, 248, 1, 132, 65, 19, 189, 93, 7, 78, 162, 39, 14, 250, 192, 62, 96, 237, 44, 162, 161, 202, 242, 59, 9, 76, 1, 214, 143, 183, 141, 231, 225, 32, 27, 238, 57, 157, 146, 179, 124, 38, 204, 18, 195, 218, 206, 140, 8, 174, 5, 69, 76, 143, 192, 177 }, new byte[] { 93, 17, 223, 123, 85, 116, 217, 5, 107, 87, 130, 193, 5, 80, 126, 159, 56, 177, 253, 228, 123, 54, 52, 138, 234, 193, 91, 58, 207, 240, 156, 179, 197, 138, 106, 100, 121, 206, 77, 247, 129, 242, 56, 88, 119, 195, 53, 172, 86, 173, 135, 30, 7, 44, 201, 221, 195, 161, 130, 206, 151, 135, 116, 21, 62, 84, 219, 94, 109, 143, 210, 9, 11, 44, 195, 71, 120, 97, 77, 128, 1, 7, 100, 33, 24, 44, 124, 64, 245, 111, 130, 142, 62, 207, 238, 197, 72, 227, 124, 64, 102, 166, 185, 197, 194, 200, 29, 118, 17, 134, 39, 222, 184, 226, 77, 202, 157, 84, 94, 81, 182, 25, 220, 2, 24, 42, 165, 239 } },
                    { 10, new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(9202), "Diederik@mail.com", "Diederik", "Luc", false, "Featurefixer", new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(9202), new byte[] { 235, 214, 58, 248, 34, 223, 156, 170, 13, 248, 1, 132, 65, 19, 189, 93, 7, 78, 162, 39, 14, 250, 192, 62, 96, 237, 44, 162, 161, 202, 242, 59, 9, 76, 1, 214, 143, 183, 141, 231, 225, 32, 27, 238, 57, 157, 146, 179, 124, 38, 204, 18, 195, 218, 206, 140, 8, 174, 5, 69, 76, 143, 192, 177 }, new byte[] { 93, 17, 223, 123, 85, 116, 217, 5, 107, 87, 130, 193, 5, 80, 126, 159, 56, 177, 253, 228, 123, 54, 52, 138, 234, 193, 91, 58, 207, 240, 156, 179, 197, 138, 106, 100, 121, 206, 77, 247, 129, 242, 56, 88, 119, 195, 53, 172, 86, 173, 135, 30, 7, 44, 201, 221, 195, 161, 130, 206, 151, 135, 116, 21, 62, 84, 219, 94, 109, 143, 210, 9, 11, 44, 195, 71, 120, 97, 77, 128, 1, 7, 100, 33, 24, 44, 124, 64, 245, 111, 130, 142, 62, 207, 238, 197, 72, 227, 124, 64, 102, 166, 185, 197, 194, 200, 29, 118, 17, 134, 39, 222, 184, 226, 77, 202, 157, 84, 94, 81, 182, 25, 220, 2, 24, 42, 165, 239 } },
                    { 22, new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(9363), "Brent@mail.com", "Brent", "29", false, "Tomatentrucker", new DateTime(2021, 5, 25, 8, 33, 33, 396, DateTimeKind.Local).AddTicks(9363), new byte[] { 235, 214, 58, 248, 34, 223, 156, 170, 13, 248, 1, 132, 65, 19, 189, 93, 7, 78, 162, 39, 14, 250, 192, 62, 96, 237, 44, 162, 161, 202, 242, 59, 9, 76, 1, 214, 143, 183, 141, 231, 225, 32, 27, 238, 57, 157, 146, 179, 124, 38, 204, 18, 195, 218, 206, 140, 8, 174, 5, 69, 76, 143, 192, 177 }, new byte[] { 93, 17, 223, 123, 85, 116, 217, 5, 107, 87, 130, 193, 5, 80, 126, 159, 56, 177, 253, 228, 123, 54, 52, 138, 234, 193, 91, 58, 207, 240, 156, 179, 197, 138, 106, 100, 121, 206, 77, 247, 129, 242, 56, 88, 119, 195, 53, 172, 86, 173, 135, 30, 7, 44, 201, 221, 195, 161, 130, 206, 151, 135, 116, 21, 62, 84, 219, 94, 109, 143, 210, 9, 11, 44, 195, 71, 120, 97, 77, 128, 1, 7, 100, 33, 24, 44, 124, 64, 245, 111, 130, 142, 62, 207, 238, 197, 72, 227, 124, 64, 102, 166, 185, 197, 194, 200, 29, 118, 17, 134, 39, 222, 184, 226, 77, 202, 157, 84, 94, 81, 182, 25, 220, 2, 24, 42, 165, 239 } }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "PostalCode", "StreetName", "StreetNumber", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 25, 8, 33, 33, 398, DateTimeKind.Local).AddTicks(9007), new DateTime(2021, 5, 25, 8, 33, 33, 398, DateTimeKind.Local).AddTicks(9007), 9000, "Anti-Veggiestraat", 89, 1 },
                    { 10, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(736), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(736), 9070, "Geenpolitiekinhetprojectstraat", 200, 10 },
                    { 12, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(741), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(741), 1000, "Blacklivesmatterstraat", 78, 12 },
                    { 9, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(734), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(734), 2000, "Greenlivesmattertooweg", 420, 9 },
                    { 8, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(731), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(731), 1000, "Kotsvisplein", 96, 8 },
                    { 13, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(744), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(744), 7000, "Worstenbroodjesstraat", 4, 13 },
                    { 7, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(729), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(729), 9050, "Greenpeacestraat", 1, 7 },
                    { 14, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(746), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(746), 9000, "Jurgenzitverstoptachterhetlamgodsstraat", 24, 14 },
                    { 6, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(726), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(726), 1000, "Spekmeteierenstraat", 43, 6 },
                    { 5, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(724), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(724), 9000, "Boerenworststraat", 85, 5 },
                    { 15, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(748), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(748), 1081, "Bloedworststraat", 78, 15 },
                    { 4, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(720), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(720), 1000, "Vleesbroodstraat", 66, 4 },
                    { 16, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(751), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(751), 1180, "Gemarineerderunderlendedreef", 36, 16 },
                    { 17, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(753), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(753), 1500, "Ribbetjesstraat", 14, 17 },
                    { 3, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(717), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(717), 4000, "Balletjesintomatensausstraat", 74, 3 },
                    { 11, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(739), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(739), 9500, "Kalfslapjesstraat", 32, 11 },
                    { 19, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(758), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(758), 2323, "Lookbroodjesstraat", 11, 19 },
                    { 20, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(760), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(760), 2890, "Worstenbroodjesstraat", 79, 20 },
                    { 18, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(756), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(756), 2070, "Bickyburgerstraat", 15, 18 },
                    { 21, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(763), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(763), 3020, "Huisgemaaktekalfsbitterballetjesstraat", 100, 21 },
                    { 2, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(705), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(705), 3000, "Vrbaan", 45, 2 },
                    { 22, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(765), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(765), 3110, "Kalfsrib-eyelaan", 107, 22 }
                });

            migrationBuilder.InsertData(
                table: "TradeItems",
                columns: new[] { "Id", "Amount", "CreatedAt", "ModifiedAt", "ResourceId", "UserId" },
                values: new object[,]
                {
                    { 82, 52, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6219), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6219), 23, 21 },
                    { 54, 19, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6078), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6078), 12, 13 },
                    { 41, 17, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6047), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6047), 1, 11 },
                    { 53, 33, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6075), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6075), 35, 13 },
                    { 52, 22, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6073), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6073), 48, 13 },
                    { 51, 17, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6070), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6070), 47, 13 },
                    { 50, 17, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6068), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6068), 51, 13 },
                    { 80, 7, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6214), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6214), 17, 20 },
                    { 81, 13, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6217), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6217), 18, 20 },
                    { 49, 21, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6065), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6065), 12, 12 },
                    { 48, 17, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6063), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6063), 9, 12 },
                    { 55, 9, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6080), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6080), 7, 13 },
                    { 47, 34, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6061), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6061), 8, 12 },
                    { 46, 25, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6058), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6058), 47, 12 },
                    { 45, 12, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6056), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6056), 29, 12 },
                    { 42, 3, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6049), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6049), 3, 11 },
                    { 44, 78, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6054), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6054), 18, 12 },
                    { 43, 28, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6051), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6051), 7, 11 },
                    { 76, 80, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6205), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6205), 5, 17 },
                    { 57, 13, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6093), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6093), 29, 13 }
                });

            migrationBuilder.InsertData(
                table: "TradeItems",
                columns: new[] { "Id", "Amount", "CreatedAt", "ModifiedAt", "ResourceId", "UserId" },
                values: new object[,]
                {
                    { 75, 113, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6202), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6202), 3, 17 },
                    { 74, 78, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6200), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6200), 36, 16 },
                    { 73, 35, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6197), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6197), 38, 16 },
                    { 72, 24, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6195), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6195), 39, 16 },
                    { 77, 17, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6207), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6207), 6, 17 },
                    { 71, 1, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6193), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6193), 3, 15 },
                    { 70, 8, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6190), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6190), 51, 15 },
                    { 69, 153, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6122), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6122), 29, 15 },
                    { 68, 157, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6120), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6120), 22, 15 },
                    { 67, 19, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6116), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6116), 21, 15 },
                    { 56, 35, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6091), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6091), 8, 13 },
                    { 66, 78, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6114), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6114), 18, 15 },
                    { 65, 24, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6112), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6112), 17, 14 },
                    { 64, 88, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6109), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6109), 12, 14 },
                    { 83, 8, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6221), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6221), 26, 22 },
                    { 62, 39, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6105), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6105), 11, 14 },
                    { 61, 47, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6102), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6102), 8, 14 },
                    { 60, 19, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6100), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6100), 1, 14 },
                    { 79, 90, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6212), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6212), 44, 19 },
                    { 59, 17, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6098), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6098), 41, 13 },
                    { 58, 8, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6096), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6096), 38, 13 },
                    { 78, 99, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6210), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6210), 51, 19 },
                    { 63, 77, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6107), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6107), 9, 14 },
                    { 40, 33, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6041), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6041), 51, 11 },
                    { 39, 53, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6038), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6038), 19, 10 },
                    { 25, 5, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6003), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6003), 39, 6 },
                    { 24, 78, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6001), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6001), 32, 5 },
                    { 23, 38, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5999), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5999), 46, 5 },
                    { 22, 39, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5996), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5996), 17, 5 },
                    { 21, 63, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5994), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5994), 51, 5 },
                    { 20, 47, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5992), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5992), 7, 5 },
                    { 5, 41, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5938), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5938), 51, 2 },
                    { 19, 50, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5989), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5989), 51, 4 },
                    { 18, 36, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5981), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5981), 44, 4 },
                    { 17, 89, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5978), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5978), 21, 4 },
                    { 6, 30, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5942), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5942), 34, 2 },
                    { 16, 17, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5976), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5976), 31, 3 },
                    { 15, 30, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5973), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5973), 6, 3 },
                    { 7, 40, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5946), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5946), 46, 2 },
                    { 14, 49, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5971), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5971), 13, 3 },
                    { 13, 17, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5968), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5968), 8, 3 },
                    { 12, 20, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5966), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5966), 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "TradeItems",
                columns: new[] { "Id", "Amount", "CreatedAt", "ModifiedAt", "ResourceId", "UserId" },
                values: new object[,]
                {
                    { 11, 47, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5961), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5961), 51, 3 },
                    { 8, 5, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5951), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5951), 32, 2 },
                    { 10, 32, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5957), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5957), 15, 2 },
                    { 26, 10, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6006), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6006), 15, 6 },
                    { 9, 25, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5953), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5953), 39, 2 },
                    { 28, 10, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6011), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6011), 4, 6 },
                    { 33, 78, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6024), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6024), 6, 8 },
                    { 27, 12, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6008), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6008), 51, 6 },
                    { 35, 26, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6029), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6029), 51, 9 },
                    { 3, 12, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5931), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5931), 5, 1 },
                    { 36, 17, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6032), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6032), 14, 9 },
                    { 37, 69, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6034), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6034), 36, 9 },
                    { 34, 53, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6027), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6027), 51, 8 },
                    { 32, 38, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6022), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6022), 51, 7 },
                    { 30, 23, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6017), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6017), 13, 7 },
                    { 29, 19, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6015), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6015), 8, 7 },
                    { 1, 47, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(4517), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(4517), 1, 1 },
                    { 38, 34, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6036), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6036), 17, 10 },
                    { 4, 99, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5934), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5934), 7, 1 },
                    { 31, 36, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6020), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(6020), 6, 7 },
                    { 2, 36, new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5919), new DateTime(2021, 5, 25, 8, 33, 33, 403, DateTimeKind.Local).AddTicks(5919), 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Trades",
                columns: new[] { "Id", "ActiveUserId", "Completed", "CreatedAt", "ModifiedAt", "ProposerId", "ReceiverId" },
                values: new object[,]
                {
                    { 2, 3, false, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(7191), new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(7191), 3, 2 },
                    { 4, 1, false, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(7206), new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(7206), 1, 8 },
                    { 6, 7, false, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(7211), new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(7211), 7, 2 },
                    { 1, 1, false, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(5575), new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(5575), 2, 1 },
                    { 5, 7, false, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(7208), new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(7208), 4, 7 },
                    { 3, 6, false, new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(7203), new DateTime(2021, 5, 25, 8, 33, 33, 401, DateTimeKind.Local).AddTicks(7203), 6, 8 }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "UserId", "VAmount" },
                values: new object[,]
                {
                    { 20, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9284), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9284), 20, 56m },
                    { 21, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9286), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9286), 21, 78m },
                    { 19, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9281), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9281), 19, 78m },
                    { 18, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9279), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9279), 18, 65m },
                    { 1, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(8207), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(8207), 1, 200m },
                    { 4, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9246), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9246), 4, 42m },
                    { 2, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9230), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9230), 2, 347m },
                    { 16, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9275), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9275), 16, 28m },
                    { 15, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9272), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9272), 15, 47m },
                    { 3, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9243), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9243), 3, 65m },
                    { 10, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9260), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9260), 10, 124m },
                    { 14, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9270), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9270), 14, 20m },
                    { 5, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9248), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9248), 5, 753m },
                    { 13, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9268), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9268), 13, 204m },
                    { 6, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9251), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9251), 6, 36m }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "UserId", "VAmount" },
                values: new object[,]
                {
                    { 7, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9253), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9253), 7, 12m },
                    { 12, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9265), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9265), 12, 57m },
                    { 8, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9256), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9256), 8, 654m },
                    { 11, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9263), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9263), 11, 269m },
                    { 9, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9258), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9258), 9, 357m },
                    { 17, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9277), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9277), 17, 104m },
                    { 22, new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9288), new DateTime(2021, 5, 25, 8, 33, 33, 399, DateTimeKind.Local).AddTicks(9288), 22, 9m }
                });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "CreatedAt", "EuroAmount", "ModifiedAt", "VAmount", "WalletId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 25, 8, 33, 33, 404, DateTimeKind.Local).AddTicks(5515), 6.9m, new DateTime(2021, 5, 25, 8, 33, 33, 404, DateTimeKind.Local).AddTicks(5515), 69m, 1 },
                    { 7, new DateTime(2021, 5, 25, 8, 33, 33, 404, DateTimeKind.Local).AddTicks(7185), 9.8m, new DateTime(2021, 5, 25, 8, 33, 33, 404, DateTimeKind.Local).AddTicks(7185), 98m, 9 },
                    { 8, new DateTime(2021, 5, 25, 8, 33, 33, 404, DateTimeKind.Local).AddTicks(7187), 5m, new DateTime(2021, 5, 25, 8, 33, 33, 404, DateTimeKind.Local).AddTicks(7187), 50m, 7 },
                    { 6, new DateTime(2021, 5, 25, 8, 33, 33, 404, DateTimeKind.Local).AddTicks(7182), 7.8m, new DateTime(2021, 5, 25, 8, 33, 33, 404, DateTimeKind.Local).AddTicks(7182), 78m, 10 },
                    { 4, new DateTime(2021, 5, 25, 8, 33, 33, 404, DateTimeKind.Local).AddTicks(7177), 10m, new DateTime(2021, 5, 25, 8, 33, 33, 404, DateTimeKind.Local).AddTicks(7177), 100m, 6 },
                    { 3, new DateTime(2021, 5, 25, 8, 33, 33, 404, DateTimeKind.Local).AddTicks(7174), 42m, new DateTime(2021, 5, 25, 8, 33, 33, 404, DateTimeKind.Local).AddTicks(7174), 420m, 5 },
                    { 10, new DateTime(2021, 5, 25, 8, 33, 33, 404, DateTimeKind.Local).AddTicks(7192), 2m, new DateTime(2021, 5, 25, 8, 33, 33, 404, DateTimeKind.Local).AddTicks(7192), 20m, 4 },
                    { 9, new DateTime(2021, 5, 25, 8, 33, 33, 404, DateTimeKind.Local).AddTicks(7190), 13m, new DateTime(2021, 5, 25, 8, 33, 33, 404, DateTimeKind.Local).AddTicks(7190), 130m, 3 },
                    { 5, new DateTime(2021, 5, 25, 8, 33, 33, 404, DateTimeKind.Local).AddTicks(7179), 3.6m, new DateTime(2021, 5, 25, 8, 33, 33, 404, DateTimeKind.Local).AddTicks(7179), 36m, 12 },
                    { 2, new DateTime(2021, 5, 25, 8, 33, 33, 404, DateTimeKind.Local).AddTicks(7155), 2m, new DateTime(2021, 5, 25, 8, 33, 33, 404, DateTimeKind.Local).AddTicks(7155), 20m, 1 }
                });

            migrationBuilder.InsertData(
                table: "TradeItemProposals",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "ProposedAmount", "TradeId", "TradeItemId" },
                values: new object[,]
                {
                    { 8, new DateTime(2021, 5, 25, 8, 33, 33, 405, DateTimeKind.Local).AddTicks(4791), new DateTime(2021, 5, 25, 8, 33, 33, 405, DateTimeKind.Local).AddTicks(4791), 15, 2, 14 },
                    { 11, new DateTime(2021, 5, 25, 8, 33, 33, 405, DateTimeKind.Local).AddTicks(4798), new DateTime(2021, 5, 25, 8, 33, 33, 405, DateTimeKind.Local).AddTicks(4798), 5, 4, 34 },
                    { 9, new DateTime(2021, 5, 25, 8, 33, 33, 405, DateTimeKind.Local).AddTicks(4794), new DateTime(2021, 5, 25, 8, 33, 33, 405, DateTimeKind.Local).AddTicks(4794), 5, 3, 33 },
                    { 15, new DateTime(2021, 5, 25, 8, 33, 33, 405, DateTimeKind.Local).AddTicks(4807), new DateTime(2021, 5, 25, 8, 33, 33, 405, DateTimeKind.Local).AddTicks(4807), 5, 4, 4 },
                    { 14, new DateTime(2021, 5, 25, 8, 33, 33, 405, DateTimeKind.Local).AddTicks(4805), new DateTime(2021, 5, 25, 8, 33, 33, 405, DateTimeKind.Local).AddTicks(4805), 15, 4, 3 },
                    { 13, new DateTime(2021, 5, 25, 8, 33, 33, 405, DateTimeKind.Local).AddTicks(4803), new DateTime(2021, 5, 25, 8, 33, 33, 405, DateTimeKind.Local).AddTicks(4803), 5, 4, 2 },
                    { 12, new DateTime(2021, 5, 25, 8, 33, 33, 405, DateTimeKind.Local).AddTicks(4800), new DateTime(2021, 5, 25, 8, 33, 33, 405, DateTimeKind.Local).AddTicks(4800), 15, 4, 1 },
                    { 10, new DateTime(2021, 5, 25, 8, 33, 33, 405, DateTimeKind.Local).AddTicks(4796), new DateTime(2021, 5, 25, 8, 33, 33, 405, DateTimeKind.Local).AddTicks(4796), 15, 3, 28 },
                    { 7, new DateTime(2021, 5, 25, 8, 33, 33, 405, DateTimeKind.Local).AddTicks(4789), new DateTime(2021, 5, 25, 8, 33, 33, 405, DateTimeKind.Local).AddTicks(4789), 5, 2, 13 },
                    { 1, new DateTime(2021, 5, 25, 8, 33, 33, 405, DateTimeKind.Local).AddTicks(3506), new DateTime(2021, 5, 25, 8, 33, 33, 405, DateTimeKind.Local).AddTicks(3506), 5, 1, 1 },
                    { 20, new DateTime(2021, 5, 25, 8, 33, 33, 405, DateTimeKind.Local).AddTicks(4819), new DateTime(2021, 5, 25, 8, 33, 33, 405, DateTimeKind.Local).AddTicks(4819), 15, 6, 30 },
                    { 19, new DateTime(2021, 5, 25, 8, 33, 33, 405, DateTimeKind.Local).AddTicks(4817), new DateTime(2021, 5, 25, 8, 33, 33, 405, DateTimeKind.Local).AddTicks(4817), 1, 6, 5 },
                    { 18, new DateTime(2021, 5, 25, 8, 33, 33, 405, DateTimeKind.Local).AddTicks(4815), new DateTime(2021, 5, 25, 8, 33, 33, 405, DateTimeKind.Local).AddTicks(4815), 15, 5, 18 },
                    { 2, new DateTime(2021, 5, 25, 8, 33, 33, 405, DateTimeKind.Local).AddTicks(4767), new DateTime(2021, 5, 25, 8, 33, 33, 405, DateTimeKind.Local).AddTicks(4767), 15, 1, 2 },
                    { 3, new DateTime(2021, 5, 25, 8, 33, 33, 405, DateTimeKind.Local).AddTicks(4779), new DateTime(2021, 5, 25, 8, 33, 33, 405, DateTimeKind.Local).AddTicks(4779), 5, 1, 3 },
                    { 4, new DateTime(2021, 5, 25, 8, 33, 33, 405, DateTimeKind.Local).AddTicks(4781), new DateTime(2021, 5, 25, 8, 33, 33, 405, DateTimeKind.Local).AddTicks(4781), 5, 1, 5 },
                    { 5, new DateTime(2021, 5, 25, 8, 33, 33, 405, DateTimeKind.Local).AddTicks(4784), new DateTime(2021, 5, 25, 8, 33, 33, 405, DateTimeKind.Local).AddTicks(4784), 5, 2, 6 },
                    { 6, new DateTime(2021, 5, 25, 8, 33, 33, 405, DateTimeKind.Local).AddTicks(4786), new DateTime(2021, 5, 25, 8, 33, 33, 405, DateTimeKind.Local).AddTicks(4786), 15, 2, 7 },
                    { 16, new DateTime(2021, 5, 25, 8, 33, 33, 405, DateTimeKind.Local).AddTicks(4810), new DateTime(2021, 5, 25, 8, 33, 33, 405, DateTimeKind.Local).AddTicks(4810), 3, 5, 32 },
                    { 17, new DateTime(2021, 5, 25, 8, 33, 33, 405, DateTimeKind.Local).AddTicks(4812), new DateTime(2021, 5, 25, 8, 33, 33, 405, DateTimeKind.Local).AddTicks(4812), 5, 5, 17 }
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
