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
                    { 1, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(3406), "apples.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(3406), "apples" },
                    { 29, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4688), "olives.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4688), "olives" },
                    { 30, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4691), "oranges.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4691), "oranges" },
                    { 31, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4694), "papayas.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4694), "papayas" },
                    { 33, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4700), "pears.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4700), "pears" },
                    { 34, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4703), "peas.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4703), "peas" },
                    { 35, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4706), "pineapples.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4706), "pineapples" },
                    { 36, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4709), "pomegranates.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4709), "pomegranates" },
                    { 37, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4712), "potatoes.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4712), "potatoes" },
                    { 38, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4715), "pumpkins.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4715), "pumpkins" },
                    { 39, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4718), "radish.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4718), "radish" },
                    { 28, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4685), "mushrooms.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4685), "mushrooms" },
                    { 40, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4721), "radishes.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4721), "radishes" },
                    { 42, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4727), "salad.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4727), "salad" },
                    { 43, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4730), "salads.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4730), "salads" },
                    { 44, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4733), "scallions.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4733), "scallions" },
                    { 45, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4736), "spinach.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4736), "spinach" },
                    { 46, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4739), "star-fruits.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4739), "star-fruits" },
                    { 47, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4742), "strawberries.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4742), "strawberries" },
                    { 48, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4745), "sweet-potatoes.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4745), "sweet-potatoes" },
                    { 49, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4748), "tomatoes.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4748), "tomatoes" },
                    { 50, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4751), "watermelons.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4751), "watermelons" },
                    { 51, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4753), "v-coin.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4753), "v-coin" },
                    { 41, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4724), "raspberries.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4724), "raspberries" },
                    { 27, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4682), "melons.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4682), "melons" },
                    { 32, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4697), "peaches.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4697), "peaches" },
                    { 25, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4676), "mangos.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4676), "mangos" },
                    { 2, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4544), "artichokes.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4544), "artichokes" },
                    { 3, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4559), "asparagus.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4559), "asparagus" },
                    { 4, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4563), "bananas.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4563), "bananas" },
                    { 5, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4566), "bell-peppers.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4566), "bell-peppers" },
                    { 6, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4569), "blueberries.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4569), "blueberries" },
                    { 7, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4572), "bok-choy.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4572), "bok-choy" },
                    { 26, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4679), "mangosteens.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4679), "mangosteens" },
                    { 9, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4578), "brussels-sprouts.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4578), "brussels-sprouts" },
                    { 10, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4581), "carrots.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4581), "carrots" },
                    { 11, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4584), "cherries.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4584), "cherries" },
                    { 12, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4637), "chilis.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4637), "chilis" },
                    { 13, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4640), "coconuts.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4640), "coconuts" },
                    { 8, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4575), "broccoli.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4575), "broccoli" },
                    { 15, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4646), "corn.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4646), "corn" },
                    { 16, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4649), "cucumbers.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4649), "cucumbers" }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreatedAt", "ImageUrl", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 17, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4652), "dragon-fruits.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4652), "dragon-fruits" },
                    { 18, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4655), "durians.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4655), "durians" },
                    { 19, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4658), "eggplants.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4658), "eggplants" },
                    { 20, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4661), "garlic.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4661), "garlic" },
                    { 21, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4664), "grapes.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4664), "grapes" },
                    { 22, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4667), "guavas.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4667), "guavas" },
                    { 23, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4670), "kiwis.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4670), "kiwis" },
                    { 24, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4673), "lemons.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4673), "lemons" },
                    { 14, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4643), "coriander.svg", new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(4643), "coriander" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "ImageUrl", "IsAdmin", "LastName", "ModifiedAt", "PasswordHash", "PasswordSalt" },
                values: new object[,]
                {
                    { 11, new DateTime(2021, 5, 18, 23, 24, 1, 710, DateTimeKind.Local).AddTicks(7738), "VerhofstadDeZeemlap@europeesemailadres.com", "Verhofstad", "https://robohash.org/Zeemlap", false, "Zeemlap", new DateTime(2021, 5, 18, 23, 24, 1, 710, DateTimeKind.Local).AddTicks(7738), new byte[] { 44, 44, 101, 143, 118, 129, 196, 130, 1, 13, 154, 56, 28, 32, 182, 28, 122, 42, 161, 3, 248, 144, 235, 185, 72, 253, 171, 73, 117, 148, 215, 39, 250, 142, 234, 114, 29, 125, 200, 108, 38, 150, 208, 29, 217, 94, 25, 53, 144, 70, 33, 16, 134, 65, 110, 96, 233, 12, 237, 75, 57, 147, 78, 89 }, new byte[] { 142, 105, 99, 18, 244, 13, 188, 157, 26, 253, 196, 83, 61, 20, 115, 209, 222, 69, 241, 143, 8, 35, 98, 55, 4, 79, 48, 128, 128, 202, 122, 107, 57, 207, 61, 22, 228, 19, 203, 77, 83, 26, 246, 33, 132, 140, 4, 235, 153, 69, 134, 84, 168, 155, 87, 182, 136, 15, 74, 250, 60, 117, 223, 87, 145, 27, 119, 231, 251, 171, 177, 62, 78, 143, 246, 205, 165, 245, 102, 247, 20, 18, 71, 143, 244, 6, 75, 159, 141, 166, 181, 156, 208, 103, 174, 183, 138, 95, 110, 81, 238, 251, 8, 192, 237, 30, 1, 249, 132, 239, 159, 166, 128, 57, 100, 102, 7, 230, 101, 206, 193, 29, 128, 247, 19, 116, 131, 253 } },
                    { 10, new DateTime(2021, 5, 18, 23, 24, 1, 710, DateTimeKind.Local).AddTicks(7722), "Luc@mail.com", "Luc", "https://robohash.org/Luc", false, "DeHaantje", new DateTime(2021, 5, 18, 23, 24, 1, 710, DateTimeKind.Local).AddTicks(7722), new byte[] { 44, 44, 101, 143, 118, 129, 196, 130, 1, 13, 154, 56, 28, 32, 182, 28, 122, 42, 161, 3, 248, 144, 235, 185, 72, 253, 171, 73, 117, 148, 215, 39, 250, 142, 234, 114, 29, 125, 200, 108, 38, 150, 208, 29, 217, 94, 25, 53, 144, 70, 33, 16, 134, 65, 110, 96, 233, 12, 237, 75, 57, 147, 78, 89 }, new byte[] { 142, 105, 99, 18, 244, 13, 188, 157, 26, 253, 196, 83, 61, 20, 115, 209, 222, 69, 241, 143, 8, 35, 98, 55, 4, 79, 48, 128, 128, 202, 122, 107, 57, 207, 61, 22, 228, 19, 203, 77, 83, 26, 246, 33, 132, 140, 4, 235, 153, 69, 134, 84, 168, 155, 87, 182, 136, 15, 74, 250, 60, 117, 223, 87, 145, 27, 119, 231, 251, 171, 177, 62, 78, 143, 246, 205, 165, 245, 102, 247, 20, 18, 71, 143, 244, 6, 75, 159, 141, 166, 181, 156, 208, 103, 174, 183, 138, 95, 110, 81, 238, 251, 8, 192, 237, 30, 1, 249, 132, 239, 159, 166, 128, 57, 100, 102, 7, 230, 101, 206, 193, 29, 128, 247, 19, 116, 131, 253 } },
                    { 9, new DateTime(2021, 5, 18, 23, 24, 1, 710, DateTimeKind.Local).AddTicks(7706), "Mihiel@mail.com", "Mihiel", "https://robohash.org/Mihiel", false, "Mihoen", new DateTime(2021, 5, 18, 23, 24, 1, 710, DateTimeKind.Local).AddTicks(7706), new byte[] { 44, 44, 101, 143, 118, 129, 196, 130, 1, 13, 154, 56, 28, 32, 182, 28, 122, 42, 161, 3, 248, 144, 235, 185, 72, 253, 171, 73, 117, 148, 215, 39, 250, 142, 234, 114, 29, 125, 200, 108, 38, 150, 208, 29, 217, 94, 25, 53, 144, 70, 33, 16, 134, 65, 110, 96, 233, 12, 237, 75, 57, 147, 78, 89 }, new byte[] { 142, 105, 99, 18, 244, 13, 188, 157, 26, 253, 196, 83, 61, 20, 115, 209, 222, 69, 241, 143, 8, 35, 98, 55, 4, 79, 48, 128, 128, 202, 122, 107, 57, 207, 61, 22, 228, 19, 203, 77, 83, 26, 246, 33, 132, 140, 4, 235, 153, 69, 134, 84, 168, 155, 87, 182, 136, 15, 74, 250, 60, 117, 223, 87, 145, 27, 119, 231, 251, 171, 177, 62, 78, 143, 246, 205, 165, 245, 102, 247, 20, 18, 71, 143, 244, 6, 75, 159, 141, 166, 181, 156, 208, 103, 174, 183, 138, 95, 110, 81, 238, 251, 8, 192, 237, 30, 1, 249, 132, 239, 159, 166, 128, 57, 100, 102, 7, 230, 101, 206, 193, 29, 128, 247, 19, 116, 131, 253 } },
                    { 8, new DateTime(2021, 5, 18, 23, 24, 1, 710, DateTimeKind.Local).AddTicks(7691), "Andreas@mail.com", "Andreas", "https://robohash.org/Andreas", false, "VanGrieken", new DateTime(2021, 5, 18, 23, 24, 1, 710, DateTimeKind.Local).AddTicks(7691), new byte[] { 44, 44, 101, 143, 118, 129, 196, 130, 1, 13, 154, 56, 28, 32, 182, 28, 122, 42, 161, 3, 248, 144, 235, 185, 72, 253, 171, 73, 117, 148, 215, 39, 250, 142, 234, 114, 29, 125, 200, 108, 38, 150, 208, 29, 217, 94, 25, 53, 144, 70, 33, 16, 134, 65, 110, 96, 233, 12, 237, 75, 57, 147, 78, 89 }, new byte[] { 142, 105, 99, 18, 244, 13, 188, 157, 26, 253, 196, 83, 61, 20, 115, 209, 222, 69, 241, 143, 8, 35, 98, 55, 4, 79, 48, 128, 128, 202, 122, 107, 57, 207, 61, 22, 228, 19, 203, 77, 83, 26, 246, 33, 132, 140, 4, 235, 153, 69, 134, 84, 168, 155, 87, 182, 136, 15, 74, 250, 60, 117, 223, 87, 145, 27, 119, 231, 251, 171, 177, 62, 78, 143, 246, 205, 165, 245, 102, 247, 20, 18, 71, 143, 244, 6, 75, 159, 141, 166, 181, 156, 208, 103, 174, 183, 138, 95, 110, 81, 238, 251, 8, 192, 237, 30, 1, 249, 132, 239, 159, 166, 128, 57, 100, 102, 7, 230, 101, 206, 193, 29, 128, 247, 19, 116, 131, 253 } },
                    { 7, new DateTime(2021, 5, 18, 23, 24, 1, 710, DateTimeKind.Local).AddTicks(7675), "Dirk@mail.com", "Dirk", "https://robohash.org/Dirk", false, "Visser", new DateTime(2021, 5, 18, 23, 24, 1, 710, DateTimeKind.Local).AddTicks(7675), new byte[] { 44, 44, 101, 143, 118, 129, 196, 130, 1, 13, 154, 56, 28, 32, 182, 28, 122, 42, 161, 3, 248, 144, 235, 185, 72, 253, 171, 73, 117, 148, 215, 39, 250, 142, 234, 114, 29, 125, 200, 108, 38, 150, 208, 29, 217, 94, 25, 53, 144, 70, 33, 16, 134, 65, 110, 96, 233, 12, 237, 75, 57, 147, 78, 89 }, new byte[] { 142, 105, 99, 18, 244, 13, 188, 157, 26, 253, 196, 83, 61, 20, 115, 209, 222, 69, 241, 143, 8, 35, 98, 55, 4, 79, 48, 128, 128, 202, 122, 107, 57, 207, 61, 22, 228, 19, 203, 77, 83, 26, 246, 33, 132, 140, 4, 235, 153, 69, 134, 84, 168, 155, 87, 182, 136, 15, 74, 250, 60, 117, 223, 87, 145, 27, 119, 231, 251, 171, 177, 62, 78, 143, 246, 205, 165, 245, 102, 247, 20, 18, 71, 143, 244, 6, 75, 159, 141, 166, 181, 156, 208, 103, 174, 183, 138, 95, 110, 81, 238, 251, 8, 192, 237, 30, 1, 249, 132, 239, 159, 166, 128, 57, 100, 102, 7, 230, 101, 206, 193, 29, 128, 247, 19, 116, 131, 253 } },
                    { 1, new DateTime(2021, 5, 18, 23, 24, 1, 706, DateTimeKind.Local).AddTicks(8137), "Pieter@mail.com", "Pieter", "https://robohash.org/Pieter", true, "Corp", new DateTime(2021, 5, 18, 23, 24, 1, 706, DateTimeKind.Local).AddTicks(8137), new byte[] { 44, 44, 101, 143, 118, 129, 196, 130, 1, 13, 154, 56, 28, 32, 182, 28, 122, 42, 161, 3, 248, 144, 235, 185, 72, 253, 171, 73, 117, 148, 215, 39, 250, 142, 234, 114, 29, 125, 200, 108, 38, 150, 208, 29, 217, 94, 25, 53, 144, 70, 33, 16, 134, 65, 110, 96, 233, 12, 237, 75, 57, 147, 78, 89 }, new byte[] { 142, 105, 99, 18, 244, 13, 188, 157, 26, 253, 196, 83, 61, 20, 115, 209, 222, 69, 241, 143, 8, 35, 98, 55, 4, 79, 48, 128, 128, 202, 122, 107, 57, 207, 61, 22, 228, 19, 203, 77, 83, 26, 246, 33, 132, 140, 4, 235, 153, 69, 134, 84, 168, 155, 87, 182, 136, 15, 74, 250, 60, 117, 223, 87, 145, 27, 119, 231, 251, 171, 177, 62, 78, 143, 246, 205, 165, 245, 102, 247, 20, 18, 71, 143, 244, 6, 75, 159, 141, 166, 181, 156, 208, 103, 174, 183, 138, 95, 110, 81, 238, 251, 8, 192, 237, 30, 1, 249, 132, 239, 159, 166, 128, 57, 100, 102, 7, 230, 101, 206, 193, 29, 128, 247, 19, 116, 131, 253 } },
                    { 5, new DateTime(2021, 5, 18, 23, 24, 1, 710, DateTimeKind.Local).AddTicks(7643), "BartjeWevertje@mail.com", "BartjeWevertje", "https://robohash.org/BartjeWevertje", false, "Wevertje", new DateTime(2021, 5, 18, 23, 24, 1, 710, DateTimeKind.Local).AddTicks(7643), new byte[] { 44, 44, 101, 143, 118, 129, 196, 130, 1, 13, 154, 56, 28, 32, 182, 28, 122, 42, 161, 3, 248, 144, 235, 185, 72, 253, 171, 73, 117, 148, 215, 39, 250, 142, 234, 114, 29, 125, 200, 108, 38, 150, 208, 29, 217, 94, 25, 53, 144, 70, 33, 16, 134, 65, 110, 96, 233, 12, 237, 75, 57, 147, 78, 89 }, new byte[] { 142, 105, 99, 18, 244, 13, 188, 157, 26, 253, 196, 83, 61, 20, 115, 209, 222, 69, 241, 143, 8, 35, 98, 55, 4, 79, 48, 128, 128, 202, 122, 107, 57, 207, 61, 22, 228, 19, 203, 77, 83, 26, 246, 33, 132, 140, 4, 235, 153, 69, 134, 84, 168, 155, 87, 182, 136, 15, 74, 250, 60, 117, 223, 87, 145, 27, 119, 231, 251, 171, 177, 62, 78, 143, 246, 205, 165, 245, 102, 247, 20, 18, 71, 143, 244, 6, 75, 159, 141, 166, 181, 156, 208, 103, 174, 183, 138, 95, 110, 81, 238, 251, 8, 192, 237, 30, 1, 249, 132, 239, 159, 166, 128, 57, 100, 102, 7, 230, 101, 206, 193, 29, 128, 247, 19, 116, 131, 253 } },
                    { 4, new DateTime(2021, 5, 18, 23, 24, 1, 710, DateTimeKind.Local).AddTicks(7622), "Dries@mail.com", "Dries", "https://robohash.org/Dries", true, "Maes", new DateTime(2021, 5, 18, 23, 24, 1, 710, DateTimeKind.Local).AddTicks(7622), new byte[] { 44, 44, 101, 143, 118, 129, 196, 130, 1, 13, 154, 56, 28, 32, 182, 28, 122, 42, 161, 3, 248, 144, 235, 185, 72, 253, 171, 73, 117, 148, 215, 39, 250, 142, 234, 114, 29, 125, 200, 108, 38, 150, 208, 29, 217, 94, 25, 53, 144, 70, 33, 16, 134, 65, 110, 96, 233, 12, 237, 75, 57, 147, 78, 89 }, new byte[] { 142, 105, 99, 18, 244, 13, 188, 157, 26, 253, 196, 83, 61, 20, 115, 209, 222, 69, 241, 143, 8, 35, 98, 55, 4, 79, 48, 128, 128, 202, 122, 107, 57, 207, 61, 22, 228, 19, 203, 77, 83, 26, 246, 33, 132, 140, 4, 235, 153, 69, 134, 84, 168, 155, 87, 182, 136, 15, 74, 250, 60, 117, 223, 87, 145, 27, 119, 231, 251, 171, 177, 62, 78, 143, 246, 205, 165, 245, 102, 247, 20, 18, 71, 143, 244, 6, 75, 159, 141, 166, 181, 156, 208, 103, 174, 183, 138, 95, 110, 81, 238, 251, 8, 192, 237, 30, 1, 249, 132, 239, 159, 166, 128, 57, 100, 102, 7, 230, 101, 206, 193, 29, 128, 247, 19, 116, 131, 253 } },
                    { 3, new DateTime(2021, 5, 18, 23, 24, 1, 710, DateTimeKind.Local).AddTicks(7505), "Kobe@mail.com", "Kobe", "https://robohash.org/Kobe", true, "Delo", new DateTime(2021, 5, 18, 23, 24, 1, 710, DateTimeKind.Local).AddTicks(7505), new byte[] { 44, 44, 101, 143, 118, 129, 196, 130, 1, 13, 154, 56, 28, 32, 182, 28, 122, 42, 161, 3, 248, 144, 235, 185, 72, 253, 171, 73, 117, 148, 215, 39, 250, 142, 234, 114, 29, 125, 200, 108, 38, 150, 208, 29, 217, 94, 25, 53, 144, 70, 33, 16, 134, 65, 110, 96, 233, 12, 237, 75, 57, 147, 78, 89 }, new byte[] { 142, 105, 99, 18, 244, 13, 188, 157, 26, 253, 196, 83, 61, 20, 115, 209, 222, 69, 241, 143, 8, 35, 98, 55, 4, 79, 48, 128, 128, 202, 122, 107, 57, 207, 61, 22, 228, 19, 203, 77, 83, 26, 246, 33, 132, 140, 4, 235, 153, 69, 134, 84, 168, 155, 87, 182, 136, 15, 74, 250, 60, 117, 223, 87, 145, 27, 119, 231, 251, 171, 177, 62, 78, 143, 246, 205, 165, 245, 102, 247, 20, 18, 71, 143, 244, 6, 75, 159, 141, 166, 181, 156, 208, 103, 174, 183, 138, 95, 110, 81, 238, 251, 8, 192, 237, 30, 1, 249, 132, 239, 159, 166, 128, 57, 100, 102, 7, 230, 101, 206, 193, 29, 128, 247, 19, 116, 131, 253 } },
                    { 2, new DateTime(2021, 5, 18, 23, 24, 1, 710, DateTimeKind.Local).AddTicks(7296), "Nick@mail.com", "Nick", "https://robohash.org/Nick", true, "Vr", new DateTime(2021, 5, 18, 23, 24, 1, 710, DateTimeKind.Local).AddTicks(7296), new byte[] { 44, 44, 101, 143, 118, 129, 196, 130, 1, 13, 154, 56, 28, 32, 182, 28, 122, 42, 161, 3, 248, 144, 235, 185, 72, 253, 171, 73, 117, 148, 215, 39, 250, 142, 234, 114, 29, 125, 200, 108, 38, 150, 208, 29, 217, 94, 25, 53, 144, 70, 33, 16, 134, 65, 110, 96, 233, 12, 237, 75, 57, 147, 78, 89 }, new byte[] { 142, 105, 99, 18, 244, 13, 188, 157, 26, 253, 196, 83, 61, 20, 115, 209, 222, 69, 241, 143, 8, 35, 98, 55, 4, 79, 48, 128, 128, 202, 122, 107, 57, 207, 61, 22, 228, 19, 203, 77, 83, 26, 246, 33, 132, 140, 4, 235, 153, 69, 134, 84, 168, 155, 87, 182, 136, 15, 74, 250, 60, 117, 223, 87, 145, 27, 119, 231, 251, 171, 177, 62, 78, 143, 246, 205, 165, 245, 102, 247, 20, 18, 71, 143, 244, 6, 75, 159, 141, 166, 181, 156, 208, 103, 174, 183, 138, 95, 110, 81, 238, 251, 8, 192, 237, 30, 1, 249, 132, 239, 159, 166, 128, 57, 100, 102, 7, 230, 101, 206, 193, 29, 128, 247, 19, 116, 131, 253 } },
                    { 12, new DateTime(2021, 5, 18, 23, 24, 1, 710, DateTimeKind.Local).AddTicks(7754), "Driesdentweedenmaarnidezelfden@mail.com", "Dries", "https://robohash.org/Dries2", false, "VanKorteNekke", new DateTime(2021, 5, 18, 23, 24, 1, 710, DateTimeKind.Local).AddTicks(7754), new byte[] { 44, 44, 101, 143, 118, 129, 196, 130, 1, 13, 154, 56, 28, 32, 182, 28, 122, 42, 161, 3, 248, 144, 235, 185, 72, 253, 171, 73, 117, 148, 215, 39, 250, 142, 234, 114, 29, 125, 200, 108, 38, 150, 208, 29, 217, 94, 25, 53, 144, 70, 33, 16, 134, 65, 110, 96, 233, 12, 237, 75, 57, 147, 78, 89 }, new byte[] { 142, 105, 99, 18, 244, 13, 188, 157, 26, 253, 196, 83, 61, 20, 115, 209, 222, 69, 241, 143, 8, 35, 98, 55, 4, 79, 48, 128, 128, 202, 122, 107, 57, 207, 61, 22, 228, 19, 203, 77, 83, 26, 246, 33, 132, 140, 4, 235, 153, 69, 134, 84, 168, 155, 87, 182, 136, 15, 74, 250, 60, 117, 223, 87, 145, 27, 119, 231, 251, 171, 177, 62, 78, 143, 246, 205, 165, 245, 102, 247, 20, 18, 71, 143, 244, 6, 75, 159, 141, 166, 181, 156, 208, 103, 174, 183, 138, 95, 110, 81, 238, 251, 8, 192, 237, 30, 1, 249, 132, 239, 159, 166, 128, 57, 100, 102, 7, 230, 101, 206, 193, 29, 128, 247, 19, 116, 131, 253 } },
                    { 6, new DateTime(2021, 5, 18, 23, 24, 1, 710, DateTimeKind.Local).AddTicks(7659), "Stofzuiger@mail.com", "Stofzuiger", "https://robohash.org/Stofzuiger", false, "Zuiger", new DateTime(2021, 5, 18, 23, 24, 1, 710, DateTimeKind.Local).AddTicks(7659), new byte[] { 44, 44, 101, 143, 118, 129, 196, 130, 1, 13, 154, 56, 28, 32, 182, 28, 122, 42, 161, 3, 248, 144, 235, 185, 72, 253, 171, 73, 117, 148, 215, 39, 250, 142, 234, 114, 29, 125, 200, 108, 38, 150, 208, 29, 217, 94, 25, 53, 144, 70, 33, 16, 134, 65, 110, 96, 233, 12, 237, 75, 57, 147, 78, 89 }, new byte[] { 142, 105, 99, 18, 244, 13, 188, 157, 26, 253, 196, 83, 61, 20, 115, 209, 222, 69, 241, 143, 8, 35, 98, 55, 4, 79, 48, 128, 128, 202, 122, 107, 57, 207, 61, 22, 228, 19, 203, 77, 83, 26, 246, 33, 132, 140, 4, 235, 153, 69, 134, 84, 168, 155, 87, 182, 136, 15, 74, 250, 60, 117, 223, 87, 145, 27, 119, 231, 251, 171, 177, 62, 78, 143, 246, 205, 165, 245, 102, 247, 20, 18, 71, 143, 244, 6, 75, 159, 141, 166, 181, 156, 208, 103, 174, 183, 138, 95, 110, 81, 238, 251, 8, 192, 237, 30, 1, 249, 132, 239, 159, 166, 128, 57, 100, 102, 7, 230, 101, 206, 193, 29, 128, 247, 19, 116, 131, 253 } },
                    { 13, new DateTime(2021, 5, 18, 23, 24, 1, 710, DateTimeKind.Local).AddTicks(7771), "Joyce@mail.com", "Joyce", "https://robohash.org/Tomatenplukker", false, "Tomatenplukker", new DateTime(2021, 5, 18, 23, 24, 1, 710, DateTimeKind.Local).AddTicks(7771), new byte[] { 44, 44, 101, 143, 118, 129, 196, 130, 1, 13, 154, 56, 28, 32, 182, 28, 122, 42, 161, 3, 248, 144, 235, 185, 72, 253, 171, 73, 117, 148, 215, 39, 250, 142, 234, 114, 29, 125, 200, 108, 38, 150, 208, 29, 217, 94, 25, 53, 144, 70, 33, 16, 134, 65, 110, 96, 233, 12, 237, 75, 57, 147, 78, 89 }, new byte[] { 142, 105, 99, 18, 244, 13, 188, 157, 26, 253, 196, 83, 61, 20, 115, 209, 222, 69, 241, 143, 8, 35, 98, 55, 4, 79, 48, 128, 128, 202, 122, 107, 57, 207, 61, 22, 228, 19, 203, 77, 83, 26, 246, 33, 132, 140, 4, 235, 153, 69, 134, 84, 168, 155, 87, 182, 136, 15, 74, 250, 60, 117, 223, 87, 145, 27, 119, 231, 251, 171, 177, 62, 78, 143, 246, 205, 165, 245, 102, 247, 20, 18, 71, 143, 244, 6, 75, 159, 141, 166, 181, 156, 208, 103, 174, 183, 138, 95, 110, 81, 238, 251, 8, 192, 237, 30, 1, 249, 132, 239, 159, 166, 128, 57, 100, 102, 7, 230, 101, 206, 193, 29, 128, 247, 19, 116, 131, 253 } }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "PostalCode", "StreetName", "StreetNumber", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 18, 23, 24, 1, 712, DateTimeKind.Local).AddTicks(7547), new DateTime(2021, 5, 18, 23, 24, 1, 712, DateTimeKind.Local).AddTicks(7547), 9000, "Anti-Veggiestraat", 89, 1 },
                    { 4, new DateTime(2021, 5, 18, 23, 24, 1, 712, DateTimeKind.Local).AddTicks(9750), new DateTime(2021, 5, 18, 23, 24, 1, 712, DateTimeKind.Local).AddTicks(9750), 1000, "Driesstraat", 66, 4 },
                    { 6, new DateTime(2021, 5, 18, 23, 24, 1, 712, DateTimeKind.Local).AddTicks(9756), new DateTime(2021, 5, 18, 23, 24, 1, 712, DateTimeKind.Local).AddTicks(9756), 1000, "Lookbroodjesstraat", 43, 6 },
                    { 5, new DateTime(2021, 5, 18, 23, 24, 1, 712, DateTimeKind.Local).AddTicks(9753), new DateTime(2021, 5, 18, 23, 24, 1, 712, DateTimeKind.Local).AddTicks(9753), 2000, "Kobestraat", 85, 5 },
                    { 10, new DateTime(2021, 5, 18, 23, 24, 1, 712, DateTimeKind.Local).AddTicks(9767), new DateTime(2021, 5, 18, 23, 24, 1, 712, DateTimeKind.Local).AddTicks(9767), 9070, "Geenpolitiekinhetprojectstraat", 200, 10 },
                    { 8, new DateTime(2021, 5, 18, 23, 24, 1, 712, DateTimeKind.Local).AddTicks(9761), new DateTime(2021, 5, 18, 23, 24, 1, 712, DateTimeKind.Local).AddTicks(9761), 1000, "Kotsvisstraat", 96, 8 },
                    { 11, new DateTime(2021, 5, 18, 23, 24, 1, 712, DateTimeKind.Local).AddTicks(9770), new DateTime(2021, 5, 18, 23, 24, 1, 712, DateTimeKind.Local).AddTicks(9770), 9500, "Kalfslapjesstraat", 32, 11 },
                    { 3, new DateTime(2021, 5, 18, 23, 24, 1, 712, DateTimeKind.Local).AddTicks(9747), new DateTime(2021, 5, 18, 23, 24, 1, 712, DateTimeKind.Local).AddTicks(9747), 9000, "Nickstraat", 74, 3 },
                    { 12, new DateTime(2021, 5, 18, 23, 24, 1, 712, DateTimeKind.Local).AddTicks(9772), new DateTime(2021, 5, 18, 23, 24, 1, 712, DateTimeKind.Local).AddTicks(9772), 1000, "Blacklivesmatterstraat", 78, 12 },
                    { 2, new DateTime(2021, 5, 18, 23, 24, 1, 712, DateTimeKind.Local).AddTicks(9730), new DateTime(2021, 5, 18, 23, 24, 1, 712, DateTimeKind.Local).AddTicks(9730), 9000, "Pieterstreaat", 45, 2 },
                    { 13, new DateTime(2021, 5, 18, 23, 24, 1, 712, DateTimeKind.Local).AddTicks(9775), new DateTime(2021, 5, 18, 23, 24, 1, 712, DateTimeKind.Local).AddTicks(9775), 9020, "Worstenbroodjesstraat", 4, 13 },
                    { 7, new DateTime(2021, 5, 18, 23, 24, 1, 712, DateTimeKind.Local).AddTicks(9759), new DateTime(2021, 5, 18, 23, 24, 1, 712, DateTimeKind.Local).AddTicks(9759), 9050, "Greenpeacestraat", 1, 7 },
                    { 9, new DateTime(2021, 5, 18, 23, 24, 1, 712, DateTimeKind.Local).AddTicks(9764), new DateTime(2021, 5, 18, 23, 24, 1, 712, DateTimeKind.Local).AddTicks(9764), 2000, "Greenlivesmattertoostraat", 420, 9 }
                });

            migrationBuilder.InsertData(
                table: "TradeItems",
                columns: new[] { "Id", "Amount", "CreatedAt", "ModifiedAt", "ResourceId", "UserId" },
                values: new object[,]
                {
                    { 2, 10, new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1666), new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1666), 11, 8 },
                    { 26, 10, new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1752), new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1752), 39, 7 },
                    { 7, 42, new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1695), new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1695), 17, 7 },
                    { 20, 30, new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1733), new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1733), 36, 7 },
                    { 10, 634, new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1704), new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1704), 10, 9 },
                    { 9, 201, new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1701), new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1701), 9, 9 },
                    { 22, 69, new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1740), new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1740), 27, 9 },
                    { 1, 2, new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(17), new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(17), 51, 10 },
                    { 13, 69, new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1713), new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1713), 19, 10 },
                    { 11, 20, new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1707), new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1707), 17, 11 },
                    { 19, 17, new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1730), new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1730), 7, 12 },
                    { 3, 50, new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1681), new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1681), 32, 13 },
                    { 8, 75, new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1698), new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1698), 8, 8 },
                    { 12, 75, new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1710), new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1710), 26, 13 },
                    { 25, 20, new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1749), new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1749), 48, 6 },
                    { 6, 30, new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1692), new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1692), 6, 6 },
                    { 18, 9, new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1727), new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1727), 6, 1 },
                    { 23, 180, new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1743), new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1743), 37, 1 },
                    { 24, 47, new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1746), new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1746), 47, 2 },
                    { 14, 25, new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1716), new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1716), 49, 3 },
                    { 21, 78, new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1736), new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1736), 23, 6 },
                    { 4, 69, new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1685), new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1685), 24, 4 },
                    { 15, 35, new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1719), new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1719), 50, 4 },
                    { 17, 10, new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1725), new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1725), 1, 3 },
                    { 5, 45, new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1688), new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1688), 45, 5 },
                    { 16, 75, new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1722), new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(1722), 7, 5 }
                });

            migrationBuilder.InsertData(
                table: "Trades",
                columns: new[] { "Id", "ActiveUserId", "Completed", "CreatedAt", "ModifiedAt", "ProposerId", "ReceiverId" },
                values: new object[,]
                {
                    { 4, 5, false, new DateTime(2021, 5, 18, 23, 24, 1, 716, DateTimeKind.Local).AddTicks(1667), new DateTime(2021, 5, 18, 23, 24, 1, 716, DateTimeKind.Local).AddTicks(1667), 5, 2 },
                    { 3, 4, false, new DateTime(2021, 5, 18, 23, 24, 1, 716, DateTimeKind.Local).AddTicks(1663), new DateTime(2021, 5, 18, 23, 24, 1, 716, DateTimeKind.Local).AddTicks(1663), 4, 2 },
                    { 5, 5, false, new DateTime(2021, 5, 18, 23, 24, 1, 716, DateTimeKind.Local).AddTicks(1670), new DateTime(2021, 5, 18, 23, 24, 1, 716, DateTimeKind.Local).AddTicks(1670), 1, 5 }
                });

            migrationBuilder.InsertData(
                table: "Trades",
                columns: new[] { "Id", "ActiveUserId", "Completed", "CreatedAt", "ModifiedAt", "ProposerId", "ReceiverId" },
                values: new object[,]
                {
                    { 6, 1, false, new DateTime(2021, 5, 18, 23, 24, 1, 716, DateTimeKind.Local).AddTicks(1674), new DateTime(2021, 5, 18, 23, 24, 1, 716, DateTimeKind.Local).AddTicks(1674), 3, 1 },
                    { 2, 3, false, new DateTime(2021, 5, 18, 23, 24, 1, 716, DateTimeKind.Local).AddTicks(1647), new DateTime(2021, 5, 18, 23, 24, 1, 716, DateTimeKind.Local).AddTicks(1647), 3, 1 },
                    { 1, 1, true, new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(9436), new DateTime(2021, 5, 18, 23, 24, 1, 715, DateTimeKind.Local).AddTicks(9436), 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "UserId", "VAmount" },
                values: new object[,]
                {
                    { 6, new DateTime(2021, 5, 18, 23, 24, 1, 714, DateTimeKind.Local).AddTicks(876), new DateTime(2021, 5, 18, 23, 24, 1, 714, DateTimeKind.Local).AddTicks(876), 6, 36m },
                    { 5, new DateTime(2021, 5, 18, 23, 24, 1, 714, DateTimeKind.Local).AddTicks(872), new DateTime(2021, 5, 18, 23, 24, 1, 714, DateTimeKind.Local).AddTicks(872), 5, 753m },
                    { 12, new DateTime(2021, 5, 18, 23, 24, 1, 714, DateTimeKind.Local).AddTicks(898), new DateTime(2021, 5, 18, 23, 24, 1, 714, DateTimeKind.Local).AddTicks(898), 12, 57m },
                    { 1, new DateTime(2021, 5, 18, 23, 24, 1, 713, DateTimeKind.Local).AddTicks(9251), new DateTime(2021, 5, 18, 23, 24, 1, 713, DateTimeKind.Local).AddTicks(9251), 1, 200m },
                    { 11, new DateTime(2021, 5, 18, 23, 24, 1, 714, DateTimeKind.Local).AddTicks(895), new DateTime(2021, 5, 18, 23, 24, 1, 714, DateTimeKind.Local).AddTicks(895), 11, 269m },
                    { 10, new DateTime(2021, 5, 18, 23, 24, 1, 714, DateTimeKind.Local).AddTicks(891), new DateTime(2021, 5, 18, 23, 24, 1, 714, DateTimeKind.Local).AddTicks(891), 10, 124m },
                    { 4, new DateTime(2021, 5, 18, 23, 24, 1, 714, DateTimeKind.Local).AddTicks(868), new DateTime(2021, 5, 18, 23, 24, 1, 714, DateTimeKind.Local).AddTicks(868), 4, 42m },
                    { 9, new DateTime(2021, 5, 18, 23, 24, 1, 714, DateTimeKind.Local).AddTicks(887), new DateTime(2021, 5, 18, 23, 24, 1, 714, DateTimeKind.Local).AddTicks(887), 9, 357m },
                    { 3, new DateTime(2021, 5, 18, 23, 24, 1, 714, DateTimeKind.Local).AddTicks(863), new DateTime(2021, 5, 18, 23, 24, 1, 714, DateTimeKind.Local).AddTicks(863), 3, 65m },
                    { 7, new DateTime(2021, 5, 18, 23, 24, 1, 714, DateTimeKind.Local).AddTicks(880), new DateTime(2021, 5, 18, 23, 24, 1, 714, DateTimeKind.Local).AddTicks(880), 7, 12m },
                    { 8, new DateTime(2021, 5, 18, 23, 24, 1, 714, DateTimeKind.Local).AddTicks(883), new DateTime(2021, 5, 18, 23, 24, 1, 714, DateTimeKind.Local).AddTicks(883), 8, 654m },
                    { 2, new DateTime(2021, 5, 18, 23, 24, 1, 714, DateTimeKind.Local).AddTicks(843), new DateTime(2021, 5, 18, 23, 24, 1, 714, DateTimeKind.Local).AddTicks(843), 2, 347m },
                    { 13, new DateTime(2021, 5, 18, 23, 24, 1, 714, DateTimeKind.Local).AddTicks(902), new DateTime(2021, 5, 18, 23, 24, 1, 714, DateTimeKind.Local).AddTicks(902), 13, 204m }
                });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "CreatedAt", "EuroAmount", "ModifiedAt", "VAmount", "WalletId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(8572), 6.9m, new DateTime(2021, 5, 18, 23, 24, 1, 717, DateTimeKind.Local).AddTicks(8572), 69m, 1 },
                    { 4, new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(108), 10m, new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(108), 100m, 6 },
                    { 3, new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(105), 42m, new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(105), 420m, 5 },
                    { 7, new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(117), 9.8m, new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(117), 98m, 9 },
                    { 6, new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(114), 7.8m, new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(114), 78m, 10 },
                    { 10, new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(125), 2m, new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(125), 20m, 4 },
                    { 8, new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(120), 5m, new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(120), 50m, 7 },
                    { 9, new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(122), 13m, new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(122), 130m, 3 },
                    { 5, new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(111), 3.6m, new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(111), 36m, 12 },
                    { 2, new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(75), 2m, new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(75), 20m, 1 }
                });

            migrationBuilder.InsertData(
                table: "TradeItemProposal",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "ProposedAmount", "TradeId", "TradeItemId" },
                values: new object[,]
                {
                    { 19, new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7737), new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7737), 23, 4, 19 },
                    { 13, new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7722), new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7722), 17, 3, 13 },
                    { 2, new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7685), new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7685), 6, 2, 2 },
                    { 22, new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7744), new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7744), 26, 2, 22 },
                    { 10, new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7715), new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7715), 14, 5, 10 },
                    { 9, new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7712), new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7712), 13, 4, 9 },
                    { 8, new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7710), new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7710), 12, 3, 8 },
                    { 11, new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7717), new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7717), 15, 1, 11 },
                    { 1, new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(6377), new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(6377), 5, 1, 1 },
                    { 7, new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7707), new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7707), 11, 2, 7 },
                    { 3, new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7696), new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7696), 7, 3, 3 },
                    { 21, new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7742), new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7742), 25, 1, 21 },
                    { 6, new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7705), new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7705), 10, 1, 6 },
                    { 16, new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7729), new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7729), 20, 1, 16 },
                    { 5, new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7702), new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7702), 9, 5, 5 },
                    { 15, new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7727), new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7727), 19, 5, 15 },
                    { 14, new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7725), new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7725), 18, 4, 14 },
                    { 4, new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7699), new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7699), 8, 4, 4 },
                    { 23, new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7747), new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7747), 27, 3, 23 },
                    { 18, new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7734), new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7734), 22, 3, 18 },
                    { 17, new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7732), new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7732), 21, 2, 17 },
                    { 20, new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7740), new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7740), 24, 5, 20 },
                    { 12, new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7720), new DateTime(2021, 5, 18, 23, 24, 1, 718, DateTimeKind.Local).AddTicks(7720), 16, 2, 12 }
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
