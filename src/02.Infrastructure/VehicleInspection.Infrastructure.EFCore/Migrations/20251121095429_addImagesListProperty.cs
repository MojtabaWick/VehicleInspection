using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleInspection.Infrastructure.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class addImagesListProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Images",
                table: "InspectionRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "Images",
                table: "DeniedInspectionRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Images",
                table: "InspectionRequests");

            migrationBuilder.DropColumn(
                name: "Images",
                table: "DeniedInspectionRequests");
        }
    }
}
