using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class UserChange_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "247acae7-e2dc-4211-8cd4-490c1f97514f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ad77537-8850-4f75-a1ae-b86ccc6d84ff");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "54f78c89-c6fe-4985-b5c0-3726284f36e7", null, "User", "USER" },
                    { "60659c7f-5082-467e-a9b8-682e61cf1896", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54f78c89-c6fe-4985-b5c0-3726284f36e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60659c7f-5082-467e-a9b8-682e61cf1896");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "247acae7-e2dc-4211-8cd4-490c1f97514f", null, "User", "USER" },
                    { "9ad77537-8850-4f75-a1ae-b86ccc6d84ff", null, "Admin", "ADMIN" }
                });
        }
    }
}
