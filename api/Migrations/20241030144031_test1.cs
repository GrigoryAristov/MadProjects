using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_RoleCode_RoleCodeFkeyId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleCode",
                table: "RoleCode");

            migrationBuilder.DropColumn(
                name: "DegreeCodeFkey",
                table: "Professors");

            migrationBuilder.RenameTable(
                name: "RoleCode",
                newName: "RoleCodes");

            migrationBuilder.AddColumn<int>(
                name: "DegreeCodeFkeyId",
                table: "Professors",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleCodes",
                table: "RoleCodes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DegreeCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Degree = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DegreeCodes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Professors_DegreeCodeFkeyId",
                table: "Professors",
                column: "DegreeCodeFkeyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Professors_DegreeCodes_DegreeCodeFkeyId",
                table: "Professors",
                column: "DegreeCodeFkeyId",
                principalTable: "DegreeCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_RoleCodes_RoleCodeFkeyId",
                table: "Users",
                column: "RoleCodeFkeyId",
                principalTable: "RoleCodes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professors_DegreeCodes_DegreeCodeFkeyId",
                table: "Professors");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_RoleCodes_RoleCodeFkeyId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "DegreeCodes");

            migrationBuilder.DropIndex(
                name: "IX_Professors_DegreeCodeFkeyId",
                table: "Professors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleCodes",
                table: "RoleCodes");

            migrationBuilder.DropColumn(
                name: "DegreeCodeFkeyId",
                table: "Professors");

            migrationBuilder.RenameTable(
                name: "RoleCodes",
                newName: "RoleCode");

            migrationBuilder.AddColumn<int>(
                name: "DegreeCodeFkey",
                table: "Professors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleCode",
                table: "RoleCode",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_RoleCode_RoleCodeFkeyId",
                table: "Users",
                column: "RoleCodeFkeyId",
                principalTable: "RoleCode",
                principalColumn: "Id");
        }
    }
}
