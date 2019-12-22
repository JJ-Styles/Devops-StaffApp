using Microsoft.EntityFrameworkCore.Migrations;

namespace StaffApp.Data.Migrations
{
    public partial class updatedProductRequests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductRequests",
                table: "ProductRequests");

            migrationBuilder.DropColumn(
                name: "ProductRequestId",
                table: "ProductRequests");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProductRequests",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<bool>(
                name: "Confirmed",
                table: "ProductRequests",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductRequests",
                table: "ProductRequests",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductRequests",
                table: "ProductRequests");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductRequests");

            migrationBuilder.DropColumn(
                name: "Confirmed",
                table: "ProductRequests");

            migrationBuilder.AddColumn<int>(
                name: "ProductRequestId",
                table: "ProductRequests",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductRequests",
                table: "ProductRequests",
                column: "ProductRequestId");
        }
    }
}
