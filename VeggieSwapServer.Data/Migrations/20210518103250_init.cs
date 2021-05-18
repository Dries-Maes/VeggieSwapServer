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
                name: "Trades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trades", x => x.Id);
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
                    TradeId = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_TradeItems_Trades_TradeId",
                        column: x => x.TradeId,
                        principalTable: "Trades",
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
                values: new object[] { 1, new DateTime(2021, 5, 18, 12, 32, 49, 702, DateTimeKind.Local).AddTicks(864), "artichokes.svg", new DateTime(2021, 5, 18, 12, 32, 49, 702, DateTimeKind.Local).AddTicks(864), "Artichokes" });

            migrationBuilder.InsertData(
                table: "Trades",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt" },
                values: new object[] { 1, new DateTime(2021, 5, 18, 12, 32, 49, 702, DateTimeKind.Local).AddTicks(6314), new DateTime(2021, 5, 18, 12, 32, 49, 702, DateTimeKind.Local).AddTicks(6314) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "ImageUrl", "IsAdmin", "LastName", "ModifiedAt", "PasswordHash", "PasswordSalt" },
                values: new object[] { 1, new DateTime(2021, 5, 18, 12, 32, 49, 694, DateTimeKind.Local).AddTicks(9785), null, "Kobe", "https://robohash.org/Kobe", true, "Delo", new DateTime(2021, 5, 18, 12, 32, 49, 694, DateTimeKind.Local).AddTicks(9785), null, null });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "PostalCode", "StreetName", "StreetNumber", "UserId" },
                values: new object[] { 1, new DateTime(2021, 5, 18, 12, 32, 49, 700, DateTimeKind.Local).AddTicks(3455), new DateTime(2021, 5, 18, 12, 32, 49, 700, DateTimeKind.Local).AddTicks(3455), 9000, "Anti-Veggiestraat", 89, 1 });

            migrationBuilder.InsertData(
                table: "TradeItems",
                columns: new[] { "Id", "Amount", "CreatedAt", "ModifiedAt", "ResourceId", "TradeId", "UserId" },
                values: new object[] { 1, 25, new DateTime(2021, 5, 18, 12, 32, 49, 702, DateTimeKind.Local).AddTicks(9914), new DateTime(2021, 5, 18, 12, 32, 49, 702, DateTimeKind.Local).AddTicks(9914), 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "UserId", "VAmount" },
                values: new object[] { 1, new DateTime(2021, 5, 18, 12, 32, 49, 701, DateTimeKind.Local).AddTicks(5949), new DateTime(2021, 5, 18, 12, 32, 49, 701, DateTimeKind.Local).AddTicks(5949), 1, 200m });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "CreatedAt", "EuroAmount", "ModifiedAt", "VAmount", "WalletId" },
                values: new object[] { 1, new DateTime(2021, 5, 18, 12, 32, 49, 704, DateTimeKind.Local).AddTicks(987), 6.9m, new DateTime(2021, 5, 18, 12, 32, 49, 704, DateTimeKind.Local).AddTicks(987), 69m, 1 });

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
                name: "IX_TradeItems_ResourceId",
                table: "TradeItems",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeItems_TradeId",
                table: "TradeItems",
                column: "TradeId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeItems_UserId",
                table: "TradeItems",
                column: "UserId");

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
                name: "TradeItems");

            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Trades");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
