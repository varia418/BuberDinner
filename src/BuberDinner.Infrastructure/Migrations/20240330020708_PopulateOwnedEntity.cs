using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuberDinner.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PopulateOwnedEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MenuItemId",
                table: "MenuItems",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "AverageRating_NumRatings",
                table: "Menus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "AverageRating_Value",
                table: "Menus",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Location_Address",
                table: "Dinners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Location_Latitude",
                table: "Dinners",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Location_Longitude",
                table: "Dinners",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Location_Name",
                table: "Dinners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Price_Amount",
                table: "Dinners",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Price_Currency",
                table: "Dinners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageRating_NumRatings",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "AverageRating_Value",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "Location_Address",
                table: "Dinners");

            migrationBuilder.DropColumn(
                name: "Location_Latitude",
                table: "Dinners");

            migrationBuilder.DropColumn(
                name: "Location_Longitude",
                table: "Dinners");

            migrationBuilder.DropColumn(
                name: "Location_Name",
                table: "Dinners");

            migrationBuilder.DropColumn(
                name: "Price_Amount",
                table: "Dinners");

            migrationBuilder.DropColumn(
                name: "Price_Currency",
                table: "Dinners");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MenuItems",
                newName: "MenuItemId");
        }
    }
}
