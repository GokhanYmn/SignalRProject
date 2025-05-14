using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalRDataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Order_OrderId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Products_ProductId",
                table: "OrderDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetail",
                table: "OrderDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "OrderDetail",
                newName: "OrdersDetails");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_ProductId",
                table: "OrdersDetails",
                newName: "IX_OrdersDetails_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrdersDetails",
                newName: "IX_OrdersDetails_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrdersDetails",
                table: "OrdersDetails",
                column: "OrderDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersDetails_Orders_OrderId",
                table: "OrdersDetails",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersDetails_Products_ProductId",
                table: "OrdersDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersDetails_Orders_OrderId",
                table: "OrdersDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersDetails_Products_ProductId",
                table: "OrdersDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrdersDetails",
                table: "OrdersDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "OrdersDetails",
                newName: "OrderDetail");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameIndex(
                name: "IX_OrdersDetails_ProductId",
                table: "OrderDetail",
                newName: "IX_OrderDetail_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrdersDetails_OrderId",
                table: "OrderDetail",
                newName: "IX_OrderDetail_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetail",
                table: "OrderDetail",
                column: "OrderDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Order_OrderId",
                table: "OrderDetail",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Products_ProductId",
                table: "OrderDetail",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
