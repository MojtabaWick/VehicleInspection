using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleInspection.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class AddAddressProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "InspectionRequests",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "DeniedInspectionRequests",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "InspectionRequests");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "DeniedInspectionRequests");
        }
    }
}
