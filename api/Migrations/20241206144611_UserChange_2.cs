using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class UserChange_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44f69e46-cf8a-4113-9ea3-e956b9ce3ee0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a286d8b0-ce08-447c-bf48-b98c786bcaed");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7c2d31de-41a3-4389-a626-c445823e2d7f", null, "Admin", "ADMIN" },
                    { "86919e16-3a06-4d33-a42b-9696acea75a7", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c2d31de-41a3-4389-a626-c445823e2d7f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86919e16-3a06-4d33-a42b-9696acea75a7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "44f69e46-cf8a-4113-9ea3-e956b9ce3ee0", null, "Admin", "ADMIN" },
                    { "a286d8b0-ce08-447c-bf48-b98c786bcaed", null, "User", "USER" }
                });
        }
    }
}
