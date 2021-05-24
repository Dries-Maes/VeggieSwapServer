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
                    { 1, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(1118), "apples.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(1118), "apples" },
                    { 29, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3226), "olives.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3226), "olives" },
                    { 30, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3231), "oranges.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3231), "oranges" },
                    { 31, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3236), "papayas.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3236), "papayas" },
                    { 32, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3244), "peaches.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3244), "peaches" },
                    { 33, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3249), "pears.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3249), "pears" },
                    { 34, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3254), "peas.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3254), "peas" },
                    { 35, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3259), "pineapples.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3259), "pineapples" },
                    { 36, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3264), "pomegranates.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3264), "pomegranates" },
                    { 38, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3276), "pumpkins.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3276), "pumpkins" },
                    { 39, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3283), "radish.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3283), "radish" },
                    { 28, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3221), "mushrooms.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3221), "mushrooms" },
                    { 40, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3288), "radishes.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3288), "radishes" },
                    { 42, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3298), "salad.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3298), "salad" },
                    { 43, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3303), "salads.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3303), "salads" },
                    { 44, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3308), "scallions.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3308), "scallions" },
                    { 45, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3313), "spinach.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3313), "spinach" },
                    { 46, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3318), "star-fruits.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3318), "star-fruits" },
                    { 47, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3323), "strawberries.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3323), "strawberries" },
                    { 48, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3328), "sweet-potatoes.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3328), "sweet-potatoes" },
                    { 49, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3333), "tomatoes.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3333), "tomatoes" },
                    { 50, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3339), "watermelons.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3339), "watermelons" },
                    { 51, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3445), "v-coin.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3445), "v-coin" },
                    { 41, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3293), "raspberries.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3293), "raspberries" },
                    { 27, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3216), "melons.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3216), "melons" },
                    { 37, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3270), "potatoes.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3270), "potatoes" },
                    { 25, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3206), "mangos.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3206), "mangos" },
                    { 2, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3063), "artichokes.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3063), "artichokes" },
                    { 26, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3211), "mangosteens.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3211), "mangosteens" },
                    { 4, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3093), "bananas.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3093), "bananas" },
                    { 5, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3099), "bell-peppers.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3099), "bell-peppers" },
                    { 6, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3104), "blueberries.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3104), "blueberries" },
                    { 7, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3109), "bok-choy.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3109), "bok-choy" },
                    { 8, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3114), "broccoli.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3114), "broccoli" },
                    { 9, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3119), "brussels-sprouts.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3119), "brussels-sprouts" },
                    { 10, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3125), "carrots.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3125), "carrots" },
                    { 11, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3130), "cherries.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3130), "cherries" },
                    { 12, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3135), "chilis.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3135), "chilis" },
                    { 13, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3140), "coconuts.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3140), "coconuts" },
                    { 3, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3088), "asparagus.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3088), "asparagus" },
                    { 15, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3151), "corn.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3151), "corn" },
                    { 14, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3145), "coriander.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3145), "coriander" }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreatedAt", "ImageUrl", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 23, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3196), "kiwis.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3196), "kiwis" },
                    { 22, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3191), "guavas.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3191), "guavas" },
                    { 21, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3186), "grapes.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3186), "grapes" },
                    { 20, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3176), "garlic.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3176), "garlic" },
                    { 24, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3201), "lemons.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3201), "lemons" },
                    { 18, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3166), "durians.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3166), "durians" },
                    { 17, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3161), "dragon-fruits.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3161), "dragon-fruits" },
                    { 16, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3156), "cucumbers.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3156), "cucumbers" },
                    { 19, new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3171), "eggplants.svg", new DateTime(2021, 5, 24, 15, 42, 34, 794, DateTimeKind.Local).AddTicks(3171), "eggplants" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "ImageUrl", "IsAdmin", "LastName", "ModifiedAt", "PasswordHash", "PasswordSalt" },
                values: new object[,]
                {
                    { 12, new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(9176), "Simon@mail.com", "Simon", "Dries2", false, "Lidllover", new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(9176), new byte[] { 234, 111, 93, 30, 191, 243, 71, 99, 53, 19, 202, 0, 155, 20, 71, 63, 166, 121, 79, 62, 221, 158, 181, 101, 59, 96, 27, 172, 99, 30, 151, 91, 134, 56, 14, 154, 142, 171, 137, 29, 120, 22, 41, 73, 231, 6, 0, 8, 144, 50, 149, 157, 47, 51, 198, 196, 171, 76, 34, 159, 255, 206, 175, 115 }, new byte[] { 172, 226, 182, 29, 237, 223, 206, 96, 173, 42, 24, 218, 208, 37, 96, 165, 112, 114, 235, 245, 208, 92, 229, 105, 10, 10, 68, 233, 66, 169, 42, 86, 62, 67, 63, 185, 164, 138, 7, 150, 120, 159, 90, 137, 9, 90, 11, 231, 118, 90, 65, 87, 152, 128, 42, 180, 118, 73, 42, 65, 23, 200, 107, 221, 104, 193, 132, 89, 78, 85, 182, 86, 65, 25, 149, 102, 60, 236, 160, 164, 207, 95, 70, 250, 14, 3, 5, 24, 12, 29, 207, 221, 15, 35, 215, 159, 255, 45, 174, 111, 37, 69, 53, 75, 97, 59, 227, 243, 155, 247, 14, 95, 74, 88, 63, 155, 115, 52, 168, 199, 12, 71, 65, 226, 85, 117, 131, 158 } },
                    { 19, new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(9284), "Karolien@mail.com", "Karolien", "78", false, "Vdabpolitie", new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(9284), new byte[] { 234, 111, 93, 30, 191, 243, 71, 99, 53, 19, 202, 0, 155, 20, 71, 63, 166, 121, 79, 62, 221, 158, 181, 101, 59, 96, 27, 172, 99, 30, 151, 91, 134, 56, 14, 154, 142, 171, 137, 29, 120, 22, 41, 73, 231, 6, 0, 8, 144, 50, 149, 157, 47, 51, 198, 196, 171, 76, 34, 159, 255, 206, 175, 115 }, new byte[] { 172, 226, 182, 29, 237, 223, 206, 96, 173, 42, 24, 218, 208, 37, 96, 165, 112, 114, 235, 245, 208, 92, 229, 105, 10, 10, 68, 233, 66, 169, 42, 86, 62, 67, 63, 185, 164, 138, 7, 150, 120, 159, 90, 137, 9, 90, 11, 231, 118, 90, 65, 87, 152, 128, 42, 180, 118, 73, 42, 65, 23, 200, 107, 221, 104, 193, 132, 89, 78, 85, 182, 86, 65, 25, 149, 102, 60, 236, 160, 164, 207, 95, 70, 250, 14, 3, 5, 24, 12, 29, 207, 221, 15, 35, 215, 159, 255, 45, 174, 111, 37, 69, 53, 75, 97, 59, 227, 243, 155, 247, 14, 95, 74, 88, 63, 155, 115, 52, 168, 199, 12, 71, 65, 226, 85, 117, 131, 158 } },
                    { 18, new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(9269), "Joke@mail.com", "Joke", "24", false, "LidlAnnoying", new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(9269), new byte[] { 234, 111, 93, 30, 191, 243, 71, 99, 53, 19, 202, 0, 155, 20, 71, 63, 166, 121, 79, 62, 221, 158, 181, 101, 59, 96, 27, 172, 99, 30, 151, 91, 134, 56, 14, 154, 142, 171, 137, 29, 120, 22, 41, 73, 231, 6, 0, 8, 144, 50, 149, 157, 47, 51, 198, 196, 171, 76, 34, 159, 255, 206, 175, 115 }, new byte[] { 172, 226, 182, 29, 237, 223, 206, 96, 173, 42, 24, 218, 208, 37, 96, 165, 112, 114, 235, 245, 208, 92, 229, 105, 10, 10, 68, 233, 66, 169, 42, 86, 62, 67, 63, 185, 164, 138, 7, 150, 120, 159, 90, 137, 9, 90, 11, 231, 118, 90, 65, 87, 152, 128, 42, 180, 118, 73, 42, 65, 23, 200, 107, 221, 104, 193, 132, 89, 78, 85, 182, 86, 65, 25, 149, 102, 60, 236, 160, 164, 207, 95, 70, 250, 14, 3, 5, 24, 12, 29, 207, 221, 15, 35, 215, 159, 255, 45, 174, 111, 37, 69, 53, 75, 97, 59, 227, 243, 155, 247, 14, 95, 74, 88, 63, 155, 115, 52, 168, 199, 12, 71, 65, 226, 85, 117, 131, 158 } },
                    { 17, new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(9254), "Sien@mail.com", "Sien", "57", false, "Rommeltje", new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(9254), new byte[] { 234, 111, 93, 30, 191, 243, 71, 99, 53, 19, 202, 0, 155, 20, 71, 63, 166, 121, 79, 62, 221, 158, 181, 101, 59, 96, 27, 172, 99, 30, 151, 91, 134, 56, 14, 154, 142, 171, 137, 29, 120, 22, 41, 73, 231, 6, 0, 8, 144, 50, 149, 157, 47, 51, 198, 196, 171, 76, 34, 159, 255, 206, 175, 115 }, new byte[] { 172, 226, 182, 29, 237, 223, 206, 96, 173, 42, 24, 218, 208, 37, 96, 165, 112, 114, 235, 245, 208, 92, 229, 105, 10, 10, 68, 233, 66, 169, 42, 86, 62, 67, 63, 185, 164, 138, 7, 150, 120, 159, 90, 137, 9, 90, 11, 231, 118, 90, 65, 87, 152, 128, 42, 180, 118, 73, 42, 65, 23, 200, 107, 221, 104, 193, 132, 89, 78, 85, 182, 86, 65, 25, 149, 102, 60, 236, 160, 164, 207, 95, 70, 250, 14, 3, 5, 24, 12, 29, 207, 221, 15, 35, 215, 159, 255, 45, 174, 111, 37, 69, 53, 75, 97, 59, 227, 243, 155, 247, 14, 95, 74, 88, 63, 155, 115, 52, 168, 199, 12, 71, 65, 226, 85, 117, 131, 158 } },
                    { 16, new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(9238), "Emma@mail.com", "Emma", "45", false, "Schoonkind", new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(9238), new byte[] { 234, 111, 93, 30, 191, 243, 71, 99, 53, 19, 202, 0, 155, 20, 71, 63, 166, 121, 79, 62, 221, 158, 181, 101, 59, 96, 27, 172, 99, 30, 151, 91, 134, 56, 14, 154, 142, 171, 137, 29, 120, 22, 41, 73, 231, 6, 0, 8, 144, 50, 149, 157, 47, 51, 198, 196, 171, 76, 34, 159, 255, 206, 175, 115 }, new byte[] { 172, 226, 182, 29, 237, 223, 206, 96, 173, 42, 24, 218, 208, 37, 96, 165, 112, 114, 235, 245, 208, 92, 229, 105, 10, 10, 68, 233, 66, 169, 42, 86, 62, 67, 63, 185, 164, 138, 7, 150, 120, 159, 90, 137, 9, 90, 11, 231, 118, 90, 65, 87, 152, 128, 42, 180, 118, 73, 42, 65, 23, 200, 107, 221, 104, 193, 132, 89, 78, 85, 182, 86, 65, 25, 149, 102, 60, 236, 160, 164, 207, 95, 70, 250, 14, 3, 5, 24, 12, 29, 207, 221, 15, 35, 215, 159, 255, 45, 174, 111, 37, 69, 53, 75, 97, 59, 227, 243, 155, 247, 14, 95, 74, 88, 63, 155, 115, 52, 168, 199, 12, 71, 65, 226, 85, 117, 131, 158 } },
                    { 15, new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(9222), "Anke@mail.com", "Anke", "27", false, "Van Kleurenkennere", new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(9222), new byte[] { 234, 111, 93, 30, 191, 243, 71, 99, 53, 19, 202, 0, 155, 20, 71, 63, 166, 121, 79, 62, 221, 158, 181, 101, 59, 96, 27, 172, 99, 30, 151, 91, 134, 56, 14, 154, 142, 171, 137, 29, 120, 22, 41, 73, 231, 6, 0, 8, 144, 50, 149, 157, 47, 51, 198, 196, 171, 76, 34, 159, 255, 206, 175, 115 }, new byte[] { 172, 226, 182, 29, 237, 223, 206, 96, 173, 42, 24, 218, 208, 37, 96, 165, 112, 114, 235, 245, 208, 92, 229, 105, 10, 10, 68, 233, 66, 169, 42, 86, 62, 67, 63, 185, 164, 138, 7, 150, 120, 159, 90, 137, 9, 90, 11, 231, 118, 90, 65, 87, 152, 128, 42, 180, 118, 73, 42, 65, 23, 200, 107, 221, 104, 193, 132, 89, 78, 85, 182, 86, 65, 25, 149, 102, 60, 236, 160, 164, 207, 95, 70, 250, 14, 3, 5, 24, 12, 29, 207, 221, 15, 35, 215, 159, 255, 45, 174, 111, 37, 69, 53, 75, 97, 59, 227, 243, 155, 247, 14, 95, 74, 88, 63, 155, 115, 52, 168, 199, 12, 71, 65, 226, 85, 117, 131, 158 } },
                    { 20, new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(9300), "Hoon@mail.com", "Hoon", "99", false, "Tomatenplukker", new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(9300), new byte[] { 234, 111, 93, 30, 191, 243, 71, 99, 53, 19, 202, 0, 155, 20, 71, 63, 166, 121, 79, 62, 221, 158, 181, 101, 59, 96, 27, 172, 99, 30, 151, 91, 134, 56, 14, 154, 142, 171, 137, 29, 120, 22, 41, 73, 231, 6, 0, 8, 144, 50, 149, 157, 47, 51, 198, 196, 171, 76, 34, 159, 255, 206, 175, 115 }, new byte[] { 172, 226, 182, 29, 237, 223, 206, 96, 173, 42, 24, 218, 208, 37, 96, 165, 112, 114, 235, 245, 208, 92, 229, 105, 10, 10, 68, 233, 66, 169, 42, 86, 62, 67, 63, 185, 164, 138, 7, 150, 120, 159, 90, 137, 9, 90, 11, 231, 118, 90, 65, 87, 152, 128, 42, 180, 118, 73, 42, 65, 23, 200, 107, 221, 104, 193, 132, 89, 78, 85, 182, 86, 65, 25, 149, 102, 60, 236, 160, 164, 207, 95, 70, 250, 14, 3, 5, 24, 12, 29, 207, 221, 15, 35, 215, 159, 255, 45, 174, 111, 37, 69, 53, 75, 97, 59, 227, 243, 155, 247, 14, 95, 74, 88, 63, 155, 115, 52, 168, 199, 12, 71, 65, 226, 85, 117, 131, 158 } },
                    { 14, new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(9207), "Marieke@mail.com", "Marieke", "T1", false, "Van Leren Broeke", new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(9207), new byte[] { 234, 111, 93, 30, 191, 243, 71, 99, 53, 19, 202, 0, 155, 20, 71, 63, 166, 121, 79, 62, 221, 158, 181, 101, 59, 96, 27, 172, 99, 30, 151, 91, 134, 56, 14, 154, 142, 171, 137, 29, 120, 22, 41, 73, 231, 6, 0, 8, 144, 50, 149, 157, 47, 51, 198, 196, 171, 76, 34, 159, 255, 206, 175, 115 }, new byte[] { 172, 226, 182, 29, 237, 223, 206, 96, 173, 42, 24, 218, 208, 37, 96, 165, 112, 114, 235, 245, 208, 92, 229, 105, 10, 10, 68, 233, 66, 169, 42, 86, 62, 67, 63, 185, 164, 138, 7, 150, 120, 159, 90, 137, 9, 90, 11, 231, 118, 90, 65, 87, 152, 128, 42, 180, 118, 73, 42, 65, 23, 200, 107, 221, 104, 193, 132, 89, 78, 85, 182, 86, 65, 25, 149, 102, 60, 236, 160, 164, 207, 95, 70, 250, 14, 3, 5, 24, 12, 29, 207, 221, 15, 35, 215, 159, 255, 45, 174, 111, 37, 69, 53, 75, 97, 59, 227, 243, 155, 247, 14, 95, 74, 88, 63, 155, 115, 52, 168, 199, 12, 71, 65, 226, 85, 117, 131, 158 } },
                    { 13, new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(9192), "Joyce@mail.com", "Joyce", "75", false, "Recruiter", new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(9192), new byte[] { 234, 111, 93, 30, 191, 243, 71, 99, 53, 19, 202, 0, 155, 20, 71, 63, 166, 121, 79, 62, 221, 158, 181, 101, 59, 96, 27, 172, 99, 30, 151, 91, 134, 56, 14, 154, 142, 171, 137, 29, 120, 22, 41, 73, 231, 6, 0, 8, 144, 50, 149, 157, 47, 51, 198, 196, 171, 76, 34, 159, 255, 206, 175, 115 }, new byte[] { 172, 226, 182, 29, 237, 223, 206, 96, 173, 42, 24, 218, 208, 37, 96, 165, 112, 114, 235, 245, 208, 92, 229, 105, 10, 10, 68, 233, 66, 169, 42, 86, 62, 67, 63, 185, 164, 138, 7, 150, 120, 159, 90, 137, 9, 90, 11, 231, 118, 90, 65, 87, 152, 128, 42, 180, 118, 73, 42, 65, 23, 200, 107, 221, 104, 193, 132, 89, 78, 85, 182, 86, 65, 25, 149, 102, 60, 236, 160, 164, 207, 95, 70, 250, 14, 3, 5, 24, 12, 29, 207, 221, 15, 35, 215, 159, 255, 45, 174, 111, 37, 69, 53, 75, 97, 59, 227, 243, 155, 247, 14, 95, 74, 88, 63, 155, 115, 52, 168, 199, 12, 71, 65, 226, 85, 117, 131, 158 } },
                    { 11, new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(9160), "Jens@mail.com", "Jens", "Zeemlap", false, "Spinning", new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(9160), new byte[] { 234, 111, 93, 30, 191, 243, 71, 99, 53, 19, 202, 0, 155, 20, 71, 63, 166, 121, 79, 62, 221, 158, 181, 101, 59, 96, 27, 172, 99, 30, 151, 91, 134, 56, 14, 154, 142, 171, 137, 29, 120, 22, 41, 73, 231, 6, 0, 8, 144, 50, 149, 157, 47, 51, 198, 196, 171, 76, 34, 159, 255, 206, 175, 115 }, new byte[] { 172, 226, 182, 29, 237, 223, 206, 96, 173, 42, 24, 218, 208, 37, 96, 165, 112, 114, 235, 245, 208, 92, 229, 105, 10, 10, 68, 233, 66, 169, 42, 86, 62, 67, 63, 185, 164, 138, 7, 150, 120, 159, 90, 137, 9, 90, 11, 231, 118, 90, 65, 87, 152, 128, 42, 180, 118, 73, 42, 65, 23, 200, 107, 221, 104, 193, 132, 89, 78, 85, 182, 86, 65, 25, 149, 102, 60, 236, 160, 164, 207, 95, 70, 250, 14, 3, 5, 24, 12, 29, 207, 221, 15, 35, 215, 159, 255, 45, 174, 111, 37, 69, 53, 75, 97, 59, 227, 243, 155, 247, 14, 95, 74, 88, 63, 155, 115, 52, 168, 199, 12, 71, 65, 226, 85, 117, 131, 158 } },
                    { 6, new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(8836), "Emma@mail.com", "Emma", "Stofzuiger", false, "Kipdorp", new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(8836), new byte[] { 234, 111, 93, 30, 191, 243, 71, 99, 53, 19, 202, 0, 155, 20, 71, 63, 166, 121, 79, 62, 221, 158, 181, 101, 59, 96, 27, 172, 99, 30, 151, 91, 134, 56, 14, 154, 142, 171, 137, 29, 120, 22, 41, 73, 231, 6, 0, 8, 144, 50, 149, 157, 47, 51, 198, 196, 171, 76, 34, 159, 255, 206, 175, 115 }, new byte[] { 172, 226, 182, 29, 237, 223, 206, 96, 173, 42, 24, 218, 208, 37, 96, 165, 112, 114, 235, 245, 208, 92, 229, 105, 10, 10, 68, 233, 66, 169, 42, 86, 62, 67, 63, 185, 164, 138, 7, 150, 120, 159, 90, 137, 9, 90, 11, 231, 118, 90, 65, 87, 152, 128, 42, 180, 118, 73, 42, 65, 23, 200, 107, 221, 104, 193, 132, 89, 78, 85, 182, 86, 65, 25, 149, 102, 60, 236, 160, 164, 207, 95, 70, 250, 14, 3, 5, 24, 12, 29, 207, 221, 15, 35, 215, 159, 255, 45, 174, 111, 37, 69, 53, 75, 97, 59, 227, 243, 155, 247, 14, 95, 74, 88, 63, 155, 115, 52, 168, 199, 12, 71, 65, 226, 85, 117, 131, 158 } },
                    { 9, new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(9125), "Michiel@mail.com", "Michiel", "g283?set=set4", false, "Demogod", new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(9125), new byte[] { 234, 111, 93, 30, 191, 243, 71, 99, 53, 19, 202, 0, 155, 20, 71, 63, 166, 121, 79, 62, 221, 158, 181, 101, 59, 96, 27, 172, 99, 30, 151, 91, 134, 56, 14, 154, 142, 171, 137, 29, 120, 22, 41, 73, 231, 6, 0, 8, 144, 50, 149, 157, 47, 51, 198, 196, 171, 76, 34, 159, 255, 206, 175, 115 }, new byte[] { 172, 226, 182, 29, 237, 223, 206, 96, 173, 42, 24, 218, 208, 37, 96, 165, 112, 114, 235, 245, 208, 92, 229, 105, 10, 10, 68, 233, 66, 169, 42, 86, 62, 67, 63, 185, 164, 138, 7, 150, 120, 159, 90, 137, 9, 90, 11, 231, 118, 90, 65, 87, 152, 128, 42, 180, 118, 73, 42, 65, 23, 200, 107, 221, 104, 193, 132, 89, 78, 85, 182, 86, 65, 25, 149, 102, 60, 236, 160, 164, 207, 95, 70, 250, 14, 3, 5, 24, 12, 29, 207, 221, 15, 35, 215, 159, 255, 45, 174, 111, 37, 69, 53, 75, 97, 59, 227, 243, 155, 247, 14, 95, 74, 88, 63, 155, 115, 52, 168, 199, 12, 71, 65, 226, 85, 117, 131, 158 } },
                    { 8, new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(9108), "Andreas@mail.com", "Andreas", "Andreas", false, "VanGrieken", new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(9108), new byte[] { 234, 111, 93, 30, 191, 243, 71, 99, 53, 19, 202, 0, 155, 20, 71, 63, 166, 121, 79, 62, 221, 158, 181, 101, 59, 96, 27, 172, 99, 30, 151, 91, 134, 56, 14, 154, 142, 171, 137, 29, 120, 22, 41, 73, 231, 6, 0, 8, 144, 50, 149, 157, 47, 51, 198, 196, 171, 76, 34, 159, 255, 206, 175, 115 }, new byte[] { 172, 226, 182, 29, 237, 223, 206, 96, 173, 42, 24, 218, 208, 37, 96, 165, 112, 114, 235, 245, 208, 92, 229, 105, 10, 10, 68, 233, 66, 169, 42, 86, 62, 67, 63, 185, 164, 138, 7, 150, 120, 159, 90, 137, 9, 90, 11, 231, 118, 90, 65, 87, 152, 128, 42, 180, 118, 73, 42, 65, 23, 200, 107, 221, 104, 193, 132, 89, 78, 85, 182, 86, 65, 25, 149, 102, 60, 236, 160, 164, 207, 95, 70, 250, 14, 3, 5, 24, 12, 29, 207, 221, 15, 35, 215, 159, 255, 45, 174, 111, 37, 69, 53, 75, 97, 59, 227, 243, 155, 247, 14, 95, 74, 88, 63, 155, 115, 52, 168, 199, 12, 71, 65, 226, 85, 117, 131, 158 } },
                    { 7, new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(8851), "Ward@mail.com", "Ward", "Dirk", false, "Zetdieplaataf", new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(8851), new byte[] { 234, 111, 93, 30, 191, 243, 71, 99, 53, 19, 202, 0, 155, 20, 71, 63, 166, 121, 79, 62, 221, 158, 181, 101, 59, 96, 27, 172, 99, 30, 151, 91, 134, 56, 14, 154, 142, 171, 137, 29, 120, 22, 41, 73, 231, 6, 0, 8, 144, 50, 149, 157, 47, 51, 198, 196, 171, 76, 34, 159, 255, 206, 175, 115 }, new byte[] { 172, 226, 182, 29, 237, 223, 206, 96, 173, 42, 24, 218, 208, 37, 96, 165, 112, 114, 235, 245, 208, 92, 229, 105, 10, 10, 68, 233, 66, 169, 42, 86, 62, 67, 63, 185, 164, 138, 7, 150, 120, 159, 90, 137, 9, 90, 11, 231, 118, 90, 65, 87, 152, 128, 42, 180, 118, 73, 42, 65, 23, 200, 107, 221, 104, 193, 132, 89, 78, 85, 182, 86, 65, 25, 149, 102, 60, 236, 160, 164, 207, 95, 70, 250, 14, 3, 5, 24, 12, 29, 207, 221, 15, 35, 215, 159, 255, 45, 174, 111, 37, 69, 53, 75, 97, 59, 227, 243, 155, 247, 14, 95, 74, 88, 63, 155, 115, 52, 168, 199, 12, 71, 65, 226, 85, 117, 131, 158 } },
                    { 5, new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(8820), "Seba@mail.com", "Seba", "BartjeWevertje", false, "Ergertzichnooit", new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(8820), new byte[] { 234, 111, 93, 30, 191, 243, 71, 99, 53, 19, 202, 0, 155, 20, 71, 63, 166, 121, 79, 62, 221, 158, 181, 101, 59, 96, 27, 172, 99, 30, 151, 91, 134, 56, 14, 154, 142, 171, 137, 29, 120, 22, 41, 73, 231, 6, 0, 8, 144, 50, 149, 157, 47, 51, 198, 196, 171, 76, 34, 159, 255, 206, 175, 115 }, new byte[] { 172, 226, 182, 29, 237, 223, 206, 96, 173, 42, 24, 218, 208, 37, 96, 165, 112, 114, 235, 245, 208, 92, 229, 105, 10, 10, 68, 233, 66, 169, 42, 86, 62, 67, 63, 185, 164, 138, 7, 150, 120, 159, 90, 137, 9, 90, 11, 231, 118, 90, 65, 87, 152, 128, 42, 180, 118, 73, 42, 65, 23, 200, 107, 221, 104, 193, 132, 89, 78, 85, 182, 86, 65, 25, 149, 102, 60, 236, 160, 164, 207, 95, 70, 250, 14, 3, 5, 24, 12, 29, 207, 221, 15, 35, 215, 159, 255, 45, 174, 111, 37, 69, 53, 75, 97, 59, 227, 243, 155, 247, 14, 95, 74, 88, 63, 155, 115, 52, 168, 199, 12, 71, 65, 226, 85, 117, 131, 158 } },
                    { 4, new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(8800), "Drieswilgraageenlangemail@mail.be", "Dries", "Dries", true, "Maileniseenkunst", new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(8800), new byte[] { 234, 111, 93, 30, 191, 243, 71, 99, 53, 19, 202, 0, 155, 20, 71, 63, 166, 121, 79, 62, 221, 158, 181, 101, 59, 96, 27, 172, 99, 30, 151, 91, 134, 56, 14, 154, 142, 171, 137, 29, 120, 22, 41, 73, 231, 6, 0, 8, 144, 50, 149, 157, 47, 51, 198, 196, 171, 76, 34, 159, 255, 206, 175, 115 }, new byte[] { 172, 226, 182, 29, 237, 223, 206, 96, 173, 42, 24, 218, 208, 37, 96, 165, 112, 114, 235, 245, 208, 92, 229, 105, 10, 10, 68, 233, 66, 169, 42, 86, 62, 67, 63, 185, 164, 138, 7, 150, 120, 159, 90, 137, 9, 90, 11, 231, 118, 90, 65, 87, 152, 128, 42, 180, 118, 73, 42, 65, 23, 200, 107, 221, 104, 193, 132, 89, 78, 85, 182, 86, 65, 25, 149, 102, 60, 236, 160, 164, 207, 95, 70, 250, 14, 3, 5, 24, 12, 29, 207, 221, 15, 35, 215, 159, 255, 45, 174, 111, 37, 69, 53, 75, 97, 59, 227, 243, 155, 247, 14, 95, 74, 88, 63, 155, 115, 52, 168, 199, 12, 71, 65, 226, 85, 117, 131, 158 } },
                    { 3, new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(8767), "Kobe@mail.com", "Kobe", "Kobe", true, "Neut", new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(8767), new byte[] { 234, 111, 93, 30, 191, 243, 71, 99, 53, 19, 202, 0, 155, 20, 71, 63, 166, 121, 79, 62, 221, 158, 181, 101, 59, 96, 27, 172, 99, 30, 151, 91, 134, 56, 14, 154, 142, 171, 137, 29, 120, 22, 41, 73, 231, 6, 0, 8, 144, 50, 149, 157, 47, 51, 198, 196, 171, 76, 34, 159, 255, 206, 175, 115 }, new byte[] { 172, 226, 182, 29, 237, 223, 206, 96, 173, 42, 24, 218, 208, 37, 96, 165, 112, 114, 235, 245, 208, 92, 229, 105, 10, 10, 68, 233, 66, 169, 42, 86, 62, 67, 63, 185, 164, 138, 7, 150, 120, 159, 90, 137, 9, 90, 11, 231, 118, 90, 65, 87, 152, 128, 42, 180, 118, 73, 42, 65, 23, 200, 107, 221, 104, 193, 132, 89, 78, 85, 182, 86, 65, 25, 149, 102, 60, 236, 160, 164, 207, 95, 70, 250, 14, 3, 5, 24, 12, 29, 207, 221, 15, 35, 215, 159, 255, 45, 174, 111, 37, 69, 53, 75, 97, 59, 227, 243, 155, 247, 14, 95, 74, 88, 63, 155, 115, 52, 168, 199, 12, 71, 65, 226, 85, 117, 131, 158 } },
                    { 2, new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(7893), "Nick@mail.com", "Nick", "Nick", true, "Angularlover", new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(7893), new byte[] { 234, 111, 93, 30, 191, 243, 71, 99, 53, 19, 202, 0, 155, 20, 71, 63, 166, 121, 79, 62, 221, 158, 181, 101, 59, 96, 27, 172, 99, 30, 151, 91, 134, 56, 14, 154, 142, 171, 137, 29, 120, 22, 41, 73, 231, 6, 0, 8, 144, 50, 149, 157, 47, 51, 198, 196, 171, 76, 34, 159, 255, 206, 175, 115 }, new byte[] { 172, 226, 182, 29, 237, 223, 206, 96, 173, 42, 24, 218, 208, 37, 96, 165, 112, 114, 235, 245, 208, 92, 229, 105, 10, 10, 68, 233, 66, 169, 42, 86, 62, 67, 63, 185, 164, 138, 7, 150, 120, 159, 90, 137, 9, 90, 11, 231, 118, 90, 65, 87, 152, 128, 42, 180, 118, 73, 42, 65, 23, 200, 107, 221, 104, 193, 132, 89, 78, 85, 182, 86, 65, 25, 149, 102, 60, 236, 160, 164, 207, 95, 70, 250, 14, 3, 5, 24, 12, 29, 207, 221, 15, 35, 215, 159, 255, 45, 174, 111, 37, 69, 53, 75, 97, 59, 227, 243, 155, 247, 14, 95, 74, 88, 63, 155, 115, 52, 168, 199, 12, 71, 65, 226, 85, 117, 131, 158 } },
                    { 1, new DateTime(2021, 5, 24, 15, 42, 34, 770, DateTimeKind.Local).AddTicks(8880), "Pieter@mail.com", "Pieter", "Pieter", true, "Slaapkop", new DateTime(2021, 5, 24, 15, 42, 34, 770, DateTimeKind.Local).AddTicks(8880), new byte[] { 234, 111, 93, 30, 191, 243, 71, 99, 53, 19, 202, 0, 155, 20, 71, 63, 166, 121, 79, 62, 221, 158, 181, 101, 59, 96, 27, 172, 99, 30, 151, 91, 134, 56, 14, 154, 142, 171, 137, 29, 120, 22, 41, 73, 231, 6, 0, 8, 144, 50, 149, 157, 47, 51, 198, 196, 171, 76, 34, 159, 255, 206, 175, 115 }, new byte[] { 172, 226, 182, 29, 237, 223, 206, 96, 173, 42, 24, 218, 208, 37, 96, 165, 112, 114, 235, 245, 208, 92, 229, 105, 10, 10, 68, 233, 66, 169, 42, 86, 62, 67, 63, 185, 164, 138, 7, 150, 120, 159, 90, 137, 9, 90, 11, 231, 118, 90, 65, 87, 152, 128, 42, 180, 118, 73, 42, 65, 23, 200, 107, 221, 104, 193, 132, 89, 78, 85, 182, 86, 65, 25, 149, 102, 60, 236, 160, 164, 207, 95, 70, 250, 14, 3, 5, 24, 12, 29, 207, 221, 15, 35, 215, 159, 255, 45, 174, 111, 37, 69, 53, 75, 97, 59, 227, 243, 155, 247, 14, 95, 74, 88, 63, 155, 115, 52, 168, 199, 12, 71, 65, 226, 85, 117, 131, 158 } },
                    { 21, new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(9315), "Michaël@mail.com", "Michaël", "25", false, "Wanderer", new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(9315), new byte[] { 234, 111, 93, 30, 191, 243, 71, 99, 53, 19, 202, 0, 155, 20, 71, 63, 166, 121, 79, 62, 221, 158, 181, 101, 59, 96, 27, 172, 99, 30, 151, 91, 134, 56, 14, 154, 142, 171, 137, 29, 120, 22, 41, 73, 231, 6, 0, 8, 144, 50, 149, 157, 47, 51, 198, 196, 171, 76, 34, 159, 255, 206, 175, 115 }, new byte[] { 172, 226, 182, 29, 237, 223, 206, 96, 173, 42, 24, 218, 208, 37, 96, 165, 112, 114, 235, 245, 208, 92, 229, 105, 10, 10, 68, 233, 66, 169, 42, 86, 62, 67, 63, 185, 164, 138, 7, 150, 120, 159, 90, 137, 9, 90, 11, 231, 118, 90, 65, 87, 152, 128, 42, 180, 118, 73, 42, 65, 23, 200, 107, 221, 104, 193, 132, 89, 78, 85, 182, 86, 65, 25, 149, 102, 60, 236, 160, 164, 207, 95, 70, 250, 14, 3, 5, 24, 12, 29, 207, 221, 15, 35, 215, 159, 255, 45, 174, 111, 37, 69, 53, 75, 97, 59, 227, 243, 155, 247, 14, 95, 74, 88, 63, 155, 115, 52, 168, 199, 12, 71, 65, 226, 85, 117, 131, 158 } },
                    { 10, new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(9142), "Diederik@mail.com", "Diederik", "Luc", false, "Van Lievegem", new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(9142), new byte[] { 234, 111, 93, 30, 191, 243, 71, 99, 53, 19, 202, 0, 155, 20, 71, 63, 166, 121, 79, 62, 221, 158, 181, 101, 59, 96, 27, 172, 99, 30, 151, 91, 134, 56, 14, 154, 142, 171, 137, 29, 120, 22, 41, 73, 231, 6, 0, 8, 144, 50, 149, 157, 47, 51, 198, 196, 171, 76, 34, 159, 255, 206, 175, 115 }, new byte[] { 172, 226, 182, 29, 237, 223, 206, 96, 173, 42, 24, 218, 208, 37, 96, 165, 112, 114, 235, 245, 208, 92, 229, 105, 10, 10, 68, 233, 66, 169, 42, 86, 62, 67, 63, 185, 164, 138, 7, 150, 120, 159, 90, 137, 9, 90, 11, 231, 118, 90, 65, 87, 152, 128, 42, 180, 118, 73, 42, 65, 23, 200, 107, 221, 104, 193, 132, 89, 78, 85, 182, 86, 65, 25, 149, 102, 60, 236, 160, 164, 207, 95, 70, 250, 14, 3, 5, 24, 12, 29, 207, 221, 15, 35, 215, 159, 255, 45, 174, 111, 37, 69, 53, 75, 97, 59, 227, 243, 155, 247, 14, 95, 74, 88, 63, 155, 115, 52, 168, 199, 12, 71, 65, 226, 85, 117, 131, 158 } },
                    { 22, new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(9331), "Brent@mail.com", "Brent", "29", false, "Tomatentrucker", new DateTime(2021, 5, 24, 15, 42, 34, 779, DateTimeKind.Local).AddTicks(9331), new byte[] { 234, 111, 93, 30, 191, 243, 71, 99, 53, 19, 202, 0, 155, 20, 71, 63, 166, 121, 79, 62, 221, 158, 181, 101, 59, 96, 27, 172, 99, 30, 151, 91, 134, 56, 14, 154, 142, 171, 137, 29, 120, 22, 41, 73, 231, 6, 0, 8, 144, 50, 149, 157, 47, 51, 198, 196, 171, 76, 34, 159, 255, 206, 175, 115 }, new byte[] { 172, 226, 182, 29, 237, 223, 206, 96, 173, 42, 24, 218, 208, 37, 96, 165, 112, 114, 235, 245, 208, 92, 229, 105, 10, 10, 68, 233, 66, 169, 42, 86, 62, 67, 63, 185, 164, 138, 7, 150, 120, 159, 90, 137, 9, 90, 11, 231, 118, 90, 65, 87, 152, 128, 42, 180, 118, 73, 42, 65, 23, 200, 107, 221, 104, 193, 132, 89, 78, 85, 182, 86, 65, 25, 149, 102, 60, 236, 160, 164, 207, 95, 70, 250, 14, 3, 5, 24, 12, 29, 207, 221, 15, 35, 215, 159, 255, 45, 174, 111, 37, 69, 53, 75, 97, 59, 227, 243, 155, 247, 14, 95, 74, 88, 63, 155, 115, 52, 168, 199, 12, 71, 65, 226, 85, 117, 131, 158 } }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "PostalCode", "StreetName", "StreetNumber", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(5046), new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(5046), 9000, "Anti-Veggiestraat", 89, 1 },
                    { 10, new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9899), new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9899), 9070, "Geenpolitiekinhetprojectstraat", 200, 10 },
                    { 12, new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9916), new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9916), 1000, "Blacklivesmatterstraat", 78, 12 },
                    { 9, new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9891), new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9891), 2000, "Greenlivesmattertooweg", 420, 9 },
                    { 8, new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9885), new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9885), 1000, "Kotsvisplein", 96, 8 },
                    { 13, new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9925), new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9925), 7000, "Worstenbroodjesstraat", 4, 13 },
                    { 7, new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9876), new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9876), 9050, "Greenpeacestraat", 1, 7 },
                    { 14, new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9931), new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9931), 9000, "Jurgenzitverstoptachterhetlamgodsstraat", 24, 14 },
                    { 6, new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9866), new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9866), 1000, "Spekmeteierenstraat", 43, 6 },
                    { 5, new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9858), new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9858), 9000, "Boerenworststraat", 85, 5 },
                    { 15, new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9938), new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9938), 1081, "Bloedworststraat", 78, 15 },
                    { 4, new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9850), new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9850), 1000, "Vleesbroodstraat", 66, 4 },
                    { 16, new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9944), new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9944), 1180, "Gemarineerderunderlendedreef", 36, 16 },
                    { 17, new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9951), new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9951), 1500, "Ribbetjesstraat", 14, 17 },
                    { 3, new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9844), new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9844), 4000, "Balletjesintomatensausstraat", 74, 3 },
                    { 11, new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9908), new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9908), 9500, "Kalfslapjesstraat", 32, 11 },
                    { 19, new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9969), new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9969), 2323, "Lookbroodjesstraat", 11, 19 },
                    { 20, new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9973), new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9973), 2890, "Worstenbroodjesstraat", 79, 20 },
                    { 18, new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9960), new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9960), 2070, "Bickyburgerstraat", 15, 18 },
                    { 21, new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9983), new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9983), 3020, "Huisgemaaktekalfsbitterballetjesstraat", 100, 21 },
                    { 2, new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9802), new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9802), 3000, "Vrbaan", 45, 2 },
                    { 22, new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9989), new DateTime(2021, 5, 24, 15, 42, 34, 787, DateTimeKind.Local).AddTicks(9989), 3110, "Kalfsrib-eyelaan", 107, 22 }
                });

            migrationBuilder.InsertData(
                table: "TradeItems",
                columns: new[] { "Id", "Amount", "CreatedAt", "ModifiedAt", "ResourceId", "UserId" },
                values: new object[,]
                {
                    { 82, 52, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1642), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1642), 23, 21 },
                    { 54, 19, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1498), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1498), 12, 13 },
                    { 41, 17, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1460), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1460), 1, 11 },
                    { 53, 33, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1495), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1495), 35, 13 },
                    { 52, 22, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1492), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1492), 48, 13 },
                    { 51, 17, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1489), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1489), 47, 13 },
                    { 50, 17, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1486), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1486), 51, 13 },
                    { 80, 7, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1636), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1636), 17, 20 },
                    { 81, 13, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1639), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1639), 18, 20 },
                    { 49, 21, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1483), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1483), 12, 12 },
                    { 48, 17, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1480), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1480), 9, 12 },
                    { 55, 9, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1501), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1501), 7, 13 },
                    { 47, 34, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1477), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1477), 8, 12 },
                    { 46, 25, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1474), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1474), 47, 12 },
                    { 45, 12, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1472), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1472), 29, 12 },
                    { 42, 3, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1463), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1463), 3, 11 },
                    { 44, 78, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1469), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1469), 18, 12 },
                    { 43, 28, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1466), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1466), 7, 11 },
                    { 76, 80, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1625), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1625), 5, 17 },
                    { 57, 13, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1507), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1507), 29, 13 }
                });

            migrationBuilder.InsertData(
                table: "TradeItems",
                columns: new[] { "Id", "Amount", "CreatedAt", "ModifiedAt", "ResourceId", "UserId" },
                values: new object[,]
                {
                    { 75, 113, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1621), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1621), 3, 17 },
                    { 74, 78, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1618), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1618), 36, 16 },
                    { 73, 35, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1615), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1615), 38, 16 },
                    { 72, 24, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1612), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1612), 39, 16 },
                    { 77, 17, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1628), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1628), 6, 17 },
                    { 71, 1, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1610), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1610), 3, 15 },
                    { 70, 8, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1607), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1607), 51, 15 },
                    { 69, 153, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1604), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1604), 29, 15 },
                    { 68, 157, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1601), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1601), 22, 15 },
                    { 67, 19, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1599), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1599), 21, 15 },
                    { 56, 35, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1504), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1504), 8, 13 },
                    { 66, 78, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1596), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1596), 18, 15 },
                    { 65, 24, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1593), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1593), 17, 14 },
                    { 64, 88, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1590), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1590), 12, 14 },
                    { 83, 8, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1644), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1644), 26, 22 },
                    { 62, 39, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1584), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1584), 11, 14 },
                    { 61, 47, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1581), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1581), 8, 14 },
                    { 60, 19, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1515), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1515), 1, 14 },
                    { 79, 90, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1633), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1633), 44, 19 },
                    { 59, 17, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1512), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1512), 41, 13 },
                    { 58, 8, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1509), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1509), 38, 13 },
                    { 78, 99, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1630), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1630), 51, 19 },
                    { 63, 77, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1587), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1587), 9, 14 },
                    { 40, 33, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1457), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1457), 51, 11 },
                    { 39, 53, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1454), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1454), 19, 10 },
                    { 25, 5, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1414), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1414), 39, 6 },
                    { 24, 78, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1410), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1410), 32, 5 },
                    { 23, 38, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1407), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1407), 46, 5 },
                    { 22, 39, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1404), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1404), 17, 5 },
                    { 21, 63, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1402), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1402), 51, 5 },
                    { 20, 47, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1399), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1399), 7, 5 },
                    { 5, 41, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1354), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1354), 51, 2 },
                    { 19, 50, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1396), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1396), 51, 4 },
                    { 18, 36, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1393), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1393), 44, 4 },
                    { 17, 89, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1390), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1390), 21, 4 },
                    { 6, 30, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1358), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1358), 34, 2 },
                    { 16, 17, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1387), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1387), 31, 3 },
                    { 15, 30, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1384), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1384), 6, 3 },
                    { 7, 40, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1361), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1361), 46, 2 },
                    { 14, 49, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1382), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1382), 13, 3 },
                    { 13, 17, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1379), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1379), 8, 3 },
                    { 12, 20, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1376), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1376), 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "TradeItems",
                columns: new[] { "Id", "Amount", "CreatedAt", "ModifiedAt", "ResourceId", "UserId" },
                values: new object[,]
                {
                    { 11, 47, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1372), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1372), 51, 3 },
                    { 8, 5, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1363), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1363), 32, 2 },
                    { 10, 32, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1369), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1369), 15, 2 },
                    { 26, 10, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1417), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1417), 15, 6 },
                    { 9, 25, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1366), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1366), 39, 2 },
                    { 28, 10, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1422), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1422), 4, 6 },
                    { 33, 78, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1437), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1437), 6, 8 },
                    { 27, 12, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1419), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1419), 51, 6 },
                    { 35, 26, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1442), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1442), 51, 9 },
                    { 3, 12, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1347), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1347), 5, 1 },
                    { 36, 17, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1445), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1445), 14, 9 },
                    { 37, 69, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1448), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1448), 36, 9 },
                    { 34, 53, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1440), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1440), 51, 8 },
                    { 32, 38, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1434), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1434), 51, 7 },
                    { 30, 23, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1428), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1428), 13, 7 },
                    { 29, 19, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1425), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1425), 8, 7 },
                    { 1, 47, new DateTime(2021, 5, 24, 15, 42, 34, 800, DateTimeKind.Local).AddTicks(9424), new DateTime(2021, 5, 24, 15, 42, 34, 800, DateTimeKind.Local).AddTicks(9424), 1, 1 },
                    { 38, 34, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1451), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1451), 17, 10 },
                    { 4, 99, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1351), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1351), 7, 1 },
                    { 31, 36, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1431), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1431), 6, 7 },
                    { 2, 36, new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1329), new DateTime(2021, 5, 24, 15, 42, 34, 801, DateTimeKind.Local).AddTicks(1329), 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Trades",
                columns: new[] { "Id", "ActiveUserId", "Completed", "CreatedAt", "ModifiedAt", "ProposerId", "ReceiverId" },
                values: new object[,]
                {
                    { 2, 3, false, new DateTime(2021, 5, 24, 15, 42, 34, 796, DateTimeKind.Local).AddTicks(987), new DateTime(2021, 5, 24, 15, 42, 34, 796, DateTimeKind.Local).AddTicks(987), 3, 2 },
                    { 4, 1, false, new DateTime(2021, 5, 24, 15, 42, 34, 796, DateTimeKind.Local).AddTicks(1028), new DateTime(2021, 5, 24, 15, 42, 34, 796, DateTimeKind.Local).AddTicks(1028), 1, 8 },
                    { 6, 7, false, new DateTime(2021, 5, 24, 15, 42, 34, 796, DateTimeKind.Local).AddTicks(1049), new DateTime(2021, 5, 24, 15, 42, 34, 796, DateTimeKind.Local).AddTicks(1049), 7, 2 },
                    { 1, 1, false, new DateTime(2021, 5, 24, 15, 42, 34, 795, DateTimeKind.Local).AddTicks(7041), new DateTime(2021, 5, 24, 15, 42, 34, 795, DateTimeKind.Local).AddTicks(7041), 2, 1 },
                    { 5, 7, false, new DateTime(2021, 5, 24, 15, 42, 34, 796, DateTimeKind.Local).AddTicks(1038), new DateTime(2021, 5, 24, 15, 42, 34, 796, DateTimeKind.Local).AddTicks(1038), 4, 7 },
                    { 3, 6, false, new DateTime(2021, 5, 24, 15, 42, 34, 796, DateTimeKind.Local).AddTicks(1017), new DateTime(2021, 5, 24, 15, 42, 34, 796, DateTimeKind.Local).AddTicks(1017), 6, 8 }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "UserId", "VAmount" },
                values: new object[,]
                {
                    { 20, new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7347), new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7347), 20, 56m },
                    { 21, new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7356), new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7356), 21, 78m },
                    { 19, new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7338), new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7338), 19, 78m },
                    { 18, new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7329), new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7329), 18, 65m },
                    { 1, new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(4676), new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(4676), 1, 200m },
                    { 4, new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7199), new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7199), 4, 42m },
                    { 2, new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7153), new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7153), 2, 347m },
                    { 16, new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7311), new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7311), 16, 28m },
                    { 15, new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7301), new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7301), 15, 47m },
                    { 3, new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7189), new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7189), 3, 65m },
                    { 10, new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7254), new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7254), 10, 124m },
                    { 14, new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7292), new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7292), 14, 20m },
                    { 5, new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7208), new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7208), 5, 753m },
                    { 13, new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7282), new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7282), 13, 204m },
                    { 6, new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7217), new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7217), 6, 36m }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "UserId", "VAmount" },
                values: new object[,]
                {
                    { 7, new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7227), new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7227), 7, 12m },
                    { 12, new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7273), new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7273), 12, 57m },
                    { 8, new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7236), new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7236), 8, 654m },
                    { 11, new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7264), new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7264), 11, 269m },
                    { 9, new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7245), new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7245), 9, 357m },
                    { 17, new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7320), new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7320), 17, 104m },
                    { 22, new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7365), new DateTime(2021, 5, 24, 15, 42, 34, 790, DateTimeKind.Local).AddTicks(7365), 22, 9m }
                });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "CreatedAt", "EuroAmount", "ModifiedAt", "VAmount", "WalletId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 24, 15, 42, 34, 802, DateTimeKind.Local).AddTicks(2438), 6.9m, new DateTime(2021, 5, 24, 15, 42, 34, 802, DateTimeKind.Local).AddTicks(2438), 69m, 1 },
                    { 7, new DateTime(2021, 5, 24, 15, 42, 34, 802, DateTimeKind.Local).AddTicks(4578), 9.8m, new DateTime(2021, 5, 24, 15, 42, 34, 802, DateTimeKind.Local).AddTicks(4578), 98m, 9 },
                    { 8, new DateTime(2021, 5, 24, 15, 42, 34, 802, DateTimeKind.Local).AddTicks(4581), 5m, new DateTime(2021, 5, 24, 15, 42, 34, 802, DateTimeKind.Local).AddTicks(4581), 50m, 7 },
                    { 6, new DateTime(2021, 5, 24, 15, 42, 34, 802, DateTimeKind.Local).AddTicks(4574), 7.8m, new DateTime(2021, 5, 24, 15, 42, 34, 802, DateTimeKind.Local).AddTicks(4574), 78m, 10 },
                    { 4, new DateTime(2021, 5, 24, 15, 42, 34, 802, DateTimeKind.Local).AddTicks(4568), 10m, new DateTime(2021, 5, 24, 15, 42, 34, 802, DateTimeKind.Local).AddTicks(4568), 100m, 6 },
                    { 3, new DateTime(2021, 5, 24, 15, 42, 34, 802, DateTimeKind.Local).AddTicks(4564), 42m, new DateTime(2021, 5, 24, 15, 42, 34, 802, DateTimeKind.Local).AddTicks(4564), 420m, 5 },
                    { 10, new DateTime(2021, 5, 24, 15, 42, 34, 802, DateTimeKind.Local).AddTicks(4587), 2m, new DateTime(2021, 5, 24, 15, 42, 34, 802, DateTimeKind.Local).AddTicks(4587), 20m, 4 },
                    { 9, new DateTime(2021, 5, 24, 15, 42, 34, 802, DateTimeKind.Local).AddTicks(4584), 13m, new DateTime(2021, 5, 24, 15, 42, 34, 802, DateTimeKind.Local).AddTicks(4584), 130m, 3 },
                    { 5, new DateTime(2021, 5, 24, 15, 42, 34, 802, DateTimeKind.Local).AddTicks(4571), 3.6m, new DateTime(2021, 5, 24, 15, 42, 34, 802, DateTimeKind.Local).AddTicks(4571), 36m, 12 },
                    { 2, new DateTime(2021, 5, 24, 15, 42, 34, 802, DateTimeKind.Local).AddTicks(4546), 2m, new DateTime(2021, 5, 24, 15, 42, 34, 802, DateTimeKind.Local).AddTicks(4546), 20m, 1 }
                });

            migrationBuilder.InsertData(
                table: "TradeItemProposals",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "ProposedAmount", "TradeId", "TradeItemId" },
                values: new object[,]
                {
                    { 8, new DateTime(2021, 5, 24, 15, 42, 34, 803, DateTimeKind.Local).AddTicks(5063), new DateTime(2021, 5, 24, 15, 42, 34, 803, DateTimeKind.Local).AddTicks(5063), 15, 2, 14 },
                    { 11, new DateTime(2021, 5, 24, 15, 42, 34, 803, DateTimeKind.Local).AddTicks(5083), new DateTime(2021, 5, 24, 15, 42, 34, 803, DateTimeKind.Local).AddTicks(5083), 5, 4, 34 },
                    { 9, new DateTime(2021, 5, 24, 15, 42, 34, 803, DateTimeKind.Local).AddTicks(5074), new DateTime(2021, 5, 24, 15, 42, 34, 803, DateTimeKind.Local).AddTicks(5074), 5, 3, 33 },
                    { 15, new DateTime(2021, 5, 24, 15, 42, 34, 803, DateTimeKind.Local).AddTicks(5104), new DateTime(2021, 5, 24, 15, 42, 34, 803, DateTimeKind.Local).AddTicks(5104), 5, 4, 4 },
                    { 14, new DateTime(2021, 5, 24, 15, 42, 34, 803, DateTimeKind.Local).AddTicks(5098), new DateTime(2021, 5, 24, 15, 42, 34, 803, DateTimeKind.Local).AddTicks(5098), 15, 4, 3 },
                    { 13, new DateTime(2021, 5, 24, 15, 42, 34, 803, DateTimeKind.Local).AddTicks(5092), new DateTime(2021, 5, 24, 15, 42, 34, 803, DateTimeKind.Local).AddTicks(5092), 5, 4, 2 },
                    { 12, new DateTime(2021, 5, 24, 15, 42, 34, 803, DateTimeKind.Local).AddTicks(5089), new DateTime(2021, 5, 24, 15, 42, 34, 803, DateTimeKind.Local).AddTicks(5089), 15, 4, 1 },
                    { 10, new DateTime(2021, 5, 24, 15, 42, 34, 803, DateTimeKind.Local).AddTicks(5077), new DateTime(2021, 5, 24, 15, 42, 34, 803, DateTimeKind.Local).AddTicks(5077), 15, 3, 28 },
                    { 7, new DateTime(2021, 5, 24, 15, 42, 34, 803, DateTimeKind.Local).AddTicks(5060), new DateTime(2021, 5, 24, 15, 42, 34, 803, DateTimeKind.Local).AddTicks(5060), 5, 2, 13 },
                    { 1, new DateTime(2021, 5, 24, 15, 42, 34, 803, DateTimeKind.Local).AddTicks(2889), new DateTime(2021, 5, 24, 15, 42, 34, 803, DateTimeKind.Local).AddTicks(2889), 5, 1, 1 },
                    { 20, new DateTime(2021, 5, 24, 15, 42, 34, 803, DateTimeKind.Local).AddTicks(5128), new DateTime(2021, 5, 24, 15, 42, 34, 803, DateTimeKind.Local).AddTicks(5128), 15, 6, 30 },
                    { 19, new DateTime(2021, 5, 24, 15, 42, 34, 803, DateTimeKind.Local).AddTicks(5122), new DateTime(2021, 5, 24, 15, 42, 34, 803, DateTimeKind.Local).AddTicks(5122), 1, 6, 5 },
                    { 18, new DateTime(2021, 5, 24, 15, 42, 34, 803, DateTimeKind.Local).AddTicks(5119), new DateTime(2021, 5, 24, 15, 42, 34, 803, DateTimeKind.Local).AddTicks(5119), 15, 5, 18 },
                    { 2, new DateTime(2021, 5, 24, 15, 42, 34, 803, DateTimeKind.Local).AddTicks(5012), new DateTime(2021, 5, 24, 15, 42, 34, 803, DateTimeKind.Local).AddTicks(5012), 15, 1, 2 },
                    { 3, new DateTime(2021, 5, 24, 15, 42, 34, 803, DateTimeKind.Local).AddTicks(5038), new DateTime(2021, 5, 24, 15, 42, 34, 803, DateTimeKind.Local).AddTicks(5038), 5, 1, 3 },
                    { 4, new DateTime(2021, 5, 24, 15, 42, 34, 803, DateTimeKind.Local).AddTicks(5044), new DateTime(2021, 5, 24, 15, 42, 34, 803, DateTimeKind.Local).AddTicks(5044), 5, 1, 5 },
                    { 5, new DateTime(2021, 5, 24, 15, 42, 34, 803, DateTimeKind.Local).AddTicks(5048), new DateTime(2021, 5, 24, 15, 42, 34, 803, DateTimeKind.Local).AddTicks(5048), 5, 2, 6 },
                    { 6, new DateTime(2021, 5, 24, 15, 42, 34, 803, DateTimeKind.Local).AddTicks(5056), new DateTime(2021, 5, 24, 15, 42, 34, 803, DateTimeKind.Local).AddTicks(5056), 15, 2, 7 },
                    { 16, new DateTime(2021, 5, 24, 15, 42, 34, 803, DateTimeKind.Local).AddTicks(5107), new DateTime(2021, 5, 24, 15, 42, 34, 803, DateTimeKind.Local).AddTicks(5107), 3, 5, 32 },
                    { 17, new DateTime(2021, 5, 24, 15, 42, 34, 803, DateTimeKind.Local).AddTicks(5113), new DateTime(2021, 5, 24, 15, 42, 34, 803, DateTimeKind.Local).AddTicks(5113), 5, 5, 17 }
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
