using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Api.Migrations
{
    public partial class DefaultRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "1241cab8-f6bb-4a33-9717-705cb3d88bdb", "1ea52f87-1805-4dc7-89ff-50ace2454ea3", "ApplicationRole", "Seller", "Seller" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "a63db36e-16b7-4244-9854-5dd5356a0149", "4c11fcb8-32a7-463b-b18e-4bb82fbd5a21", "ApplicationRole", "Admin", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1241cab8-f6bb-4a33-9717-705cb3d88bdb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a63db36e-16b7-4244-9854-5dd5356a0149");
        }
    }
}
