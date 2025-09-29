using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreApp.Migrations
{
    /// <inheritdoc />
    public partial class IdentityRoleSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "32470899-cb14-4172-8726-1cabf9783853", null, "Editor", "EDITOR" },
                    { "61fd0b4f-340d-4dbd-abb8-4df304436ee7", null, "Admin", "ADMIN" },
                    { "fb8e6ecb-83d4-4d83-89c7-321f33c91fee", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32470899-cb14-4172-8726-1cabf9783853");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61fd0b4f-340d-4dbd-abb8-4df304436ee7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb8e6ecb-83d4-4d83-89c7-321f33c91fee");
        }
    }
}
