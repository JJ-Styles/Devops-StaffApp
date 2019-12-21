using Microsoft.EntityFrameworkCore.Migrations;

namespace StaffApp.Data.Migrations
{
    public partial class updatedUserAccounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "UserAccounts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "UserAccounts");
        }
    }
}
