using Microsoft.EntityFrameworkCore.Migrations;
using System;

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
                    { 1, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(6784), "apples.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(6784), "apples" },
                    { 29, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7873), "olives.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7873), "olives" },
                    { 30, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7875), "oranges.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7875), "oranges" },
                    { 31, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7877), "papayas.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7877), "papayas" },
                    { 33, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7882), "pears.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7882), "pears" },
                    { 34, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7884), "peas.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7884), "peas" },
                    { 35, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7890), "pineapples.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7890), "pineapples" },
                    { 36, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7892), "pomegranates.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7892), "pomegranates" },
                    { 37, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7895), "potatoes.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7895), "potatoes" },
                    { 38, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7897), "pumpkins.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7897), "pumpkins" },
                    { 39, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7899), "radish.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7899), "radish" },
                    { 28, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7870), "mushrooms.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7870), "mushrooms" },
                    { 40, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7902), "radishes.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7902), "radishes" },
                    { 42, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7906), "salad.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7906), "salad" },
                    { 43, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7908), "salads.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7908), "salads" },
                    { 44, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7911), "scallions.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7911), "scallions" },
                    { 45, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7913), "spinach.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7913), "spinach" },
                    { 46, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7915), "star-fruits.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7915), "star-fruits" },
                    { 47, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7918), "strawberries.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7918), "strawberries" },
                    { 48, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7920), "sweet-potatoes.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7920), "sweet-potatoes" },
                    { 49, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7922), "tomatoes.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7922), "tomatoes" },
                    { 50, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7925), "watermelons.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7925), "watermelons" },
                    { 51, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7927), "v-coin.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7927), "v-coin" },
                    { 41, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7904), "raspberries.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7904), "raspberries" },
                    { 27, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7868), "melons.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7868), "melons" },
                    { 32, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7880), "peaches.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7880), "peaches" },
                    { 25, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7863), "mangos.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7863), "mangos" },
                    { 2, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7754), "artichokes.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7754), "artichokes" },
                    { 3, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7767), "asparagus.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7767), "asparagus" },
                    { 4, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7770), "bananas.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7770), "bananas" },
                    { 5, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7772), "bell-peppers.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7772), "bell-peppers" },
                    { 6, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7775), "blueberries.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7775), "blueberries" },
                    { 7, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7777), "bok-choy.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7777), "bok-choy" },
                    { 26, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7866), "mangosteens.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7866), "mangosteens" },
                    { 9, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7782), "brussels-sprouts.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7782), "brussels-sprouts" },
                    { 10, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7784), "carrots.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7784), "carrots" },
                    { 11, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7787), "cherries.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7787), "cherries" },
                    { 12, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7829), "chilis.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7829), "chilis" },
                    { 13, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7834), "coconuts.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7834), "coconuts" },
                    { 8, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7780), "broccoli.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7780), "broccoli" },
                    { 15, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7839), "corn.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7839), "corn" },
                    { 16, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7842), "cucumbers.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7842), "cucumbers" }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreatedAt", "ImageUrl", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 17, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7844), "dragon-fruits.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7844), "dragon-fruits" },
                    { 18, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7846), "durians.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7846), "durians" },
                    { 19, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7849), "eggplants.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7849), "eggplants" },
                    { 20, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7851), "garlic.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7851), "garlic" },
                    { 21, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7854), "grapes.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7854), "grapes" },
                    { 22, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7856), "guavas.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7856), "guavas" },
                    { 23, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7858), "kiwis.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7858), "kiwis" },
                    { 24, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7861), "lemons.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7861), "lemons" },
                    { 14, new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7837), "coriander.svg", new DateTime(2021, 5, 20, 23, 32, 7, 735, DateTimeKind.Local).AddTicks(7837), "coriander" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "ImageUrl", "IsAdmin", "LastName", "ModifiedAt", "PasswordHash", "PasswordSalt" },
                values: new object[,]
                {
                    { 11, new DateTime(2021, 5, 20, 23, 32, 7, 731, DateTimeKind.Local).AddTicks(9049), "VerhofstadDeZeemlap@europeesemailadres.com", "Verhofstad", "https://robohash.org/Zeemlap", false, "Zeemlap", new DateTime(2021, 5, 20, 23, 32, 7, 731, DateTimeKind.Local).AddTicks(9049), new byte[] { 79, 140, 139, 20, 63, 113, 87, 160, 53, 239, 166, 136, 181, 42, 204, 161, 112, 194, 87, 117, 102, 240, 237, 241, 2, 0, 192, 214, 50, 240, 39, 50, 24, 250, 128, 134, 197, 210, 171, 36, 68, 187, 57, 19, 234, 15, 53, 242, 89, 34, 197, 217, 241, 41, 108, 51, 175, 244, 190, 225, 6, 192, 53, 39 }, new byte[] { 122, 75, 93, 116, 77, 111, 213, 42, 5, 205, 188, 112, 31, 75, 109, 138, 246, 137, 167, 208, 86, 30, 243, 177, 61, 37, 55, 233, 23, 18, 81, 153, 210, 211, 38, 49, 91, 161, 134, 106, 194, 153, 192, 197, 207, 47, 87, 26, 182, 12, 222, 161, 206, 227, 254, 108, 10, 4, 235, 225, 89, 46, 231, 224, 50, 233, 4, 252, 62, 119, 151, 213, 81, 242, 197, 195, 94, 32, 208, 128, 95, 167, 252, 11, 73, 118, 40, 66, 55, 15, 92, 187, 32, 216, 183, 104, 237, 166, 35, 54, 203, 151, 228, 199, 54, 242, 79, 31, 177, 74, 178, 203, 132, 60, 169, 243, 226, 247, 51, 203, 204, 130, 59, 76, 212, 67, 90, 142 } },
                    { 10, new DateTime(2021, 5, 20, 23, 32, 7, 731, DateTimeKind.Local).AddTicks(9036), "Luc@mail.com", "Luc", "https://robohash.org/Luc", false, "DeHaantje", new DateTime(2021, 5, 20, 23, 32, 7, 731, DateTimeKind.Local).AddTicks(9036), new byte[] { 79, 140, 139, 20, 63, 113, 87, 160, 53, 239, 166, 136, 181, 42, 204, 161, 112, 194, 87, 117, 102, 240, 237, 241, 2, 0, 192, 214, 50, 240, 39, 50, 24, 250, 128, 134, 197, 210, 171, 36, 68, 187, 57, 19, 234, 15, 53, 242, 89, 34, 197, 217, 241, 41, 108, 51, 175, 244, 190, 225, 6, 192, 53, 39 }, new byte[] { 122, 75, 93, 116, 77, 111, 213, 42, 5, 205, 188, 112, 31, 75, 109, 138, 246, 137, 167, 208, 86, 30, 243, 177, 61, 37, 55, 233, 23, 18, 81, 153, 210, 211, 38, 49, 91, 161, 134, 106, 194, 153, 192, 197, 207, 47, 87, 26, 182, 12, 222, 161, 206, 227, 254, 108, 10, 4, 235, 225, 89, 46, 231, 224, 50, 233, 4, 252, 62, 119, 151, 213, 81, 242, 197, 195, 94, 32, 208, 128, 95, 167, 252, 11, 73, 118, 40, 66, 55, 15, 92, 187, 32, 216, 183, 104, 237, 166, 35, 54, 203, 151, 228, 199, 54, 242, 79, 31, 177, 74, 178, 203, 132, 60, 169, 243, 226, 247, 51, 203, 204, 130, 59, 76, 212, 67, 90, 142 } },
                    { 9, new DateTime(2021, 5, 20, 23, 32, 7, 731, DateTimeKind.Local).AddTicks(9023), "Mihiel@mail.com", "Mihiel", "https://robohash.org/Mihiel", false, "Mihoen", new DateTime(2021, 5, 20, 23, 32, 7, 731, DateTimeKind.Local).AddTicks(9023), new byte[] { 79, 140, 139, 20, 63, 113, 87, 160, 53, 239, 166, 136, 181, 42, 204, 161, 112, 194, 87, 117, 102, 240, 237, 241, 2, 0, 192, 214, 50, 240, 39, 50, 24, 250, 128, 134, 197, 210, 171, 36, 68, 187, 57, 19, 234, 15, 53, 242, 89, 34, 197, 217, 241, 41, 108, 51, 175, 244, 190, 225, 6, 192, 53, 39 }, new byte[] { 122, 75, 93, 116, 77, 111, 213, 42, 5, 205, 188, 112, 31, 75, 109, 138, 246, 137, 167, 208, 86, 30, 243, 177, 61, 37, 55, 233, 23, 18, 81, 153, 210, 211, 38, 49, 91, 161, 134, 106, 194, 153, 192, 197, 207, 47, 87, 26, 182, 12, 222, 161, 206, 227, 254, 108, 10, 4, 235, 225, 89, 46, 231, 224, 50, 233, 4, 252, 62, 119, 151, 213, 81, 242, 197, 195, 94, 32, 208, 128, 95, 167, 252, 11, 73, 118, 40, 66, 55, 15, 92, 187, 32, 216, 183, 104, 237, 166, 35, 54, 203, 151, 228, 199, 54, 242, 79, 31, 177, 74, 178, 203, 132, 60, 169, 243, 226, 247, 51, 203, 204, 130, 59, 76, 212, 67, 90, 142 } },
                    { 8, new DateTime(2021, 5, 20, 23, 32, 7, 731, DateTimeKind.Local).AddTicks(9010), "Andreas@mail.com", "Andreas", "https://robohash.org/Andreas", false, "VanGrieken", new DateTime(2021, 5, 20, 23, 32, 7, 731, DateTimeKind.Local).AddTicks(9010), new byte[] { 79, 140, 139, 20, 63, 113, 87, 160, 53, 239, 166, 136, 181, 42, 204, 161, 112, 194, 87, 117, 102, 240, 237, 241, 2, 0, 192, 214, 50, 240, 39, 50, 24, 250, 128, 134, 197, 210, 171, 36, 68, 187, 57, 19, 234, 15, 53, 242, 89, 34, 197, 217, 241, 41, 108, 51, 175, 244, 190, 225, 6, 192, 53, 39 }, new byte[] { 122, 75, 93, 116, 77, 111, 213, 42, 5, 205, 188, 112, 31, 75, 109, 138, 246, 137, 167, 208, 86, 30, 243, 177, 61, 37, 55, 233, 23, 18, 81, 153, 210, 211, 38, 49, 91, 161, 134, 106, 194, 153, 192, 197, 207, 47, 87, 26, 182, 12, 222, 161, 206, 227, 254, 108, 10, 4, 235, 225, 89, 46, 231, 224, 50, 233, 4, 252, 62, 119, 151, 213, 81, 242, 197, 195, 94, 32, 208, 128, 95, 167, 252, 11, 73, 118, 40, 66, 55, 15, 92, 187, 32, 216, 183, 104, 237, 166, 35, 54, 203, 151, 228, 199, 54, 242, 79, 31, 177, 74, 178, 203, 132, 60, 169, 243, 226, 247, 51, 203, 204, 130, 59, 76, 212, 67, 90, 142 } },
                    { 7, new DateTime(2021, 5, 20, 23, 32, 7, 731, DateTimeKind.Local).AddTicks(8998), "Dirk@mail.com", "Dirk", "https://robohash.org/Dirk", false, "Visser", new DateTime(2021, 5, 20, 23, 32, 7, 731, DateTimeKind.Local).AddTicks(8998), new byte[] { 79, 140, 139, 20, 63, 113, 87, 160, 53, 239, 166, 136, 181, 42, 204, 161, 112, 194, 87, 117, 102, 240, 237, 241, 2, 0, 192, 214, 50, 240, 39, 50, 24, 250, 128, 134, 197, 210, 171, 36, 68, 187, 57, 19, 234, 15, 53, 242, 89, 34, 197, 217, 241, 41, 108, 51, 175, 244, 190, 225, 6, 192, 53, 39 }, new byte[] { 122, 75, 93, 116, 77, 111, 213, 42, 5, 205, 188, 112, 31, 75, 109, 138, 246, 137, 167, 208, 86, 30, 243, 177, 61, 37, 55, 233, 23, 18, 81, 153, 210, 211, 38, 49, 91, 161, 134, 106, 194, 153, 192, 197, 207, 47, 87, 26, 182, 12, 222, 161, 206, 227, 254, 108, 10, 4, 235, 225, 89, 46, 231, 224, 50, 233, 4, 252, 62, 119, 151, 213, 81, 242, 197, 195, 94, 32, 208, 128, 95, 167, 252, 11, 73, 118, 40, 66, 55, 15, 92, 187, 32, 216, 183, 104, 237, 166, 35, 54, 203, 151, 228, 199, 54, 242, 79, 31, 177, 74, 178, 203, 132, 60, 169, 243, 226, 247, 51, 203, 204, 130, 59, 76, 212, 67, 90, 142 } },
                    { 1, new DateTime(2021, 5, 20, 23, 32, 7, 728, DateTimeKind.Local).AddTicks(6718), "Pieter@mail.com", "Pieter", "https://robohash.org/Pieter", true, "Corp", new DateTime(2021, 5, 20, 23, 32, 7, 728, DateTimeKind.Local).AddTicks(6718), new byte[] { 79, 140, 139, 20, 63, 113, 87, 160, 53, 239, 166, 136, 181, 42, 204, 161, 112, 194, 87, 117, 102, 240, 237, 241, 2, 0, 192, 214, 50, 240, 39, 50, 24, 250, 128, 134, 197, 210, 171, 36, 68, 187, 57, 19, 234, 15, 53, 242, 89, 34, 197, 217, 241, 41, 108, 51, 175, 244, 190, 225, 6, 192, 53, 39 }, new byte[] { 122, 75, 93, 116, 77, 111, 213, 42, 5, 205, 188, 112, 31, 75, 109, 138, 246, 137, 167, 208, 86, 30, 243, 177, 61, 37, 55, 233, 23, 18, 81, 153, 210, 211, 38, 49, 91, 161, 134, 106, 194, 153, 192, 197, 207, 47, 87, 26, 182, 12, 222, 161, 206, 227, 254, 108, 10, 4, 235, 225, 89, 46, 231, 224, 50, 233, 4, 252, 62, 119, 151, 213, 81, 242, 197, 195, 94, 32, 208, 128, 95, 167, 252, 11, 73, 118, 40, 66, 55, 15, 92, 187, 32, 216, 183, 104, 237, 166, 35, 54, 203, 151, 228, 199, 54, 242, 79, 31, 177, 74, 178, 203, 132, 60, 169, 243, 226, 247, 51, 203, 204, 130, 59, 76, 212, 67, 90, 142 } },
                    { 5, new DateTime(2021, 5, 20, 23, 32, 7, 731, DateTimeKind.Local).AddTicks(8972), "BartjeWevertje@mail.com", "BartjeWevertje", "https://robohash.org/BartjeWevertje", false, "Wevertje", new DateTime(2021, 5, 20, 23, 32, 7, 731, DateTimeKind.Local).AddTicks(8972), new byte[] { 79, 140, 139, 20, 63, 113, 87, 160, 53, 239, 166, 136, 181, 42, 204, 161, 112, 194, 87, 117, 102, 240, 237, 241, 2, 0, 192, 214, 50, 240, 39, 50, 24, 250, 128, 134, 197, 210, 171, 36, 68, 187, 57, 19, 234, 15, 53, 242, 89, 34, 197, 217, 241, 41, 108, 51, 175, 244, 190, 225, 6, 192, 53, 39 }, new byte[] { 122, 75, 93, 116, 77, 111, 213, 42, 5, 205, 188, 112, 31, 75, 109, 138, 246, 137, 167, 208, 86, 30, 243, 177, 61, 37, 55, 233, 23, 18, 81, 153, 210, 211, 38, 49, 91, 161, 134, 106, 194, 153, 192, 197, 207, 47, 87, 26, 182, 12, 222, 161, 206, 227, 254, 108, 10, 4, 235, 225, 89, 46, 231, 224, 50, 233, 4, 252, 62, 119, 151, 213, 81, 242, 197, 195, 94, 32, 208, 128, 95, 167, 252, 11, 73, 118, 40, 66, 55, 15, 92, 187, 32, 216, 183, 104, 237, 166, 35, 54, 203, 151, 228, 199, 54, 242, 79, 31, 177, 74, 178, 203, 132, 60, 169, 243, 226, 247, 51, 203, 204, 130, 59, 76, 212, 67, 90, 142 } },
                    { 4, new DateTime(2021, 5, 20, 23, 32, 7, 731, DateTimeKind.Local).AddTicks(8955), "Dries@mail.com", "Dries", "https://robohash.org/Dries", true, "Maes", new DateTime(2021, 5, 20, 23, 32, 7, 731, DateTimeKind.Local).AddTicks(8955), new byte[] { 79, 140, 139, 20, 63, 113, 87, 160, 53, 239, 166, 136, 181, 42, 204, 161, 112, 194, 87, 117, 102, 240, 237, 241, 2, 0, 192, 214, 50, 240, 39, 50, 24, 250, 128, 134, 197, 210, 171, 36, 68, 187, 57, 19, 234, 15, 53, 242, 89, 34, 197, 217, 241, 41, 108, 51, 175, 244, 190, 225, 6, 192, 53, 39 }, new byte[] { 122, 75, 93, 116, 77, 111, 213, 42, 5, 205, 188, 112, 31, 75, 109, 138, 246, 137, 167, 208, 86, 30, 243, 177, 61, 37, 55, 233, 23, 18, 81, 153, 210, 211, 38, 49, 91, 161, 134, 106, 194, 153, 192, 197, 207, 47, 87, 26, 182, 12, 222, 161, 206, 227, 254, 108, 10, 4, 235, 225, 89, 46, 231, 224, 50, 233, 4, 252, 62, 119, 151, 213, 81, 242, 197, 195, 94, 32, 208, 128, 95, 167, 252, 11, 73, 118, 40, 66, 55, 15, 92, 187, 32, 216, 183, 104, 237, 166, 35, 54, 203, 151, 228, 199, 54, 242, 79, 31, 177, 74, 178, 203, 132, 60, 169, 243, 226, 247, 51, 203, 204, 130, 59, 76, 212, 67, 90, 142 } },
                    { 3, new DateTime(2021, 5, 20, 23, 32, 7, 731, DateTimeKind.Local).AddTicks(8860), "Kobe@mail.com", "Kobe", "https://robohash.org/Kobe", true, "Delo", new DateTime(2021, 5, 20, 23, 32, 7, 731, DateTimeKind.Local).AddTicks(8860), new byte[] { 79, 140, 139, 20, 63, 113, 87, 160, 53, 239, 166, 136, 181, 42, 204, 161, 112, 194, 87, 117, 102, 240, 237, 241, 2, 0, 192, 214, 50, 240, 39, 50, 24, 250, 128, 134, 197, 210, 171, 36, 68, 187, 57, 19, 234, 15, 53, 242, 89, 34, 197, 217, 241, 41, 108, 51, 175, 244, 190, 225, 6, 192, 53, 39 }, new byte[] { 122, 75, 93, 116, 77, 111, 213, 42, 5, 205, 188, 112, 31, 75, 109, 138, 246, 137, 167, 208, 86, 30, 243, 177, 61, 37, 55, 233, 23, 18, 81, 153, 210, 211, 38, 49, 91, 161, 134, 106, 194, 153, 192, 197, 207, 47, 87, 26, 182, 12, 222, 161, 206, 227, 254, 108, 10, 4, 235, 225, 89, 46, 231, 224, 50, 233, 4, 252, 62, 119, 151, 213, 81, 242, 197, 195, 94, 32, 208, 128, 95, 167, 252, 11, 73, 118, 40, 66, 55, 15, 92, 187, 32, 216, 183, 104, 237, 166, 35, 54, 203, 151, 228, 199, 54, 242, 79, 31, 177, 74, 178, 203, 132, 60, 169, 243, 226, 247, 51, 203, 204, 130, 59, 76, 212, 67, 90, 142 } },
                    { 2, new DateTime(2021, 5, 20, 23, 32, 7, 731, DateTimeKind.Local).AddTicks(8694), "Nick@mail.com", "Nick", "https://robohash.org/Nick", true, "Vr", new DateTime(2021, 5, 20, 23, 32, 7, 731, DateTimeKind.Local).AddTicks(8694), new byte[] { 79, 140, 139, 20, 63, 113, 87, 160, 53, 239, 166, 136, 181, 42, 204, 161, 112, 194, 87, 117, 102, 240, 237, 241, 2, 0, 192, 214, 50, 240, 39, 50, 24, 250, 128, 134, 197, 210, 171, 36, 68, 187, 57, 19, 234, 15, 53, 242, 89, 34, 197, 217, 241, 41, 108, 51, 175, 244, 190, 225, 6, 192, 53, 39 }, new byte[] { 122, 75, 93, 116, 77, 111, 213, 42, 5, 205, 188, 112, 31, 75, 109, 138, 246, 137, 167, 208, 86, 30, 243, 177, 61, 37, 55, 233, 23, 18, 81, 153, 210, 211, 38, 49, 91, 161, 134, 106, 194, 153, 192, 197, 207, 47, 87, 26, 182, 12, 222, 161, 206, 227, 254, 108, 10, 4, 235, 225, 89, 46, 231, 224, 50, 233, 4, 252, 62, 119, 151, 213, 81, 242, 197, 195, 94, 32, 208, 128, 95, 167, 252, 11, 73, 118, 40, 66, 55, 15, 92, 187, 32, 216, 183, 104, 237, 166, 35, 54, 203, 151, 228, 199, 54, 242, 79, 31, 177, 74, 178, 203, 132, 60, 169, 243, 226, 247, 51, 203, 204, 130, 59, 76, 212, 67, 90, 142 } },
                    { 12, new DateTime(2021, 5, 20, 23, 32, 7, 731, DateTimeKind.Local).AddTicks(9061), "Driesdentweedenmaarnidezelfden@mail.com", "Dries", "https://robohash.org/Dries2", false, "VanKorteNekke", new DateTime(2021, 5, 20, 23, 32, 7, 731, DateTimeKind.Local).AddTicks(9061), new byte[] { 79, 140, 139, 20, 63, 113, 87, 160, 53, 239, 166, 136, 181, 42, 204, 161, 112, 194, 87, 117, 102, 240, 237, 241, 2, 0, 192, 214, 50, 240, 39, 50, 24, 250, 128, 134, 197, 210, 171, 36, 68, 187, 57, 19, 234, 15, 53, 242, 89, 34, 197, 217, 241, 41, 108, 51, 175, 244, 190, 225, 6, 192, 53, 39 }, new byte[] { 122, 75, 93, 116, 77, 111, 213, 42, 5, 205, 188, 112, 31, 75, 109, 138, 246, 137, 167, 208, 86, 30, 243, 177, 61, 37, 55, 233, 23, 18, 81, 153, 210, 211, 38, 49, 91, 161, 134, 106, 194, 153, 192, 197, 207, 47, 87, 26, 182, 12, 222, 161, 206, 227, 254, 108, 10, 4, 235, 225, 89, 46, 231, 224, 50, 233, 4, 252, 62, 119, 151, 213, 81, 242, 197, 195, 94, 32, 208, 128, 95, 167, 252, 11, 73, 118, 40, 66, 55, 15, 92, 187, 32, 216, 183, 104, 237, 166, 35, 54, 203, 151, 228, 199, 54, 242, 79, 31, 177, 74, 178, 203, 132, 60, 169, 243, 226, 247, 51, 203, 204, 130, 59, 76, 212, 67, 90, 142 } },
                    { 6, new DateTime(2021, 5, 20, 23, 32, 7, 731, DateTimeKind.Local).AddTicks(8985), "Stofzuiger@mail.com", "Stofzuiger", "https://robohash.org/Stofzuiger", false, "Zuiger", new DateTime(2021, 5, 20, 23, 32, 7, 731, DateTimeKind.Local).AddTicks(8985), new byte[] { 79, 140, 139, 20, 63, 113, 87, 160, 53, 239, 166, 136, 181, 42, 204, 161, 112, 194, 87, 117, 102, 240, 237, 241, 2, 0, 192, 214, 50, 240, 39, 50, 24, 250, 128, 134, 197, 210, 171, 36, 68, 187, 57, 19, 234, 15, 53, 242, 89, 34, 197, 217, 241, 41, 108, 51, 175, 244, 190, 225, 6, 192, 53, 39 }, new byte[] { 122, 75, 93, 116, 77, 111, 213, 42, 5, 205, 188, 112, 31, 75, 109, 138, 246, 137, 167, 208, 86, 30, 243, 177, 61, 37, 55, 233, 23, 18, 81, 153, 210, 211, 38, 49, 91, 161, 134, 106, 194, 153, 192, 197, 207, 47, 87, 26, 182, 12, 222, 161, 206, 227, 254, 108, 10, 4, 235, 225, 89, 46, 231, 224, 50, 233, 4, 252, 62, 119, 151, 213, 81, 242, 197, 195, 94, 32, 208, 128, 95, 167, 252, 11, 73, 118, 40, 66, 55, 15, 92, 187, 32, 216, 183, 104, 237, 166, 35, 54, 203, 151, 228, 199, 54, 242, 79, 31, 177, 74, 178, 203, 132, 60, 169, 243, 226, 247, 51, 203, 204, 130, 59, 76, 212, 67, 90, 142 } },
                    { 13, new DateTime(2021, 5, 20, 23, 32, 7, 731, DateTimeKind.Local).AddTicks(9074), "Joyce@mail.com", "Joyce", "https://robohash.org/Tomatenplukker", false, "Tomatenplukker", new DateTime(2021, 5, 20, 23, 32, 7, 731, DateTimeKind.Local).AddTicks(9074), new byte[] { 79, 140, 139, 20, 63, 113, 87, 160, 53, 239, 166, 136, 181, 42, 204, 161, 112, 194, 87, 117, 102, 240, 237, 241, 2, 0, 192, 214, 50, 240, 39, 50, 24, 250, 128, 134, 197, 210, 171, 36, 68, 187, 57, 19, 234, 15, 53, 242, 89, 34, 197, 217, 241, 41, 108, 51, 175, 244, 190, 225, 6, 192, 53, 39 }, new byte[] { 122, 75, 93, 116, 77, 111, 213, 42, 5, 205, 188, 112, 31, 75, 109, 138, 246, 137, 167, 208, 86, 30, 243, 177, 61, 37, 55, 233, 23, 18, 81, 153, 210, 211, 38, 49, 91, 161, 134, 106, 194, 153, 192, 197, 207, 47, 87, 26, 182, 12, 222, 161, 206, 227, 254, 108, 10, 4, 235, 225, 89, 46, 231, 224, 50, 233, 4, 252, 62, 119, 151, 213, 81, 242, 197, 195, 94, 32, 208, 128, 95, 167, 252, 11, 73, 118, 40, 66, 55, 15, 92, 187, 32, 216, 183, 104, 237, 166, 35, 54, 203, 151, 228, 199, 54, 242, 79, 31, 177, 74, 178, 203, 132, 60, 169, 243, 226, 247, 51, 203, 204, 130, 59, 76, 212, 67, 90, 142 } }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "PostalCode", "StreetName", "StreetNumber", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 20, 23, 32, 7, 733, DateTimeKind.Local).AddTicks(6227), new DateTime(2021, 5, 20, 23, 32, 7, 733, DateTimeKind.Local).AddTicks(6227), 9000, "Anti-Veggiestraat", 89, 1 },
                    { 4, new DateTime(2021, 5, 20, 23, 32, 7, 733, DateTimeKind.Local).AddTicks(7952), new DateTime(2021, 5, 20, 23, 32, 7, 733, DateTimeKind.Local).AddTicks(7952), 1000, "Driesstraat", 66, 4 },
                    { 6, new DateTime(2021, 5, 20, 23, 32, 7, 733, DateTimeKind.Local).AddTicks(7958), new DateTime(2021, 5, 20, 23, 32, 7, 733, DateTimeKind.Local).AddTicks(7958), 1000, "Lookbroodjesstraat", 43, 6 },
                    { 5, new DateTime(2021, 5, 20, 23, 32, 7, 733, DateTimeKind.Local).AddTicks(7955), new DateTime(2021, 5, 20, 23, 32, 7, 733, DateTimeKind.Local).AddTicks(7955), 2000, "Kobestraat", 85, 5 },
                    { 10, new DateTime(2021, 5, 20, 23, 32, 7, 733, DateTimeKind.Local).AddTicks(7968), new DateTime(2021, 5, 20, 23, 32, 7, 733, DateTimeKind.Local).AddTicks(7968), 9070, "Geenpolitiekinhetprojectstraat", 200, 10 },
                    { 8, new DateTime(2021, 5, 20, 23, 32, 7, 733, DateTimeKind.Local).AddTicks(7963), new DateTime(2021, 5, 20, 23, 32, 7, 733, DateTimeKind.Local).AddTicks(7963), 1000, "Kotsvisstraat", 96, 8 },
                    { 11, new DateTime(2021, 5, 20, 23, 32, 7, 733, DateTimeKind.Local).AddTicks(7970), new DateTime(2021, 5, 20, 23, 32, 7, 733, DateTimeKind.Local).AddTicks(7970), 9500, "Kalfslapjesstraat", 32, 11 },
                    { 3, new DateTime(2021, 5, 20, 23, 32, 7, 733, DateTimeKind.Local).AddTicks(7949), new DateTime(2021, 5, 20, 23, 32, 7, 733, DateTimeKind.Local).AddTicks(7949), 9000, "Nickstraat", 74, 3 },
                    { 12, new DateTime(2021, 5, 20, 23, 32, 7, 733, DateTimeKind.Local).AddTicks(7973), new DateTime(2021, 5, 20, 23, 32, 7, 733, DateTimeKind.Local).AddTicks(7973), 1000, "Blacklivesmatterstraat", 78, 12 },
                    { 2, new DateTime(2021, 5, 20, 23, 32, 7, 733, DateTimeKind.Local).AddTicks(7935), new DateTime(2021, 5, 20, 23, 32, 7, 733, DateTimeKind.Local).AddTicks(7935), 9000, "Pieterstreaat", 45, 2 },
                    { 13, new DateTime(2021, 5, 20, 23, 32, 7, 733, DateTimeKind.Local).AddTicks(7975), new DateTime(2021, 5, 20, 23, 32, 7, 733, DateTimeKind.Local).AddTicks(7975), 9020, "Worstenbroodjesstraat", 4, 13 },
                    { 7, new DateTime(2021, 5, 20, 23, 32, 7, 733, DateTimeKind.Local).AddTicks(7960), new DateTime(2021, 5, 20, 23, 32, 7, 733, DateTimeKind.Local).AddTicks(7960), 9050, "Greenpeacestraat", 1, 7 },
                    { 9, new DateTime(2021, 5, 20, 23, 32, 7, 733, DateTimeKind.Local).AddTicks(7965), new DateTime(2021, 5, 20, 23, 32, 7, 733, DateTimeKind.Local).AddTicks(7965), 2000, "Greenlivesmattertoostraat", 420, 9 }
                });

            migrationBuilder.InsertData(
                table: "TradeItems",
                columns: new[] { "Id", "Amount", "CreatedAt", "ModifiedAt", "ResourceId", "UserId" },
                values: new object[,]
                {
                    { 2, 10, new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(5955), new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(5955), 11, 8 },
                    { 26, 10, new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(6025), new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(6025), 39, 7 },
                    { 7, 42, new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(5978), new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(5978), 17, 7 },
                    { 20, 30, new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(6011), new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(6011), 36, 7 },
                    { 10, 634, new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(5986), new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(5986), 10, 9 },
                    { 9, 201, new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(5984), new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(5984), 9, 9 },
                    { 22, 69, new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(6015), new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(6015), 27, 9 },
                    { 1, 2, new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(4649), new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(4649), 51, 10 },
                    { 13, 69, new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(5993), new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(5993), 19, 10 },
                    { 11, 20, new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(5989), new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(5989), 17, 11 },
                    { 19, 17, new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(6008), new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(6008), 7, 12 },
                    { 3, 50, new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(5967), new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(5967), 32, 13 },
                    { 8, 75, new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(5981), new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(5981), 8, 8 },
                    { 12, 75, new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(5991), new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(5991), 26, 13 },
                    { 25, 20, new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(6023), new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(6023), 48, 6 },
                    { 6, 30, new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(5976), new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(5976), 6, 6 },
                    { 18, 9, new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(6006), new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(6006), 6, 1 },
                    { 23, 180, new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(6018), new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(6018), 37, 1 },
                    { 24, 47, new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(6020), new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(6020), 47, 2 },
                    { 14, 25, new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(5996), new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(5996), 49, 3 },
                    { 21, 78, new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(6013), new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(6013), 23, 6 },
                    { 4, 69, new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(5971), new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(5971), 24, 4 },
                    { 15, 35, new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(5998), new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(5998), 50, 4 },
                    { 17, 10, new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(6003), new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(6003), 1, 3 },
                    { 5, 45, new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(5973), new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(5973), 45, 5 },
                    { 16, 75, new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(6001), new DateTime(2021, 5, 20, 23, 32, 7, 737, DateTimeKind.Local).AddTicks(6001), 7, 5 }
                });

            migrationBuilder.InsertData(
                table: "Trades",
                columns: new[] { "Id", "ActiveUserId", "Completed", "CreatedAt", "ModifiedAt", "ProposerId", "ReceiverId" },
                values: new object[,]
                {
                    { 4, 5, false, new DateTime(2021, 5, 20, 23, 32, 7, 736, DateTimeKind.Local).AddTicks(6679), new DateTime(2021, 5, 20, 23, 32, 7, 736, DateTimeKind.Local).AddTicks(6679), 5, 2 },
                    { 3, 4, false, new DateTime(2021, 5, 20, 23, 32, 7, 736, DateTimeKind.Local).AddTicks(6674), new DateTime(2021, 5, 20, 23, 32, 7, 736, DateTimeKind.Local).AddTicks(6674), 4, 2 },
                    { 5, 5, false, new DateTime(2021, 5, 20, 23, 32, 7, 736, DateTimeKind.Local).AddTicks(6683), new DateTime(2021, 5, 20, 23, 32, 7, 736, DateTimeKind.Local).AddTicks(6683), 1, 5 }
                });

            migrationBuilder.InsertData(
                table: "Trades",
                columns: new[] { "Id", "ActiveUserId", "Completed", "CreatedAt", "ModifiedAt", "ProposerId", "ReceiverId" },
                values: new object[,]
                {
                    { 6, 1, false, new DateTime(2021, 5, 20, 23, 32, 7, 736, DateTimeKind.Local).AddTicks(6687), new DateTime(2021, 5, 20, 23, 32, 7, 736, DateTimeKind.Local).AddTicks(6687), 3, 1 },
                    { 2, 3, false, new DateTime(2021, 5, 20, 23, 32, 7, 736, DateTimeKind.Local).AddTicks(6655), new DateTime(2021, 5, 20, 23, 32, 7, 736, DateTimeKind.Local).AddTicks(6655), 3, 1 },
                    { 1, 1, true, new DateTime(2021, 5, 20, 23, 32, 7, 736, DateTimeKind.Local).AddTicks(4097), new DateTime(2021, 5, 20, 23, 32, 7, 736, DateTimeKind.Local).AddTicks(4097), 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "UserId", "VAmount" },
                values: new object[,]
                {
                    { 6, new DateTime(2021, 5, 20, 23, 32, 7, 734, DateTimeKind.Local).AddTicks(4703), new DateTime(2021, 5, 20, 23, 32, 7, 734, DateTimeKind.Local).AddTicks(4703), 6, 36m },
                    { 5, new DateTime(2021, 5, 20, 23, 32, 7, 734, DateTimeKind.Local).AddTicks(4700), new DateTime(2021, 5, 20, 23, 32, 7, 734, DateTimeKind.Local).AddTicks(4700), 5, 753m },
                    { 12, new DateTime(2021, 5, 20, 23, 32, 7, 734, DateTimeKind.Local).AddTicks(4718), new DateTime(2021, 5, 20, 23, 32, 7, 734, DateTimeKind.Local).AddTicks(4718), 12, 57m },
                    { 1, new DateTime(2021, 5, 20, 23, 32, 7, 734, DateTimeKind.Local).AddTicks(3667), new DateTime(2021, 5, 20, 23, 32, 7, 734, DateTimeKind.Local).AddTicks(3667), 1, 200m },
                    { 11, new DateTime(2021, 5, 20, 23, 32, 7, 734, DateTimeKind.Local).AddTicks(4716), new DateTime(2021, 5, 20, 23, 32, 7, 734, DateTimeKind.Local).AddTicks(4716), 11, 269m },
                    { 10, new DateTime(2021, 5, 20, 23, 32, 7, 734, DateTimeKind.Local).AddTicks(4713), new DateTime(2021, 5, 20, 23, 32, 7, 734, DateTimeKind.Local).AddTicks(4713), 10, 124m },
                    { 4, new DateTime(2021, 5, 20, 23, 32, 7, 734, DateTimeKind.Local).AddTicks(4698), new DateTime(2021, 5, 20, 23, 32, 7, 734, DateTimeKind.Local).AddTicks(4698), 4, 42m },
                    { 9, new DateTime(2021, 5, 20, 23, 32, 7, 734, DateTimeKind.Local).AddTicks(4711), new DateTime(2021, 5, 20, 23, 32, 7, 734, DateTimeKind.Local).AddTicks(4711), 9, 357m },
                    { 3, new DateTime(2021, 5, 20, 23, 32, 7, 734, DateTimeKind.Local).AddTicks(4695), new DateTime(2021, 5, 20, 23, 32, 7, 734, DateTimeKind.Local).AddTicks(4695), 3, 65m },
                    { 7, new DateTime(2021, 5, 20, 23, 32, 7, 734, DateTimeKind.Local).AddTicks(4706), new DateTime(2021, 5, 20, 23, 32, 7, 734, DateTimeKind.Local).AddTicks(4706), 7, 12m },
                    { 8, new DateTime(2021, 5, 20, 23, 32, 7, 734, DateTimeKind.Local).AddTicks(4708), new DateTime(2021, 5, 20, 23, 32, 7, 734, DateTimeKind.Local).AddTicks(4708), 8, 654m },
                    { 2, new DateTime(2021, 5, 20, 23, 32, 7, 734, DateTimeKind.Local).AddTicks(4681), new DateTime(2021, 5, 20, 23, 32, 7, 734, DateTimeKind.Local).AddTicks(4681), 2, 347m },
                    { 13, new DateTime(2021, 5, 20, 23, 32, 7, 734, DateTimeKind.Local).AddTicks(4721), new DateTime(2021, 5, 20, 23, 32, 7, 734, DateTimeKind.Local).AddTicks(4721), 13, 204m }
                });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "CreatedAt", "EuroAmount", "ModifiedAt", "VAmount", "WalletId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 20, 23, 32, 7, 738, DateTimeKind.Local).AddTicks(2626), 6.9m, new DateTime(2021, 5, 20, 23, 32, 7, 738, DateTimeKind.Local).AddTicks(2626), 69m, 1 },
                    { 4, new DateTime(2021, 5, 20, 23, 32, 7, 738, DateTimeKind.Local).AddTicks(4259), 10m, new DateTime(2021, 5, 20, 23, 32, 7, 738, DateTimeKind.Local).AddTicks(4259), 100m, 6 },
                    { 3, new DateTime(2021, 5, 20, 23, 32, 7, 738, DateTimeKind.Local).AddTicks(4256), 42m, new DateTime(2021, 5, 20, 23, 32, 7, 738, DateTimeKind.Local).AddTicks(4256), 420m, 5 },
                    { 7, new DateTime(2021, 5, 20, 23, 32, 7, 738, DateTimeKind.Local).AddTicks(4268), 9.8m, new DateTime(2021, 5, 20, 23, 32, 7, 738, DateTimeKind.Local).AddTicks(4268), 98m, 9 },
                    { 6, new DateTime(2021, 5, 20, 23, 32, 7, 738, DateTimeKind.Local).AddTicks(4266), 7.8m, new DateTime(2021, 5, 20, 23, 32, 7, 738, DateTimeKind.Local).AddTicks(4266), 78m, 10 },
                    { 10, new DateTime(2021, 5, 20, 23, 32, 7, 738, DateTimeKind.Local).AddTicks(4276), 2m, new DateTime(2021, 5, 20, 23, 32, 7, 738, DateTimeKind.Local).AddTicks(4276), 20m, 4 },
                    { 8, new DateTime(2021, 5, 20, 23, 32, 7, 738, DateTimeKind.Local).AddTicks(4271), 5m, new DateTime(2021, 5, 20, 23, 32, 7, 738, DateTimeKind.Local).AddTicks(4271), 50m, 7 },
                    { 9, new DateTime(2021, 5, 20, 23, 32, 7, 738, DateTimeKind.Local).AddTicks(4273), 13m, new DateTime(2021, 5, 20, 23, 32, 7, 738, DateTimeKind.Local).AddTicks(4273), 130m, 3 },
                    { 5, new DateTime(2021, 5, 20, 23, 32, 7, 738, DateTimeKind.Local).AddTicks(4263), 3.6m, new DateTime(2021, 5, 20, 23, 32, 7, 738, DateTimeKind.Local).AddTicks(4263), 36m, 12 },
                    { 2, new DateTime(2021, 5, 20, 23, 32, 7, 738, DateTimeKind.Local).AddTicks(4242), 2m, new DateTime(2021, 5, 20, 23, 32, 7, 738, DateTimeKind.Local).AddTicks(4242), 20m, 1 }
                });

            migrationBuilder.InsertData(
                table: "TradeItemProposals",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "ProposedAmount", "TradeId", "TradeItemId" },
                values: new object[,]
                {
                    { 19, new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2087), new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2087), 23, 4, 19 },
                    { 13, new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2072), new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2072), 17, 3, 13 },
                    { 2, new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2033), new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2033), 6, 2, 2 },
                    { 22, new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2094), new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2094), 26, 2, 22 },
                    { 10, new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2064), new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2064), 14, 5, 10 },
                    { 9, new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2062), new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2062), 13, 4, 9 },
                    { 8, new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2060), new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2060), 12, 3, 8 },
                    { 11, new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2067), new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2067), 15, 1, 11 },
                    { 1, new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(639), new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(639), 5, 1, 1 },
                    { 7, new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2057), new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2057), 11, 2, 7 },
                    { 3, new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2046), new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2046), 7, 3, 3 },
                    { 21, new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2092), new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2092), 25, 1, 21 },
                    { 6, new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2054), new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2054), 10, 1, 6 },
                    { 16, new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2079), new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2079), 20, 1, 16 },
                    { 5, new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2052), new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2052), 9, 5, 5 },
                    { 15, new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2077), new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2077), 19, 5, 15 },
                    { 14, new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2074), new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2074), 18, 4, 14 },
                    { 4, new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2049), new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2049), 8, 4, 4 },
                    { 23, new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2097), new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2097), 27, 3, 23 },
                    { 18, new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2084), new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2084), 22, 3, 18 },
                    { 17, new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2082), new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2082), 21, 2, 17 },
                    { 20, new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2089), new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2089), 24, 5, 20 },
                    { 12, new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2069), new DateTime(2021, 5, 20, 23, 32, 7, 739, DateTimeKind.Local).AddTicks(2069), 16, 2, 12 }
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