using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_RoleCodes_RoleCodeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_UserId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RoleCodeId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "225cc507-219f-4c3d-b729-9c13cfc3398f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "979c5b7e-03a1-4f8d-a6d3-7bb552ae7b9d");

            migrationBuilder.DropColumn(
                name: "RoleCodeId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "RoleCodes",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1b9e5ba9-a7ea-49a8-bf6c-6a927af1ba75", null, "Admin", "ADMIN" },
                    { "6c40f5ff-01db-48a5-853d-9bcfd43a83ab", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleCodes_UserId",
                table: "RoleCodes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleCodes_AspNetUsers_UserId",
                table: "RoleCodes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_UserId",
                table: "Students",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleCodes_AspNetUsers_UserId",
                table: "RoleCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_UserId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_RoleCodes_UserId",
                table: "RoleCodes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b9e5ba9-a7ea-49a8-bf6c-6a927af1ba75");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c40f5ff-01db-48a5-853d-9bcfd43a83ab");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RoleCodes");

            migrationBuilder.AddColumn<int>(
                name: "RoleCodeId",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "225cc507-219f-4c3d-b729-9c13cfc3398f", null, "User", "USER" },
                    { "979c5b7e-03a1-4f8d-a6d3-7bb552ae7b9d", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RoleCodeId",
                table: "AspNetUsers",
                column: "RoleCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_RoleCodes_RoleCodeId",
                table: "AspNetUsers",
                column: "RoleCodeId",
                principalTable: "RoleCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_UserId",
                table: "Students",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
