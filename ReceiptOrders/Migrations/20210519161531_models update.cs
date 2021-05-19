using Microsoft.EntityFrameworkCore.Migrations;

namespace ReceiptOrders.Migrations
{
    public partial class modelsupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInOrders_Orders_OrderId",
                table: "ProductsInOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsInOrders_Products_ProductId",
                table: "ProductsInOrders");

            migrationBuilder.DropIndex(
                name: "IX_ProductsInOrders_OrderId",
                table: "ProductsInOrders");

            migrationBuilder.DropIndex(
                name: "IX_ProductsInOrders_ProductId",
                table: "ProductsInOrders");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "ProductsInOrders");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductsInOrders");

            migrationBuilder.AddColumn<int>(
                name: "OrderNumber",
                table: "ProductsInOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductNumber",
                table: "ProductsInOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "ProductsInOrders");

            migrationBuilder.DropColumn(
                name: "ProductNumber",
                table: "ProductsInOrders");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "ProductsInOrders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductsInOrders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductsInOrders_OrderId",
                table: "ProductsInOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsInOrders_ProductId",
                table: "ProductsInOrders",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInOrders_Orders_OrderId",
                table: "ProductsInOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsInOrders_Products_ProductId",
                table: "ProductsInOrders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
