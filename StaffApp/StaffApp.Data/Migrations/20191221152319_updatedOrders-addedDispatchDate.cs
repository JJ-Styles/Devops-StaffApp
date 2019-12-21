using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StaffApp.Data.Migrations
{
    public partial class updatedOrdersaddedDispatchDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DispatchDate",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Dispatched",
                table: "Orders",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DispatchDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Dispatched",
                table: "Orders");
        }
    }
}
