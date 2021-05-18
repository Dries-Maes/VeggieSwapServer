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
                values: new object[] { 1, new DateTime(2021, 5, 18, 13, 28, 10, 889, DateTimeKind.Local).AddTicks(3041), "artichokes.svg", new DateTime(2021, 5, 18, 13, 28, 10, 889, DateTimeKind.Local).AddTicks(3041), "Artichokes" });

            migrationBuilder.InsertData(
                table: "Trades",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt" },
                values: new object[] { 1, new DateTime(2021, 5, 18, 13, 28, 10, 889, DateTimeKind.Local).AddTicks(6687), new DateTime(2021, 5, 18, 13, 28, 10, 889, DateTimeKind.Local).AddTicks(6687) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "ImageUrl", "IsAdmin", "LastName", "ModifiedAt", "PasswordHash", "PasswordSalt" },
                values: new object[] { 1, new DateTime(2021, 5, 18, 13, 28, 10, 882, DateTimeKind.Local).AddTicks(6137), "kobe@mail.com", "Kobe", "https://robohash.org/Kobe", true, "Delo", new DateTime(2021, 5, 18, 13, 28, 10, 882, DateTimeKind.Local).AddTicks(6137), new byte[] { 10, 133, 53, 120, 120, 216, 41, 232, 174, 152, 236, 213, 22, 73, 242, 123, 168, 218, 228, 237, 43, 140, 129, 142, 162, 247, 97, 150, 120, 142, 205, 72, 30, 219, 167, 80, 235, 196, 153, 236, 159, 43, 113, 34, 96, 192, 173, 153, 209, 91, 122, 218, 205, 213, 114, 35, 82, 58, 87, 61, 73, 192, 63, 179 }, new byte[] { 46, 27, 175, 50, 250, 135, 27, 29, 226, 26, 174, 219, 42, 124, 113, 46, 0, 51, 234, 102, 6, 97, 17, 72, 99, 142, 109, 56, 246, 171, 76, 2, 100, 171, 115, 190, 139, 106, 60, 130, 151, 188, 9, 244, 176, 176, 175, 172, 20, 98, 73, 249, 26, 52, 180, 215, 247, 90, 104, 116, 215, 110, 126, 245, 107, 62, 135, 121, 237, 227, 133, 172, 89, 149, 80, 24, 43, 132, 137, 156, 155, 38, 112, 213, 90, 59, 190, 48, 144, 58, 158, 84, 109, 63, 38, 254, 42, 172, 65, 157, 204, 251, 37, 110, 166, 27, 215, 6, 191, 60, 252, 203, 241, 168, 77, 127, 229, 251, 17, 30, 46, 54, 250, 1, 159, 71, 84, 11 } });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "PostalCode", "StreetName", "StreetNumber", "UserId" },
                values: new object[] { 1, new DateTime(2021, 5, 18, 13, 28, 10, 888, DateTimeKind.Local).AddTicks(3975), new DateTime(2021, 5, 18, 13, 28, 10, 888, DateTimeKind.Local).AddTicks(3975), 9000, "Anti-Veggiestraat", 89, 1 });

            migrationBuilder.InsertData(
                table: "TradeItems",
                columns: new[] { "Id", "Amount", "CreatedAt", "ModifiedAt", "ResourceId", "TradeId", "UserId" },
                values: new object[] { 1, 25, new DateTime(2021, 5, 18, 13, 28, 10, 889, DateTimeKind.Local).AddTicks(9687), new DateTime(2021, 5, 18, 13, 28, 10, 889, DateTimeKind.Local).AddTicks(9687), 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "UserId", "VAmount" },
                values: new object[] { 1, new DateTime(2021, 5, 18, 13, 28, 10, 888, DateTimeKind.Local).AddTicks(9106), new DateTime(2021, 5, 18, 13, 28, 10, 888, DateTimeKind.Local).AddTicks(9106), 1, 200m });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "CreatedAt", "EuroAmount", "ModifiedAt", "VAmount", "WalletId" },
                values: new object[] { 1, new DateTime(2021, 5, 18, 13, 28, 10, 890, DateTimeKind.Local).AddTicks(4769), 6.9m, new DateTime(2021, 5, 18, 13, 28, 10, 890, DateTimeKind.Local).AddTicks(4769), 69m, 1 });

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
