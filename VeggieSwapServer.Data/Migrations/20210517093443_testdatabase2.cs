using Microsoft.EntityFrameworkCore.Migrations;

namespace VeggieSwapServer.Data.Migrations
{
    public partial class testdatabase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trades_Wallets_WalletId",
                table: "Trades");

            migrationBuilder.DropTable(
                name: "TradeTradeItem");

            migrationBuilder.DropIndex(
                name: "IX_Trades_WalletId",
                table: "Trades");

            migrationBuilder.DropColumn(
                name: "WalletId",
                table: "Trades");

            migrationBuilder.AddColumn<int>(
                name: "TradeId",
                table: "TradeItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TradeWallet",
                columns: table => new
                {
                    TradesId = table.Column<int>(type: "int", nullable: false),
                    WalletsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeWallet", x => new { x.TradesId, x.WalletsId });
                    table.ForeignKey(
                        name: "FK_TradeWallet_Trades_TradesId",
                        column: x => x.TradesId,
                        principalTable: "Trades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TradeWallet_Wallets_WalletsId",
                        column: x => x.WalletsId,
                        principalTable: "Wallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TradeItems_TradeId",
                table: "TradeItems",
                column: "TradeId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeWallet_WalletsId",
                table: "TradeWallet",
                column: "WalletsId");

            migrationBuilder.AddForeignKey(
                name: "FK_TradeItems_Trades_TradeId",
                table: "TradeItems",
                column: "TradeId",
                principalTable: "Trades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TradeItems_Trades_TradeId",
                table: "TradeItems");

            migrationBuilder.DropTable(
                name: "TradeWallet");

            migrationBuilder.DropIndex(
                name: "IX_TradeItems_TradeId",
                table: "TradeItems");

            migrationBuilder.DropColumn(
                name: "TradeId",
                table: "TradeItems");

            migrationBuilder.AddColumn<int>(
                name: "WalletId",
                table: "Trades",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TradeTradeItem",
                columns: table => new
                {
                    TradeItemsId = table.Column<int>(type: "int", nullable: false),
                    TradesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeTradeItem", x => new { x.TradeItemsId, x.TradesId });
                    table.ForeignKey(
                        name: "FK_TradeTradeItem_TradeItems_TradeItemsId",
                        column: x => x.TradeItemsId,
                        principalTable: "TradeItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TradeTradeItem_Trades_TradesId",
                        column: x => x.TradesId,
                        principalTable: "Trades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trades_WalletId",
                table: "Trades",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_TradeTradeItem_TradesId",
                table: "TradeTradeItem",
                column: "TradesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trades_Wallets_WalletId",
                table: "Trades",
                column: "WalletId",
                principalTable: "Wallets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
