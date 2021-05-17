using Microsoft.EntityFrameworkCore.Migrations;

namespace VeggieSwapServer.Data.Migrations
{
    public partial class testdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TradeItems_Trades_TradeId",
                table: "TradeItems");

            migrationBuilder.DropIndex(
                name: "IX_TradeItems_TradeId",
                table: "TradeItems");

            migrationBuilder.DropColumn(
                name: "TradeId",
                table: "TradeItems");

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
                name: "IX_TradeTradeItem_TradesId",
                table: "TradeTradeItem",
                column: "TradesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TradeTradeItem");

            migrationBuilder.AddColumn<int>(
                name: "TradeId",
                table: "TradeItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TradeItems_TradeId",
                table: "TradeItems",
                column: "TradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TradeItems_Trades_TradeId",
                table: "TradeItems",
                column: "TradeId",
                principalTable: "Trades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
