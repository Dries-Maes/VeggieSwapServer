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
                    { 1, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(6292), "apples.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(6292), "apples" },
                    { 29, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7519), "olives.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7519), "olives" },
                    { 30, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7522), "oranges.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7522), "oranges" },
                    { 31, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7526), "papayas.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7526), "papayas" },
                    { 32, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7529), "peaches.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7529), "peaches" },
                    { 33, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7532), "pears.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7532), "pears" },
                    { 34, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7535), "peas.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7535), "peas" },
                    { 35, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7538), "pineapples.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7538), "pineapples" },
                    { 36, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7541), "pomegranates.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7541), "pomegranates" },
                    { 38, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7547), "pumpkins.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7547), "pumpkins" },
                    { 39, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7553), "radish.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7553), "radish" },
                    { 28, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7516), "mushrooms.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7516), "mushrooms" },
                    { 40, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7556), "radishes.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7556), "radishes" },
                    { 42, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7562), "salad.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7562), "salad" },
                    { 43, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7565), "salads.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7565), "salads" },
                    { 44, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7650), "scallions.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7650), "scallions" },
                    { 45, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7655), "spinach.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7655), "spinach" },
                    { 46, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7658), "star-fruits.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7658), "star-fruits" },
                    { 47, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7661), "strawberries.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7661), "strawberries" },
                    { 48, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7665), "sweet-potatoes.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7665), "sweet-potatoes" },
                    { 49, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7668), "tomatoes.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7668), "tomatoes" },
                    { 50, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7671), "watermelons.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7671), "watermelons" },
                    { 51, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7675), "v-coin.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7675), "v-coin" },
                    { 41, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7559), "raspberries.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7559), "raspberries" },
                    { 27, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7513), "melons.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7513), "melons" },
                    { 37, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7544), "potatoes.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7544), "potatoes" },
                    { 25, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7507), "mangos.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7507), "mangos" },
                    { 2, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7419), "artichokes.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7419), "artichokes" },
                    { 26, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7510), "mangosteens.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7510), "mangosteens" },
                    { 4, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7438), "bananas.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7438), "bananas" },
                    { 5, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7442), "bell-peppers.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7442), "bell-peppers" },
                    { 6, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7445), "blueberries.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7445), "blueberries" },
                    { 7, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7448), "bok-choy.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7448), "bok-choy" },
                    { 8, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7451), "broccoli.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7451), "broccoli" },
                    { 9, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7454), "brussels-sprouts.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7454), "brussels-sprouts" },
                    { 10, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7457), "carrots.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7457), "carrots" },
                    { 11, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7461), "cherries.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7461), "cherries" },
                    { 12, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7464), "chilis.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7464), "chilis" },
                    { 13, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7467), "coconuts.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7467), "coconuts" },
                    { 3, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7434), "asparagus.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7434), "asparagus" },
                    { 15, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7473), "corn.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7473), "corn" },
                    { 14, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7470), "coriander.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7470), "coriander" }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreatedAt", "ImageUrl", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 23, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7500), "kiwis.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7500), "kiwis" },
                    { 22, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7497), "guavas.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7497), "guavas" },
                    { 21, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7493), "grapes.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7493), "grapes" },
                    { 20, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7489), "garlic.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7489), "garlic" },
                    { 24, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7504), "lemons.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7504), "lemons" },
                    { 18, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7483), "durians.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7483), "durians" },
                    { 17, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7480), "dragon-fruits.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7480), "dragon-fruits" },
                    { 16, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7476), "cucumbers.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7476), "cucumbers" },
                    { 19, new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7486), "eggplants.svg", new DateTime(2021, 5, 24, 15, 17, 54, 280, DateTimeKind.Local).AddTicks(7486), "eggplants" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "ImageUrl", "IsAdmin", "LastName", "ModifiedAt", "PasswordHash", "PasswordSalt" },
                values: new object[,]
                {
                    { 12, new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(5686), "Simon@mail.com", "Simon", "Dries2", false, "Lidllover", new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(5686), new byte[] { 248, 185, 174, 197, 234, 235, 67, 138, 244, 75, 213, 114, 150, 47, 46, 177, 209, 12, 79, 201, 220, 64, 15, 97, 27, 61, 108, 238, 215, 128, 85, 231, 194, 225, 128, 182, 119, 138, 184, 117, 119, 96, 25, 57, 104, 65, 206, 129, 173, 95, 195, 35, 176, 183, 197, 145, 59, 56, 204, 214, 149, 197, 179, 225 }, new byte[] { 212, 167, 142, 121, 208, 107, 254, 26, 252, 172, 130, 147, 224, 190, 200, 97, 65, 65, 81, 154, 46, 98, 121, 60, 33, 187, 232, 84, 233, 245, 255, 232, 15, 201, 58, 98, 242, 174, 16, 191, 189, 178, 246, 37, 3, 153, 15, 58, 37, 192, 232, 26, 170, 48, 46, 235, 34, 171, 122, 115, 19, 101, 190, 183, 72, 13, 70, 203, 43, 227, 114, 227, 171, 121, 34, 99, 18, 115, 15, 51, 15, 75, 90, 51, 141, 73, 162, 155, 116, 148, 43, 1, 171, 1, 51, 151, 83, 78, 168, 127, 176, 11, 39, 230, 19, 10, 186, 99, 69, 33, 36, 224, 33, 73, 222, 9, 160, 211, 32, 228, 66, 164, 150, 149, 14, 250, 132, 130 } },
                    { 19, new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(5893), "Karolien@mail.com", "Karolien", "78", false, "Vdabpolitie", new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(5893), new byte[] { 248, 185, 174, 197, 234, 235, 67, 138, 244, 75, 213, 114, 150, 47, 46, 177, 209, 12, 79, 201, 220, 64, 15, 97, 27, 61, 108, 238, 215, 128, 85, 231, 194, 225, 128, 182, 119, 138, 184, 117, 119, 96, 25, 57, 104, 65, 206, 129, 173, 95, 195, 35, 176, 183, 197, 145, 59, 56, 204, 214, 149, 197, 179, 225 }, new byte[] { 212, 167, 142, 121, 208, 107, 254, 26, 252, 172, 130, 147, 224, 190, 200, 97, 65, 65, 81, 154, 46, 98, 121, 60, 33, 187, 232, 84, 233, 245, 255, 232, 15, 201, 58, 98, 242, 174, 16, 191, 189, 178, 246, 37, 3, 153, 15, 58, 37, 192, 232, 26, 170, 48, 46, 235, 34, 171, 122, 115, 19, 101, 190, 183, 72, 13, 70, 203, 43, 227, 114, 227, 171, 121, 34, 99, 18, 115, 15, 51, 15, 75, 90, 51, 141, 73, 162, 155, 116, 148, 43, 1, 171, 1, 51, 151, 83, 78, 168, 127, 176, 11, 39, 230, 19, 10, 186, 99, 69, 33, 36, 224, 33, 73, 222, 9, 160, 211, 32, 228, 66, 164, 150, 149, 14, 250, 132, 130 } },
                    { 18, new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(5878), "Joke@mail.com", "Joke", "24", false, "LidlAnnoying", new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(5878), new byte[] { 248, 185, 174, 197, 234, 235, 67, 138, 244, 75, 213, 114, 150, 47, 46, 177, 209, 12, 79, 201, 220, 64, 15, 97, 27, 61, 108, 238, 215, 128, 85, 231, 194, 225, 128, 182, 119, 138, 184, 117, 119, 96, 25, 57, 104, 65, 206, 129, 173, 95, 195, 35, 176, 183, 197, 145, 59, 56, 204, 214, 149, 197, 179, 225 }, new byte[] { 212, 167, 142, 121, 208, 107, 254, 26, 252, 172, 130, 147, 224, 190, 200, 97, 65, 65, 81, 154, 46, 98, 121, 60, 33, 187, 232, 84, 233, 245, 255, 232, 15, 201, 58, 98, 242, 174, 16, 191, 189, 178, 246, 37, 3, 153, 15, 58, 37, 192, 232, 26, 170, 48, 46, 235, 34, 171, 122, 115, 19, 101, 190, 183, 72, 13, 70, 203, 43, 227, 114, 227, 171, 121, 34, 99, 18, 115, 15, 51, 15, 75, 90, 51, 141, 73, 162, 155, 116, 148, 43, 1, 171, 1, 51, 151, 83, 78, 168, 127, 176, 11, 39, 230, 19, 10, 186, 99, 69, 33, 36, 224, 33, 73, 222, 9, 160, 211, 32, 228, 66, 164, 150, 149, 14, 250, 132, 130 } },
                    { 17, new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(5859), "Sien@mail.com", "Sien", "57", false, "Rommeltje", new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(5859), new byte[] { 248, 185, 174, 197, 234, 235, 67, 138, 244, 75, 213, 114, 150, 47, 46, 177, 209, 12, 79, 201, 220, 64, 15, 97, 27, 61, 108, 238, 215, 128, 85, 231, 194, 225, 128, 182, 119, 138, 184, 117, 119, 96, 25, 57, 104, 65, 206, 129, 173, 95, 195, 35, 176, 183, 197, 145, 59, 56, 204, 214, 149, 197, 179, 225 }, new byte[] { 212, 167, 142, 121, 208, 107, 254, 26, 252, 172, 130, 147, 224, 190, 200, 97, 65, 65, 81, 154, 46, 98, 121, 60, 33, 187, 232, 84, 233, 245, 255, 232, 15, 201, 58, 98, 242, 174, 16, 191, 189, 178, 246, 37, 3, 153, 15, 58, 37, 192, 232, 26, 170, 48, 46, 235, 34, 171, 122, 115, 19, 101, 190, 183, 72, 13, 70, 203, 43, 227, 114, 227, 171, 121, 34, 99, 18, 115, 15, 51, 15, 75, 90, 51, 141, 73, 162, 155, 116, 148, 43, 1, 171, 1, 51, 151, 83, 78, 168, 127, 176, 11, 39, 230, 19, 10, 186, 99, 69, 33, 36, 224, 33, 73, 222, 9, 160, 211, 32, 228, 66, 164, 150, 149, 14, 250, 132, 130 } },
                    { 16, new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(5813), "Emma@mail.com", "Emma", "45", false, "Schoonkind", new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(5813), new byte[] { 248, 185, 174, 197, 234, 235, 67, 138, 244, 75, 213, 114, 150, 47, 46, 177, 209, 12, 79, 201, 220, 64, 15, 97, 27, 61, 108, 238, 215, 128, 85, 231, 194, 225, 128, 182, 119, 138, 184, 117, 119, 96, 25, 57, 104, 65, 206, 129, 173, 95, 195, 35, 176, 183, 197, 145, 59, 56, 204, 214, 149, 197, 179, 225 }, new byte[] { 212, 167, 142, 121, 208, 107, 254, 26, 252, 172, 130, 147, 224, 190, 200, 97, 65, 65, 81, 154, 46, 98, 121, 60, 33, 187, 232, 84, 233, 245, 255, 232, 15, 201, 58, 98, 242, 174, 16, 191, 189, 178, 246, 37, 3, 153, 15, 58, 37, 192, 232, 26, 170, 48, 46, 235, 34, 171, 122, 115, 19, 101, 190, 183, 72, 13, 70, 203, 43, 227, 114, 227, 171, 121, 34, 99, 18, 115, 15, 51, 15, 75, 90, 51, 141, 73, 162, 155, 116, 148, 43, 1, 171, 1, 51, 151, 83, 78, 168, 127, 176, 11, 39, 230, 19, 10, 186, 99, 69, 33, 36, 224, 33, 73, 222, 9, 160, 211, 32, 228, 66, 164, 150, 149, 14, 250, 132, 130 } },
                    { 15, new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(5754), "Anke@mail.com", "Anke", "27", false, "Van Kleurenkennere", new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(5754), new byte[] { 248, 185, 174, 197, 234, 235, 67, 138, 244, 75, 213, 114, 150, 47, 46, 177, 209, 12, 79, 201, 220, 64, 15, 97, 27, 61, 108, 238, 215, 128, 85, 231, 194, 225, 128, 182, 119, 138, 184, 117, 119, 96, 25, 57, 104, 65, 206, 129, 173, 95, 195, 35, 176, 183, 197, 145, 59, 56, 204, 214, 149, 197, 179, 225 }, new byte[] { 212, 167, 142, 121, 208, 107, 254, 26, 252, 172, 130, 147, 224, 190, 200, 97, 65, 65, 81, 154, 46, 98, 121, 60, 33, 187, 232, 84, 233, 245, 255, 232, 15, 201, 58, 98, 242, 174, 16, 191, 189, 178, 246, 37, 3, 153, 15, 58, 37, 192, 232, 26, 170, 48, 46, 235, 34, 171, 122, 115, 19, 101, 190, 183, 72, 13, 70, 203, 43, 227, 114, 227, 171, 121, 34, 99, 18, 115, 15, 51, 15, 75, 90, 51, 141, 73, 162, 155, 116, 148, 43, 1, 171, 1, 51, 151, 83, 78, 168, 127, 176, 11, 39, 230, 19, 10, 186, 99, 69, 33, 36, 224, 33, 73, 222, 9, 160, 211, 32, 228, 66, 164, 150, 149, 14, 250, 132, 130 } },
                    { 20, new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(5909), "Hoon@mail.com", "Hoon", "99", false, "Tomatenplukker", new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(5909), new byte[] { 248, 185, 174, 197, 234, 235, 67, 138, 244, 75, 213, 114, 150, 47, 46, 177, 209, 12, 79, 201, 220, 64, 15, 97, 27, 61, 108, 238, 215, 128, 85, 231, 194, 225, 128, 182, 119, 138, 184, 117, 119, 96, 25, 57, 104, 65, 206, 129, 173, 95, 195, 35, 176, 183, 197, 145, 59, 56, 204, 214, 149, 197, 179, 225 }, new byte[] { 212, 167, 142, 121, 208, 107, 254, 26, 252, 172, 130, 147, 224, 190, 200, 97, 65, 65, 81, 154, 46, 98, 121, 60, 33, 187, 232, 84, 233, 245, 255, 232, 15, 201, 58, 98, 242, 174, 16, 191, 189, 178, 246, 37, 3, 153, 15, 58, 37, 192, 232, 26, 170, 48, 46, 235, 34, 171, 122, 115, 19, 101, 190, 183, 72, 13, 70, 203, 43, 227, 114, 227, 171, 121, 34, 99, 18, 115, 15, 51, 15, 75, 90, 51, 141, 73, 162, 155, 116, 148, 43, 1, 171, 1, 51, 151, 83, 78, 168, 127, 176, 11, 39, 230, 19, 10, 186, 99, 69, 33, 36, 224, 33, 73, 222, 9, 160, 211, 32, 228, 66, 164, 150, 149, 14, 250, 132, 130 } },
                    { 14, new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(5730), "Marieke@mail.com", "Marieke", "T1", false, "Van Leren Broeke", new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(5730), new byte[] { 248, 185, 174, 197, 234, 235, 67, 138, 244, 75, 213, 114, 150, 47, 46, 177, 209, 12, 79, 201, 220, 64, 15, 97, 27, 61, 108, 238, 215, 128, 85, 231, 194, 225, 128, 182, 119, 138, 184, 117, 119, 96, 25, 57, 104, 65, 206, 129, 173, 95, 195, 35, 176, 183, 197, 145, 59, 56, 204, 214, 149, 197, 179, 225 }, new byte[] { 212, 167, 142, 121, 208, 107, 254, 26, 252, 172, 130, 147, 224, 190, 200, 97, 65, 65, 81, 154, 46, 98, 121, 60, 33, 187, 232, 84, 233, 245, 255, 232, 15, 201, 58, 98, 242, 174, 16, 191, 189, 178, 246, 37, 3, 153, 15, 58, 37, 192, 232, 26, 170, 48, 46, 235, 34, 171, 122, 115, 19, 101, 190, 183, 72, 13, 70, 203, 43, 227, 114, 227, 171, 121, 34, 99, 18, 115, 15, 51, 15, 75, 90, 51, 141, 73, 162, 155, 116, 148, 43, 1, 171, 1, 51, 151, 83, 78, 168, 127, 176, 11, 39, 230, 19, 10, 186, 99, 69, 33, 36, 224, 33, 73, 222, 9, 160, 211, 32, 228, 66, 164, 150, 149, 14, 250, 132, 130 } },
                    { 13, new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(5707), "Joyce@mail.com", "Joyce", "75", false, "Recruiter", new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(5707), new byte[] { 248, 185, 174, 197, 234, 235, 67, 138, 244, 75, 213, 114, 150, 47, 46, 177, 209, 12, 79, 201, 220, 64, 15, 97, 27, 61, 108, 238, 215, 128, 85, 231, 194, 225, 128, 182, 119, 138, 184, 117, 119, 96, 25, 57, 104, 65, 206, 129, 173, 95, 195, 35, 176, 183, 197, 145, 59, 56, 204, 214, 149, 197, 179, 225 }, new byte[] { 212, 167, 142, 121, 208, 107, 254, 26, 252, 172, 130, 147, 224, 190, 200, 97, 65, 65, 81, 154, 46, 98, 121, 60, 33, 187, 232, 84, 233, 245, 255, 232, 15, 201, 58, 98, 242, 174, 16, 191, 189, 178, 246, 37, 3, 153, 15, 58, 37, 192, 232, 26, 170, 48, 46, 235, 34, 171, 122, 115, 19, 101, 190, 183, 72, 13, 70, 203, 43, 227, 114, 227, 171, 121, 34, 99, 18, 115, 15, 51, 15, 75, 90, 51, 141, 73, 162, 155, 116, 148, 43, 1, 171, 1, 51, 151, 83, 78, 168, 127, 176, 11, 39, 230, 19, 10, 186, 99, 69, 33, 36, 224, 33, 73, 222, 9, 160, 211, 32, 228, 66, 164, 150, 149, 14, 250, 132, 130 } },
                    { 11, new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(5663), "Jens@mail.com", "Jens", "Zeemlap", false, "Spinning", new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(5663), new byte[] { 248, 185, 174, 197, 234, 235, 67, 138, 244, 75, 213, 114, 150, 47, 46, 177, 209, 12, 79, 201, 220, 64, 15, 97, 27, 61, 108, 238, 215, 128, 85, 231, 194, 225, 128, 182, 119, 138, 184, 117, 119, 96, 25, 57, 104, 65, 206, 129, 173, 95, 195, 35, 176, 183, 197, 145, 59, 56, 204, 214, 149, 197, 179, 225 }, new byte[] { 212, 167, 142, 121, 208, 107, 254, 26, 252, 172, 130, 147, 224, 190, 200, 97, 65, 65, 81, 154, 46, 98, 121, 60, 33, 187, 232, 84, 233, 245, 255, 232, 15, 201, 58, 98, 242, 174, 16, 191, 189, 178, 246, 37, 3, 153, 15, 58, 37, 192, 232, 26, 170, 48, 46, 235, 34, 171, 122, 115, 19, 101, 190, 183, 72, 13, 70, 203, 43, 227, 114, 227, 171, 121, 34, 99, 18, 115, 15, 51, 15, 75, 90, 51, 141, 73, 162, 155, 116, 148, 43, 1, 171, 1, 51, 151, 83, 78, 168, 127, 176, 11, 39, 230, 19, 10, 186, 99, 69, 33, 36, 224, 33, 73, 222, 9, 160, 211, 32, 228, 66, 164, 150, 149, 14, 250, 132, 130 } },
                    { 6, new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(5228), "Emma@mail.com", "Emma", "Stofzuiger", false, "Kipdorp", new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(5228), new byte[] { 248, 185, 174, 197, 234, 235, 67, 138, 244, 75, 213, 114, 150, 47, 46, 177, 209, 12, 79, 201, 220, 64, 15, 97, 27, 61, 108, 238, 215, 128, 85, 231, 194, 225, 128, 182, 119, 138, 184, 117, 119, 96, 25, 57, 104, 65, 206, 129, 173, 95, 195, 35, 176, 183, 197, 145, 59, 56, 204, 214, 149, 197, 179, 225 }, new byte[] { 212, 167, 142, 121, 208, 107, 254, 26, 252, 172, 130, 147, 224, 190, 200, 97, 65, 65, 81, 154, 46, 98, 121, 60, 33, 187, 232, 84, 233, 245, 255, 232, 15, 201, 58, 98, 242, 174, 16, 191, 189, 178, 246, 37, 3, 153, 15, 58, 37, 192, 232, 26, 170, 48, 46, 235, 34, 171, 122, 115, 19, 101, 190, 183, 72, 13, 70, 203, 43, 227, 114, 227, 171, 121, 34, 99, 18, 115, 15, 51, 15, 75, 90, 51, 141, 73, 162, 155, 116, 148, 43, 1, 171, 1, 51, 151, 83, 78, 168, 127, 176, 11, 39, 230, 19, 10, 186, 99, 69, 33, 36, 224, 33, 73, 222, 9, 160, 211, 32, 228, 66, 164, 150, 149, 14, 250, 132, 130 } },
                    { 9, new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(5619), "Michiel@mail.com", "Michiel", "Mihiel", false, "Demogod", new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(5619), new byte[] { 248, 185, 174, 197, 234, 235, 67, 138, 244, 75, 213, 114, 150, 47, 46, 177, 209, 12, 79, 201, 220, 64, 15, 97, 27, 61, 108, 238, 215, 128, 85, 231, 194, 225, 128, 182, 119, 138, 184, 117, 119, 96, 25, 57, 104, 65, 206, 129, 173, 95, 195, 35, 176, 183, 197, 145, 59, 56, 204, 214, 149, 197, 179, 225 }, new byte[] { 212, 167, 142, 121, 208, 107, 254, 26, 252, 172, 130, 147, 224, 190, 200, 97, 65, 65, 81, 154, 46, 98, 121, 60, 33, 187, 232, 84, 233, 245, 255, 232, 15, 201, 58, 98, 242, 174, 16, 191, 189, 178, 246, 37, 3, 153, 15, 58, 37, 192, 232, 26, 170, 48, 46, 235, 34, 171, 122, 115, 19, 101, 190, 183, 72, 13, 70, 203, 43, 227, 114, 227, 171, 121, 34, 99, 18, 115, 15, 51, 15, 75, 90, 51, 141, 73, 162, 155, 116, 148, 43, 1, 171, 1, 51, 151, 83, 78, 168, 127, 176, 11, 39, 230, 19, 10, 186, 99, 69, 33, 36, 224, 33, 73, 222, 9, 160, 211, 32, 228, 66, 164, 150, 149, 14, 250, 132, 130 } },
                    { 8, new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(5595), "Andreas@mail.com", "Andreas", "Andreas", false, "VanGrieken", new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(5595), new byte[] { 248, 185, 174, 197, 234, 235, 67, 138, 244, 75, 213, 114, 150, 47, 46, 177, 209, 12, 79, 201, 220, 64, 15, 97, 27, 61, 108, 238, 215, 128, 85, 231, 194, 225, 128, 182, 119, 138, 184, 117, 119, 96, 25, 57, 104, 65, 206, 129, 173, 95, 195, 35, 176, 183, 197, 145, 59, 56, 204, 214, 149, 197, 179, 225 }, new byte[] { 212, 167, 142, 121, 208, 107, 254, 26, 252, 172, 130, 147, 224, 190, 200, 97, 65, 65, 81, 154, 46, 98, 121, 60, 33, 187, 232, 84, 233, 245, 255, 232, 15, 201, 58, 98, 242, 174, 16, 191, 189, 178, 246, 37, 3, 153, 15, 58, 37, 192, 232, 26, 170, 48, 46, 235, 34, 171, 122, 115, 19, 101, 190, 183, 72, 13, 70, 203, 43, 227, 114, 227, 171, 121, 34, 99, 18, 115, 15, 51, 15, 75, 90, 51, 141, 73, 162, 155, 116, 148, 43, 1, 171, 1, 51, 151, 83, 78, 168, 127, 176, 11, 39, 230, 19, 10, 186, 99, 69, 33, 36, 224, 33, 73, 222, 9, 160, 211, 32, 228, 66, 164, 150, 149, 14, 250, 132, 130 } },
                    { 7, new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(5536), "Ward@mail.com", "Ward", "Dirk", false, "Zetdieplaataf", new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(5536), new byte[] { 248, 185, 174, 197, 234, 235, 67, 138, 244, 75, 213, 114, 150, 47, 46, 177, 209, 12, 79, 201, 220, 64, 15, 97, 27, 61, 108, 238, 215, 128, 85, 231, 194, 225, 128, 182, 119, 138, 184, 117, 119, 96, 25, 57, 104, 65, 206, 129, 173, 95, 195, 35, 176, 183, 197, 145, 59, 56, 204, 214, 149, 197, 179, 225 }, new byte[] { 212, 167, 142, 121, 208, 107, 254, 26, 252, 172, 130, 147, 224, 190, 200, 97, 65, 65, 81, 154, 46, 98, 121, 60, 33, 187, 232, 84, 233, 245, 255, 232, 15, 201, 58, 98, 242, 174, 16, 191, 189, 178, 246, 37, 3, 153, 15, 58, 37, 192, 232, 26, 170, 48, 46, 235, 34, 171, 122, 115, 19, 101, 190, 183, 72, 13, 70, 203, 43, 227, 114, 227, 171, 121, 34, 99, 18, 115, 15, 51, 15, 75, 90, 51, 141, 73, 162, 155, 116, 148, 43, 1, 171, 1, 51, 151, 83, 78, 168, 127, 176, 11, 39, 230, 19, 10, 186, 99, 69, 33, 36, 224, 33, 73, 222, 9, 160, 211, 32, 228, 66, 164, 150, 149, 14, 250, 132, 130 } },
                    { 5, new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(5211), "Seba@mail.com", "Seba", "BartjeWevertje", false, "Ergertzichnooit", new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(5211), new byte[] { 248, 185, 174, 197, 234, 235, 67, 138, 244, 75, 213, 114, 150, 47, 46, 177, 209, 12, 79, 201, 220, 64, 15, 97, 27, 61, 108, 238, 215, 128, 85, 231, 194, 225, 128, 182, 119, 138, 184, 117, 119, 96, 25, 57, 104, 65, 206, 129, 173, 95, 195, 35, 176, 183, 197, 145, 59, 56, 204, 214, 149, 197, 179, 225 }, new byte[] { 212, 167, 142, 121, 208, 107, 254, 26, 252, 172, 130, 147, 224, 190, 200, 97, 65, 65, 81, 154, 46, 98, 121, 60, 33, 187, 232, 84, 233, 245, 255, 232, 15, 201, 58, 98, 242, 174, 16, 191, 189, 178, 246, 37, 3, 153, 15, 58, 37, 192, 232, 26, 170, 48, 46, 235, 34, 171, 122, 115, 19, 101, 190, 183, 72, 13, 70, 203, 43, 227, 114, 227, 171, 121, 34, 99, 18, 115, 15, 51, 15, 75, 90, 51, 141, 73, 162, 155, 116, 148, 43, 1, 171, 1, 51, 151, 83, 78, 168, 127, 176, 11, 39, 230, 19, 10, 186, 99, 69, 33, 36, 224, 33, 73, 222, 9, 160, 211, 32, 228, 66, 164, 150, 149, 14, 250, 132, 130 } },
                    { 4, new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(5194), "Drieswilgraageenlangemail@mail.be", "Dries", "Dries", true, "Maileniseenkunst", new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(5194), new byte[] { 248, 185, 174, 197, 234, 235, 67, 138, 244, 75, 213, 114, 150, 47, 46, 177, 209, 12, 79, 201, 220, 64, 15, 97, 27, 61, 108, 238, 215, 128, 85, 231, 194, 225, 128, 182, 119, 138, 184, 117, 119, 96, 25, 57, 104, 65, 206, 129, 173, 95, 195, 35, 176, 183, 197, 145, 59, 56, 204, 214, 149, 197, 179, 225 }, new byte[] { 212, 167, 142, 121, 208, 107, 254, 26, 252, 172, 130, 147, 224, 190, 200, 97, 65, 65, 81, 154, 46, 98, 121, 60, 33, 187, 232, 84, 233, 245, 255, 232, 15, 201, 58, 98, 242, 174, 16, 191, 189, 178, 246, 37, 3, 153, 15, 58, 37, 192, 232, 26, 170, 48, 46, 235, 34, 171, 122, 115, 19, 101, 190, 183, 72, 13, 70, 203, 43, 227, 114, 227, 171, 121, 34, 99, 18, 115, 15, 51, 15, 75, 90, 51, 141, 73, 162, 155, 116, 148, 43, 1, 171, 1, 51, 151, 83, 78, 168, 127, 176, 11, 39, 230, 19, 10, 186, 99, 69, 33, 36, 224, 33, 73, 222, 9, 160, 211, 32, 228, 66, 164, 150, 149, 14, 250, 132, 130 } },
                    { 3, new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(5165), "Kobe@mail.com", "Kobe", "Kobe", true, "Neut", new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(5165), new byte[] { 248, 185, 174, 197, 234, 235, 67, 138, 244, 75, 213, 114, 150, 47, 46, 177, 209, 12, 79, 201, 220, 64, 15, 97, 27, 61, 108, 238, 215, 128, 85, 231, 194, 225, 128, 182, 119, 138, 184, 117, 119, 96, 25, 57, 104, 65, 206, 129, 173, 95, 195, 35, 176, 183, 197, 145, 59, 56, 204, 214, 149, 197, 179, 225 }, new byte[] { 212, 167, 142, 121, 208, 107, 254, 26, 252, 172, 130, 147, 224, 190, 200, 97, 65, 65, 81, 154, 46, 98, 121, 60, 33, 187, 232, 84, 233, 245, 255, 232, 15, 201, 58, 98, 242, 174, 16, 191, 189, 178, 246, 37, 3, 153, 15, 58, 37, 192, 232, 26, 170, 48, 46, 235, 34, 171, 122, 115, 19, 101, 190, 183, 72, 13, 70, 203, 43, 227, 114, 227, 171, 121, 34, 99, 18, 115, 15, 51, 15, 75, 90, 51, 141, 73, 162, 155, 116, 148, 43, 1, 171, 1, 51, 151, 83, 78, 168, 127, 176, 11, 39, 230, 19, 10, 186, 99, 69, 33, 36, 224, 33, 73, 222, 9, 160, 211, 32, 228, 66, 164, 150, 149, 14, 250, 132, 130 } },
                    { 2, new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(4665), "Nick@mail.com", "Nick", "Nick", true, "Angularlover", new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(4665), new byte[] { 248, 185, 174, 197, 234, 235, 67, 138, 244, 75, 213, 114, 150, 47, 46, 177, 209, 12, 79, 201, 220, 64, 15, 97, 27, 61, 108, 238, 215, 128, 85, 231, 194, 225, 128, 182, 119, 138, 184, 117, 119, 96, 25, 57, 104, 65, 206, 129, 173, 95, 195, 35, 176, 183, 197, 145, 59, 56, 204, 214, 149, 197, 179, 225 }, new byte[] { 212, 167, 142, 121, 208, 107, 254, 26, 252, 172, 130, 147, 224, 190, 200, 97, 65, 65, 81, 154, 46, 98, 121, 60, 33, 187, 232, 84, 233, 245, 255, 232, 15, 201, 58, 98, 242, 174, 16, 191, 189, 178, 246, 37, 3, 153, 15, 58, 37, 192, 232, 26, 170, 48, 46, 235, 34, 171, 122, 115, 19, 101, 190, 183, 72, 13, 70, 203, 43, 227, 114, 227, 171, 121, 34, 99, 18, 115, 15, 51, 15, 75, 90, 51, 141, 73, 162, 155, 116, 148, 43, 1, 171, 1, 51, 151, 83, 78, 168, 127, 176, 11, 39, 230, 19, 10, 186, 99, 69, 33, 36, 224, 33, 73, 222, 9, 160, 211, 32, 228, 66, 164, 150, 149, 14, 250, 132, 130 } },
                    { 1, new DateTime(2021, 5, 24, 15, 17, 54, 270, DateTimeKind.Local).AddTicks(9005), "Pieter@mail.com", "Pieter", "Pieter", true, "Slaapkop", new DateTime(2021, 5, 24, 15, 17, 54, 270, DateTimeKind.Local).AddTicks(9005), new byte[] { 248, 185, 174, 197, 234, 235, 67, 138, 244, 75, 213, 114, 150, 47, 46, 177, 209, 12, 79, 201, 220, 64, 15, 97, 27, 61, 108, 238, 215, 128, 85, 231, 194, 225, 128, 182, 119, 138, 184, 117, 119, 96, 25, 57, 104, 65, 206, 129, 173, 95, 195, 35, 176, 183, 197, 145, 59, 56, 204, 214, 149, 197, 179, 225 }, new byte[] { 212, 167, 142, 121, 208, 107, 254, 26, 252, 172, 130, 147, 224, 190, 200, 97, 65, 65, 81, 154, 46, 98, 121, 60, 33, 187, 232, 84, 233, 245, 255, 232, 15, 201, 58, 98, 242, 174, 16, 191, 189, 178, 246, 37, 3, 153, 15, 58, 37, 192, 232, 26, 170, 48, 46, 235, 34, 171, 122, 115, 19, 101, 190, 183, 72, 13, 70, 203, 43, 227, 114, 227, 171, 121, 34, 99, 18, 115, 15, 51, 15, 75, 90, 51, 141, 73, 162, 155, 116, 148, 43, 1, 171, 1, 51, 151, 83, 78, 168, 127, 176, 11, 39, 230, 19, 10, 186, 99, 69, 33, 36, 224, 33, 73, 222, 9, 160, 211, 32, 228, 66, 164, 150, 149, 14, 250, 132, 130 } },
                    { 21, new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(5925), "Michaël@mail.com", "Michaël", "25", false, "Wanderer", new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(5925), new byte[] { 248, 185, 174, 197, 234, 235, 67, 138, 244, 75, 213, 114, 150, 47, 46, 177, 209, 12, 79, 201, 220, 64, 15, 97, 27, 61, 108, 238, 215, 128, 85, 231, 194, 225, 128, 182, 119, 138, 184, 117, 119, 96, 25, 57, 104, 65, 206, 129, 173, 95, 195, 35, 176, 183, 197, 145, 59, 56, 204, 214, 149, 197, 179, 225 }, new byte[] { 212, 167, 142, 121, 208, 107, 254, 26, 252, 172, 130, 147, 224, 190, 200, 97, 65, 65, 81, 154, 46, 98, 121, 60, 33, 187, 232, 84, 233, 245, 255, 232, 15, 201, 58, 98, 242, 174, 16, 191, 189, 178, 246, 37, 3, 153, 15, 58, 37, 192, 232, 26, 170, 48, 46, 235, 34, 171, 122, 115, 19, 101, 190, 183, 72, 13, 70, 203, 43, 227, 114, 227, 171, 121, 34, 99, 18, 115, 15, 51, 15, 75, 90, 51, 141, 73, 162, 155, 116, 148, 43, 1, 171, 1, 51, 151, 83, 78, 168, 127, 176, 11, 39, 230, 19, 10, 186, 99, 69, 33, 36, 224, 33, 73, 222, 9, 160, 211, 32, 228, 66, 164, 150, 149, 14, 250, 132, 130 } },
                    { 10, new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(5641), "Diederik@mail.com", "Diederik", "Luc", false, "Van Lievegem", new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(5641), new byte[] { 248, 185, 174, 197, 234, 235, 67, 138, 244, 75, 213, 114, 150, 47, 46, 177, 209, 12, 79, 201, 220, 64, 15, 97, 27, 61, 108, 238, 215, 128, 85, 231, 194, 225, 128, 182, 119, 138, 184, 117, 119, 96, 25, 57, 104, 65, 206, 129, 173, 95, 195, 35, 176, 183, 197, 145, 59, 56, 204, 214, 149, 197, 179, 225 }, new byte[] { 212, 167, 142, 121, 208, 107, 254, 26, 252, 172, 130, 147, 224, 190, 200, 97, 65, 65, 81, 154, 46, 98, 121, 60, 33, 187, 232, 84, 233, 245, 255, 232, 15, 201, 58, 98, 242, 174, 16, 191, 189, 178, 246, 37, 3, 153, 15, 58, 37, 192, 232, 26, 170, 48, 46, 235, 34, 171, 122, 115, 19, 101, 190, 183, 72, 13, 70, 203, 43, 227, 114, 227, 171, 121, 34, 99, 18, 115, 15, 51, 15, 75, 90, 51, 141, 73, 162, 155, 116, 148, 43, 1, 171, 1, 51, 151, 83, 78, 168, 127, 176, 11, 39, 230, 19, 10, 186, 99, 69, 33, 36, 224, 33, 73, 222, 9, 160, 211, 32, 228, 66, 164, 150, 149, 14, 250, 132, 130 } },
                    { 22, new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(5940), "Brent@mail.com", "Brent", "29", false, "Tomatentrucker", new DateTime(2021, 5, 24, 15, 17, 54, 275, DateTimeKind.Local).AddTicks(5940), new byte[] { 248, 185, 174, 197, 234, 235, 67, 138, 244, 75, 213, 114, 150, 47, 46, 177, 209, 12, 79, 201, 220, 64, 15, 97, 27, 61, 108, 238, 215, 128, 85, 231, 194, 225, 128, 182, 119, 138, 184, 117, 119, 96, 25, 57, 104, 65, 206, 129, 173, 95, 195, 35, 176, 183, 197, 145, 59, 56, 204, 214, 149, 197, 179, 225 }, new byte[] { 212, 167, 142, 121, 208, 107, 254, 26, 252, 172, 130, 147, 224, 190, 200, 97, 65, 65, 81, 154, 46, 98, 121, 60, 33, 187, 232, 84, 233, 245, 255, 232, 15, 201, 58, 98, 242, 174, 16, 191, 189, 178, 246, 37, 3, 153, 15, 58, 37, 192, 232, 26, 170, 48, 46, 235, 34, 171, 122, 115, 19, 101, 190, 183, 72, 13, 70, 203, 43, 227, 114, 227, 171, 121, 34, 99, 18, 115, 15, 51, 15, 75, 90, 51, 141, 73, 162, 155, 116, 148, 43, 1, 171, 1, 51, 151, 83, 78, 168, 127, 176, 11, 39, 230, 19, 10, 186, 99, 69, 33, 36, 224, 33, 73, 222, 9, 160, 211, 32, 228, 66, 164, 150, 149, 14, 250, 132, 130 } }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "PostalCode", "StreetName", "StreetNumber", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(366), new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(366), 9000, "Anti-Veggiestraat", 89, 1 },
                    { 10, new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2440), new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2440), 9070, "Geenpolitiekinhetprojectstraat", 200, 10 },
                    { 12, new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2446), new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2446), 1000, "Blacklivesmatterstraat", 78, 12 },
                    { 9, new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2437), new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2437), 2000, "Greenlivesmattertooweg", 420, 9 },
                    { 8, new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2434), new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2434), 1000, "Kotsvisplein", 96, 8 },
                    { 13, new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2449), new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2449), 7000, "Worstenbroodjesstraat", 4, 13 },
                    { 7, new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2431), new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2431), 9050, "Greenpeacestraat", 1, 7 },
                    { 14, new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2452), new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2452), 9000, "Jurgenzitverstoptachterhetlamgodsstraat", 24, 14 },
                    { 6, new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2427), new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2427), 1000, "Spekmeteierenstraat", 43, 6 },
                    { 5, new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2424), new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2424), 9000, "Boerenworststraat", 85, 5 },
                    { 15, new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2455), new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2455), 1081, "Bloedworststraat", 78, 15 },
                    { 4, new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2421), new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2421), 1000, "Vleesbroodstraat", 66, 4 },
                    { 16, new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2458), new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2458), 1180, "Gemarineerderunderlendedreef", 36, 16 },
                    { 17, new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2462), new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2462), 1500, "Ribbetjesstraat", 14, 17 },
                    { 3, new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2417), new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2417), 4000, "Balletjesintomatensausstraat", 74, 3 },
                    { 11, new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2443), new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2443), 9500, "Kalfslapjesstraat", 32, 11 },
                    { 19, new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2468), new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2468), 2323, "Lookbroodjesstraat", 11, 19 },
                    { 20, new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2471), new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2471), 2890, "Worstenbroodjesstraat", 79, 20 },
                    { 18, new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2465), new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2465), 2070, "Bickyburgerstraat", 15, 18 },
                    { 21, new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2474), new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2474), 3020, "Huisgemaaktekalfsbitterballetjesstraat", 100, 21 },
                    { 2, new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2402), new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2402), 3000, "Vrbaan", 45, 2 },
                    { 22, new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2477), new DateTime(2021, 5, 24, 15, 17, 54, 278, DateTimeKind.Local).AddTicks(2477), 3110, "Kalfsrib-eyelaan", 107, 22 }
                });

            migrationBuilder.InsertData(
                table: "TradeItems",
                columns: new[] { "Id", "Amount", "CreatedAt", "ModifiedAt", "ResourceId", "UserId" },
                values: new object[,]
                {
                    { 82, 52, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6772), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6772), 23, 21 },
                    { 54, 19, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6591), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6591), 12, 13 },
                    { 41, 17, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6551), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6551), 1, 11 },
                    { 53, 33, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6588), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6588), 35, 13 },
                    { 52, 22, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6585), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6585), 48, 13 },
                    { 51, 17, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6583), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6583), 47, 13 },
                    { 50, 17, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6580), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6580), 51, 13 },
                    { 80, 7, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6765), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6765), 17, 20 },
                    { 81, 13, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6768), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6768), 18, 20 },
                    { 49, 21, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6577), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6577), 12, 12 },
                    { 48, 17, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6574), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6574), 9, 12 },
                    { 55, 9, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6594), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6594), 7, 13 },
                    { 47, 34, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6571), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6571), 8, 12 },
                    { 46, 25, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6568), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6568), 47, 12 },
                    { 45, 12, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6565), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6565), 29, 12 },
                    { 42, 3, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6557), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6557), 3, 11 },
                    { 44, 78, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6562), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6562), 18, 12 },
                    { 43, 28, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6560), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6560), 7, 11 },
                    { 76, 80, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6750), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6750), 5, 17 },
                    { 57, 13, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6695), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6695), 29, 13 }
                });

            migrationBuilder.InsertData(
                table: "TradeItems",
                columns: new[] { "Id", "Amount", "CreatedAt", "ModifiedAt", "ResourceId", "UserId" },
                values: new object[,]
                {
                    { 75, 113, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6747), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6747), 3, 17 },
                    { 74, 78, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6744), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6744), 36, 16 },
                    { 73, 35, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6741), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6741), 38, 16 },
                    { 72, 24, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6739), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6739), 39, 16 },
                    { 77, 17, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6753), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6753), 6, 17 },
                    { 71, 1, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6736), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6736), 3, 15 },
                    { 70, 8, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6732), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6732), 51, 15 },
                    { 69, 153, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6729), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6729), 29, 15 },
                    { 68, 157, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6726), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6726), 22, 15 },
                    { 67, 19, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6723), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6723), 21, 15 },
                    { 56, 35, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6691), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6691), 8, 13 },
                    { 66, 78, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6720), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6720), 18, 15 },
                    { 65, 24, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6718), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6718), 17, 14 },
                    { 64, 88, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6715), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6715), 12, 14 },
                    { 83, 8, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6777), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6777), 26, 22 },
                    { 62, 39, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6709), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6709), 11, 14 },
                    { 61, 47, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6706), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6706), 8, 14 },
                    { 60, 19, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6704), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6704), 1, 14 },
                    { 79, 90, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6758), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6758), 44, 19 },
                    { 59, 17, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6701), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6701), 41, 13 },
                    { 58, 8, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6698), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6698), 38, 13 },
                    { 78, 99, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6756), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6756), 51, 19 },
                    { 63, 77, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6712), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6712), 9, 14 },
                    { 40, 33, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6548), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6548), 51, 11 },
                    { 39, 53, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6545), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6545), 19, 10 },
                    { 25, 5, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6505), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6505), 39, 6 },
                    { 24, 78, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6502), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6502), 32, 5 },
                    { 23, 38, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6499), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6499), 46, 5 },
                    { 22, 39, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6496), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6496), 17, 5 },
                    { 21, 63, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6493), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6493), 51, 5 },
                    { 20, 47, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6491), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6491), 7, 5 },
                    { 5, 41, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6444), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6444), 51, 2 },
                    { 19, 50, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6488), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6488), 51, 4 },
                    { 18, 36, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6485), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6485), 44, 4 },
                    { 17, 89, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6482), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6482), 21, 4 },
                    { 6, 30, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6448), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6448), 34, 2 },
                    { 16, 17, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6479), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6479), 31, 3 },
                    { 15, 30, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6476), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6476), 6, 3 },
                    { 7, 40, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6451), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6451), 46, 2 },
                    { 14, 49, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6473), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6473), 13, 3 },
                    { 13, 17, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6469), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6469), 8, 3 },
                    { 12, 20, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6466), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6466), 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "TradeItems",
                columns: new[] { "Id", "Amount", "CreatedAt", "ModifiedAt", "ResourceId", "UserId" },
                values: new object[,]
                {
                    { 11, 47, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6463), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6463), 51, 3 },
                    { 8, 5, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6454), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6454), 32, 2 },
                    { 10, 32, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6460), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6460), 15, 2 },
                    { 26, 10, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6508), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6508), 15, 6 },
                    { 9, 25, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6457), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6457), 39, 2 },
                    { 28, 10, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6513), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6513), 4, 6 },
                    { 33, 78, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6527), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6527), 6, 8 },
                    { 27, 12, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6510), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6510), 51, 6 },
                    { 35, 26, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6533), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6533), 51, 9 },
                    { 3, 12, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6437), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6437), 5, 1 },
                    { 36, 17, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6536), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6536), 14, 9 },
                    { 37, 69, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6539), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6539), 36, 9 },
                    { 34, 53, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6530), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6530), 51, 8 },
                    { 32, 38, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6525), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6525), 51, 7 },
                    { 30, 23, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6519), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6519), 13, 7 },
                    { 29, 19, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6516), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6516), 8, 7 },
                    { 1, 47, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(4724), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(4724), 1, 1 },
                    { 38, 34, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6542), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6542), 17, 10 },
                    { 4, 99, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6440), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6440), 7, 1 },
                    { 31, 36, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6522), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6522), 6, 7 },
                    { 2, 36, new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6421), new DateTime(2021, 5, 24, 15, 17, 54, 283, DateTimeKind.Local).AddTicks(6421), 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Trades",
                columns: new[] { "Id", "ActiveUserId", "Completed", "CreatedAt", "ModifiedAt", "ProposerId", "ReceiverId" },
                values: new object[,]
                {
                    { 2, 3, false, new DateTime(2021, 5, 24, 15, 17, 54, 281, DateTimeKind.Local).AddTicks(4540), new DateTime(2021, 5, 24, 15, 17, 54, 281, DateTimeKind.Local).AddTicks(4540), 3, 2 },
                    { 4, 1, false, new DateTime(2021, 5, 24, 15, 17, 54, 281, DateTimeKind.Local).AddTicks(4558), new DateTime(2021, 5, 24, 15, 17, 54, 281, DateTimeKind.Local).AddTicks(4558), 1, 8 },
                    { 6, 7, false, new DateTime(2021, 5, 24, 15, 17, 54, 281, DateTimeKind.Local).AddTicks(4564), new DateTime(2021, 5, 24, 15, 17, 54, 281, DateTimeKind.Local).AddTicks(4564), 7, 2 },
                    { 1, 1, false, new DateTime(2021, 5, 24, 15, 17, 54, 281, DateTimeKind.Local).AddTicks(2445), new DateTime(2021, 5, 24, 15, 17, 54, 281, DateTimeKind.Local).AddTicks(2445), 2, 1 },
                    { 5, 7, false, new DateTime(2021, 5, 24, 15, 17, 54, 281, DateTimeKind.Local).AddTicks(4561), new DateTime(2021, 5, 24, 15, 17, 54, 281, DateTimeKind.Local).AddTicks(4561), 4, 7 },
                    { 3, 6, false, new DateTime(2021, 5, 24, 15, 17, 54, 281, DateTimeKind.Local).AddTicks(4555), new DateTime(2021, 5, 24, 15, 17, 54, 281, DateTimeKind.Local).AddTicks(4555), 6, 8 }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "UserId", "VAmount" },
                values: new object[,]
                {
                    { 20, new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2941), new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2941), 20, 56m },
                    { 21, new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2943), new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2943), 21, 78m },
                    { 19, new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2938), new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2938), 19, 78m },
                    { 18, new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2935), new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2935), 18, 65m },
                    { 1, new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(1567), new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(1567), 1, 200m },
                    { 4, new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2894), new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2894), 4, 42m },
                    { 2, new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2876), new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2876), 2, 347m },
                    { 16, new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2929), new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2929), 16, 28m },
                    { 15, new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2926), new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2926), 15, 47m },
                    { 3, new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2891), new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2891), 3, 65m },
                    { 10, new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2912), new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2912), 10, 124m },
                    { 14, new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2923), new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2923), 14, 20m },
                    { 5, new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2897), new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2897), 5, 753m },
                    { 13, new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2920), new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2920), 13, 204m },
                    { 6, new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2900), new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2900), 6, 36m }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "UserId", "VAmount" },
                values: new object[,]
                {
                    { 7, new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2903), new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2903), 7, 12m },
                    { 12, new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2917), new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2917), 12, 57m },
                    { 8, new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2906), new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2906), 8, 654m },
                    { 11, new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2915), new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2915), 11, 269m },
                    { 9, new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2909), new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2909), 9, 357m },
                    { 17, new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2932), new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2932), 17, 104m },
                    { 22, new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2946), new DateTime(2021, 5, 24, 15, 17, 54, 279, DateTimeKind.Local).AddTicks(2946), 22, 9m }
                });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "CreatedAt", "EuroAmount", "ModifiedAt", "VAmount", "WalletId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 24, 15, 17, 54, 284, DateTimeKind.Local).AddTicks(7146), 6.9m, new DateTime(2021, 5, 24, 15, 17, 54, 284, DateTimeKind.Local).AddTicks(7146), 69m, 1 },
                    { 7, new DateTime(2021, 5, 24, 15, 17, 54, 284, DateTimeKind.Local).AddTicks(9110), 9.8m, new DateTime(2021, 5, 24, 15, 17, 54, 284, DateTimeKind.Local).AddTicks(9110), 98m, 9 },
                    { 8, new DateTime(2021, 5, 24, 15, 17, 54, 284, DateTimeKind.Local).AddTicks(9113), 5m, new DateTime(2021, 5, 24, 15, 17, 54, 284, DateTimeKind.Local).AddTicks(9113), 50m, 7 },
                    { 6, new DateTime(2021, 5, 24, 15, 17, 54, 284, DateTimeKind.Local).AddTicks(9105), 7.8m, new DateTime(2021, 5, 24, 15, 17, 54, 284, DateTimeKind.Local).AddTicks(9105), 78m, 10 },
                    { 4, new DateTime(2021, 5, 24, 15, 17, 54, 284, DateTimeKind.Local).AddTicks(9099), 10m, new DateTime(2021, 5, 24, 15, 17, 54, 284, DateTimeKind.Local).AddTicks(9099), 100m, 6 },
                    { 3, new DateTime(2021, 5, 24, 15, 17, 54, 284, DateTimeKind.Local).AddTicks(9094), 42m, new DateTime(2021, 5, 24, 15, 17, 54, 284, DateTimeKind.Local).AddTicks(9094), 420m, 5 },
                    { 10, new DateTime(2021, 5, 24, 15, 17, 54, 284, DateTimeKind.Local).AddTicks(9119), 2m, new DateTime(2021, 5, 24, 15, 17, 54, 284, DateTimeKind.Local).AddTicks(9119), 20m, 4 },
                    { 9, new DateTime(2021, 5, 24, 15, 17, 54, 284, DateTimeKind.Local).AddTicks(9116), 13m, new DateTime(2021, 5, 24, 15, 17, 54, 284, DateTimeKind.Local).AddTicks(9116), 130m, 3 },
                    { 5, new DateTime(2021, 5, 24, 15, 17, 54, 284, DateTimeKind.Local).AddTicks(9102), 3.6m, new DateTime(2021, 5, 24, 15, 17, 54, 284, DateTimeKind.Local).AddTicks(9102), 36m, 12 },
                    { 2, new DateTime(2021, 5, 24, 15, 17, 54, 284, DateTimeKind.Local).AddTicks(9078), 2m, new DateTime(2021, 5, 24, 15, 17, 54, 284, DateTimeKind.Local).AddTicks(9078), 20m, 1 }
                });

            migrationBuilder.InsertData(
                table: "TradeItemProposals",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "ProposedAmount", "TradeId", "TradeItemId" },
                values: new object[,]
                {
                    { 8, new DateTime(2021, 5, 24, 15, 17, 54, 285, DateTimeKind.Local).AddTicks(8763), new DateTime(2021, 5, 24, 15, 17, 54, 285, DateTimeKind.Local).AddTicks(8763), 15, 2, 14 },
                    { 11, new DateTime(2021, 5, 24, 15, 17, 54, 285, DateTimeKind.Local).AddTicks(8771), new DateTime(2021, 5, 24, 15, 17, 54, 285, DateTimeKind.Local).AddTicks(8771), 5, 4, 34 },
                    { 9, new DateTime(2021, 5, 24, 15, 17, 54, 285, DateTimeKind.Local).AddTicks(8766), new DateTime(2021, 5, 24, 15, 17, 54, 285, DateTimeKind.Local).AddTicks(8766), 5, 3, 33 },
                    { 15, new DateTime(2021, 5, 24, 15, 17, 54, 285, DateTimeKind.Local).AddTicks(8783), new DateTime(2021, 5, 24, 15, 17, 54, 285, DateTimeKind.Local).AddTicks(8783), 5, 4, 4 },
                    { 14, new DateTime(2021, 5, 24, 15, 17, 54, 285, DateTimeKind.Local).AddTicks(8780), new DateTime(2021, 5, 24, 15, 17, 54, 285, DateTimeKind.Local).AddTicks(8780), 15, 4, 3 },
                    { 13, new DateTime(2021, 5, 24, 15, 17, 54, 285, DateTimeKind.Local).AddTicks(8777), new DateTime(2021, 5, 24, 15, 17, 54, 285, DateTimeKind.Local).AddTicks(8777), 5, 4, 2 },
                    { 12, new DateTime(2021, 5, 24, 15, 17, 54, 285, DateTimeKind.Local).AddTicks(8774), new DateTime(2021, 5, 24, 15, 17, 54, 285, DateTimeKind.Local).AddTicks(8774), 15, 4, 1 },
                    { 10, new DateTime(2021, 5, 24, 15, 17, 54, 285, DateTimeKind.Local).AddTicks(8769), new DateTime(2021, 5, 24, 15, 17, 54, 285, DateTimeKind.Local).AddTicks(8769), 15, 3, 28 },
                    { 7, new DateTime(2021, 5, 24, 15, 17, 54, 285, DateTimeKind.Local).AddTicks(8760), new DateTime(2021, 5, 24, 15, 17, 54, 285, DateTimeKind.Local).AddTicks(8760), 5, 2, 13 },
                    { 1, new DateTime(2021, 5, 24, 15, 17, 54, 285, DateTimeKind.Local).AddTicks(7177), new DateTime(2021, 5, 24, 15, 17, 54, 285, DateTimeKind.Local).AddTicks(7177), 5, 1, 1 },
                    { 20, new DateTime(2021, 5, 24, 15, 17, 54, 285, DateTimeKind.Local).AddTicks(8798), new DateTime(2021, 5, 24, 15, 17, 54, 285, DateTimeKind.Local).AddTicks(8798), 15, 6, 30 },
                    { 19, new DateTime(2021, 5, 24, 15, 17, 54, 285, DateTimeKind.Local).AddTicks(8795), new DateTime(2021, 5, 24, 15, 17, 54, 285, DateTimeKind.Local).AddTicks(8795), 1, 6, 5 },
                    { 18, new DateTime(2021, 5, 24, 15, 17, 54, 285, DateTimeKind.Local).AddTicks(8792), new DateTime(2021, 5, 24, 15, 17, 54, 285, DateTimeKind.Local).AddTicks(8792), 15, 5, 18 },
                    { 2, new DateTime(2021, 5, 24, 15, 17, 54, 285, DateTimeKind.Local).AddTicks(8734), new DateTime(2021, 5, 24, 15, 17, 54, 285, DateTimeKind.Local).AddTicks(8734), 15, 1, 2 },
                    { 3, new DateTime(2021, 5, 24, 15, 17, 54, 285, DateTimeKind.Local).AddTicks(8748), new DateTime(2021, 5, 24, 15, 17, 54, 285, DateTimeKind.Local).AddTicks(8748), 5, 1, 3 },
                    { 4, new DateTime(2021, 5, 24, 15, 17, 54, 285, DateTimeKind.Local).AddTicks(8751), new DateTime(2021, 5, 24, 15, 17, 54, 285, DateTimeKind.Local).AddTicks(8751), 5, 1, 5 },
                    { 5, new DateTime(2021, 5, 24, 15, 17, 54, 285, DateTimeKind.Local).AddTicks(8754), new DateTime(2021, 5, 24, 15, 17, 54, 285, DateTimeKind.Local).AddTicks(8754), 5, 2, 6 },
                    { 6, new DateTime(2021, 5, 24, 15, 17, 54, 285, DateTimeKind.Local).AddTicks(8757), new DateTime(2021, 5, 24, 15, 17, 54, 285, DateTimeKind.Local).AddTicks(8757), 15, 2, 7 },
                    { 16, new DateTime(2021, 5, 24, 15, 17, 54, 285, DateTimeKind.Local).AddTicks(8786), new DateTime(2021, 5, 24, 15, 17, 54, 285, DateTimeKind.Local).AddTicks(8786), 3, 5, 32 },
                    { 17, new DateTime(2021, 5, 24, 15, 17, 54, 285, DateTimeKind.Local).AddTicks(8789), new DateTime(2021, 5, 24, 15, 17, 54, 285, DateTimeKind.Local).AddTicks(8789), 5, 5, 17 }
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
