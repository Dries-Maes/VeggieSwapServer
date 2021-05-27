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
                    { 1, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(8404), "apples.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(8404), "apples" },
                    { 29, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9631), "olives.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9631), "olives" },
                    { 30, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9634), "oranges.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9634), "oranges" },
                    { 31, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9637), "papayas.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9637), "papayas" },
                    { 32, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9639), "peaches.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9639), "peaches" },
                    { 33, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9642), "pears.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9642), "pears" },
                    { 34, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9645), "peas.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9645), "peas" },
                    { 35, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9648), "pineapples.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9648), "pineapples" },
                    { 36, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9650), "pomegranates.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9650), "pomegranates" },
                    { 38, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9656), "pumpkins.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9656), "pumpkins" },
                    { 39, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9659), "radish.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9659), "radish" },
                    { 28, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9628), "mushrooms.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9628), "mushrooms" },
                    { 40, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9661), "radishes.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9661), "radishes" },
                    { 42, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9667), "salad.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9667), "salad" },
                    { 43, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9669), "salads.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9669), "salads" },
                    { 44, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9672), "scallions.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9672), "scallions" },
                    { 45, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9675), "spinach.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9675), "spinach" },
                    { 46, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9678), "star-fruits.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9678), "star-fruits" },
                    { 47, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9680), "strawberries.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9680), "strawberries" },
                    { 48, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9683), "sweet-potatoes.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9683), "sweet-potatoes" },
                    { 49, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9686), "tomatoes.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9686), "tomatoes" },
                    { 50, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9689), "watermelons.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9689), "watermelons" },
                    { 51, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9691), "v-coin.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9691), "v-coin" },
                    { 41, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9664), "raspberries.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9664), "raspberries" },
                    { 27, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9625), "melons.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9625), "melons" },
                    { 37, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9653), "potatoes.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9653), "potatoes" },
                    { 25, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9620), "mangos.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9620), "mangos" },
                    { 2, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9494), "artichokes.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9494), "artichokes" },
                    { 26, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9623), "mangosteens.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9623), "mangosteens" },
                    { 4, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9513), "bananas.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9513), "bananas" },
                    { 5, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9516), "bell-peppers.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9516), "bell-peppers" },
                    { 6, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9519), "blueberries.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9519), "blueberries" },
                    { 7, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9522), "bok-choy.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9522), "bok-choy" },
                    { 8, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9525), "broccoli.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9525), "broccoli" },
                    { 9, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9527), "brussels-sprouts.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9527), "brussels-sprouts" },
                    { 10, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9530), "carrots.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9530), "carrots" },
                    { 11, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9533), "cherries.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9533), "cherries" },
                    { 12, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9536), "chilis.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9536), "chilis" },
                    { 13, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9539), "coconuts.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9539), "coconuts" },
                    { 3, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9509), "asparagus.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9509), "asparagus" },
                    { 15, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9545), "corn.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9545), "corn" },
                    { 14, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9542), "coriander.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9542), "coriander" }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreatedAt", "ImageUrl", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 23, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9614), "kiwis.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9614), "kiwis" },
                    { 22, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9611), "guavas.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9611), "guavas" },
                    { 21, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9609), "grapes.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9609), "grapes" },
                    { 20, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9605), "garlic.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9605), "garlic" },
                    { 24, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9617), "lemons.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9617), "lemons" },
                    { 18, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9553), "durians.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9553), "durians" },
                    { 17, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9550), "dragon-fruits.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9550), "dragon-fruits" },
                    { 16, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9547), "cucumbers.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9547), "cucumbers" },
                    { 19, new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9556), "eggplants.svg", new DateTime(2021, 5, 27, 11, 14, 6, 62, DateTimeKind.Local).AddTicks(9556), "eggplants" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "ImageUrl", "IsAdmin", "LastName", "ModifiedAt", "PasswordHash", "PasswordSalt" },
                values: new object[,]
                {
                    { 12, new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(6359), "Simon@mail.com", "Simon", "Dries2", false, "Lidllover", new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(6359), new byte[] { 125, 101, 252, 234, 71, 84, 133, 64, 244, 41, 73, 113, 120, 135, 76, 135, 226, 175, 225, 131, 113, 49, 240, 182, 82, 49, 248, 216, 48, 11, 213, 122, 109, 87, 41, 97, 83, 55, 162, 185, 14, 83, 172, 154, 49, 138, 176, 167, 22, 190, 155, 56, 0, 246, 103, 173, 81, 30, 247, 27, 25, 169, 36, 113 }, new byte[] { 234, 159, 203, 131, 183, 234, 180, 2, 9, 224, 171, 68, 62, 170, 129, 248, 71, 251, 224, 143, 109, 246, 27, 26, 181, 14, 202, 111, 186, 130, 48, 32, 211, 14, 166, 72, 221, 91, 32, 135, 104, 191, 254, 103, 8, 173, 237, 34, 241, 34, 14, 29, 84, 24, 221, 28, 91, 120, 111, 62, 65, 35, 129, 51, 169, 165, 243, 97, 38, 244, 118, 128, 62, 210, 58, 53, 221, 250, 94, 176, 230, 231, 161, 93, 130, 50, 186, 157, 203, 165, 156, 121, 206, 184, 83, 127, 116, 66, 172, 121, 180, 36, 58, 87, 44, 155, 70, 216, 37, 45, 212, 116, 135, 15, 92, 225, 174, 207, 226, 138, 5, 240, 64, 252, 214, 145, 214, 191 } },
                    { 19, new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(6467), "Karolien@mail.com", "Karolien", "78", false, "Vdabpolitie", new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(6467), new byte[] { 125, 101, 252, 234, 71, 84, 133, 64, 244, 41, 73, 113, 120, 135, 76, 135, 226, 175, 225, 131, 113, 49, 240, 182, 82, 49, 248, 216, 48, 11, 213, 122, 109, 87, 41, 97, 83, 55, 162, 185, 14, 83, 172, 154, 49, 138, 176, 167, 22, 190, 155, 56, 0, 246, 103, 173, 81, 30, 247, 27, 25, 169, 36, 113 }, new byte[] { 234, 159, 203, 131, 183, 234, 180, 2, 9, 224, 171, 68, 62, 170, 129, 248, 71, 251, 224, 143, 109, 246, 27, 26, 181, 14, 202, 111, 186, 130, 48, 32, 211, 14, 166, 72, 221, 91, 32, 135, 104, 191, 254, 103, 8, 173, 237, 34, 241, 34, 14, 29, 84, 24, 221, 28, 91, 120, 111, 62, 65, 35, 129, 51, 169, 165, 243, 97, 38, 244, 118, 128, 62, 210, 58, 53, 221, 250, 94, 176, 230, 231, 161, 93, 130, 50, 186, 157, 203, 165, 156, 121, 206, 184, 83, 127, 116, 66, 172, 121, 180, 36, 58, 87, 44, 155, 70, 216, 37, 45, 212, 116, 135, 15, 92, 225, 174, 207, 226, 138, 5, 240, 64, 252, 214, 145, 214, 191 } },
                    { 18, new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(6452), "Joke@mail.com", "Joke", "24", false, "LidlAnnoying", new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(6452), new byte[] { 125, 101, 252, 234, 71, 84, 133, 64, 244, 41, 73, 113, 120, 135, 76, 135, 226, 175, 225, 131, 113, 49, 240, 182, 82, 49, 248, 216, 48, 11, 213, 122, 109, 87, 41, 97, 83, 55, 162, 185, 14, 83, 172, 154, 49, 138, 176, 167, 22, 190, 155, 56, 0, 246, 103, 173, 81, 30, 247, 27, 25, 169, 36, 113 }, new byte[] { 234, 159, 203, 131, 183, 234, 180, 2, 9, 224, 171, 68, 62, 170, 129, 248, 71, 251, 224, 143, 109, 246, 27, 26, 181, 14, 202, 111, 186, 130, 48, 32, 211, 14, 166, 72, 221, 91, 32, 135, 104, 191, 254, 103, 8, 173, 237, 34, 241, 34, 14, 29, 84, 24, 221, 28, 91, 120, 111, 62, 65, 35, 129, 51, 169, 165, 243, 97, 38, 244, 118, 128, 62, 210, 58, 53, 221, 250, 94, 176, 230, 231, 161, 93, 130, 50, 186, 157, 203, 165, 156, 121, 206, 184, 83, 127, 116, 66, 172, 121, 180, 36, 58, 87, 44, 155, 70, 216, 37, 45, 212, 116, 135, 15, 92, 225, 174, 207, 226, 138, 5, 240, 64, 252, 214, 145, 214, 191 } },
                    { 17, new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(6436), "Sien@mail.com", "Sien", "57", false, "Rommeltje", new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(6436), new byte[] { 125, 101, 252, 234, 71, 84, 133, 64, 244, 41, 73, 113, 120, 135, 76, 135, 226, 175, 225, 131, 113, 49, 240, 182, 82, 49, 248, 216, 48, 11, 213, 122, 109, 87, 41, 97, 83, 55, 162, 185, 14, 83, 172, 154, 49, 138, 176, 167, 22, 190, 155, 56, 0, 246, 103, 173, 81, 30, 247, 27, 25, 169, 36, 113 }, new byte[] { 234, 159, 203, 131, 183, 234, 180, 2, 9, 224, 171, 68, 62, 170, 129, 248, 71, 251, 224, 143, 109, 246, 27, 26, 181, 14, 202, 111, 186, 130, 48, 32, 211, 14, 166, 72, 221, 91, 32, 135, 104, 191, 254, 103, 8, 173, 237, 34, 241, 34, 14, 29, 84, 24, 221, 28, 91, 120, 111, 62, 65, 35, 129, 51, 169, 165, 243, 97, 38, 244, 118, 128, 62, 210, 58, 53, 221, 250, 94, 176, 230, 231, 161, 93, 130, 50, 186, 157, 203, 165, 156, 121, 206, 184, 83, 127, 116, 66, 172, 121, 180, 36, 58, 87, 44, 155, 70, 216, 37, 45, 212, 116, 135, 15, 92, 225, 174, 207, 226, 138, 5, 240, 64, 252, 214, 145, 214, 191 } },
                    { 16, new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(6420), "Emma@mail.com", "Emma", "45", false, "Schoonkind", new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(6420), new byte[] { 125, 101, 252, 234, 71, 84, 133, 64, 244, 41, 73, 113, 120, 135, 76, 135, 226, 175, 225, 131, 113, 49, 240, 182, 82, 49, 248, 216, 48, 11, 213, 122, 109, 87, 41, 97, 83, 55, 162, 185, 14, 83, 172, 154, 49, 138, 176, 167, 22, 190, 155, 56, 0, 246, 103, 173, 81, 30, 247, 27, 25, 169, 36, 113 }, new byte[] { 234, 159, 203, 131, 183, 234, 180, 2, 9, 224, 171, 68, 62, 170, 129, 248, 71, 251, 224, 143, 109, 246, 27, 26, 181, 14, 202, 111, 186, 130, 48, 32, 211, 14, 166, 72, 221, 91, 32, 135, 104, 191, 254, 103, 8, 173, 237, 34, 241, 34, 14, 29, 84, 24, 221, 28, 91, 120, 111, 62, 65, 35, 129, 51, 169, 165, 243, 97, 38, 244, 118, 128, 62, 210, 58, 53, 221, 250, 94, 176, 230, 231, 161, 93, 130, 50, 186, 157, 203, 165, 156, 121, 206, 184, 83, 127, 116, 66, 172, 121, 180, 36, 58, 87, 44, 155, 70, 216, 37, 45, 212, 116, 135, 15, 92, 225, 174, 207, 226, 138, 5, 240, 64, 252, 214, 145, 214, 191 } },
                    { 15, new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(6405), "Anke@mail.com", "Anke", "27", false, "Kleurenkenner", new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(6405), new byte[] { 125, 101, 252, 234, 71, 84, 133, 64, 244, 41, 73, 113, 120, 135, 76, 135, 226, 175, 225, 131, 113, 49, 240, 182, 82, 49, 248, 216, 48, 11, 213, 122, 109, 87, 41, 97, 83, 55, 162, 185, 14, 83, 172, 154, 49, 138, 176, 167, 22, 190, 155, 56, 0, 246, 103, 173, 81, 30, 247, 27, 25, 169, 36, 113 }, new byte[] { 234, 159, 203, 131, 183, 234, 180, 2, 9, 224, 171, 68, 62, 170, 129, 248, 71, 251, 224, 143, 109, 246, 27, 26, 181, 14, 202, 111, 186, 130, 48, 32, 211, 14, 166, 72, 221, 91, 32, 135, 104, 191, 254, 103, 8, 173, 237, 34, 241, 34, 14, 29, 84, 24, 221, 28, 91, 120, 111, 62, 65, 35, 129, 51, 169, 165, 243, 97, 38, 244, 118, 128, 62, 210, 58, 53, 221, 250, 94, 176, 230, 231, 161, 93, 130, 50, 186, 157, 203, 165, 156, 121, 206, 184, 83, 127, 116, 66, 172, 121, 180, 36, 58, 87, 44, 155, 70, 216, 37, 45, 212, 116, 135, 15, 92, 225, 174, 207, 226, 138, 5, 240, 64, 252, 214, 145, 214, 191 } },
                    { 20, new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(6572), "Hoon@mail.com", "Hoon", "99", false, "Tomatenplukker", new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(6572), new byte[] { 125, 101, 252, 234, 71, 84, 133, 64, 244, 41, 73, 113, 120, 135, 76, 135, 226, 175, 225, 131, 113, 49, 240, 182, 82, 49, 248, 216, 48, 11, 213, 122, 109, 87, 41, 97, 83, 55, 162, 185, 14, 83, 172, 154, 49, 138, 176, 167, 22, 190, 155, 56, 0, 246, 103, 173, 81, 30, 247, 27, 25, 169, 36, 113 }, new byte[] { 234, 159, 203, 131, 183, 234, 180, 2, 9, 224, 171, 68, 62, 170, 129, 248, 71, 251, 224, 143, 109, 246, 27, 26, 181, 14, 202, 111, 186, 130, 48, 32, 211, 14, 166, 72, 221, 91, 32, 135, 104, 191, 254, 103, 8, 173, 237, 34, 241, 34, 14, 29, 84, 24, 221, 28, 91, 120, 111, 62, 65, 35, 129, 51, 169, 165, 243, 97, 38, 244, 118, 128, 62, 210, 58, 53, 221, 250, 94, 176, 230, 231, 161, 93, 130, 50, 186, 157, 203, 165, 156, 121, 206, 184, 83, 127, 116, 66, 172, 121, 180, 36, 58, 87, 44, 155, 70, 216, 37, 45, 212, 116, 135, 15, 92, 225, 174, 207, 226, 138, 5, 240, 64, 252, 214, 145, 214, 191 } },
                    { 14, new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(6390), "Marieke@mail.com", "Marieke", "T1", false, "Van Leren Broeke", new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(6390), new byte[] { 125, 101, 252, 234, 71, 84, 133, 64, 244, 41, 73, 113, 120, 135, 76, 135, 226, 175, 225, 131, 113, 49, 240, 182, 82, 49, 248, 216, 48, 11, 213, 122, 109, 87, 41, 97, 83, 55, 162, 185, 14, 83, 172, 154, 49, 138, 176, 167, 22, 190, 155, 56, 0, 246, 103, 173, 81, 30, 247, 27, 25, 169, 36, 113 }, new byte[] { 234, 159, 203, 131, 183, 234, 180, 2, 9, 224, 171, 68, 62, 170, 129, 248, 71, 251, 224, 143, 109, 246, 27, 26, 181, 14, 202, 111, 186, 130, 48, 32, 211, 14, 166, 72, 221, 91, 32, 135, 104, 191, 254, 103, 8, 173, 237, 34, 241, 34, 14, 29, 84, 24, 221, 28, 91, 120, 111, 62, 65, 35, 129, 51, 169, 165, 243, 97, 38, 244, 118, 128, 62, 210, 58, 53, 221, 250, 94, 176, 230, 231, 161, 93, 130, 50, 186, 157, 203, 165, 156, 121, 206, 184, 83, 127, 116, 66, 172, 121, 180, 36, 58, 87, 44, 155, 70, 216, 37, 45, 212, 116, 135, 15, 92, 225, 174, 207, 226, 138, 5, 240, 64, 252, 214, 145, 214, 191 } },
                    { 13, new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(6375), "Joyce@mail.com", "Joyce", "75", false, "Recruiter", new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(6375), new byte[] { 125, 101, 252, 234, 71, 84, 133, 64, 244, 41, 73, 113, 120, 135, 76, 135, 226, 175, 225, 131, 113, 49, 240, 182, 82, 49, 248, 216, 48, 11, 213, 122, 109, 87, 41, 97, 83, 55, 162, 185, 14, 83, 172, 154, 49, 138, 176, 167, 22, 190, 155, 56, 0, 246, 103, 173, 81, 30, 247, 27, 25, 169, 36, 113 }, new byte[] { 234, 159, 203, 131, 183, 234, 180, 2, 9, 224, 171, 68, 62, 170, 129, 248, 71, 251, 224, 143, 109, 246, 27, 26, 181, 14, 202, 111, 186, 130, 48, 32, 211, 14, 166, 72, 221, 91, 32, 135, 104, 191, 254, 103, 8, 173, 237, 34, 241, 34, 14, 29, 84, 24, 221, 28, 91, 120, 111, 62, 65, 35, 129, 51, 169, 165, 243, 97, 38, 244, 118, 128, 62, 210, 58, 53, 221, 250, 94, 176, 230, 231, 161, 93, 130, 50, 186, 157, 203, 165, 156, 121, 206, 184, 83, 127, 116, 66, 172, 121, 180, 36, 58, 87, 44, 155, 70, 216, 37, 45, 212, 116, 135, 15, 92, 225, 174, 207, 226, 138, 5, 240, 64, 252, 214, 145, 214, 191 } },
                    { 11, new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(6343), "Jens@mail.com", "Jens", "Zeemlap", false, "Spinning", new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(6343), new byte[] { 125, 101, 252, 234, 71, 84, 133, 64, 244, 41, 73, 113, 120, 135, 76, 135, 226, 175, 225, 131, 113, 49, 240, 182, 82, 49, 248, 216, 48, 11, 213, 122, 109, 87, 41, 97, 83, 55, 162, 185, 14, 83, 172, 154, 49, 138, 176, 167, 22, 190, 155, 56, 0, 246, 103, 173, 81, 30, 247, 27, 25, 169, 36, 113 }, new byte[] { 234, 159, 203, 131, 183, 234, 180, 2, 9, 224, 171, 68, 62, 170, 129, 248, 71, 251, 224, 143, 109, 246, 27, 26, 181, 14, 202, 111, 186, 130, 48, 32, 211, 14, 166, 72, 221, 91, 32, 135, 104, 191, 254, 103, 8, 173, 237, 34, 241, 34, 14, 29, 84, 24, 221, 28, 91, 120, 111, 62, 65, 35, 129, 51, 169, 165, 243, 97, 38, 244, 118, 128, 62, 210, 58, 53, 221, 250, 94, 176, 230, 231, 161, 93, 130, 50, 186, 157, 203, 165, 156, 121, 206, 184, 83, 127, 116, 66, 172, 121, 180, 36, 58, 87, 44, 155, 70, 216, 37, 45, 212, 116, 135, 15, 92, 225, 174, 207, 226, 138, 5, 240, 64, 252, 214, 145, 214, 191 } },
                    { 6, new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(6265), "Emma@mail.com", "Emma", "Stofzuiger", false, "Kipdorp", new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(6265), new byte[] { 125, 101, 252, 234, 71, 84, 133, 64, 244, 41, 73, 113, 120, 135, 76, 135, 226, 175, 225, 131, 113, 49, 240, 182, 82, 49, 248, 216, 48, 11, 213, 122, 109, 87, 41, 97, 83, 55, 162, 185, 14, 83, 172, 154, 49, 138, 176, 167, 22, 190, 155, 56, 0, 246, 103, 173, 81, 30, 247, 27, 25, 169, 36, 113 }, new byte[] { 234, 159, 203, 131, 183, 234, 180, 2, 9, 224, 171, 68, 62, 170, 129, 248, 71, 251, 224, 143, 109, 246, 27, 26, 181, 14, 202, 111, 186, 130, 48, 32, 211, 14, 166, 72, 221, 91, 32, 135, 104, 191, 254, 103, 8, 173, 237, 34, 241, 34, 14, 29, 84, 24, 221, 28, 91, 120, 111, 62, 65, 35, 129, 51, 169, 165, 243, 97, 38, 244, 118, 128, 62, 210, 58, 53, 221, 250, 94, 176, 230, 231, 161, 93, 130, 50, 186, 157, 203, 165, 156, 121, 206, 184, 83, 127, 116, 66, 172, 121, 180, 36, 58, 87, 44, 155, 70, 216, 37, 45, 212, 116, 135, 15, 92, 225, 174, 207, 226, 138, 5, 240, 64, 252, 214, 145, 214, 191 } },
                    { 9, new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(6312), "Michiel@mail.com", "Michiel", "g283?set=set4", false, "Demogod", new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(6312), new byte[] { 125, 101, 252, 234, 71, 84, 133, 64, 244, 41, 73, 113, 120, 135, 76, 135, 226, 175, 225, 131, 113, 49, 240, 182, 82, 49, 248, 216, 48, 11, 213, 122, 109, 87, 41, 97, 83, 55, 162, 185, 14, 83, 172, 154, 49, 138, 176, 167, 22, 190, 155, 56, 0, 246, 103, 173, 81, 30, 247, 27, 25, 169, 36, 113 }, new byte[] { 234, 159, 203, 131, 183, 234, 180, 2, 9, 224, 171, 68, 62, 170, 129, 248, 71, 251, 224, 143, 109, 246, 27, 26, 181, 14, 202, 111, 186, 130, 48, 32, 211, 14, 166, 72, 221, 91, 32, 135, 104, 191, 254, 103, 8, 173, 237, 34, 241, 34, 14, 29, 84, 24, 221, 28, 91, 120, 111, 62, 65, 35, 129, 51, 169, 165, 243, 97, 38, 244, 118, 128, 62, 210, 58, 53, 221, 250, 94, 176, 230, 231, 161, 93, 130, 50, 186, 157, 203, 165, 156, 121, 206, 184, 83, 127, 116, 66, 172, 121, 180, 36, 58, 87, 44, 155, 70, 216, 37, 45, 212, 116, 135, 15, 92, 225, 174, 207, 226, 138, 5, 240, 64, 252, 214, 145, 214, 191 } },
                    { 8, new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(6296), "Andreas@mail.com", "Andreas", "Andreas", false, "VanGrieken", new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(6296), new byte[] { 125, 101, 252, 234, 71, 84, 133, 64, 244, 41, 73, 113, 120, 135, 76, 135, 226, 175, 225, 131, 113, 49, 240, 182, 82, 49, 248, 216, 48, 11, 213, 122, 109, 87, 41, 97, 83, 55, 162, 185, 14, 83, 172, 154, 49, 138, 176, 167, 22, 190, 155, 56, 0, 246, 103, 173, 81, 30, 247, 27, 25, 169, 36, 113 }, new byte[] { 234, 159, 203, 131, 183, 234, 180, 2, 9, 224, 171, 68, 62, 170, 129, 248, 71, 251, 224, 143, 109, 246, 27, 26, 181, 14, 202, 111, 186, 130, 48, 32, 211, 14, 166, 72, 221, 91, 32, 135, 104, 191, 254, 103, 8, 173, 237, 34, 241, 34, 14, 29, 84, 24, 221, 28, 91, 120, 111, 62, 65, 35, 129, 51, 169, 165, 243, 97, 38, 244, 118, 128, 62, 210, 58, 53, 221, 250, 94, 176, 230, 231, 161, 93, 130, 50, 186, 157, 203, 165, 156, 121, 206, 184, 83, 127, 116, 66, 172, 121, 180, 36, 58, 87, 44, 155, 70, 216, 37, 45, 212, 116, 135, 15, 92, 225, 174, 207, 226, 138, 5, 240, 64, 252, 214, 145, 214, 191 } },
                    { 7, new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(6281), "Ward@mail.com", "Ward", "Dirk", false, "Motormouth", new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(6281), new byte[] { 125, 101, 252, 234, 71, 84, 133, 64, 244, 41, 73, 113, 120, 135, 76, 135, 226, 175, 225, 131, 113, 49, 240, 182, 82, 49, 248, 216, 48, 11, 213, 122, 109, 87, 41, 97, 83, 55, 162, 185, 14, 83, 172, 154, 49, 138, 176, 167, 22, 190, 155, 56, 0, 246, 103, 173, 81, 30, 247, 27, 25, 169, 36, 113 }, new byte[] { 234, 159, 203, 131, 183, 234, 180, 2, 9, 224, 171, 68, 62, 170, 129, 248, 71, 251, 224, 143, 109, 246, 27, 26, 181, 14, 202, 111, 186, 130, 48, 32, 211, 14, 166, 72, 221, 91, 32, 135, 104, 191, 254, 103, 8, 173, 237, 34, 241, 34, 14, 29, 84, 24, 221, 28, 91, 120, 111, 62, 65, 35, 129, 51, 169, 165, 243, 97, 38, 244, 118, 128, 62, 210, 58, 53, 221, 250, 94, 176, 230, 231, 161, 93, 130, 50, 186, 157, 203, 165, 156, 121, 206, 184, 83, 127, 116, 66, 172, 121, 180, 36, 58, 87, 44, 155, 70, 216, 37, 45, 212, 116, 135, 15, 92, 225, 174, 207, 226, 138, 5, 240, 64, 252, 214, 145, 214, 191 } },
                    { 5, new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(6250), "Seba@mail.com", "Seba", "BartjeWevertje", false, "Alwayszen", new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(6250), new byte[] { 125, 101, 252, 234, 71, 84, 133, 64, 244, 41, 73, 113, 120, 135, 76, 135, 226, 175, 225, 131, 113, 49, 240, 182, 82, 49, 248, 216, 48, 11, 213, 122, 109, 87, 41, 97, 83, 55, 162, 185, 14, 83, 172, 154, 49, 138, 176, 167, 22, 190, 155, 56, 0, 246, 103, 173, 81, 30, 247, 27, 25, 169, 36, 113 }, new byte[] { 234, 159, 203, 131, 183, 234, 180, 2, 9, 224, 171, 68, 62, 170, 129, 248, 71, 251, 224, 143, 109, 246, 27, 26, 181, 14, 202, 111, 186, 130, 48, 32, 211, 14, 166, 72, 221, 91, 32, 135, 104, 191, 254, 103, 8, 173, 237, 34, 241, 34, 14, 29, 84, 24, 221, 28, 91, 120, 111, 62, 65, 35, 129, 51, 169, 165, 243, 97, 38, 244, 118, 128, 62, 210, 58, 53, 221, 250, 94, 176, 230, 231, 161, 93, 130, 50, 186, 157, 203, 165, 156, 121, 206, 184, 83, 127, 116, 66, 172, 121, 180, 36, 58, 87, 44, 155, 70, 216, 37, 45, 212, 116, 135, 15, 92, 225, 174, 207, 226, 138, 5, 240, 64, 252, 214, 145, 214, 191 } },
                    { 4, new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(6231), "Dries@mail.be", "Dries", "Dries", true, "Promailer", new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(6231), new byte[] { 125, 101, 252, 234, 71, 84, 133, 64, 244, 41, 73, 113, 120, 135, 76, 135, 226, 175, 225, 131, 113, 49, 240, 182, 82, 49, 248, 216, 48, 11, 213, 122, 109, 87, 41, 97, 83, 55, 162, 185, 14, 83, 172, 154, 49, 138, 176, 167, 22, 190, 155, 56, 0, 246, 103, 173, 81, 30, 247, 27, 25, 169, 36, 113 }, new byte[] { 234, 159, 203, 131, 183, 234, 180, 2, 9, 224, 171, 68, 62, 170, 129, 248, 71, 251, 224, 143, 109, 246, 27, 26, 181, 14, 202, 111, 186, 130, 48, 32, 211, 14, 166, 72, 221, 91, 32, 135, 104, 191, 254, 103, 8, 173, 237, 34, 241, 34, 14, 29, 84, 24, 221, 28, 91, 120, 111, 62, 65, 35, 129, 51, 169, 165, 243, 97, 38, 244, 118, 128, 62, 210, 58, 53, 221, 250, 94, 176, 230, 231, 161, 93, 130, 50, 186, 157, 203, 165, 156, 121, 206, 184, 83, 127, 116, 66, 172, 121, 180, 36, 58, 87, 44, 155, 70, 216, 37, 45, 212, 116, 135, 15, 92, 225, 174, 207, 226, 138, 5, 240, 64, 252, 214, 145, 214, 191 } },
                    { 3, new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(6149), "Kobe@mail.com", "Kobe", "Kobe", true, "Neut", new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(6149), new byte[] { 125, 101, 252, 234, 71, 84, 133, 64, 244, 41, 73, 113, 120, 135, 76, 135, 226, 175, 225, 131, 113, 49, 240, 182, 82, 49, 248, 216, 48, 11, 213, 122, 109, 87, 41, 97, 83, 55, 162, 185, 14, 83, 172, 154, 49, 138, 176, 167, 22, 190, 155, 56, 0, 246, 103, 173, 81, 30, 247, 27, 25, 169, 36, 113 }, new byte[] { 234, 159, 203, 131, 183, 234, 180, 2, 9, 224, 171, 68, 62, 170, 129, 248, 71, 251, 224, 143, 109, 246, 27, 26, 181, 14, 202, 111, 186, 130, 48, 32, 211, 14, 166, 72, 221, 91, 32, 135, 104, 191, 254, 103, 8, 173, 237, 34, 241, 34, 14, 29, 84, 24, 221, 28, 91, 120, 111, 62, 65, 35, 129, 51, 169, 165, 243, 97, 38, 244, 118, 128, 62, 210, 58, 53, 221, 250, 94, 176, 230, 231, 161, 93, 130, 50, 186, 157, 203, 165, 156, 121, 206, 184, 83, 127, 116, 66, 172, 121, 180, 36, 58, 87, 44, 155, 70, 216, 37, 45, 212, 116, 135, 15, 92, 225, 174, 207, 226, 138, 5, 240, 64, 252, 214, 145, 214, 191 } },
                    { 2, new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(5947), "Nick@mail.com", "Nick", "Nick", true, "Angularlover", new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(5947), new byte[] { 125, 101, 252, 234, 71, 84, 133, 64, 244, 41, 73, 113, 120, 135, 76, 135, 226, 175, 225, 131, 113, 49, 240, 182, 82, 49, 248, 216, 48, 11, 213, 122, 109, 87, 41, 97, 83, 55, 162, 185, 14, 83, 172, 154, 49, 138, 176, 167, 22, 190, 155, 56, 0, 246, 103, 173, 81, 30, 247, 27, 25, 169, 36, 113 }, new byte[] { 234, 159, 203, 131, 183, 234, 180, 2, 9, 224, 171, 68, 62, 170, 129, 248, 71, 251, 224, 143, 109, 246, 27, 26, 181, 14, 202, 111, 186, 130, 48, 32, 211, 14, 166, 72, 221, 91, 32, 135, 104, 191, 254, 103, 8, 173, 237, 34, 241, 34, 14, 29, 84, 24, 221, 28, 91, 120, 111, 62, 65, 35, 129, 51, 169, 165, 243, 97, 38, 244, 118, 128, 62, 210, 58, 53, 221, 250, 94, 176, 230, 231, 161, 93, 130, 50, 186, 157, 203, 165, 156, 121, 206, 184, 83, 127, 116, 66, 172, 121, 180, 36, 58, 87, 44, 155, 70, 216, 37, 45, 212, 116, 135, 15, 92, 225, 174, 207, 226, 138, 5, 240, 64, 252, 214, 145, 214, 191 } },
                    { 1, new DateTime(2021, 5, 27, 11, 14, 6, 53, DateTimeKind.Local).AddTicks(7804), "Pieter@mail.com", "Pieter", "Pieter", true, "Slaapkop", new DateTime(2021, 5, 27, 11, 14, 6, 53, DateTimeKind.Local).AddTicks(7804), new byte[] { 125, 101, 252, 234, 71, 84, 133, 64, 244, 41, 73, 113, 120, 135, 76, 135, 226, 175, 225, 131, 113, 49, 240, 182, 82, 49, 248, 216, 48, 11, 213, 122, 109, 87, 41, 97, 83, 55, 162, 185, 14, 83, 172, 154, 49, 138, 176, 167, 22, 190, 155, 56, 0, 246, 103, 173, 81, 30, 247, 27, 25, 169, 36, 113 }, new byte[] { 234, 159, 203, 131, 183, 234, 180, 2, 9, 224, 171, 68, 62, 170, 129, 248, 71, 251, 224, 143, 109, 246, 27, 26, 181, 14, 202, 111, 186, 130, 48, 32, 211, 14, 166, 72, 221, 91, 32, 135, 104, 191, 254, 103, 8, 173, 237, 34, 241, 34, 14, 29, 84, 24, 221, 28, 91, 120, 111, 62, 65, 35, 129, 51, 169, 165, 243, 97, 38, 244, 118, 128, 62, 210, 58, 53, 221, 250, 94, 176, 230, 231, 161, 93, 130, 50, 186, 157, 203, 165, 156, 121, 206, 184, 83, 127, 116, 66, 172, 121, 180, 36, 58, 87, 44, 155, 70, 216, 37, 45, 212, 116, 135, 15, 92, 225, 174, 207, 226, 138, 5, 240, 64, 252, 214, 145, 214, 191 } },
                    { 21, new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(6590), "Michaël@mail.com", "Michaël", "25", false, "Wanderer", new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(6590), new byte[] { 125, 101, 252, 234, 71, 84, 133, 64, 244, 41, 73, 113, 120, 135, 76, 135, 226, 175, 225, 131, 113, 49, 240, 182, 82, 49, 248, 216, 48, 11, 213, 122, 109, 87, 41, 97, 83, 55, 162, 185, 14, 83, 172, 154, 49, 138, 176, 167, 22, 190, 155, 56, 0, 246, 103, 173, 81, 30, 247, 27, 25, 169, 36, 113 }, new byte[] { 234, 159, 203, 131, 183, 234, 180, 2, 9, 224, 171, 68, 62, 170, 129, 248, 71, 251, 224, 143, 109, 246, 27, 26, 181, 14, 202, 111, 186, 130, 48, 32, 211, 14, 166, 72, 221, 91, 32, 135, 104, 191, 254, 103, 8, 173, 237, 34, 241, 34, 14, 29, 84, 24, 221, 28, 91, 120, 111, 62, 65, 35, 129, 51, 169, 165, 243, 97, 38, 244, 118, 128, 62, 210, 58, 53, 221, 250, 94, 176, 230, 231, 161, 93, 130, 50, 186, 157, 203, 165, 156, 121, 206, 184, 83, 127, 116, 66, 172, 121, 180, 36, 58, 87, 44, 155, 70, 216, 37, 45, 212, 116, 135, 15, 92, 225, 174, 207, 226, 138, 5, 240, 64, 252, 214, 145, 214, 191 } },
                    { 10, new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(6328), "Diederik@mail.com", "Diederik", "Luc", false, "Featurefixer", new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(6328), new byte[] { 125, 101, 252, 234, 71, 84, 133, 64, 244, 41, 73, 113, 120, 135, 76, 135, 226, 175, 225, 131, 113, 49, 240, 182, 82, 49, 248, 216, 48, 11, 213, 122, 109, 87, 41, 97, 83, 55, 162, 185, 14, 83, 172, 154, 49, 138, 176, 167, 22, 190, 155, 56, 0, 246, 103, 173, 81, 30, 247, 27, 25, 169, 36, 113 }, new byte[] { 234, 159, 203, 131, 183, 234, 180, 2, 9, 224, 171, 68, 62, 170, 129, 248, 71, 251, 224, 143, 109, 246, 27, 26, 181, 14, 202, 111, 186, 130, 48, 32, 211, 14, 166, 72, 221, 91, 32, 135, 104, 191, 254, 103, 8, 173, 237, 34, 241, 34, 14, 29, 84, 24, 221, 28, 91, 120, 111, 62, 65, 35, 129, 51, 169, 165, 243, 97, 38, 244, 118, 128, 62, 210, 58, 53, 221, 250, 94, 176, 230, 231, 161, 93, 130, 50, 186, 157, 203, 165, 156, 121, 206, 184, 83, 127, 116, 66, 172, 121, 180, 36, 58, 87, 44, 155, 70, 216, 37, 45, 212, 116, 135, 15, 92, 225, 174, 207, 226, 138, 5, 240, 64, 252, 214, 145, 214, 191 } },
                    { 22, new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(6606), "Brent@mail.com", "Brent", "29", false, "Tomatentrucker", new DateTime(2021, 5, 27, 11, 14, 6, 57, DateTimeKind.Local).AddTicks(6606), new byte[] { 125, 101, 252, 234, 71, 84, 133, 64, 244, 41, 73, 113, 120, 135, 76, 135, 226, 175, 225, 131, 113, 49, 240, 182, 82, 49, 248, 216, 48, 11, 213, 122, 109, 87, 41, 97, 83, 55, 162, 185, 14, 83, 172, 154, 49, 138, 176, 167, 22, 190, 155, 56, 0, 246, 103, 173, 81, 30, 247, 27, 25, 169, 36, 113 }, new byte[] { 234, 159, 203, 131, 183, 234, 180, 2, 9, 224, 171, 68, 62, 170, 129, 248, 71, 251, 224, 143, 109, 246, 27, 26, 181, 14, 202, 111, 186, 130, 48, 32, 211, 14, 166, 72, 221, 91, 32, 135, 104, 191, 254, 103, 8, 173, 237, 34, 241, 34, 14, 29, 84, 24, 221, 28, 91, 120, 111, 62, 65, 35, 129, 51, 169, 165, 243, 97, 38, 244, 118, 128, 62, 210, 58, 53, 221, 250, 94, 176, 230, 231, 161, 93, 130, 50, 186, 157, 203, 165, 156, 121, 206, 184, 83, 127, 116, 66, 172, 121, 180, 36, 58, 87, 44, 155, 70, 216, 37, 45, 212, 116, 135, 15, 92, 225, 174, 207, 226, 138, 5, 240, 64, 252, 214, 145, 214, 191 } }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "PostalCode", "StreetName", "StreetNumber", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(2826), new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(2826), 9000, "Anti-Veggiestraat", 89, 1 },
                    { 10, new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5063), new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5063), 9070, "Geenpolitiekinhetprojectstraat", 200, 10 },
                    { 12, new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5069), new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5069), 1000, "Blacklivesmatterstraat", 78, 12 },
                    { 9, new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5060), new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5060), 2000, "Greenlivesmattertooweg", 420, 9 },
                    { 8, new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5056), new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5056), 1000, "Kotsvisplein", 96, 8 },
                    { 13, new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5071), new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5071), 7000, "Worstenbroodjesstraat", 4, 13 },
                    { 7, new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5053), new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5053), 9050, "Greenpeacestraat", 1, 7 },
                    { 14, new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5075), new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5075), 9000, "Jurgenzitverstoptachterhetlamgodsstraat", 24, 14 },
                    { 6, new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5050), new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5050), 1000, "Spekmeteierenstraat", 43, 6 },
                    { 5, new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5046), new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5046), 9000, "Boerenworststraat", 85, 5 },
                    { 15, new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5078), new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5078), 1081, "Bloedworststraat", 78, 15 },
                    { 4, new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5043), new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5043), 1000, "Vleesbroodstraat", 66, 4 },
                    { 16, new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5080), new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5080), 1180, "Gemarineerderunderlendedreef", 36, 16 },
                    { 17, new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5083), new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5083), 1500, "Ribbetjesstraat", 14, 17 },
                    { 3, new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5039), new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5039), 4000, "Balletjesintomatensausstraat", 74, 3 },
                    { 11, new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5066), new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5066), 9500, "Kalfslapjesstraat", 32, 11 },
                    { 19, new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5089), new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5089), 2323, "Lookbroodjesstraat", 11, 19 },
                    { 20, new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5091), new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5091), 2890, "Worstenbroodjesstraat", 79, 20 },
                    { 18, new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5086), new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5086), 2070, "Bickyburgerstraat", 15, 18 },
                    { 21, new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5094), new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5094), 3020, "Huisgemaaktekalfsbitterballetjesstraat", 100, 21 },
                    { 2, new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5023), new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5023), 3000, "Vrbaan", 45, 2 },
                    { 22, new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5097), new DateTime(2021, 5, 27, 11, 14, 6, 60, DateTimeKind.Local).AddTicks(5097), 3110, "Kalfsrib-eyelaan", 107, 22 }
                });

            migrationBuilder.InsertData(
                table: "TradeItems",
                columns: new[] { "Id", "Amount", "CreatedAt", "ModifiedAt", "ResourceId", "UserId" },
                values: new object[,]
                {
                    { 82, 52, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6777), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6777), 23, 21 },
                    { 54, 19, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6696), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6696), 12, 13 },
                    { 41, 17, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6659), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6659), 1, 11 },
                    { 53, 33, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6694), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6694), 35, 13 },
                    { 52, 22, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6691), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6691), 48, 13 },
                    { 51, 17, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6688), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6688), 47, 13 },
                    { 50, 17, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6685), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6685), 51, 13 },
                    { 80, 7, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6771), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6771), 17, 20 },
                    { 81, 13, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6774), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6774), 18, 20 },
                    { 49, 21, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6682), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6682), 12, 12 },
                    { 48, 17, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6679), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6679), 9, 12 },
                    { 55, 9, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6699), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6699), 7, 13 },
                    { 47, 34, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6676), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6676), 8, 12 },
                    { 46, 25, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6674), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6674), 47, 12 },
                    { 45, 12, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6671), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6671), 29, 12 },
                    { 42, 3, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6662), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6662), 3, 11 },
                    { 44, 78, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6668), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6668), 18, 12 },
                    { 43, 28, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6665), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6665), 7, 11 },
                    { 76, 80, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6760), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6760), 5, 17 },
                    { 57, 13, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6705), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6705), 29, 13 }
                });

            migrationBuilder.InsertData(
                table: "TradeItems",
                columns: new[] { "Id", "Amount", "CreatedAt", "ModifiedAt", "ResourceId", "UserId" },
                values: new object[,]
                {
                    { 75, 113, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6757), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6757), 3, 17 },
                    { 74, 78, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6754), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6754), 36, 16 },
                    { 73, 35, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6751), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6751), 38, 16 },
                    { 72, 24, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6748), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6748), 39, 16 },
                    { 77, 17, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6763), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6763), 6, 17 },
                    { 71, 1, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6745), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6745), 3, 15 },
                    { 70, 8, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6742), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6742), 51, 15 },
                    { 69, 153, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6740), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6740), 29, 15 },
                    { 68, 157, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6737), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6737), 22, 15 },
                    { 67, 19, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6734), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6734), 21, 15 },
                    { 56, 35, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6702), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6702), 8, 13 },
                    { 66, 78, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6731), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6731), 18, 15 },
                    { 65, 24, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6728), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6728), 17, 14 },
                    { 64, 88, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6725), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6725), 12, 14 },
                    { 83, 8, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6780), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6780), 26, 22 },
                    { 62, 39, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6720), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6720), 11, 14 },
                    { 61, 47, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6717), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6717), 8, 14 },
                    { 60, 19, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6714), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6714), 1, 14 },
                    { 79, 90, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6768), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6768), 44, 19 },
                    { 59, 17, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6711), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6711), 41, 13 },
                    { 58, 8, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6708), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6708), 38, 13 },
                    { 78, 99, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6766), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6766), 51, 19 },
                    { 63, 77, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6723), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6723), 9, 14 },
                    { 40, 33, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6656), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6656), 51, 11 },
                    { 39, 53, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6653), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6653), 19, 10 },
                    { 25, 5, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6564), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6564), 39, 6 },
                    { 24, 78, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6561), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6561), 32, 5 },
                    { 23, 38, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6558), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6558), 46, 5 },
                    { 22, 39, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6555), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6555), 17, 5 },
                    { 21, 63, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6553), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6553), 51, 5 },
                    { 20, 47, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6550), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6550), 7, 5 },
                    { 5, 41, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6506), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6506), 51, 2 },
                    { 19, 50, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6547), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6547), 51, 4 },
                    { 18, 36, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6544), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6544), 44, 4 },
                    { 17, 89, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6541), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6541), 21, 4 },
                    { 6, 30, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6510), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6510), 34, 2 },
                    { 16, 17, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6538), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6538), 31, 3 },
                    { 15, 30, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6536), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6536), 6, 3 },
                    { 7, 40, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6513), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6513), 46, 2 },
                    { 14, 49, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6533), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6533), 13, 3 },
                    { 13, 17, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6530), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6530), 8, 3 },
                    { 12, 20, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6527), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6527), 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "TradeItems",
                columns: new[] { "Id", "Amount", "CreatedAt", "ModifiedAt", "ResourceId", "UserId" },
                values: new object[,]
                {
                    { 11, 47, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6524), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6524), 51, 3 },
                    { 8, 5, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6516), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6516), 32, 2 },
                    { 10, 32, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6521), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6521), 15, 2 },
                    { 26, 10, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6567), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6567), 15, 6 },
                    { 9, 25, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6519), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6519), 39, 2 },
                    { 28, 10, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6573), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6573), 4, 6 },
                    { 33, 78, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6587), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6587), 6, 8 },
                    { 27, 12, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6570), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6570), 51, 6 },
                    { 35, 26, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6593), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6593), 51, 9 },
                    { 3, 12, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6500), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6500), 5, 1 },
                    { 36, 17, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6644), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6644), 14, 9 },
                    { 37, 69, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6648), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6648), 36, 9 },
                    { 34, 53, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6590), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6590), 51, 8 },
                    { 32, 38, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6584), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6584), 51, 7 },
                    { 30, 23, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6578), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6578), 13, 7 },
                    { 29, 19, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6576), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6576), 8, 7 },
                    { 1, 47, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(4923), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(4923), 1, 1 },
                    { 38, 34, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6650), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6650), 17, 10 },
                    { 4, 99, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6503), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6503), 7, 1 },
                    { 31, 36, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6581), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6581), 6, 7 },
                    { 2, 36, new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6484), new DateTime(2021, 5, 27, 11, 14, 6, 65, DateTimeKind.Local).AddTicks(6484), 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Trades",
                columns: new[] { "Id", "ActiveUserId", "Completed", "CreatedAt", "ModifiedAt", "ProposerId", "ReceiverId" },
                values: new object[,]
                {
                    { 2, 3, false, new DateTime(2021, 5, 27, 11, 14, 6, 63, DateTimeKind.Local).AddTicks(6213), new DateTime(2021, 5, 27, 11, 14, 6, 63, DateTimeKind.Local).AddTicks(6213), 3, 2 },
                    { 4, 1, false, new DateTime(2021, 5, 27, 11, 14, 6, 63, DateTimeKind.Local).AddTicks(6232), new DateTime(2021, 5, 27, 11, 14, 6, 63, DateTimeKind.Local).AddTicks(6232), 1, 8 },
                    { 6, 7, false, new DateTime(2021, 5, 27, 11, 14, 6, 63, DateTimeKind.Local).AddTicks(6238), new DateTime(2021, 5, 27, 11, 14, 6, 63, DateTimeKind.Local).AddTicks(6238), 7, 2 },
                    { 1, 1, false, new DateTime(2021, 5, 27, 11, 14, 6, 63, DateTimeKind.Local).AddTicks(4271), new DateTime(2021, 5, 27, 11, 14, 6, 63, DateTimeKind.Local).AddTicks(4271), 2, 1 },
                    { 5, 7, false, new DateTime(2021, 5, 27, 11, 14, 6, 63, DateTimeKind.Local).AddTicks(6235), new DateTime(2021, 5, 27, 11, 14, 6, 63, DateTimeKind.Local).AddTicks(6235), 4, 7 },
                    { 3, 6, false, new DateTime(2021, 5, 27, 11, 14, 6, 63, DateTimeKind.Local).AddTicks(6228), new DateTime(2021, 5, 27, 11, 14, 6, 63, DateTimeKind.Local).AddTicks(6228), 6, 8 }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "UserId", "VAmount" },
                values: new object[,]
                {
                    { 20, new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(6026), new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(6026), 20, 56m },
                    { 21, new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(6029), new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(6029), 21, 78m },
                    { 19, new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(6023), new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(6023), 19, 78m },
                    { 18, new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(6021), new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(6021), 18, 65m },
                    { 1, new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(4735), new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(4735), 1, 200m },
                    { 4, new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(5931), new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(5931), 4, 42m },
                    { 2, new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(5912), new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(5912), 2, 347m },
                    { 16, new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(6015), new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(6015), 16, 28m },
                    { 15, new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(6012), new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(6012), 15, 47m },
                    { 3, new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(5927), new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(5927), 3, 65m },
                    { 10, new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(5948), new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(5948), 10, 124m },
                    { 14, new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(6009), new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(6009), 14, 20m },
                    { 5, new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(5934), new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(5934), 5, 753m },
                    { 13, new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(6007), new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(6007), 13, 204m },
                    { 6, new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(5936), new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(5936), 6, 36m }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "UserId", "VAmount" },
                values: new object[,]
                {
                    { 7, new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(5939), new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(5939), 7, 12m },
                    { 12, new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(6004), new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(6004), 12, 57m },
                    { 8, new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(5942), new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(5942), 8, 654m },
                    { 11, new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(6001), new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(6001), 11, 269m },
                    { 9, new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(5945), new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(5945), 9, 357m },
                    { 17, new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(6018), new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(6018), 17, 104m },
                    { 22, new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(6031), new DateTime(2021, 5, 27, 11, 14, 6, 61, DateTimeKind.Local).AddTicks(6031), 22, 9m }
                });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "CreatedAt", "EuroAmount", "ModifiedAt", "VAmount", "WalletId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 27, 11, 14, 6, 66, DateTimeKind.Local).AddTicks(4269), 6.9m, new DateTime(2021, 5, 27, 11, 14, 6, 66, DateTimeKind.Local).AddTicks(4269), 69m, 1 },
                    { 7, new DateTime(2021, 5, 27, 11, 14, 6, 66, DateTimeKind.Local).AddTicks(6141), 9.8m, new DateTime(2021, 5, 27, 11, 14, 6, 66, DateTimeKind.Local).AddTicks(6141), 98m, 9 },
                    { 8, new DateTime(2021, 5, 27, 11, 14, 6, 66, DateTimeKind.Local).AddTicks(6144), 5m, new DateTime(2021, 5, 27, 11, 14, 6, 66, DateTimeKind.Local).AddTicks(6144), 50m, 7 },
                    { 6, new DateTime(2021, 5, 27, 11, 14, 6, 66, DateTimeKind.Local).AddTicks(6137), 7.8m, new DateTime(2021, 5, 27, 11, 14, 6, 66, DateTimeKind.Local).AddTicks(6137), 78m, 10 },
                    { 4, new DateTime(2021, 5, 27, 11, 14, 6, 66, DateTimeKind.Local).AddTicks(6131), 10m, new DateTime(2021, 5, 27, 11, 14, 6, 66, DateTimeKind.Local).AddTicks(6131), 100m, 6 },
                    { 3, new DateTime(2021, 5, 27, 11, 14, 6, 66, DateTimeKind.Local).AddTicks(6127), 42m, new DateTime(2021, 5, 27, 11, 14, 6, 66, DateTimeKind.Local).AddTicks(6127), 420m, 5 },
                    { 10, new DateTime(2021, 5, 27, 11, 14, 6, 66, DateTimeKind.Local).AddTicks(6150), 2m, new DateTime(2021, 5, 27, 11, 14, 6, 66, DateTimeKind.Local).AddTicks(6150), 20m, 4 },
                    { 9, new DateTime(2021, 5, 27, 11, 14, 6, 66, DateTimeKind.Local).AddTicks(6147), 13m, new DateTime(2021, 5, 27, 11, 14, 6, 66, DateTimeKind.Local).AddTicks(6147), 130m, 3 },
                    { 5, new DateTime(2021, 5, 27, 11, 14, 6, 66, DateTimeKind.Local).AddTicks(6134), 3.6m, new DateTime(2021, 5, 27, 11, 14, 6, 66, DateTimeKind.Local).AddTicks(6134), 36m, 12 },
                    { 2, new DateTime(2021, 5, 27, 11, 14, 6, 66, DateTimeKind.Local).AddTicks(6111), 2m, new DateTime(2021, 5, 27, 11, 14, 6, 66, DateTimeKind.Local).AddTicks(6111), 20m, 1 }
                });

            migrationBuilder.InsertData(
                table: "TradeItemProposals",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "ProposedAmount", "TradeId", "TradeItemId" },
                values: new object[,]
                {
                    { 8, new DateTime(2021, 5, 27, 11, 14, 6, 67, DateTimeKind.Local).AddTicks(5046), new DateTime(2021, 5, 27, 11, 14, 6, 67, DateTimeKind.Local).AddTicks(5046), 15, 2, 14 },
                    { 11, new DateTime(2021, 5, 27, 11, 14, 6, 67, DateTimeKind.Local).AddTicks(5055), new DateTime(2021, 5, 27, 11, 14, 6, 67, DateTimeKind.Local).AddTicks(5055), 5, 4, 34 },
                    { 9, new DateTime(2021, 5, 27, 11, 14, 6, 67, DateTimeKind.Local).AddTicks(5049), new DateTime(2021, 5, 27, 11, 14, 6, 67, DateTimeKind.Local).AddTicks(5049), 5, 3, 33 },
                    { 15, new DateTime(2021, 5, 27, 11, 14, 6, 67, DateTimeKind.Local).AddTicks(5066), new DateTime(2021, 5, 27, 11, 14, 6, 67, DateTimeKind.Local).AddTicks(5066), 5, 4, 4 },
                    { 14, new DateTime(2021, 5, 27, 11, 14, 6, 67, DateTimeKind.Local).AddTicks(5063), new DateTime(2021, 5, 27, 11, 14, 6, 67, DateTimeKind.Local).AddTicks(5063), 15, 4, 3 },
                    { 13, new DateTime(2021, 5, 27, 11, 14, 6, 67, DateTimeKind.Local).AddTicks(5061), new DateTime(2021, 5, 27, 11, 14, 6, 67, DateTimeKind.Local).AddTicks(5061), 5, 4, 2 },
                    { 12, new DateTime(2021, 5, 27, 11, 14, 6, 67, DateTimeKind.Local).AddTicks(5058), new DateTime(2021, 5, 27, 11, 14, 6, 67, DateTimeKind.Local).AddTicks(5058), 15, 4, 1 },
                    { 10, new DateTime(2021, 5, 27, 11, 14, 6, 67, DateTimeKind.Local).AddTicks(5052), new DateTime(2021, 5, 27, 11, 14, 6, 67, DateTimeKind.Local).AddTicks(5052), 15, 3, 28 },
                    { 7, new DateTime(2021, 5, 27, 11, 14, 6, 67, DateTimeKind.Local).AddTicks(5044), new DateTime(2021, 5, 27, 11, 14, 6, 67, DateTimeKind.Local).AddTicks(5044), 5, 2, 13 },
                    { 1, new DateTime(2021, 5, 27, 11, 14, 6, 67, DateTimeKind.Local).AddTicks(3445), new DateTime(2021, 5, 27, 11, 14, 6, 67, DateTimeKind.Local).AddTicks(3445), 5, 1, 1 },
                    { 20, new DateTime(2021, 5, 27, 11, 14, 6, 67, DateTimeKind.Local).AddTicks(5081), new DateTime(2021, 5, 27, 11, 14, 6, 67, DateTimeKind.Local).AddTicks(5081), 15, 6, 30 },
                    { 19, new DateTime(2021, 5, 27, 11, 14, 6, 67, DateTimeKind.Local).AddTicks(5078), new DateTime(2021, 5, 27, 11, 14, 6, 67, DateTimeKind.Local).AddTicks(5078), 1, 6, 5 },
                    { 18, new DateTime(2021, 5, 27, 11, 14, 6, 67, DateTimeKind.Local).AddTicks(5075), new DateTime(2021, 5, 27, 11, 14, 6, 67, DateTimeKind.Local).AddTicks(5075), 15, 5, 18 },
                    { 2, new DateTime(2021, 5, 27, 11, 14, 6, 67, DateTimeKind.Local).AddTicks(5014), new DateTime(2021, 5, 27, 11, 14, 6, 67, DateTimeKind.Local).AddTicks(5014), 15, 1, 2 },
                    { 3, new DateTime(2021, 5, 27, 11, 14, 6, 67, DateTimeKind.Local).AddTicks(5031), new DateTime(2021, 5, 27, 11, 14, 6, 67, DateTimeKind.Local).AddTicks(5031), 5, 1, 3 },
                    { 4, new DateTime(2021, 5, 27, 11, 14, 6, 67, DateTimeKind.Local).AddTicks(5034), new DateTime(2021, 5, 27, 11, 14, 6, 67, DateTimeKind.Local).AddTicks(5034), 5, 1, 5 },
                    { 5, new DateTime(2021, 5, 27, 11, 14, 6, 67, DateTimeKind.Local).AddTicks(5037), new DateTime(2021, 5, 27, 11, 14, 6, 67, DateTimeKind.Local).AddTicks(5037), 5, 2, 6 },
                    { 6, new DateTime(2021, 5, 27, 11, 14, 6, 67, DateTimeKind.Local).AddTicks(5040), new DateTime(2021, 5, 27, 11, 14, 6, 67, DateTimeKind.Local).AddTicks(5040), 15, 2, 7 },
                    { 16, new DateTime(2021, 5, 27, 11, 14, 6, 67, DateTimeKind.Local).AddTicks(5069), new DateTime(2021, 5, 27, 11, 14, 6, 67, DateTimeKind.Local).AddTicks(5069), 3, 5, 32 },
                    { 17, new DateTime(2021, 5, 27, 11, 14, 6, 67, DateTimeKind.Local).AddTicks(5072), new DateTime(2021, 5, 27, 11, 14, 6, 67, DateTimeKind.Local).AddTicks(5072), 5, 5, 17 }
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
