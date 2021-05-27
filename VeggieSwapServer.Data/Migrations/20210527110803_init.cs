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
                    { 1, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(396), "apples.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(396), "apples" },
                    { 29, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1743), "olives.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1743), "olives" },
                    { 30, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1746), "oranges.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1746), "oranges" },
                    { 31, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1748), "papayas.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1748), "papayas" },
                    { 32, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1750), "peaches.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1750), "peaches" },
                    { 33, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1753), "pears.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1753), "pears" },
                    { 34, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1755), "peas.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1755), "peas" },
                    { 35, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1757), "pineapples.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1757), "pineapples" },
                    { 36, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1760), "pomegranates.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1760), "pomegranates" },
                    { 38, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1764), "pumpkins.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1764), "pumpkins" },
                    { 39, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1767), "radish.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1767), "radish" },
                    { 28, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1741), "mushrooms.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1741), "mushrooms" },
                    { 40, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1769), "radishes.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1769), "radishes" },
                    { 42, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1773), "salad.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1773), "salad" },
                    { 43, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1776), "salads.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1776), "salads" },
                    { 44, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1778), "scallions.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1778), "scallions" },
                    { 45, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1780), "spinach.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1780), "spinach" },
                    { 46, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1782), "star-fruits.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1782), "star-fruits" },
                    { 47, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1785), "strawberries.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1785), "strawberries" },
                    { 48, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1787), "sweet-potatoes.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1787), "sweet-potatoes" },
                    { 49, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1789), "tomatoes.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1789), "tomatoes" },
                    { 50, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1792), "watermelons.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1792), "watermelons" },
                    { 51, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1794), "v-coin.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1794), "v-coin" },
                    { 41, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1771), "raspberries.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1771), "raspberries" },
                    { 27, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1739), "melons.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1739), "melons" },
                    { 37, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1762), "potatoes.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1762), "potatoes" },
                    { 25, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1734), "mangos.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1734), "mangos" },
                    { 2, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1670), "artichokes.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1670), "artichokes" },
                    { 26, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1737), "mangosteens.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1737), "mangosteens" },
                    { 4, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1685), "bananas.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1685), "bananas" },
                    { 5, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1688), "bell-peppers.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1688), "bell-peppers" },
                    { 6, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1690), "blueberries.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1690), "blueberries" },
                    { 7, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1692), "bok-choy.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1692), "bok-choy" },
                    { 8, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1695), "broccoli.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1695), "broccoli" },
                    { 9, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1697), "brussels-sprouts.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1697), "brussels-sprouts" },
                    { 10, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1699), "carrots.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1699), "carrots" },
                    { 11, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1702), "cherries.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1702), "cherries" },
                    { 12, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1704), "chilis.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1704), "chilis" },
                    { 13, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1706), "coconuts.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1706), "coconuts" },
                    { 3, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1682), "asparagus.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1682), "asparagus" },
                    { 15, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1711), "corn.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1711), "corn" },
                    { 14, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1709), "coriander.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1709), "coriander" }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreatedAt", "ImageUrl", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 23, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1730), "kiwis.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1730), "kiwis" },
                    { 22, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1727), "guavas.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1727), "guavas" },
                    { 21, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1725), "grapes.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1725), "grapes" },
                    { 20, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1723), "garlic.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1723), "garlic" },
                    { 24, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1732), "lemons.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1732), "lemons" },
                    { 18, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1718), "durians.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1718), "durians" },
                    { 17, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1716), "dragon-fruits.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1716), "dragon-fruits" },
                    { 16, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1713), "cucumbers.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1713), "cucumbers" },
                    { 19, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1720), "eggplants.svg", new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(1720), "eggplants" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "ImageUrl", "IsAdmin", "LastName", "ModifiedAt", "PasswordHash", "PasswordSalt" },
                values: new object[,]
                {
                    { 12, new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(595), "Simon@mail.com", "Simon", "Dries2", false, "Lidllover", new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(595), new byte[] { 23, 65, 83, 46, 63, 43, 240, 38, 144, 93, 115, 214, 97, 20, 134, 35, 85, 172, 103, 23, 152, 16, 192, 203, 0, 115, 10, 44, 193, 62, 72, 31, 136, 247, 210, 98, 199, 184, 56, 137, 215, 58, 29, 197, 108, 33, 82, 40, 109, 38, 184, 183, 66, 74, 214, 229, 205, 253, 0, 85, 251, 86, 145, 163 }, new byte[] { 3, 204, 220, 227, 6, 0, 93, 131, 161, 247, 107, 37, 110, 108, 12, 60, 199, 155, 150, 61, 212, 158, 206, 173, 98, 198, 1, 83, 160, 137, 5, 96, 183, 74, 195, 33, 186, 173, 42, 136, 56, 241, 132, 252, 85, 84, 7, 249, 244, 16, 214, 228, 149, 24, 107, 162, 134, 176, 113, 163, 11, 203, 53, 193, 15, 107, 178, 172, 137, 147, 84, 233, 189, 217, 101, 112, 38, 2, 75, 196, 212, 39, 165, 211, 155, 227, 143, 40, 33, 163, 69, 185, 37, 19, 20, 81, 96, 34, 233, 58, 39, 211, 80, 32, 108, 13, 236, 25, 246, 93, 5, 116, 163, 34, 223, 229, 180, 74, 15, 130, 76, 253, 43, 212, 116, 210, 243, 134 } },
                    { 19, new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(686), "Karolien@mail.com", "Karolien", "78", false, "Vdabpolitie", new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(686), new byte[] { 23, 65, 83, 46, 63, 43, 240, 38, 144, 93, 115, 214, 97, 20, 134, 35, 85, 172, 103, 23, 152, 16, 192, 203, 0, 115, 10, 44, 193, 62, 72, 31, 136, 247, 210, 98, 199, 184, 56, 137, 215, 58, 29, 197, 108, 33, 82, 40, 109, 38, 184, 183, 66, 74, 214, 229, 205, 253, 0, 85, 251, 86, 145, 163 }, new byte[] { 3, 204, 220, 227, 6, 0, 93, 131, 161, 247, 107, 37, 110, 108, 12, 60, 199, 155, 150, 61, 212, 158, 206, 173, 98, 198, 1, 83, 160, 137, 5, 96, 183, 74, 195, 33, 186, 173, 42, 136, 56, 241, 132, 252, 85, 84, 7, 249, 244, 16, 214, 228, 149, 24, 107, 162, 134, 176, 113, 163, 11, 203, 53, 193, 15, 107, 178, 172, 137, 147, 84, 233, 189, 217, 101, 112, 38, 2, 75, 196, 212, 39, 165, 211, 155, 227, 143, 40, 33, 163, 69, 185, 37, 19, 20, 81, 96, 34, 233, 58, 39, 211, 80, 32, 108, 13, 236, 25, 246, 93, 5, 116, 163, 34, 223, 229, 180, 74, 15, 130, 76, 253, 43, 212, 116, 210, 243, 134 } },
                    { 18, new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(672), "Joke@mail.com", "Joke", "24", false, "LidlAnnoying", new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(672), new byte[] { 23, 65, 83, 46, 63, 43, 240, 38, 144, 93, 115, 214, 97, 20, 134, 35, 85, 172, 103, 23, 152, 16, 192, 203, 0, 115, 10, 44, 193, 62, 72, 31, 136, 247, 210, 98, 199, 184, 56, 137, 215, 58, 29, 197, 108, 33, 82, 40, 109, 38, 184, 183, 66, 74, 214, 229, 205, 253, 0, 85, 251, 86, 145, 163 }, new byte[] { 3, 204, 220, 227, 6, 0, 93, 131, 161, 247, 107, 37, 110, 108, 12, 60, 199, 155, 150, 61, 212, 158, 206, 173, 98, 198, 1, 83, 160, 137, 5, 96, 183, 74, 195, 33, 186, 173, 42, 136, 56, 241, 132, 252, 85, 84, 7, 249, 244, 16, 214, 228, 149, 24, 107, 162, 134, 176, 113, 163, 11, 203, 53, 193, 15, 107, 178, 172, 137, 147, 84, 233, 189, 217, 101, 112, 38, 2, 75, 196, 212, 39, 165, 211, 155, 227, 143, 40, 33, 163, 69, 185, 37, 19, 20, 81, 96, 34, 233, 58, 39, 211, 80, 32, 108, 13, 236, 25, 246, 93, 5, 116, 163, 34, 223, 229, 180, 74, 15, 130, 76, 253, 43, 212, 116, 210, 243, 134 } },
                    { 17, new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(659), "Sien@mail.com", "Sien", "57", false, "Rommeltje", new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(659), new byte[] { 23, 65, 83, 46, 63, 43, 240, 38, 144, 93, 115, 214, 97, 20, 134, 35, 85, 172, 103, 23, 152, 16, 192, 203, 0, 115, 10, 44, 193, 62, 72, 31, 136, 247, 210, 98, 199, 184, 56, 137, 215, 58, 29, 197, 108, 33, 82, 40, 109, 38, 184, 183, 66, 74, 214, 229, 205, 253, 0, 85, 251, 86, 145, 163 }, new byte[] { 3, 204, 220, 227, 6, 0, 93, 131, 161, 247, 107, 37, 110, 108, 12, 60, 199, 155, 150, 61, 212, 158, 206, 173, 98, 198, 1, 83, 160, 137, 5, 96, 183, 74, 195, 33, 186, 173, 42, 136, 56, 241, 132, 252, 85, 84, 7, 249, 244, 16, 214, 228, 149, 24, 107, 162, 134, 176, 113, 163, 11, 203, 53, 193, 15, 107, 178, 172, 137, 147, 84, 233, 189, 217, 101, 112, 38, 2, 75, 196, 212, 39, 165, 211, 155, 227, 143, 40, 33, 163, 69, 185, 37, 19, 20, 81, 96, 34, 233, 58, 39, 211, 80, 32, 108, 13, 236, 25, 246, 93, 5, 116, 163, 34, 223, 229, 180, 74, 15, 130, 76, 253, 43, 212, 116, 210, 243, 134 } },
                    { 16, new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(646), "Emma@mail.com", "Emma", "45", false, "Schoonkind", new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(646), new byte[] { 23, 65, 83, 46, 63, 43, 240, 38, 144, 93, 115, 214, 97, 20, 134, 35, 85, 172, 103, 23, 152, 16, 192, 203, 0, 115, 10, 44, 193, 62, 72, 31, 136, 247, 210, 98, 199, 184, 56, 137, 215, 58, 29, 197, 108, 33, 82, 40, 109, 38, 184, 183, 66, 74, 214, 229, 205, 253, 0, 85, 251, 86, 145, 163 }, new byte[] { 3, 204, 220, 227, 6, 0, 93, 131, 161, 247, 107, 37, 110, 108, 12, 60, 199, 155, 150, 61, 212, 158, 206, 173, 98, 198, 1, 83, 160, 137, 5, 96, 183, 74, 195, 33, 186, 173, 42, 136, 56, 241, 132, 252, 85, 84, 7, 249, 244, 16, 214, 228, 149, 24, 107, 162, 134, 176, 113, 163, 11, 203, 53, 193, 15, 107, 178, 172, 137, 147, 84, 233, 189, 217, 101, 112, 38, 2, 75, 196, 212, 39, 165, 211, 155, 227, 143, 40, 33, 163, 69, 185, 37, 19, 20, 81, 96, 34, 233, 58, 39, 211, 80, 32, 108, 13, 236, 25, 246, 93, 5, 116, 163, 34, 223, 229, 180, 74, 15, 130, 76, 253, 43, 212, 116, 210, 243, 134 } },
                    { 15, new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(633), "Anke@mail.com", "Anke", "27", false, "Kleurenkenner", new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(633), new byte[] { 23, 65, 83, 46, 63, 43, 240, 38, 144, 93, 115, 214, 97, 20, 134, 35, 85, 172, 103, 23, 152, 16, 192, 203, 0, 115, 10, 44, 193, 62, 72, 31, 136, 247, 210, 98, 199, 184, 56, 137, 215, 58, 29, 197, 108, 33, 82, 40, 109, 38, 184, 183, 66, 74, 214, 229, 205, 253, 0, 85, 251, 86, 145, 163 }, new byte[] { 3, 204, 220, 227, 6, 0, 93, 131, 161, 247, 107, 37, 110, 108, 12, 60, 199, 155, 150, 61, 212, 158, 206, 173, 98, 198, 1, 83, 160, 137, 5, 96, 183, 74, 195, 33, 186, 173, 42, 136, 56, 241, 132, 252, 85, 84, 7, 249, 244, 16, 214, 228, 149, 24, 107, 162, 134, 176, 113, 163, 11, 203, 53, 193, 15, 107, 178, 172, 137, 147, 84, 233, 189, 217, 101, 112, 38, 2, 75, 196, 212, 39, 165, 211, 155, 227, 143, 40, 33, 163, 69, 185, 37, 19, 20, 81, 96, 34, 233, 58, 39, 211, 80, 32, 108, 13, 236, 25, 246, 93, 5, 116, 163, 34, 223, 229, 180, 74, 15, 130, 76, 253, 43, 212, 116, 210, 243, 134 } },
                    { 20, new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(699), "Hoon@mail.com", "Hoon", "99", false, "Tomatenplukker", new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(699), new byte[] { 23, 65, 83, 46, 63, 43, 240, 38, 144, 93, 115, 214, 97, 20, 134, 35, 85, 172, 103, 23, 152, 16, 192, 203, 0, 115, 10, 44, 193, 62, 72, 31, 136, 247, 210, 98, 199, 184, 56, 137, 215, 58, 29, 197, 108, 33, 82, 40, 109, 38, 184, 183, 66, 74, 214, 229, 205, 253, 0, 85, 251, 86, 145, 163 }, new byte[] { 3, 204, 220, 227, 6, 0, 93, 131, 161, 247, 107, 37, 110, 108, 12, 60, 199, 155, 150, 61, 212, 158, 206, 173, 98, 198, 1, 83, 160, 137, 5, 96, 183, 74, 195, 33, 186, 173, 42, 136, 56, 241, 132, 252, 85, 84, 7, 249, 244, 16, 214, 228, 149, 24, 107, 162, 134, 176, 113, 163, 11, 203, 53, 193, 15, 107, 178, 172, 137, 147, 84, 233, 189, 217, 101, 112, 38, 2, 75, 196, 212, 39, 165, 211, 155, 227, 143, 40, 33, 163, 69, 185, 37, 19, 20, 81, 96, 34, 233, 58, 39, 211, 80, 32, 108, 13, 236, 25, 246, 93, 5, 116, 163, 34, 223, 229, 180, 74, 15, 130, 76, 253, 43, 212, 116, 210, 243, 134 } },
                    { 14, new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(620), "Marieke@mail.com", "Marieke", "T1", false, "Van Leren Broeke", new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(620), new byte[] { 23, 65, 83, 46, 63, 43, 240, 38, 144, 93, 115, 214, 97, 20, 134, 35, 85, 172, 103, 23, 152, 16, 192, 203, 0, 115, 10, 44, 193, 62, 72, 31, 136, 247, 210, 98, 199, 184, 56, 137, 215, 58, 29, 197, 108, 33, 82, 40, 109, 38, 184, 183, 66, 74, 214, 229, 205, 253, 0, 85, 251, 86, 145, 163 }, new byte[] { 3, 204, 220, 227, 6, 0, 93, 131, 161, 247, 107, 37, 110, 108, 12, 60, 199, 155, 150, 61, 212, 158, 206, 173, 98, 198, 1, 83, 160, 137, 5, 96, 183, 74, 195, 33, 186, 173, 42, 136, 56, 241, 132, 252, 85, 84, 7, 249, 244, 16, 214, 228, 149, 24, 107, 162, 134, 176, 113, 163, 11, 203, 53, 193, 15, 107, 178, 172, 137, 147, 84, 233, 189, 217, 101, 112, 38, 2, 75, 196, 212, 39, 165, 211, 155, 227, 143, 40, 33, 163, 69, 185, 37, 19, 20, 81, 96, 34, 233, 58, 39, 211, 80, 32, 108, 13, 236, 25, 246, 93, 5, 116, 163, 34, 223, 229, 180, 74, 15, 130, 76, 253, 43, 212, 116, 210, 243, 134 } },
                    { 13, new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(607), "Joyce@mail.com", "Joyce", "75", false, "Recruiter", new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(607), new byte[] { 23, 65, 83, 46, 63, 43, 240, 38, 144, 93, 115, 214, 97, 20, 134, 35, 85, 172, 103, 23, 152, 16, 192, 203, 0, 115, 10, 44, 193, 62, 72, 31, 136, 247, 210, 98, 199, 184, 56, 137, 215, 58, 29, 197, 108, 33, 82, 40, 109, 38, 184, 183, 66, 74, 214, 229, 205, 253, 0, 85, 251, 86, 145, 163 }, new byte[] { 3, 204, 220, 227, 6, 0, 93, 131, 161, 247, 107, 37, 110, 108, 12, 60, 199, 155, 150, 61, 212, 158, 206, 173, 98, 198, 1, 83, 160, 137, 5, 96, 183, 74, 195, 33, 186, 173, 42, 136, 56, 241, 132, 252, 85, 84, 7, 249, 244, 16, 214, 228, 149, 24, 107, 162, 134, 176, 113, 163, 11, 203, 53, 193, 15, 107, 178, 172, 137, 147, 84, 233, 189, 217, 101, 112, 38, 2, 75, 196, 212, 39, 165, 211, 155, 227, 143, 40, 33, 163, 69, 185, 37, 19, 20, 81, 96, 34, 233, 58, 39, 211, 80, 32, 108, 13, 236, 25, 246, 93, 5, 116, 163, 34, 223, 229, 180, 74, 15, 130, 76, 253, 43, 212, 116, 210, 243, 134 } },
                    { 11, new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(582), "Jens@mail.com", "Jens", "Zeemlap", false, "Spinning", new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(582), new byte[] { 23, 65, 83, 46, 63, 43, 240, 38, 144, 93, 115, 214, 97, 20, 134, 35, 85, 172, 103, 23, 152, 16, 192, 203, 0, 115, 10, 44, 193, 62, 72, 31, 136, 247, 210, 98, 199, 184, 56, 137, 215, 58, 29, 197, 108, 33, 82, 40, 109, 38, 184, 183, 66, 74, 214, 229, 205, 253, 0, 85, 251, 86, 145, 163 }, new byte[] { 3, 204, 220, 227, 6, 0, 93, 131, 161, 247, 107, 37, 110, 108, 12, 60, 199, 155, 150, 61, 212, 158, 206, 173, 98, 198, 1, 83, 160, 137, 5, 96, 183, 74, 195, 33, 186, 173, 42, 136, 56, 241, 132, 252, 85, 84, 7, 249, 244, 16, 214, 228, 149, 24, 107, 162, 134, 176, 113, 163, 11, 203, 53, 193, 15, 107, 178, 172, 137, 147, 84, 233, 189, 217, 101, 112, 38, 2, 75, 196, 212, 39, 165, 211, 155, 227, 143, 40, 33, 163, 69, 185, 37, 19, 20, 81, 96, 34, 233, 58, 39, 211, 80, 32, 108, 13, 236, 25, 246, 93, 5, 116, 163, 34, 223, 229, 180, 74, 15, 130, 76, 253, 43, 212, 116, 210, 243, 134 } },
                    { 6, new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(424), "Emma@mail.com", "Emma", "Stofzuiger", false, "Kipdorp", new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(424), new byte[] { 23, 65, 83, 46, 63, 43, 240, 38, 144, 93, 115, 214, 97, 20, 134, 35, 85, 172, 103, 23, 152, 16, 192, 203, 0, 115, 10, 44, 193, 62, 72, 31, 136, 247, 210, 98, 199, 184, 56, 137, 215, 58, 29, 197, 108, 33, 82, 40, 109, 38, 184, 183, 66, 74, 214, 229, 205, 253, 0, 85, 251, 86, 145, 163 }, new byte[] { 3, 204, 220, 227, 6, 0, 93, 131, 161, 247, 107, 37, 110, 108, 12, 60, 199, 155, 150, 61, 212, 158, 206, 173, 98, 198, 1, 83, 160, 137, 5, 96, 183, 74, 195, 33, 186, 173, 42, 136, 56, 241, 132, 252, 85, 84, 7, 249, 244, 16, 214, 228, 149, 24, 107, 162, 134, 176, 113, 163, 11, 203, 53, 193, 15, 107, 178, 172, 137, 147, 84, 233, 189, 217, 101, 112, 38, 2, 75, 196, 212, 39, 165, 211, 155, 227, 143, 40, 33, 163, 69, 185, 37, 19, 20, 81, 96, 34, 233, 58, 39, 211, 80, 32, 108, 13, 236, 25, 246, 93, 5, 116, 163, 34, 223, 229, 180, 74, 15, 130, 76, 253, 43, 212, 116, 210, 243, 134 } },
                    { 9, new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(465), "Michiel@mail.com", "Michiel", "g283?set=set4", false, "Demogod", new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(465), new byte[] { 23, 65, 83, 46, 63, 43, 240, 38, 144, 93, 115, 214, 97, 20, 134, 35, 85, 172, 103, 23, 152, 16, 192, 203, 0, 115, 10, 44, 193, 62, 72, 31, 136, 247, 210, 98, 199, 184, 56, 137, 215, 58, 29, 197, 108, 33, 82, 40, 109, 38, 184, 183, 66, 74, 214, 229, 205, 253, 0, 85, 251, 86, 145, 163 }, new byte[] { 3, 204, 220, 227, 6, 0, 93, 131, 161, 247, 107, 37, 110, 108, 12, 60, 199, 155, 150, 61, 212, 158, 206, 173, 98, 198, 1, 83, 160, 137, 5, 96, 183, 74, 195, 33, 186, 173, 42, 136, 56, 241, 132, 252, 85, 84, 7, 249, 244, 16, 214, 228, 149, 24, 107, 162, 134, 176, 113, 163, 11, 203, 53, 193, 15, 107, 178, 172, 137, 147, 84, 233, 189, 217, 101, 112, 38, 2, 75, 196, 212, 39, 165, 211, 155, 227, 143, 40, 33, 163, 69, 185, 37, 19, 20, 81, 96, 34, 233, 58, 39, 211, 80, 32, 108, 13, 236, 25, 246, 93, 5, 116, 163, 34, 223, 229, 180, 74, 15, 130, 76, 253, 43, 212, 116, 210, 243, 134 } },
                    { 8, new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(451), "Andreas@mail.com", "Andreas", "Andreas", false, "VanGrieken", new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(451), new byte[] { 23, 65, 83, 46, 63, 43, 240, 38, 144, 93, 115, 214, 97, 20, 134, 35, 85, 172, 103, 23, 152, 16, 192, 203, 0, 115, 10, 44, 193, 62, 72, 31, 136, 247, 210, 98, 199, 184, 56, 137, 215, 58, 29, 197, 108, 33, 82, 40, 109, 38, 184, 183, 66, 74, 214, 229, 205, 253, 0, 85, 251, 86, 145, 163 }, new byte[] { 3, 204, 220, 227, 6, 0, 93, 131, 161, 247, 107, 37, 110, 108, 12, 60, 199, 155, 150, 61, 212, 158, 206, 173, 98, 198, 1, 83, 160, 137, 5, 96, 183, 74, 195, 33, 186, 173, 42, 136, 56, 241, 132, 252, 85, 84, 7, 249, 244, 16, 214, 228, 149, 24, 107, 162, 134, 176, 113, 163, 11, 203, 53, 193, 15, 107, 178, 172, 137, 147, 84, 233, 189, 217, 101, 112, 38, 2, 75, 196, 212, 39, 165, 211, 155, 227, 143, 40, 33, 163, 69, 185, 37, 19, 20, 81, 96, 34, 233, 58, 39, 211, 80, 32, 108, 13, 236, 25, 246, 93, 5, 116, 163, 34, 223, 229, 180, 74, 15, 130, 76, 253, 43, 212, 116, 210, 243, 134 } },
                    { 7, new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(438), "Ward@mail.com", "Ward", "Dirk", false, "Motormouth", new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(438), new byte[] { 23, 65, 83, 46, 63, 43, 240, 38, 144, 93, 115, 214, 97, 20, 134, 35, 85, 172, 103, 23, 152, 16, 192, 203, 0, 115, 10, 44, 193, 62, 72, 31, 136, 247, 210, 98, 199, 184, 56, 137, 215, 58, 29, 197, 108, 33, 82, 40, 109, 38, 184, 183, 66, 74, 214, 229, 205, 253, 0, 85, 251, 86, 145, 163 }, new byte[] { 3, 204, 220, 227, 6, 0, 93, 131, 161, 247, 107, 37, 110, 108, 12, 60, 199, 155, 150, 61, 212, 158, 206, 173, 98, 198, 1, 83, 160, 137, 5, 96, 183, 74, 195, 33, 186, 173, 42, 136, 56, 241, 132, 252, 85, 84, 7, 249, 244, 16, 214, 228, 149, 24, 107, 162, 134, 176, 113, 163, 11, 203, 53, 193, 15, 107, 178, 172, 137, 147, 84, 233, 189, 217, 101, 112, 38, 2, 75, 196, 212, 39, 165, 211, 155, 227, 143, 40, 33, 163, 69, 185, 37, 19, 20, 81, 96, 34, 233, 58, 39, 211, 80, 32, 108, 13, 236, 25, 246, 93, 5, 116, 163, 34, 223, 229, 180, 74, 15, 130, 76, 253, 43, 212, 116, 210, 243, 134 } },
                    { 5, new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(411), "Seba@mail.com", "Seba", "BartjeWevertje", false, "Alwayszen", new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(411), new byte[] { 23, 65, 83, 46, 63, 43, 240, 38, 144, 93, 115, 214, 97, 20, 134, 35, 85, 172, 103, 23, 152, 16, 192, 203, 0, 115, 10, 44, 193, 62, 72, 31, 136, 247, 210, 98, 199, 184, 56, 137, 215, 58, 29, 197, 108, 33, 82, 40, 109, 38, 184, 183, 66, 74, 214, 229, 205, 253, 0, 85, 251, 86, 145, 163 }, new byte[] { 3, 204, 220, 227, 6, 0, 93, 131, 161, 247, 107, 37, 110, 108, 12, 60, 199, 155, 150, 61, 212, 158, 206, 173, 98, 198, 1, 83, 160, 137, 5, 96, 183, 74, 195, 33, 186, 173, 42, 136, 56, 241, 132, 252, 85, 84, 7, 249, 244, 16, 214, 228, 149, 24, 107, 162, 134, 176, 113, 163, 11, 203, 53, 193, 15, 107, 178, 172, 137, 147, 84, 233, 189, 217, 101, 112, 38, 2, 75, 196, 212, 39, 165, 211, 155, 227, 143, 40, 33, 163, 69, 185, 37, 19, 20, 81, 96, 34, 233, 58, 39, 211, 80, 32, 108, 13, 236, 25, 246, 93, 5, 116, 163, 34, 223, 229, 180, 74, 15, 130, 76, 253, 43, 212, 116, 210, 243, 134 } },
                    { 4, new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(398), "Dries@mail.com", "Dries", "Dries", true, "Promailer", new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(398), new byte[] { 23, 65, 83, 46, 63, 43, 240, 38, 144, 93, 115, 214, 97, 20, 134, 35, 85, 172, 103, 23, 152, 16, 192, 203, 0, 115, 10, 44, 193, 62, 72, 31, 136, 247, 210, 98, 199, 184, 56, 137, 215, 58, 29, 197, 108, 33, 82, 40, 109, 38, 184, 183, 66, 74, 214, 229, 205, 253, 0, 85, 251, 86, 145, 163 }, new byte[] { 3, 204, 220, 227, 6, 0, 93, 131, 161, 247, 107, 37, 110, 108, 12, 60, 199, 155, 150, 61, 212, 158, 206, 173, 98, 198, 1, 83, 160, 137, 5, 96, 183, 74, 195, 33, 186, 173, 42, 136, 56, 241, 132, 252, 85, 84, 7, 249, 244, 16, 214, 228, 149, 24, 107, 162, 134, 176, 113, 163, 11, 203, 53, 193, 15, 107, 178, 172, 137, 147, 84, 233, 189, 217, 101, 112, 38, 2, 75, 196, 212, 39, 165, 211, 155, 227, 143, 40, 33, 163, 69, 185, 37, 19, 20, 81, 96, 34, 233, 58, 39, 211, 80, 32, 108, 13, 236, 25, 246, 93, 5, 116, 163, 34, 223, 229, 180, 74, 15, 130, 76, 253, 43, 212, 116, 210, 243, 134 } },
                    { 3, new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(375), "Kobe@mail.com", "Kobe", "Kobe", true, "Neut", new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(375), new byte[] { 23, 65, 83, 46, 63, 43, 240, 38, 144, 93, 115, 214, 97, 20, 134, 35, 85, 172, 103, 23, 152, 16, 192, 203, 0, 115, 10, 44, 193, 62, 72, 31, 136, 247, 210, 98, 199, 184, 56, 137, 215, 58, 29, 197, 108, 33, 82, 40, 109, 38, 184, 183, 66, 74, 214, 229, 205, 253, 0, 85, 251, 86, 145, 163 }, new byte[] { 3, 204, 220, 227, 6, 0, 93, 131, 161, 247, 107, 37, 110, 108, 12, 60, 199, 155, 150, 61, 212, 158, 206, 173, 98, 198, 1, 83, 160, 137, 5, 96, 183, 74, 195, 33, 186, 173, 42, 136, 56, 241, 132, 252, 85, 84, 7, 249, 244, 16, 214, 228, 149, 24, 107, 162, 134, 176, 113, 163, 11, 203, 53, 193, 15, 107, 178, 172, 137, 147, 84, 233, 189, 217, 101, 112, 38, 2, 75, 196, 212, 39, 165, 211, 155, 227, 143, 40, 33, 163, 69, 185, 37, 19, 20, 81, 96, 34, 233, 58, 39, 211, 80, 32, 108, 13, 236, 25, 246, 93, 5, 116, 163, 34, 223, 229, 180, 74, 15, 130, 76, 253, 43, 212, 116, 210, 243, 134 } },
                    { 2, new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(209), "Nick@mail.com", "Nick", "Nick", true, "Angularlover", new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(209), new byte[] { 23, 65, 83, 46, 63, 43, 240, 38, 144, 93, 115, 214, 97, 20, 134, 35, 85, 172, 103, 23, 152, 16, 192, 203, 0, 115, 10, 44, 193, 62, 72, 31, 136, 247, 210, 98, 199, 184, 56, 137, 215, 58, 29, 197, 108, 33, 82, 40, 109, 38, 184, 183, 66, 74, 214, 229, 205, 253, 0, 85, 251, 86, 145, 163 }, new byte[] { 3, 204, 220, 227, 6, 0, 93, 131, 161, 247, 107, 37, 110, 108, 12, 60, 199, 155, 150, 61, 212, 158, 206, 173, 98, 198, 1, 83, 160, 137, 5, 96, 183, 74, 195, 33, 186, 173, 42, 136, 56, 241, 132, 252, 85, 84, 7, 249, 244, 16, 214, 228, 149, 24, 107, 162, 134, 176, 113, 163, 11, 203, 53, 193, 15, 107, 178, 172, 137, 147, 84, 233, 189, 217, 101, 112, 38, 2, 75, 196, 212, 39, 165, 211, 155, 227, 143, 40, 33, 163, 69, 185, 37, 19, 20, 81, 96, 34, 233, 58, 39, 211, 80, 32, 108, 13, 236, 25, 246, 93, 5, 116, 163, 34, 223, 229, 180, 74, 15, 130, 76, 253, 43, 212, 116, 210, 243, 134 } },
                    { 1, new DateTime(2021, 5, 27, 13, 8, 2, 691, DateTimeKind.Local).AddTicks(591), "Pieter@mail.com", "Pieter", "Pieter", true, "Slaapkop", new DateTime(2021, 5, 27, 13, 8, 2, 691, DateTimeKind.Local).AddTicks(591), new byte[] { 23, 65, 83, 46, 63, 43, 240, 38, 144, 93, 115, 214, 97, 20, 134, 35, 85, 172, 103, 23, 152, 16, 192, 203, 0, 115, 10, 44, 193, 62, 72, 31, 136, 247, 210, 98, 199, 184, 56, 137, 215, 58, 29, 197, 108, 33, 82, 40, 109, 38, 184, 183, 66, 74, 214, 229, 205, 253, 0, 85, 251, 86, 145, 163 }, new byte[] { 3, 204, 220, 227, 6, 0, 93, 131, 161, 247, 107, 37, 110, 108, 12, 60, 199, 155, 150, 61, 212, 158, 206, 173, 98, 198, 1, 83, 160, 137, 5, 96, 183, 74, 195, 33, 186, 173, 42, 136, 56, 241, 132, 252, 85, 84, 7, 249, 244, 16, 214, 228, 149, 24, 107, 162, 134, 176, 113, 163, 11, 203, 53, 193, 15, 107, 178, 172, 137, 147, 84, 233, 189, 217, 101, 112, 38, 2, 75, 196, 212, 39, 165, 211, 155, 227, 143, 40, 33, 163, 69, 185, 37, 19, 20, 81, 96, 34, 233, 58, 39, 211, 80, 32, 108, 13, 236, 25, 246, 93, 5, 116, 163, 34, 223, 229, 180, 74, 15, 130, 76, 253, 43, 212, 116, 210, 243, 134 } },
                    { 21, new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(712), "Michaël@mail.com", "Michaël", "25", false, "Wanderer", new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(712), new byte[] { 23, 65, 83, 46, 63, 43, 240, 38, 144, 93, 115, 214, 97, 20, 134, 35, 85, 172, 103, 23, 152, 16, 192, 203, 0, 115, 10, 44, 193, 62, 72, 31, 136, 247, 210, 98, 199, 184, 56, 137, 215, 58, 29, 197, 108, 33, 82, 40, 109, 38, 184, 183, 66, 74, 214, 229, 205, 253, 0, 85, 251, 86, 145, 163 }, new byte[] { 3, 204, 220, 227, 6, 0, 93, 131, 161, 247, 107, 37, 110, 108, 12, 60, 199, 155, 150, 61, 212, 158, 206, 173, 98, 198, 1, 83, 160, 137, 5, 96, 183, 74, 195, 33, 186, 173, 42, 136, 56, 241, 132, 252, 85, 84, 7, 249, 244, 16, 214, 228, 149, 24, 107, 162, 134, 176, 113, 163, 11, 203, 53, 193, 15, 107, 178, 172, 137, 147, 84, 233, 189, 217, 101, 112, 38, 2, 75, 196, 212, 39, 165, 211, 155, 227, 143, 40, 33, 163, 69, 185, 37, 19, 20, 81, 96, 34, 233, 58, 39, 211, 80, 32, 108, 13, 236, 25, 246, 93, 5, 116, 163, 34, 223, 229, 180, 74, 15, 130, 76, 253, 43, 212, 116, 210, 243, 134 } },
                    { 10, new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(567), "Diederik@mail.com", "Diederik", "Luc", false, "Featurefixer", new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(567), new byte[] { 23, 65, 83, 46, 63, 43, 240, 38, 144, 93, 115, 214, 97, 20, 134, 35, 85, 172, 103, 23, 152, 16, 192, 203, 0, 115, 10, 44, 193, 62, 72, 31, 136, 247, 210, 98, 199, 184, 56, 137, 215, 58, 29, 197, 108, 33, 82, 40, 109, 38, 184, 183, 66, 74, 214, 229, 205, 253, 0, 85, 251, 86, 145, 163 }, new byte[] { 3, 204, 220, 227, 6, 0, 93, 131, 161, 247, 107, 37, 110, 108, 12, 60, 199, 155, 150, 61, 212, 158, 206, 173, 98, 198, 1, 83, 160, 137, 5, 96, 183, 74, 195, 33, 186, 173, 42, 136, 56, 241, 132, 252, 85, 84, 7, 249, 244, 16, 214, 228, 149, 24, 107, 162, 134, 176, 113, 163, 11, 203, 53, 193, 15, 107, 178, 172, 137, 147, 84, 233, 189, 217, 101, 112, 38, 2, 75, 196, 212, 39, 165, 211, 155, 227, 143, 40, 33, 163, 69, 185, 37, 19, 20, 81, 96, 34, 233, 58, 39, 211, 80, 32, 108, 13, 236, 25, 246, 93, 5, 116, 163, 34, 223, 229, 180, 74, 15, 130, 76, 253, 43, 212, 116, 210, 243, 134 } },
                    { 22, new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(725), "Brent@mail.com", "Brent", "29", false, "Tomatentrucker", new DateTime(2021, 5, 27, 13, 8, 2, 694, DateTimeKind.Local).AddTicks(725), new byte[] { 23, 65, 83, 46, 63, 43, 240, 38, 144, 93, 115, 214, 97, 20, 134, 35, 85, 172, 103, 23, 152, 16, 192, 203, 0, 115, 10, 44, 193, 62, 72, 31, 136, 247, 210, 98, 199, 184, 56, 137, 215, 58, 29, 197, 108, 33, 82, 40, 109, 38, 184, 183, 66, 74, 214, 229, 205, 253, 0, 85, 251, 86, 145, 163 }, new byte[] { 3, 204, 220, 227, 6, 0, 93, 131, 161, 247, 107, 37, 110, 108, 12, 60, 199, 155, 150, 61, 212, 158, 206, 173, 98, 198, 1, 83, 160, 137, 5, 96, 183, 74, 195, 33, 186, 173, 42, 136, 56, 241, 132, 252, 85, 84, 7, 249, 244, 16, 214, 228, 149, 24, 107, 162, 134, 176, 113, 163, 11, 203, 53, 193, 15, 107, 178, 172, 137, 147, 84, 233, 189, 217, 101, 112, 38, 2, 75, 196, 212, 39, 165, 211, 155, 227, 143, 40, 33, 163, 69, 185, 37, 19, 20, 81, 96, 34, 233, 58, 39, 211, 80, 32, 108, 13, 236, 25, 246, 93, 5, 116, 163, 34, 223, 229, 180, 74, 15, 130, 76, 253, 43, 212, 116, 210, 243, 134 } }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "PostalCode", "StreetName", "StreetNumber", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 27, 13, 8, 2, 695, DateTimeKind.Local).AddTicks(9188), new DateTime(2021, 5, 27, 13, 8, 2, 695, DateTimeKind.Local).AddTicks(9188), 9000, "Anti-Veggiestraat", 89, 1 },
                    { 10, new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1399), new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1399), 9070, "Geenpolitiekinhetprojectstraat", 200, 10 },
                    { 12, new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1403), new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1403), 1000, "Blacklivesmatterstraat", 78, 12 },
                    { 9, new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1396), new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1396), 2000, "Greenlivesmattertooweg", 420, 9 },
                    { 8, new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1394), new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1394), 1000, "Kotsvisplein", 96, 8 },
                    { 13, new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1406), new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1406), 7000, "Worstenbroodjesstraat", 4, 13 },
                    { 7, new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1391), new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1391), 9050, "Greenpeacestraat", 1, 7 },
                    { 14, new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1408), new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1408), 9000, "Jurgenzitverstoptachterhetlamgodsstraat", 24, 14 },
                    { 6, new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1388), new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1388), 1000, "Spekmeteierenstraat", 43, 6 },
                    { 5, new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1386), new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1386), 9000, "Boerenworststraat", 85, 5 },
                    { 15, new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1410), new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1410), 1081, "Bloedworststraat", 78, 15 },
                    { 4, new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1383), new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1383), 1000, "Vleesbroodstraat", 66, 4 },
                    { 16, new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1413), new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1413), 1180, "Gemarineerderunderlendedreef", 36, 16 },
                    { 17, new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1415), new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1415), 1500, "Ribbetjesstraat", 14, 17 },
                    { 3, new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1380), new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1380), 4000, "Balletjesintomatensausstraat", 74, 3 },
                    { 11, new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1401), new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1401), 9500, "Kalfslapjesstraat", 32, 11 },
                    { 19, new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1420), new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1420), 2323, "Lookbroodjesstraat", 11, 19 },
                    { 20, new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1422), new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1422), 2890, "Worstenbroodjesstraat", 79, 20 },
                    { 18, new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1417), new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1417), 2070, "Bickyburgerstraat", 15, 18 },
                    { 21, new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1425), new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1425), 3020, "Huisgemaaktekalfsbitterballetjesstraat", 100, 21 },
                    { 2, new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1366), new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1366), 3000, "Vrbaan", 45, 2 },
                    { 22, new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1427), new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(1427), 3110, "Kalfsrib-eyelaan", 107, 22 }
                });

            migrationBuilder.InsertData(
                table: "TradeItems",
                columns: new[] { "Id", "Amount", "CreatedAt", "ModifiedAt", "ResourceId", "UserId" },
                values: new object[,]
                {
                    { 82, 52, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5909), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5909), 23, 21 },
                    { 54, 19, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5779), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5779), 12, 13 },
                    { 41, 17, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5747), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5747), 1, 11 },
                    { 53, 33, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5776), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5776), 35, 13 },
                    { 52, 22, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5774), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5774), 48, 13 },
                    { 51, 17, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5771), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5771), 47, 13 },
                    { 50, 17, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5769), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5769), 51, 13 },
                    { 80, 7, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5904), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5904), 17, 20 },
                    { 81, 13, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5907), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5907), 18, 20 },
                    { 49, 21, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5767), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5767), 12, 12 },
                    { 48, 17, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5764), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5764), 9, 12 },
                    { 55, 9, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5781), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5781), 7, 13 },
                    { 47, 34, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5762), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5762), 8, 12 },
                    { 46, 25, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5760), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5760), 47, 12 },
                    { 45, 12, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5757), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5757), 29, 12 },
                    { 42, 3, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5750), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5750), 3, 11 },
                    { 44, 78, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5755), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5755), 18, 12 },
                    { 43, 28, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5752), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5752), 7, 11 },
                    { 76, 80, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5895), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5895), 5, 17 },
                    { 57, 13, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5786), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5786), 29, 13 }
                });

            migrationBuilder.InsertData(
                table: "TradeItems",
                columns: new[] { "Id", "Amount", "CreatedAt", "ModifiedAt", "ResourceId", "UserId" },
                values: new object[,]
                {
                    { 75, 113, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5892), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5892), 3, 17 },
                    { 74, 78, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5889), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5889), 36, 16 },
                    { 73, 35, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5824), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5824), 38, 16 },
                    { 72, 24, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5822), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5822), 39, 16 },
                    { 77, 17, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5897), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5897), 6, 17 },
                    { 71, 1, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5820), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5820), 3, 15 },
                    { 70, 8, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5817), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5817), 51, 15 },
                    { 69, 153, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5815), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5815), 29, 15 },
                    { 68, 157, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5812), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5812), 22, 15 },
                    { 67, 19, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5810), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5810), 21, 15 },
                    { 56, 35, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5784), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5784), 8, 13 },
                    { 66, 78, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5807), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5807), 18, 15 },
                    { 65, 24, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5805), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5805), 17, 14 },
                    { 64, 88, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5803), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5803), 12, 14 },
                    { 83, 8, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5911), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5911), 26, 22 },
                    { 62, 39, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5798), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5798), 11, 14 },
                    { 61, 47, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5796), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5796), 8, 14 },
                    { 60, 19, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5793), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5793), 1, 14 },
                    { 79, 90, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5902), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5902), 44, 19 },
                    { 59, 17, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5791), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5791), 41, 13 },
                    { 58, 8, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5788), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5788), 38, 13 },
                    { 78, 99, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5899), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5899), 51, 19 },
                    { 63, 77, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5800), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5800), 9, 14 },
                    { 40, 33, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5745), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5745), 51, 11 },
                    { 39, 53, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5743), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5743), 19, 10 },
                    { 25, 5, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5709), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5709), 39, 6 },
                    { 24, 78, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5707), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5707), 32, 5 },
                    { 23, 38, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5704), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5704), 46, 5 },
                    { 22, 39, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5702), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5702), 17, 5 },
                    { 21, 63, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5698), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5698), 51, 5 },
                    { 20, 47, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5696), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5696), 7, 5 },
                    { 5, 41, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5659), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5659), 51, 2 },
                    { 19, 50, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5694), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5694), 51, 4 },
                    { 18, 36, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5691), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5691), 44, 4 },
                    { 17, 89, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5689), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5689), 21, 4 },
                    { 6, 30, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5662), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5662), 34, 2 },
                    { 16, 17, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5686), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5686), 31, 3 },
                    { 15, 30, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5684), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5684), 6, 3 },
                    { 7, 40, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5665), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5665), 46, 2 },
                    { 14, 49, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5681), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5681), 13, 3 },
                    { 13, 17, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5679), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5679), 8, 3 },
                    { 12, 20, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5677), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5677), 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "TradeItems",
                columns: new[] { "Id", "Amount", "CreatedAt", "ModifiedAt", "ResourceId", "UserId" },
                values: new object[,]
                {
                    { 11, 47, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5674), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5674), 51, 3 },
                    { 8, 5, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5667), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5667), 32, 2 },
                    { 10, 32, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5672), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5672), 15, 2 },
                    { 26, 10, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5712), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5712), 15, 6 },
                    { 9, 25, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5669), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5669), 39, 2 },
                    { 28, 10, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5716), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5716), 4, 6 },
                    { 33, 78, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5728), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5728), 6, 8 },
                    { 27, 12, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5714), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5714), 51, 6 },
                    { 35, 26, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5733), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5733), 51, 9 },
                    { 3, 12, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5654), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5654), 5, 1 },
                    { 36, 17, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5736), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5736), 14, 9 },
                    { 37, 69, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5738), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5738), 36, 9 },
                    { 34, 53, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5731), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5731), 51, 8 },
                    { 32, 38, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5726), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5726), 51, 7 },
                    { 30, 23, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5721), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5721), 13, 7 },
                    { 29, 19, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5719), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5719), 8, 7 },
                    { 1, 47, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(4065), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(4065), 1, 1 },
                    { 38, 34, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5740), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5740), 17, 10 },
                    { 4, 99, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5657), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5657), 7, 1 },
                    { 31, 36, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5723), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5723), 6, 7 },
                    { 2, 36, new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5640), new DateTime(2021, 5, 27, 13, 8, 2, 700, DateTimeKind.Local).AddTicks(5640), 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Trades",
                columns: new[] { "Id", "ActiveUserId", "Completed", "CreatedAt", "ModifiedAt", "ProposerId", "ReceiverId" },
                values: new object[,]
                {
                    { 2, 3, false, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(7731), new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(7731), 3, 2 },
                    { 4, 1, false, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(7747), new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(7747), 1, 8 },
                    { 6, 7, false, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(7753), new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(7753), 7, 2 },
                    { 1, 1, false, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(5747), new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(5747), 2, 1 },
                    { 5, 7, false, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(7750), new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(7750), 4, 7 },
                    { 3, 6, false, new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(7744), new DateTime(2021, 5, 27, 13, 8, 2, 698, DateTimeKind.Local).AddTicks(7744), 6, 8 }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "UserId", "VAmount" },
                values: new object[,]
                {
                    { 20, new DateTime(2021, 5, 27, 13, 8, 2, 697, DateTimeKind.Local).AddTicks(17), new DateTime(2021, 5, 27, 13, 8, 2, 697, DateTimeKind.Local).AddTicks(17), 20, 56m },
                    { 21, new DateTime(2021, 5, 27, 13, 8, 2, 697, DateTimeKind.Local).AddTicks(20), new DateTime(2021, 5, 27, 13, 8, 2, 697, DateTimeKind.Local).AddTicks(20), 21, 78m },
                    { 19, new DateTime(2021, 5, 27, 13, 8, 2, 697, DateTimeKind.Local).AddTicks(15), new DateTime(2021, 5, 27, 13, 8, 2, 697, DateTimeKind.Local).AddTicks(15), 19, 78m },
                    { 18, new DateTime(2021, 5, 27, 13, 8, 2, 697, DateTimeKind.Local).AddTicks(12), new DateTime(2021, 5, 27, 13, 8, 2, 697, DateTimeKind.Local).AddTicks(12), 18, 65m },
                    { 1, new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(8952), new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(8952), 1, 200m },
                    { 4, new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(9979), new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(9979), 4, 42m },
                    { 2, new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(9962), new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(9962), 2, 347m },
                    { 16, new DateTime(2021, 5, 27, 13, 8, 2, 697, DateTimeKind.Local).AddTicks(8), new DateTime(2021, 5, 27, 13, 8, 2, 697, DateTimeKind.Local).AddTicks(8), 16, 28m },
                    { 15, new DateTime(2021, 5, 27, 13, 8, 2, 697, DateTimeKind.Local).AddTicks(5), new DateTime(2021, 5, 27, 13, 8, 2, 697, DateTimeKind.Local).AddTicks(5), 15, 47m },
                    { 3, new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(9976), new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(9976), 3, 65m },
                    { 10, new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(9994), new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(9994), 10, 124m },
                    { 14, new DateTime(2021, 5, 27, 13, 8, 2, 697, DateTimeKind.Local).AddTicks(3), new DateTime(2021, 5, 27, 13, 8, 2, 697, DateTimeKind.Local).AddTicks(3), 14, 20m },
                    { 5, new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(9981), new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(9981), 5, 753m },
                    { 13, new DateTime(2021, 5, 27, 13, 8, 2, 697, DateTimeKind.Local), new DateTime(2021, 5, 27, 13, 8, 2, 697, DateTimeKind.Local), 13, 204m },
                    { 6, new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(9984), new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(9984), 6, 36m }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "UserId", "VAmount" },
                values: new object[,]
                {
                    { 7, new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(9986), new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(9986), 7, 12m },
                    { 12, new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(9998), new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(9998), 12, 57m },
                    { 8, new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(9988), new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(9988), 8, 654m },
                    { 11, new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(9996), new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(9996), 11, 269m },
                    { 9, new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(9991), new DateTime(2021, 5, 27, 13, 8, 2, 696, DateTimeKind.Local).AddTicks(9991), 9, 357m },
                    { 17, new DateTime(2021, 5, 27, 13, 8, 2, 697, DateTimeKind.Local).AddTicks(10), new DateTime(2021, 5, 27, 13, 8, 2, 697, DateTimeKind.Local).AddTicks(10), 17, 104m },
                    { 22, new DateTime(2021, 5, 27, 13, 8, 2, 697, DateTimeKind.Local).AddTicks(22), new DateTime(2021, 5, 27, 13, 8, 2, 697, DateTimeKind.Local).AddTicks(22), 22, 9m }
                });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "CreatedAt", "EuroAmount", "ModifiedAt", "VAmount", "WalletId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 27, 13, 8, 2, 701, DateTimeKind.Local).AddTicks(2442), 6.9m, new DateTime(2021, 5, 27, 13, 8, 2, 701, DateTimeKind.Local).AddTicks(2442), 69m, 1 },
                    { 7, new DateTime(2021, 5, 27, 13, 8, 2, 701, DateTimeKind.Local).AddTicks(4075), 9.8m, new DateTime(2021, 5, 27, 13, 8, 2, 701, DateTimeKind.Local).AddTicks(4075), 98m, 9 },
                    { 8, new DateTime(2021, 5, 27, 13, 8, 2, 701, DateTimeKind.Local).AddTicks(4077), 5m, new DateTime(2021, 5, 27, 13, 8, 2, 701, DateTimeKind.Local).AddTicks(4077), 50m, 7 },
                    { 6, new DateTime(2021, 5, 27, 13, 8, 2, 701, DateTimeKind.Local).AddTicks(4072), 7.8m, new DateTime(2021, 5, 27, 13, 8, 2, 701, DateTimeKind.Local).AddTicks(4072), 78m, 10 },
                    { 4, new DateTime(2021, 5, 27, 13, 8, 2, 701, DateTimeKind.Local).AddTicks(4066), 10m, new DateTime(2021, 5, 27, 13, 8, 2, 701, DateTimeKind.Local).AddTicks(4066), 100m, 6 },
                    { 3, new DateTime(2021, 5, 27, 13, 8, 2, 701, DateTimeKind.Local).AddTicks(4063), 42m, new DateTime(2021, 5, 27, 13, 8, 2, 701, DateTimeKind.Local).AddTicks(4063), 420m, 5 },
                    { 10, new DateTime(2021, 5, 27, 13, 8, 2, 701, DateTimeKind.Local).AddTicks(4083), 2m, new DateTime(2021, 5, 27, 13, 8, 2, 701, DateTimeKind.Local).AddTicks(4083), 20m, 4 },
                    { 9, new DateTime(2021, 5, 27, 13, 8, 2, 701, DateTimeKind.Local).AddTicks(4080), 13m, new DateTime(2021, 5, 27, 13, 8, 2, 701, DateTimeKind.Local).AddTicks(4080), 130m, 3 },
                    { 5, new DateTime(2021, 5, 27, 13, 8, 2, 701, DateTimeKind.Local).AddTicks(4069), 3.6m, new DateTime(2021, 5, 27, 13, 8, 2, 701, DateTimeKind.Local).AddTicks(4069), 36m, 12 },
                    { 2, new DateTime(2021, 5, 27, 13, 8, 2, 701, DateTimeKind.Local).AddTicks(4047), 2m, new DateTime(2021, 5, 27, 13, 8, 2, 701, DateTimeKind.Local).AddTicks(4047), 20m, 1 }
                });

            migrationBuilder.InsertData(
                table: "TradeItemProposals",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "ProposedAmount", "TradeId", "TradeItemId" },
                values: new object[,]
                {
                    { 8, new DateTime(2021, 5, 27, 13, 8, 2, 702, DateTimeKind.Local).AddTicks(1712), new DateTime(2021, 5, 27, 13, 8, 2, 702, DateTimeKind.Local).AddTicks(1712), 15, 2, 14 },
                    { 11, new DateTime(2021, 5, 27, 13, 8, 2, 702, DateTimeKind.Local).AddTicks(1719), new DateTime(2021, 5, 27, 13, 8, 2, 702, DateTimeKind.Local).AddTicks(1719), 5, 4, 34 },
                    { 9, new DateTime(2021, 5, 27, 13, 8, 2, 702, DateTimeKind.Local).AddTicks(1714), new DateTime(2021, 5, 27, 13, 8, 2, 702, DateTimeKind.Local).AddTicks(1714), 5, 3, 33 },
                    { 15, new DateTime(2021, 5, 27, 13, 8, 2, 702, DateTimeKind.Local).AddTicks(1729), new DateTime(2021, 5, 27, 13, 8, 2, 702, DateTimeKind.Local).AddTicks(1729), 5, 4, 4 },
                    { 14, new DateTime(2021, 5, 27, 13, 8, 2, 702, DateTimeKind.Local).AddTicks(1726), new DateTime(2021, 5, 27, 13, 8, 2, 702, DateTimeKind.Local).AddTicks(1726), 15, 4, 3 },
                    { 13, new DateTime(2021, 5, 27, 13, 8, 2, 702, DateTimeKind.Local).AddTicks(1724), new DateTime(2021, 5, 27, 13, 8, 2, 702, DateTimeKind.Local).AddTicks(1724), 5, 4, 2 },
                    { 12, new DateTime(2021, 5, 27, 13, 8, 2, 702, DateTimeKind.Local).AddTicks(1722), new DateTime(2021, 5, 27, 13, 8, 2, 702, DateTimeKind.Local).AddTicks(1722), 15, 4, 1 },
                    { 10, new DateTime(2021, 5, 27, 13, 8, 2, 702, DateTimeKind.Local).AddTicks(1717), new DateTime(2021, 5, 27, 13, 8, 2, 702, DateTimeKind.Local).AddTicks(1717), 15, 3, 28 },
                    { 7, new DateTime(2021, 5, 27, 13, 8, 2, 702, DateTimeKind.Local).AddTicks(1709), new DateTime(2021, 5, 27, 13, 8, 2, 702, DateTimeKind.Local).AddTicks(1709), 5, 2, 13 },
                    { 1, new DateTime(2021, 5, 27, 13, 8, 2, 702, DateTimeKind.Local).AddTicks(218), new DateTime(2021, 5, 27, 13, 8, 2, 702, DateTimeKind.Local).AddTicks(218), 5, 1, 1 },
                    { 20, new DateTime(2021, 5, 27, 13, 8, 2, 702, DateTimeKind.Local).AddTicks(1741), new DateTime(2021, 5, 27, 13, 8, 2, 702, DateTimeKind.Local).AddTicks(1741), 15, 6, 30 },
                    { 19, new DateTime(2021, 5, 27, 13, 8, 2, 702, DateTimeKind.Local).AddTicks(1738), new DateTime(2021, 5, 27, 13, 8, 2, 702, DateTimeKind.Local).AddTicks(1738), 1, 6, 5 },
                    { 18, new DateTime(2021, 5, 27, 13, 8, 2, 702, DateTimeKind.Local).AddTicks(1736), new DateTime(2021, 5, 27, 13, 8, 2, 702, DateTimeKind.Local).AddTicks(1736), 15, 5, 18 },
                    { 2, new DateTime(2021, 5, 27, 13, 8, 2, 702, DateTimeKind.Local).AddTicks(1685), new DateTime(2021, 5, 27, 13, 8, 2, 702, DateTimeKind.Local).AddTicks(1685), 15, 1, 2 },
                    { 3, new DateTime(2021, 5, 27, 13, 8, 2, 702, DateTimeKind.Local).AddTicks(1698), new DateTime(2021, 5, 27, 13, 8, 2, 702, DateTimeKind.Local).AddTicks(1698), 5, 1, 3 },
                    { 4, new DateTime(2021, 5, 27, 13, 8, 2, 702, DateTimeKind.Local).AddTicks(1701), new DateTime(2021, 5, 27, 13, 8, 2, 702, DateTimeKind.Local).AddTicks(1701), 5, 1, 5 },
                    { 5, new DateTime(2021, 5, 27, 13, 8, 2, 702, DateTimeKind.Local).AddTicks(1704), new DateTime(2021, 5, 27, 13, 8, 2, 702, DateTimeKind.Local).AddTicks(1704), 5, 2, 6 },
                    { 6, new DateTime(2021, 5, 27, 13, 8, 2, 702, DateTimeKind.Local).AddTicks(1707), new DateTime(2021, 5, 27, 13, 8, 2, 702, DateTimeKind.Local).AddTicks(1707), 15, 2, 7 },
                    { 16, new DateTime(2021, 5, 27, 13, 8, 2, 702, DateTimeKind.Local).AddTicks(1731), new DateTime(2021, 5, 27, 13, 8, 2, 702, DateTimeKind.Local).AddTicks(1731), 3, 5, 32 },
                    { 17, new DateTime(2021, 5, 27, 13, 8, 2, 702, DateTimeKind.Local).AddTicks(1733), new DateTime(2021, 5, 27, 13, 8, 2, 702, DateTimeKind.Local).AddTicks(1733), 5, 5, 17 }
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
