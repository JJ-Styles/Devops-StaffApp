using Microsoft.EntityFrameworkCore.Migrations;

namespace StaffApp.Data.Migrations
{
    public partial class updatedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceHistories_Products_Productid",
                table: "PriceHistories");

            migrationBuilder.RenameColumn(
                name: "Productid",
                table: "PriceHistories",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_PriceHistories_Productid",
                table: "PriceHistories",
                newName: "IX_PriceHistories_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceHistories_Products_ProductId",
                table: "PriceHistories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceHistories_Products_ProductId",
                table: "PriceHistories");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "PriceHistories",
                newName: "Productid");

            migrationBuilder.RenameIndex(
                name: "IX_PriceHistories_ProductId",
                table: "PriceHistories",
                newName: "IX_PriceHistories_Productid");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceHistories_Products_Productid",
                table: "PriceHistories",
                column: "Productid",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
