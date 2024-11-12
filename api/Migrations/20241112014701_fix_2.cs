using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class fix_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_RoleCodes_RoleCodeFkeyId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_IdFkeyId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Groups_GroupFkeyId",
                table: "Students");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5ca3e42-cc61-47db-8ad1-77cb35fd089e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5d7d274-16a0-4ed8-8e0b-7756b2572e45");

            migrationBuilder.RenameColumn(
                name: "IdFkeyId",
                table: "Students",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "GroupFkeyId",
                table: "Students",
                newName: "StudentGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_IdFkeyId",
                table: "Students",
                newName: "IX_Students_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_GroupFkeyId",
                table: "Students",
                newName: "IX_Students_StudentGroupId");

            migrationBuilder.RenameColumn(
                name: "RoleCodeFkeyId",
                table: "AspNetUsers",
                newName: "RoleCodeId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_RoleCodeFkeyId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_RoleCodeId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04f83f9f-8f3b-4353-bed7-716bf9939c44", null, "Admin", "ADMIN" },
                    { "156c4d5d-abef-41df-ad02-0a6a602ac6da", null, "User", "USER" }
                });

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
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Groups_StudentGroupId",
                table: "Students",
                column: "StudentGroupId",
                principalTable: "Groups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_RoleCodes_RoleCodeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_UserId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Groups_StudentGroupId",
                table: "Students");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04f83f9f-8f3b-4353-bed7-716bf9939c44");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "156c4d5d-abef-41df-ad02-0a6a602ac6da");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Students",
                newName: "IdFkeyId");

            migrationBuilder.RenameColumn(
                name: "StudentGroupId",
                table: "Students",
                newName: "GroupFkeyId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_UserId",
                table: "Students",
                newName: "IX_Students_IdFkeyId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_StudentGroupId",
                table: "Students",
                newName: "IX_Students_GroupFkeyId");

            migrationBuilder.RenameColumn(
                name: "RoleCodeId",
                table: "AspNetUsers",
                newName: "RoleCodeFkeyId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_RoleCodeId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_RoleCodeFkeyId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b5ca3e42-cc61-47db-8ad1-77cb35fd089e", null, "User", "USER" },
                    { "c5d7d274-16a0-4ed8-8e0b-7756b2572e45", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_RoleCodes_RoleCodeFkeyId",
                table: "AspNetUsers",
                column: "RoleCodeFkeyId",
                principalTable: "RoleCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_IdFkeyId",
                table: "Students",
                column: "IdFkeyId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Groups_GroupFkeyId",
                table: "Students",
                column: "GroupFkeyId",
                principalTable: "Groups",
                principalColumn: "Id");
        }
    }
}
