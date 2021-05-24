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
                    { 1, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(8530), "apples.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(8530), "apples" },
                    { 29, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9935), "olives.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9935), "olives" },
                    { 30, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9938), "oranges.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9938), "oranges" },
                    { 31, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9941), "papayas.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9941), "papayas" },
                    { 33, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9948), "pears.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9948), "pears" },
                    { 34, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9951), "peas.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9951), "peas" },
                    { 35, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9954), "pineapples.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9954), "pineapples" },
                    { 36, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9958), "pomegranates.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9958), "pomegranates" },
                    { 37, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9961), "potatoes.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9961), "potatoes" },
                    { 38, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9964), "pumpkins.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9964), "pumpkins" },
                    { 39, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9967), "radish.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9967), "radish" },
                    { 28, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9932), "mushrooms.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9932), "mushrooms" },
                    { 40, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9970), "radishes.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9970), "radishes" },
                    { 42, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9977), "salad.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9977), "salad" },
                    { 43, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9980), "salads.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9980), "salads" },
                    { 44, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9983), "scallions.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9983), "scallions" },
                    { 45, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9987), "spinach.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9987), "spinach" },
                    { 46, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9990), "star-fruits.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9990), "star-fruits" },
                    { 47, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9993), "strawberries.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9993), "strawberries" },
                    { 48, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9996), "sweet-potatoes.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9996), "sweet-potatoes" },
                    { 49, new DateTime(2021, 5, 24, 12, 33, 41, 703, DateTimeKind.Local), "tomatoes.svg", new DateTime(2021, 5, 24, 12, 33, 41, 703, DateTimeKind.Local), "tomatoes" },
                    { 50, new DateTime(2021, 5, 24, 12, 33, 41, 703, DateTimeKind.Local).AddTicks(3), "watermelons.svg", new DateTime(2021, 5, 24, 12, 33, 41, 703, DateTimeKind.Local).AddTicks(3), "watermelons" },
                    { 51, new DateTime(2021, 5, 24, 12, 33, 41, 703, DateTimeKind.Local).AddTicks(6), "v-coin.svg", new DateTime(2021, 5, 24, 12, 33, 41, 703, DateTimeKind.Local).AddTicks(6), "v-coin" },
                    { 41, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9974), "raspberries.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9974), "raspberries" },
                    { 27, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9928), "melons.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9928), "melons" },
                    { 32, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9945), "peaches.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9945), "peaches" },
                    { 25, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9922), "mangos.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9922), "mangos" },
                    { 2, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9831), "artichokes.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9831), "artichokes" },
                    { 3, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9848), "asparagus.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9848), "asparagus" },
                    { 4, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9852), "bananas.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9852), "bananas" },
                    { 5, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9855), "bell-peppers.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9855), "bell-peppers" },
                    { 6, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9859), "blueberries.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9859), "blueberries" },
                    { 7, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9862), "bok-choy.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9862), "bok-choy" },
                    { 26, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9925), "mangosteens.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9925), "mangosteens" },
                    { 9, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9869), "brussels-sprouts.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9869), "brussels-sprouts" },
                    { 10, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9872), "carrots.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9872), "carrots" },
                    { 11, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9876), "cherries.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9876), "cherries" },
                    { 12, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9879), "chilis.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9879), "chilis" },
                    { 13, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9883), "coconuts.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9883), "coconuts" },
                    { 8, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9866), "broccoli.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9866), "broccoli" },
                    { 15, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9889), "corn.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9889), "corn" },
                    { 16, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9892), "cucumbers.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9892), "cucumbers" }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "CreatedAt", "ImageUrl", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 17, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9896), "dragon-fruits.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9896), "dragon-fruits" },
                    { 18, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9899), "durians.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9899), "durians" },
                    { 19, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9902), "eggplants.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9902), "eggplants" },
                    { 20, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9905), "garlic.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9905), "garlic" },
                    { 21, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9909), "grapes.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9909), "grapes" },
                    { 22, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9912), "guavas.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9912), "guavas" },
                    { 23, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9915), "kiwis.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9915), "kiwis" },
                    { 24, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9919), "lemons.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9919), "lemons" },
                    { 14, new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9886), "coriander.svg", new DateTime(2021, 5, 24, 12, 33, 41, 702, DateTimeKind.Local).AddTicks(9886), "coriander" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "ImageUrl", "IsAdmin", "LastName", "ModifiedAt", "PasswordHash", "PasswordSalt" },
                values: new object[,]
                {
                    { 11, new DateTime(2021, 5, 24, 12, 33, 41, 695, DateTimeKind.Local).AddTicks(5785), "VerhofstadDeZeemlap@europeesemailadres.com", "Verhofstad", "https://robohash.org/Zeemlap", false, "Zeemlap", new DateTime(2021, 5, 24, 12, 33, 41, 695, DateTimeKind.Local).AddTicks(5785), new byte[] { 154, 253, 128, 114, 96, 236, 154, 141, 253, 29, 40, 100, 213, 81, 19, 33, 191, 75, 20, 76, 33, 92, 53, 124, 222, 122, 50, 245, 128, 173, 24, 184, 148, 55, 88, 125, 209, 7, 243, 222, 33, 32, 77, 101, 162, 18, 19, 115, 133, 199, 249, 34, 142, 72, 201, 189, 171, 142, 212, 2, 144, 164, 146, 4 }, new byte[] { 250, 141, 51, 223, 126, 13, 131, 89, 239, 240, 85, 43, 168, 245, 18, 243, 183, 51, 138, 141, 227, 185, 151, 169, 182, 165, 75, 31, 238, 121, 143, 1, 118, 16, 148, 177, 244, 125, 142, 217, 228, 176, 10, 139, 243, 164, 48, 251, 177, 6, 62, 202, 91, 134, 216, 139, 119, 66, 53, 24, 198, 254, 117, 176, 85, 26, 156, 171, 221, 169, 56, 13, 43, 247, 110, 162, 188, 118, 160, 115, 232, 141, 238, 167, 116, 6, 86, 203, 195, 148, 252, 94, 119, 199, 188, 114, 223, 216, 79, 35, 201, 141, 195, 213, 183, 133, 209, 164, 102, 80, 23, 48, 6, 205, 4, 51, 233, 167, 59, 103, 24, 31, 197, 30, 142, 88, 242, 186 } },
                    { 10, new DateTime(2021, 5, 24, 12, 33, 41, 695, DateTimeKind.Local).AddTicks(5765), "Luc@mail.com", "Luc", "https://robohash.org/Luc", false, "DeHaantje", new DateTime(2021, 5, 24, 12, 33, 41, 695, DateTimeKind.Local).AddTicks(5765), new byte[] { 154, 253, 128, 114, 96, 236, 154, 141, 253, 29, 40, 100, 213, 81, 19, 33, 191, 75, 20, 76, 33, 92, 53, 124, 222, 122, 50, 245, 128, 173, 24, 184, 148, 55, 88, 125, 209, 7, 243, 222, 33, 32, 77, 101, 162, 18, 19, 115, 133, 199, 249, 34, 142, 72, 201, 189, 171, 142, 212, 2, 144, 164, 146, 4 }, new byte[] { 250, 141, 51, 223, 126, 13, 131, 89, 239, 240, 85, 43, 168, 245, 18, 243, 183, 51, 138, 141, 227, 185, 151, 169, 182, 165, 75, 31, 238, 121, 143, 1, 118, 16, 148, 177, 244, 125, 142, 217, 228, 176, 10, 139, 243, 164, 48, 251, 177, 6, 62, 202, 91, 134, 216, 139, 119, 66, 53, 24, 198, 254, 117, 176, 85, 26, 156, 171, 221, 169, 56, 13, 43, 247, 110, 162, 188, 118, 160, 115, 232, 141, 238, 167, 116, 6, 86, 203, 195, 148, 252, 94, 119, 199, 188, 114, 223, 216, 79, 35, 201, 141, 195, 213, 183, 133, 209, 164, 102, 80, 23, 48, 6, 205, 4, 51, 233, 167, 59, 103, 24, 31, 197, 30, 142, 88, 242, 186 } },
                    { 9, new DateTime(2021, 5, 24, 12, 33, 41, 695, DateTimeKind.Local).AddTicks(5644), "Mihiel@mail.com", "Mihiel", "https://robohash.org/Mihiel", false, "Mihoen", new DateTime(2021, 5, 24, 12, 33, 41, 695, DateTimeKind.Local).AddTicks(5644), new byte[] { 154, 253, 128, 114, 96, 236, 154, 141, 253, 29, 40, 100, 213, 81, 19, 33, 191, 75, 20, 76, 33, 92, 53, 124, 222, 122, 50, 245, 128, 173, 24, 184, 148, 55, 88, 125, 209, 7, 243, 222, 33, 32, 77, 101, 162, 18, 19, 115, 133, 199, 249, 34, 142, 72, 201, 189, 171, 142, 212, 2, 144, 164, 146, 4 }, new byte[] { 250, 141, 51, 223, 126, 13, 131, 89, 239, 240, 85, 43, 168, 245, 18, 243, 183, 51, 138, 141, 227, 185, 151, 169, 182, 165, 75, 31, 238, 121, 143, 1, 118, 16, 148, 177, 244, 125, 142, 217, 228, 176, 10, 139, 243, 164, 48, 251, 177, 6, 62, 202, 91, 134, 216, 139, 119, 66, 53, 24, 198, 254, 117, 176, 85, 26, 156, 171, 221, 169, 56, 13, 43, 247, 110, 162, 188, 118, 160, 115, 232, 141, 238, 167, 116, 6, 86, 203, 195, 148, 252, 94, 119, 199, 188, 114, 223, 216, 79, 35, 201, 141, 195, 213, 183, 133, 209, 164, 102, 80, 23, 48, 6, 205, 4, 51, 233, 167, 59, 103, 24, 31, 197, 30, 142, 88, 242, 186 } },
                    { 8, new DateTime(2021, 5, 24, 12, 33, 41, 695, DateTimeKind.Local).AddTicks(5626), "Andreas@mail.com", "Andreas", "https://robohash.org/Andreas", false, "VanGrieken", new DateTime(2021, 5, 24, 12, 33, 41, 695, DateTimeKind.Local).AddTicks(5626), new byte[] { 154, 253, 128, 114, 96, 236, 154, 141, 253, 29, 40, 100, 213, 81, 19, 33, 191, 75, 20, 76, 33, 92, 53, 124, 222, 122, 50, 245, 128, 173, 24, 184, 148, 55, 88, 125, 209, 7, 243, 222, 33, 32, 77, 101, 162, 18, 19, 115, 133, 199, 249, 34, 142, 72, 201, 189, 171, 142, 212, 2, 144, 164, 146, 4 }, new byte[] { 250, 141, 51, 223, 126, 13, 131, 89, 239, 240, 85, 43, 168, 245, 18, 243, 183, 51, 138, 141, 227, 185, 151, 169, 182, 165, 75, 31, 238, 121, 143, 1, 118, 16, 148, 177, 244, 125, 142, 217, 228, 176, 10, 139, 243, 164, 48, 251, 177, 6, 62, 202, 91, 134, 216, 139, 119, 66, 53, 24, 198, 254, 117, 176, 85, 26, 156, 171, 221, 169, 56, 13, 43, 247, 110, 162, 188, 118, 160, 115, 232, 141, 238, 167, 116, 6, 86, 203, 195, 148, 252, 94, 119, 199, 188, 114, 223, 216, 79, 35, 201, 141, 195, 213, 183, 133, 209, 164, 102, 80, 23, 48, 6, 205, 4, 51, 233, 167, 59, 103, 24, 31, 197, 30, 142, 88, 242, 186 } },
                    { 7, new DateTime(2021, 5, 24, 12, 33, 41, 695, DateTimeKind.Local).AddTicks(5607), "Dirk@mail.com", "Dirk", "https://robohash.org/Dirk", false, "Visser", new DateTime(2021, 5, 24, 12, 33, 41, 695, DateTimeKind.Local).AddTicks(5607), new byte[] { 154, 253, 128, 114, 96, 236, 154, 141, 253, 29, 40, 100, 213, 81, 19, 33, 191, 75, 20, 76, 33, 92, 53, 124, 222, 122, 50, 245, 128, 173, 24, 184, 148, 55, 88, 125, 209, 7, 243, 222, 33, 32, 77, 101, 162, 18, 19, 115, 133, 199, 249, 34, 142, 72, 201, 189, 171, 142, 212, 2, 144, 164, 146, 4 }, new byte[] { 250, 141, 51, 223, 126, 13, 131, 89, 239, 240, 85, 43, 168, 245, 18, 243, 183, 51, 138, 141, 227, 185, 151, 169, 182, 165, 75, 31, 238, 121, 143, 1, 118, 16, 148, 177, 244, 125, 142, 217, 228, 176, 10, 139, 243, 164, 48, 251, 177, 6, 62, 202, 91, 134, 216, 139, 119, 66, 53, 24, 198, 254, 117, 176, 85, 26, 156, 171, 221, 169, 56, 13, 43, 247, 110, 162, 188, 118, 160, 115, 232, 141, 238, 167, 116, 6, 86, 203, 195, 148, 252, 94, 119, 199, 188, 114, 223, 216, 79, 35, 201, 141, 195, 213, 183, 133, 209, 164, 102, 80, 23, 48, 6, 205, 4, 51, 233, 167, 59, 103, 24, 31, 197, 30, 142, 88, 242, 186 } },
                    { 1, new DateTime(2021, 5, 24, 12, 33, 41, 685, DateTimeKind.Local).AddTicks(7315), "Pieter@mail.com", "Pieter", "https://robohash.org/Pieter", true, "Corp", new DateTime(2021, 5, 24, 12, 33, 41, 685, DateTimeKind.Local).AddTicks(7315), new byte[] { 154, 253, 128, 114, 96, 236, 154, 141, 253, 29, 40, 100, 213, 81, 19, 33, 191, 75, 20, 76, 33, 92, 53, 124, 222, 122, 50, 245, 128, 173, 24, 184, 148, 55, 88, 125, 209, 7, 243, 222, 33, 32, 77, 101, 162, 18, 19, 115, 133, 199, 249, 34, 142, 72, 201, 189, 171, 142, 212, 2, 144, 164, 146, 4 }, new byte[] { 250, 141, 51, 223, 126, 13, 131, 89, 239, 240, 85, 43, 168, 245, 18, 243, 183, 51, 138, 141, 227, 185, 151, 169, 182, 165, 75, 31, 238, 121, 143, 1, 118, 16, 148, 177, 244, 125, 142, 217, 228, 176, 10, 139, 243, 164, 48, 251, 177, 6, 62, 202, 91, 134, 216, 139, 119, 66, 53, 24, 198, 254, 117, 176, 85, 26, 156, 171, 221, 169, 56, 13, 43, 247, 110, 162, 188, 118, 160, 115, 232, 141, 238, 167, 116, 6, 86, 203, 195, 148, 252, 94, 119, 199, 188, 114, 223, 216, 79, 35, 201, 141, 195, 213, 183, 133, 209, 164, 102, 80, 23, 48, 6, 205, 4, 51, 233, 167, 59, 103, 24, 31, 197, 30, 142, 88, 242, 186 } },
                    { 5, new DateTime(2021, 5, 24, 12, 33, 41, 695, DateTimeKind.Local).AddTicks(5569), "BartjeWevertje@mail.com", "BartjeWevertje", "https://robohash.org/BartjeWevertje", false, "Wevertje", new DateTime(2021, 5, 24, 12, 33, 41, 695, DateTimeKind.Local).AddTicks(5569), new byte[] { 154, 253, 128, 114, 96, 236, 154, 141, 253, 29, 40, 100, 213, 81, 19, 33, 191, 75, 20, 76, 33, 92, 53, 124, 222, 122, 50, 245, 128, 173, 24, 184, 148, 55, 88, 125, 209, 7, 243, 222, 33, 32, 77, 101, 162, 18, 19, 115, 133, 199, 249, 34, 142, 72, 201, 189, 171, 142, 212, 2, 144, 164, 146, 4 }, new byte[] { 250, 141, 51, 223, 126, 13, 131, 89, 239, 240, 85, 43, 168, 245, 18, 243, 183, 51, 138, 141, 227, 185, 151, 169, 182, 165, 75, 31, 238, 121, 143, 1, 118, 16, 148, 177, 244, 125, 142, 217, 228, 176, 10, 139, 243, 164, 48, 251, 177, 6, 62, 202, 91, 134, 216, 139, 119, 66, 53, 24, 198, 254, 117, 176, 85, 26, 156, 171, 221, 169, 56, 13, 43, 247, 110, 162, 188, 118, 160, 115, 232, 141, 238, 167, 116, 6, 86, 203, 195, 148, 252, 94, 119, 199, 188, 114, 223, 216, 79, 35, 201, 141, 195, 213, 183, 133, 209, 164, 102, 80, 23, 48, 6, 205, 4, 51, 233, 167, 59, 103, 24, 31, 197, 30, 142, 88, 242, 186 } },
                    { 4, new DateTime(2021, 5, 24, 12, 33, 41, 695, DateTimeKind.Local).AddTicks(5549), "Dries@mail.com", "Dries", "https://robohash.org/Dries", true, "Maes", new DateTime(2021, 5, 24, 12, 33, 41, 695, DateTimeKind.Local).AddTicks(5549), new byte[] { 154, 253, 128, 114, 96, 236, 154, 141, 253, 29, 40, 100, 213, 81, 19, 33, 191, 75, 20, 76, 33, 92, 53, 124, 222, 122, 50, 245, 128, 173, 24, 184, 148, 55, 88, 125, 209, 7, 243, 222, 33, 32, 77, 101, 162, 18, 19, 115, 133, 199, 249, 34, 142, 72, 201, 189, 171, 142, 212, 2, 144, 164, 146, 4 }, new byte[] { 250, 141, 51, 223, 126, 13, 131, 89, 239, 240, 85, 43, 168, 245, 18, 243, 183, 51, 138, 141, 227, 185, 151, 169, 182, 165, 75, 31, 238, 121, 143, 1, 118, 16, 148, 177, 244, 125, 142, 217, 228, 176, 10, 139, 243, 164, 48, 251, 177, 6, 62, 202, 91, 134, 216, 139, 119, 66, 53, 24, 198, 254, 117, 176, 85, 26, 156, 171, 221, 169, 56, 13, 43, 247, 110, 162, 188, 118, 160, 115, 232, 141, 238, 167, 116, 6, 86, 203, 195, 148, 252, 94, 119, 199, 188, 114, 223, 216, 79, 35, 201, 141, 195, 213, 183, 133, 209, 164, 102, 80, 23, 48, 6, 205, 4, 51, 233, 167, 59, 103, 24, 31, 197, 30, 142, 88, 242, 186 } },
                    { 3, new DateTime(2021, 5, 24, 12, 33, 41, 695, DateTimeKind.Local).AddTicks(5517), "Kobe@mail.com", "Kobe", "https://robohash.org/Kobe", true, "Delo", new DateTime(2021, 5, 24, 12, 33, 41, 695, DateTimeKind.Local).AddTicks(5517), new byte[] { 154, 253, 128, 114, 96, 236, 154, 141, 253, 29, 40, 100, 213, 81, 19, 33, 191, 75, 20, 76, 33, 92, 53, 124, 222, 122, 50, 245, 128, 173, 24, 184, 148, 55, 88, 125, 209, 7, 243, 222, 33, 32, 77, 101, 162, 18, 19, 115, 133, 199, 249, 34, 142, 72, 201, 189, 171, 142, 212, 2, 144, 164, 146, 4 }, new byte[] { 250, 141, 51, 223, 126, 13, 131, 89, 239, 240, 85, 43, 168, 245, 18, 243, 183, 51, 138, 141, 227, 185, 151, 169, 182, 165, 75, 31, 238, 121, 143, 1, 118, 16, 148, 177, 244, 125, 142, 217, 228, 176, 10, 139, 243, 164, 48, 251, 177, 6, 62, 202, 91, 134, 216, 139, 119, 66, 53, 24, 198, 254, 117, 176, 85, 26, 156, 171, 221, 169, 56, 13, 43, 247, 110, 162, 188, 118, 160, 115, 232, 141, 238, 167, 116, 6, 86, 203, 195, 148, 252, 94, 119, 199, 188, 114, 223, 216, 79, 35, 201, 141, 195, 213, 183, 133, 209, 164, 102, 80, 23, 48, 6, 205, 4, 51, 233, 167, 59, 103, 24, 31, 197, 30, 142, 88, 242, 186 } },
                    { 2, new DateTime(2021, 5, 24, 12, 33, 41, 695, DateTimeKind.Local).AddTicks(5211), "Nick@mail.com", "Nick", "https://robohash.org/Nick", true, "Vr", new DateTime(2021, 5, 24, 12, 33, 41, 695, DateTimeKind.Local).AddTicks(5211), new byte[] { 154, 253, 128, 114, 96, 236, 154, 141, 253, 29, 40, 100, 213, 81, 19, 33, 191, 75, 20, 76, 33, 92, 53, 124, 222, 122, 50, 245, 128, 173, 24, 184, 148, 55, 88, 125, 209, 7, 243, 222, 33, 32, 77, 101, 162, 18, 19, 115, 133, 199, 249, 34, 142, 72, 201, 189, 171, 142, 212, 2, 144, 164, 146, 4 }, new byte[] { 250, 141, 51, 223, 126, 13, 131, 89, 239, 240, 85, 43, 168, 245, 18, 243, 183, 51, 138, 141, 227, 185, 151, 169, 182, 165, 75, 31, 238, 121, 143, 1, 118, 16, 148, 177, 244, 125, 142, 217, 228, 176, 10, 139, 243, 164, 48, 251, 177, 6, 62, 202, 91, 134, 216, 139, 119, 66, 53, 24, 198, 254, 117, 176, 85, 26, 156, 171, 221, 169, 56, 13, 43, 247, 110, 162, 188, 118, 160, 115, 232, 141, 238, 167, 116, 6, 86, 203, 195, 148, 252, 94, 119, 199, 188, 114, 223, 216, 79, 35, 201, 141, 195, 213, 183, 133, 209, 164, 102, 80, 23, 48, 6, 205, 4, 51, 233, 167, 59, 103, 24, 31, 197, 30, 142, 88, 242, 186 } },
                    { 12, new DateTime(2021, 5, 24, 12, 33, 41, 695, DateTimeKind.Local).AddTicks(5804), "Driesdentweedenmaarnidezelfden@mail.com", "Dries", "https://robohash.org/Dries2", false, "VanKorteNekke", new DateTime(2021, 5, 24, 12, 33, 41, 695, DateTimeKind.Local).AddTicks(5804), new byte[] { 154, 253, 128, 114, 96, 236, 154, 141, 253, 29, 40, 100, 213, 81, 19, 33, 191, 75, 20, 76, 33, 92, 53, 124, 222, 122, 50, 245, 128, 173, 24, 184, 148, 55, 88, 125, 209, 7, 243, 222, 33, 32, 77, 101, 162, 18, 19, 115, 133, 199, 249, 34, 142, 72, 201, 189, 171, 142, 212, 2, 144, 164, 146, 4 }, new byte[] { 250, 141, 51, 223, 126, 13, 131, 89, 239, 240, 85, 43, 168, 245, 18, 243, 183, 51, 138, 141, 227, 185, 151, 169, 182, 165, 75, 31, 238, 121, 143, 1, 118, 16, 148, 177, 244, 125, 142, 217, 228, 176, 10, 139, 243, 164, 48, 251, 177, 6, 62, 202, 91, 134, 216, 139, 119, 66, 53, 24, 198, 254, 117, 176, 85, 26, 156, 171, 221, 169, 56, 13, 43, 247, 110, 162, 188, 118, 160, 115, 232, 141, 238, 167, 116, 6, 86, 203, 195, 148, 252, 94, 119, 199, 188, 114, 223, 216, 79, 35, 201, 141, 195, 213, 183, 133, 209, 164, 102, 80, 23, 48, 6, 205, 4, 51, 233, 167, 59, 103, 24, 31, 197, 30, 142, 88, 242, 186 } },
                    { 6, new DateTime(2021, 5, 24, 12, 33, 41, 695, DateTimeKind.Local).AddTicks(5588), "Stofzuiger@mail.com", "Stofzuiger", "https://robohash.org/Stofzuiger", false, "Zuiger", new DateTime(2021, 5, 24, 12, 33, 41, 695, DateTimeKind.Local).AddTicks(5588), new byte[] { 154, 253, 128, 114, 96, 236, 154, 141, 253, 29, 40, 100, 213, 81, 19, 33, 191, 75, 20, 76, 33, 92, 53, 124, 222, 122, 50, 245, 128, 173, 24, 184, 148, 55, 88, 125, 209, 7, 243, 222, 33, 32, 77, 101, 162, 18, 19, 115, 133, 199, 249, 34, 142, 72, 201, 189, 171, 142, 212, 2, 144, 164, 146, 4 }, new byte[] { 250, 141, 51, 223, 126, 13, 131, 89, 239, 240, 85, 43, 168, 245, 18, 243, 183, 51, 138, 141, 227, 185, 151, 169, 182, 165, 75, 31, 238, 121, 143, 1, 118, 16, 148, 177, 244, 125, 142, 217, 228, 176, 10, 139, 243, 164, 48, 251, 177, 6, 62, 202, 91, 134, 216, 139, 119, 66, 53, 24, 198, 254, 117, 176, 85, 26, 156, 171, 221, 169, 56, 13, 43, 247, 110, 162, 188, 118, 160, 115, 232, 141, 238, 167, 116, 6, 86, 203, 195, 148, 252, 94, 119, 199, 188, 114, 223, 216, 79, 35, 201, 141, 195, 213, 183, 133, 209, 164, 102, 80, 23, 48, 6, 205, 4, 51, 233, 167, 59, 103, 24, 31, 197, 30, 142, 88, 242, 186 } },
                    { 13, new DateTime(2021, 5, 24, 12, 33, 41, 695, DateTimeKind.Local).AddTicks(5823), "Joyce@mail.com", "Joyce", "https://robohash.org/Tomatenplukker", false, "Tomatenplukker", new DateTime(2021, 5, 24, 12, 33, 41, 695, DateTimeKind.Local).AddTicks(5823), new byte[] { 154, 253, 128, 114, 96, 236, 154, 141, 253, 29, 40, 100, 213, 81, 19, 33, 191, 75, 20, 76, 33, 92, 53, 124, 222, 122, 50, 245, 128, 173, 24, 184, 148, 55, 88, 125, 209, 7, 243, 222, 33, 32, 77, 101, 162, 18, 19, 115, 133, 199, 249, 34, 142, 72, 201, 189, 171, 142, 212, 2, 144, 164, 146, 4 }, new byte[] { 250, 141, 51, 223, 126, 13, 131, 89, 239, 240, 85, 43, 168, 245, 18, 243, 183, 51, 138, 141, 227, 185, 151, 169, 182, 165, 75, 31, 238, 121, 143, 1, 118, 16, 148, 177, 244, 125, 142, 217, 228, 176, 10, 139, 243, 164, 48, 251, 177, 6, 62, 202, 91, 134, 216, 139, 119, 66, 53, 24, 198, 254, 117, 176, 85, 26, 156, 171, 221, 169, 56, 13, 43, 247, 110, 162, 188, 118, 160, 115, 232, 141, 238, 167, 116, 6, 86, 203, 195, 148, 252, 94, 119, 199, 188, 114, 223, 216, 79, 35, 201, 141, 195, 213, 183, 133, 209, 164, 102, 80, 23, 48, 6, 205, 4, 51, 233, 167, 59, 103, 24, 31, 197, 30, 142, 88, 242, 186 } }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "PostalCode", "StreetName", "StreetNumber", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 24, 12, 33, 41, 698, DateTimeKind.Local).AddTicks(2083), new DateTime(2021, 5, 24, 12, 33, 41, 698, DateTimeKind.Local).AddTicks(2083), 9000, "Anti-Veggiestraat", 89, 1 },
                    { 8, new DateTime(2021, 5, 24, 12, 33, 41, 698, DateTimeKind.Local).AddTicks(4695), new DateTime(2021, 5, 24, 12, 33, 41, 698, DateTimeKind.Local).AddTicks(4695), 1000, "Kotsvisstraat", 96, 8 },
                    { 6, new DateTime(2021, 5, 24, 12, 33, 41, 698, DateTimeKind.Local).AddTicks(4688), new DateTime(2021, 5, 24, 12, 33, 41, 698, DateTimeKind.Local).AddTicks(4688), 1000, "Lookbroodjesstraat", 43, 6 },
                    { 9, new DateTime(2021, 5, 24, 12, 33, 41, 698, DateTimeKind.Local).AddTicks(4699), new DateTime(2021, 5, 24, 12, 33, 41, 698, DateTimeKind.Local).AddTicks(4699), 2000, "Greenlivesmattertoostraat", 420, 9 },
                    { 5, new DateTime(2021, 5, 24, 12, 33, 41, 698, DateTimeKind.Local).AddTicks(4684), new DateTime(2021, 5, 24, 12, 33, 41, 698, DateTimeKind.Local).AddTicks(4684), 9000, "Kobestraat", 85, 5 },
                    { 10, new DateTime(2021, 5, 24, 12, 33, 41, 698, DateTimeKind.Local).AddTicks(4702), new DateTime(2021, 5, 24, 12, 33, 41, 698, DateTimeKind.Local).AddTicks(4702), 9070, "Geenpolitiekinhetprojectstraat", 200, 10 },
                    { 11, new DateTime(2021, 5, 24, 12, 33, 41, 698, DateTimeKind.Local).AddTicks(4706), new DateTime(2021, 5, 24, 12, 33, 41, 698, DateTimeKind.Local).AddTicks(4706), 9500, "Kalfslapjesstraat", 32, 11 },
                    { 4, new DateTime(2021, 5, 24, 12, 33, 41, 698, DateTimeKind.Local).AddTicks(4680), new DateTime(2021, 5, 24, 12, 33, 41, 698, DateTimeKind.Local).AddTicks(4680), 1000, "Driesstraat", 66, 4 },
                    { 12, new DateTime(2021, 5, 24, 12, 33, 41, 698, DateTimeKind.Local).AddTicks(4710), new DateTime(2021, 5, 24, 12, 33, 41, 698, DateTimeKind.Local).AddTicks(4710), 1000, "Blacklivesmatterstraat", 78, 12 },
                    { 3, new DateTime(2021, 5, 24, 12, 33, 41, 698, DateTimeKind.Local).AddTicks(4676), new DateTime(2021, 5, 24, 12, 33, 41, 698, DateTimeKind.Local).AddTicks(4676), 4000, "Nickstraat", 74, 3 },
                    { 13, new DateTime(2021, 5, 24, 12, 33, 41, 698, DateTimeKind.Local).AddTicks(4713), new DateTime(2021, 5, 24, 12, 33, 41, 698, DateTimeKind.Local).AddTicks(4713), 7000, "Worstenbroodjesstraat", 4, 13 },
                    { 7, new DateTime(2021, 5, 24, 12, 33, 41, 698, DateTimeKind.Local).AddTicks(4692), new DateTime(2021, 5, 24, 12, 33, 41, 698, DateTimeKind.Local).AddTicks(4692), 9050, "Greenpeacestraat", 1, 7 },
                    { 2, new DateTime(2021, 5, 24, 12, 33, 41, 698, DateTimeKind.Local).AddTicks(4652), new DateTime(2021, 5, 24, 12, 33, 41, 698, DateTimeKind.Local).AddTicks(4652), 3000, "Pieterstreaat", 45, 2 }
                });

            migrationBuilder.InsertData(
                table: "TradeItems",
                columns: new[] { "Id", "Amount", "CreatedAt", "ModifiedAt", "ResourceId", "UserId" },
                values: new object[,]
                {
                    { 49, 21, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9316), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9316), 12, 12 },
                    { 30, 23, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9250), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9250), 13, 7 },
                    { 31, 36, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9253), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9253), 6, 7 },
                    { 32, 38, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9261), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9261), 51, 7 },
                    { 58, 8, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9343), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9343), 38, 13 },
                    { 57, 13, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9340), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9340), 29, 13 },
                    { 33, 78, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9264), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9264), 6, 8 },
                    { 34, 53, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9267), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9267), 51, 8 },
                    { 56, 17, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9337), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9337), 8, 13 },
                    { 35, 26, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9270), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9270), 51, 9 },
                    { 36, 17, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9273), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9273), 14, 9 },
                    { 37, 69, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9276), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9276), 36, 9 },
                    { 55, 9, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9334), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9334), 7, 13 },
                    { 54, 19, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9331), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9331), 12, 13 },
                    { 38, 34, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9279), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9279), 17, 10 },
                    { 39, 53, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9282), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9282), 19, 10 },
                    { 53, 33, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9328), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9328), 35, 13 },
                    { 40, 33, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9286), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9286), 51, 11 },
                    { 41, 17, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9289), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9289), 1, 11 },
                    { 59, 17, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9346), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9346), 41, 13 },
                    { 43, 28, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9295), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9295), 7, 11 },
                    { 52, 22, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9325), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9325), 48, 13 },
                    { 44, 78, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9299), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9299), 18, 12 },
                    { 45, 12, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9302), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9302), 29, 12 },
                    { 46, 25, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9306), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9306), 47, 12 },
                    { 51, 17, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9322), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9322), 47, 13 },
                    { 47, 34, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9310), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9310), 8, 12 },
                    { 48, 17, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9313), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9313), 9, 12 },
                    { 50, 17, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9319), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9319), 51, 13 }
                });

            migrationBuilder.InsertData(
                table: "TradeItems",
                columns: new[] { "Id", "Amount", "CreatedAt", "ModifiedAt", "ResourceId", "UserId" },
                values: new object[,]
                {
                    { 42, 3, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9292), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9292), 3, 11 },
                    { 29, 19, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9247), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9247), 8, 7 },
                    { 16, 17, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9206), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9206), 31, 3 },
                    { 13, 17, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9195), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9195), 8, 3 },
                    { 14, 49, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9199), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9199), 13, 3 },
                    { 15, 30, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9202), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9202), 6, 3 },
                    { 10, 32, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9186), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9186), 15, 2 },
                    { 9, 25, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9183), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9183), 39, 2 },
                    { 17, 89, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9209), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9209), 21, 4 },
                    { 8, 5, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9180), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9180), 32, 2 },
                    { 18, 36, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9213), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9213), 44, 4 },
                    { 19, 50, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9216), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9216), 51, 4 },
                    { 7, 40, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9177), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9177), 46, 2 },
                    { 6, 30, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9173), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9173), 34, 2 },
                    { 20, 47, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9219), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9219), 7, 5 },
                    { 12, 20, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9192), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9192), 4, 3 },
                    { 21, 63, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9222), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9222), 51, 5 },
                    { 23, 38, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9228), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9228), 46, 5 },
                    { 5, 41, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9170), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9170), 51, 2 },
                    { 24, 78, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9231), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9231), 32, 5 },
                    { 4, 99, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9167), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9167), 7, 1 },
                    { 3, 12, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9162), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9162), 5, 1 },
                    { 25, 5, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9234), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9234), 39, 6 },
                    { 2, 36, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9146), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9146), 3, 1 },
                    { 26, 10, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9238), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9238), 15, 6 },
                    { 27, 12, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9241), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9241), 51, 6 },
                    { 28, 10, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9244), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9244), 4, 6 },
                    { 1, 47, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(7469), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(7469), 1, 1 },
                    { 22, 39, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9225), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9225), 17, 5 },
                    { 11, 47, new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9189), new DateTime(2021, 5, 24, 12, 33, 41, 705, DateTimeKind.Local).AddTicks(9189), 51, 3 }
                });

            migrationBuilder.InsertData(
                table: "Trades",
                columns: new[] { "Id", "ActiveUserId", "Completed", "CreatedAt", "ModifiedAt", "ProposerId", "ReceiverId" },
                values: new object[,]
                {
                    { 1, 1, false, new DateTime(2021, 5, 24, 12, 33, 41, 703, DateTimeKind.Local).AddTicks(5702), new DateTime(2021, 5, 24, 12, 33, 41, 703, DateTimeKind.Local).AddTicks(5702), 2, 1 },
                    { 2, 3, false, new DateTime(2021, 5, 24, 12, 33, 41, 703, DateTimeKind.Local).AddTicks(8351), new DateTime(2021, 5, 24, 12, 33, 41, 703, DateTimeKind.Local).AddTicks(8351), 3, 2 },
                    { 6, 7, false, new DateTime(2021, 5, 24, 12, 33, 41, 703, DateTimeKind.Local).AddTicks(8382), new DateTime(2021, 5, 24, 12, 33, 41, 703, DateTimeKind.Local).AddTicks(8382), 7, 2 },
                    { 5, 7, false, new DateTime(2021, 5, 24, 12, 33, 41, 703, DateTimeKind.Local).AddTicks(8378), new DateTime(2021, 5, 24, 12, 33, 41, 703, DateTimeKind.Local).AddTicks(8378), 4, 7 },
                    { 4, 1, false, new DateTime(2021, 5, 24, 12, 33, 41, 703, DateTimeKind.Local).AddTicks(8375), new DateTime(2021, 5, 24, 12, 33, 41, 703, DateTimeKind.Local).AddTicks(8375), 1, 8 },
                    { 3, 6, false, new DateTime(2021, 5, 24, 12, 33, 41, 703, DateTimeKind.Local).AddTicks(8371), new DateTime(2021, 5, 24, 12, 33, 41, 703, DateTimeKind.Local).AddTicks(8371), 6, 8 }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "UserId", "VAmount" },
                values: new object[,]
                {
                    { 2, new DateTime(2021, 5, 24, 12, 33, 41, 700, DateTimeKind.Local).AddTicks(8404), new DateTime(2021, 5, 24, 12, 33, 41, 700, DateTimeKind.Local).AddTicks(8404), 2, 347m },
                    { 3, new DateTime(2021, 5, 24, 12, 33, 41, 700, DateTimeKind.Local).AddTicks(8494), new DateTime(2021, 5, 24, 12, 33, 41, 700, DateTimeKind.Local).AddTicks(8494), 3, 65m },
                    { 12, new DateTime(2021, 5, 24, 12, 33, 41, 700, DateTimeKind.Local).AddTicks(8604), new DateTime(2021, 5, 24, 12, 33, 41, 700, DateTimeKind.Local).AddTicks(8604), 12, 57m },
                    { 10, new DateTime(2021, 5, 24, 12, 33, 41, 700, DateTimeKind.Local).AddTicks(8580), new DateTime(2021, 5, 24, 12, 33, 41, 700, DateTimeKind.Local).AddTicks(8580), 10, 124m },
                    { 4, new DateTime(2021, 5, 24, 12, 33, 41, 700, DateTimeKind.Local).AddTicks(8510), new DateTime(2021, 5, 24, 12, 33, 41, 700, DateTimeKind.Local).AddTicks(8510), 4, 42m },
                    { 9, new DateTime(2021, 5, 24, 12, 33, 41, 700, DateTimeKind.Local).AddTicks(8567), new DateTime(2021, 5, 24, 12, 33, 41, 700, DateTimeKind.Local).AddTicks(8567), 9, 357m }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "UserId", "VAmount" },
                values: new object[,]
                {
                    { 8, new DateTime(2021, 5, 24, 12, 33, 41, 700, DateTimeKind.Local).AddTicks(8556), new DateTime(2021, 5, 24, 12, 33, 41, 700, DateTimeKind.Local).AddTicks(8556), 8, 654m },
                    { 5, new DateTime(2021, 5, 24, 12, 33, 41, 700, DateTimeKind.Local).AddTicks(8520), new DateTime(2021, 5, 24, 12, 33, 41, 700, DateTimeKind.Local).AddTicks(8520), 5, 753m },
                    { 1, new DateTime(2021, 5, 24, 12, 33, 41, 700, DateTimeKind.Local).AddTicks(446), new DateTime(2021, 5, 24, 12, 33, 41, 700, DateTimeKind.Local).AddTicks(446), 1, 200m },
                    { 7, new DateTime(2021, 5, 24, 12, 33, 41, 700, DateTimeKind.Local).AddTicks(8546), new DateTime(2021, 5, 24, 12, 33, 41, 700, DateTimeKind.Local).AddTicks(8546), 7, 12m },
                    { 6, new DateTime(2021, 5, 24, 12, 33, 41, 700, DateTimeKind.Local).AddTicks(8533), new DateTime(2021, 5, 24, 12, 33, 41, 700, DateTimeKind.Local).AddTicks(8533), 6, 36m },
                    { 11, new DateTime(2021, 5, 24, 12, 33, 41, 700, DateTimeKind.Local).AddTicks(8592), new DateTime(2021, 5, 24, 12, 33, 41, 700, DateTimeKind.Local).AddTicks(8592), 11, 269m },
                    { 13, new DateTime(2021, 5, 24, 12, 33, 41, 700, DateTimeKind.Local).AddTicks(8618), new DateTime(2021, 5, 24, 12, 33, 41, 700, DateTimeKind.Local).AddTicks(8618), 13, 204m }
                });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "CreatedAt", "EuroAmount", "ModifiedAt", "VAmount", "WalletId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 24, 12, 33, 41, 706, DateTimeKind.Local).AddTicks(8463), 6.9m, new DateTime(2021, 5, 24, 12, 33, 41, 706, DateTimeKind.Local).AddTicks(8463), 69m, 1 },
                    { 7, new DateTime(2021, 5, 24, 12, 33, 41, 707, DateTimeKind.Local).AddTicks(359), 9.8m, new DateTime(2021, 5, 24, 12, 33, 41, 707, DateTimeKind.Local).AddTicks(359), 98m, 9 },
                    { 8, new DateTime(2021, 5, 24, 12, 33, 41, 707, DateTimeKind.Local).AddTicks(362), 5m, new DateTime(2021, 5, 24, 12, 33, 41, 707, DateTimeKind.Local).AddTicks(362), 50m, 7 },
                    { 6, new DateTime(2021, 5, 24, 12, 33, 41, 707, DateTimeKind.Local).AddTicks(355), 7.8m, new DateTime(2021, 5, 24, 12, 33, 41, 707, DateTimeKind.Local).AddTicks(355), 78m, 10 },
                    { 4, new DateTime(2021, 5, 24, 12, 33, 41, 707, DateTimeKind.Local).AddTicks(348), 10m, new DateTime(2021, 5, 24, 12, 33, 41, 707, DateTimeKind.Local).AddTicks(348), 100m, 6 },
                    { 3, new DateTime(2021, 5, 24, 12, 33, 41, 707, DateTimeKind.Local).AddTicks(344), 42m, new DateTime(2021, 5, 24, 12, 33, 41, 707, DateTimeKind.Local).AddTicks(344), 420m, 5 },
                    { 10, new DateTime(2021, 5, 24, 12, 33, 41, 707, DateTimeKind.Local).AddTicks(368), 2m, new DateTime(2021, 5, 24, 12, 33, 41, 707, DateTimeKind.Local).AddTicks(368), 20m, 4 },
                    { 9, new DateTime(2021, 5, 24, 12, 33, 41, 707, DateTimeKind.Local).AddTicks(365), 13m, new DateTime(2021, 5, 24, 12, 33, 41, 707, DateTimeKind.Local).AddTicks(365), 130m, 3 },
                    { 5, new DateTime(2021, 5, 24, 12, 33, 41, 707, DateTimeKind.Local).AddTicks(351), 3.6m, new DateTime(2021, 5, 24, 12, 33, 41, 707, DateTimeKind.Local).AddTicks(351), 36m, 12 },
                    { 2, new DateTime(2021, 5, 24, 12, 33, 41, 707, DateTimeKind.Local).AddTicks(327), 2m, new DateTime(2021, 5, 24, 12, 33, 41, 707, DateTimeKind.Local).AddTicks(327), 20m, 1 }
                });

            migrationBuilder.InsertData(
                table: "TradeItemProposals",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "ProposedAmount", "TradeId", "TradeItemId" },
                values: new object[,]
                {
                    { 8, new DateTime(2021, 5, 24, 12, 33, 41, 708, DateTimeKind.Local).AddTicks(2377), new DateTime(2021, 5, 24, 12, 33, 41, 708, DateTimeKind.Local).AddTicks(2377), 15, 2, 14 },
                    { 11, new DateTime(2021, 5, 24, 12, 33, 41, 708, DateTimeKind.Local).AddTicks(2388), new DateTime(2021, 5, 24, 12, 33, 41, 708, DateTimeKind.Local).AddTicks(2388), 5, 4, 34 },
                    { 9, new DateTime(2021, 5, 24, 12, 33, 41, 708, DateTimeKind.Local).AddTicks(2380), new DateTime(2021, 5, 24, 12, 33, 41, 708, DateTimeKind.Local).AddTicks(2380), 5, 3, 33 },
                    { 15, new DateTime(2021, 5, 24, 12, 33, 41, 708, DateTimeKind.Local).AddTicks(2400), new DateTime(2021, 5, 24, 12, 33, 41, 708, DateTimeKind.Local).AddTicks(2400), 5, 4, 4 },
                    { 14, new DateTime(2021, 5, 24, 12, 33, 41, 708, DateTimeKind.Local).AddTicks(2397), new DateTime(2021, 5, 24, 12, 33, 41, 708, DateTimeKind.Local).AddTicks(2397), 15, 4, 3 },
                    { 13, new DateTime(2021, 5, 24, 12, 33, 41, 708, DateTimeKind.Local).AddTicks(2394), new DateTime(2021, 5, 24, 12, 33, 41, 708, DateTimeKind.Local).AddTicks(2394), 5, 4, 2 },
                    { 12, new DateTime(2021, 5, 24, 12, 33, 41, 708, DateTimeKind.Local).AddTicks(2391), new DateTime(2021, 5, 24, 12, 33, 41, 708, DateTimeKind.Local).AddTicks(2391), 15, 4, 1 },
                    { 10, new DateTime(2021, 5, 24, 12, 33, 41, 708, DateTimeKind.Local).AddTicks(2385), new DateTime(2021, 5, 24, 12, 33, 41, 708, DateTimeKind.Local).AddTicks(2385), 15, 3, 28 },
                    { 7, new DateTime(2021, 5, 24, 12, 33, 41, 708, DateTimeKind.Local).AddTicks(2373), new DateTime(2021, 5, 24, 12, 33, 41, 708, DateTimeKind.Local).AddTicks(2373), 5, 2, 13 },
                    { 1, new DateTime(2021, 5, 24, 12, 33, 41, 708, DateTimeKind.Local).AddTicks(299), new DateTime(2021, 5, 24, 12, 33, 41, 708, DateTimeKind.Local).AddTicks(299), 5, 1, 1 },
                    { 20, new DateTime(2021, 5, 24, 12, 33, 41, 708, DateTimeKind.Local).AddTicks(2415), new DateTime(2021, 5, 24, 12, 33, 41, 708, DateTimeKind.Local).AddTicks(2415), 15, 6, 30 },
                    { 19, new DateTime(2021, 5, 24, 12, 33, 41, 708, DateTimeKind.Local).AddTicks(2412), new DateTime(2021, 5, 24, 12, 33, 41, 708, DateTimeKind.Local).AddTicks(2412), 1, 6, 5 },
                    { 18, new DateTime(2021, 5, 24, 12, 33, 41, 708, DateTimeKind.Local).AddTicks(2410), new DateTime(2021, 5, 24, 12, 33, 41, 708, DateTimeKind.Local).AddTicks(2410), 15, 5, 18 },
                    { 2, new DateTime(2021, 5, 24, 12, 33, 41, 708, DateTimeKind.Local).AddTicks(2339), new DateTime(2021, 5, 24, 12, 33, 41, 708, DateTimeKind.Local).AddTicks(2339), 15, 1, 2 },
                    { 3, new DateTime(2021, 5, 24, 12, 33, 41, 708, DateTimeKind.Local).AddTicks(2358), new DateTime(2021, 5, 24, 12, 33, 41, 708, DateTimeKind.Local).AddTicks(2358), 5, 1, 3 },
                    { 4, new DateTime(2021, 5, 24, 12, 33, 41, 708, DateTimeKind.Local).AddTicks(2362), new DateTime(2021, 5, 24, 12, 33, 41, 708, DateTimeKind.Local).AddTicks(2362), 5, 1, 5 },
                    { 5, new DateTime(2021, 5, 24, 12, 33, 41, 708, DateTimeKind.Local).AddTicks(2366), new DateTime(2021, 5, 24, 12, 33, 41, 708, DateTimeKind.Local).AddTicks(2366), 5, 2, 6 },
                    { 6, new DateTime(2021, 5, 24, 12, 33, 41, 708, DateTimeKind.Local).AddTicks(2369), new DateTime(2021, 5, 24, 12, 33, 41, 708, DateTimeKind.Local).AddTicks(2369), 15, 2, 7 },
                    { 16, new DateTime(2021, 5, 24, 12, 33, 41, 708, DateTimeKind.Local).AddTicks(2403), new DateTime(2021, 5, 24, 12, 33, 41, 708, DateTimeKind.Local).AddTicks(2403), 3, 5, 32 },
                    { 17, new DateTime(2021, 5, 24, 12, 33, 41, 708, DateTimeKind.Local).AddTicks(2406), new DateTime(2021, 5, 24, 12, 33, 41, 708, DateTimeKind.Local).AddTicks(2406), 5, 5, 17 }
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
