using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class test4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectGroupProject_ProjectGroups_GroupFkeyId",
                table: "ProjectGroupProject");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectGroupProject_Project_ProjectFkeyId",
                table: "ProjectGroupProject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectGroupProject",
                table: "ProjectGroupProject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Project",
                table: "Project");

            migrationBuilder.RenameTable(
                name: "ProjectGroupProject",
                newName: "ProjectGroupProjects");

            migrationBuilder.RenameTable(
                name: "Project",
                newName: "Projects");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectGroupProject_ProjectFkeyId",
                table: "ProjectGroupProjects",
                newName: "IX_ProjectGroupProjects_ProjectFkeyId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectGroupProject_GroupFkeyId",
                table: "ProjectGroupProjects",
                newName: "IX_ProjectGroupProjects_GroupFkeyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectGroupProjects",
                table: "ProjectGroupProjects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ProjectRoleCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProjectRole = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectRoleCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserFkeyId = table.Column<int>(type: "integer", nullable: true),
                    ProjectFkeyId = table.Column<int>(type: "integer", nullable: true),
                    ProjectRoleCodeFkeyId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProjects_ProjectRoleCodes_ProjectRoleCodeFkeyId",
                        column: x => x.ProjectRoleCodeFkeyId,
                        principalTable: "ProjectRoleCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserProjects_Projects_ProjectFkeyId",
                        column: x => x.ProjectFkeyId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserProjects_Users_UserFkeyId",
                        column: x => x.UserFkeyId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProjects_ProjectFkeyId",
                table: "UserProjects",
                column: "ProjectFkeyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProjects_ProjectRoleCodeFkeyId",
                table: "UserProjects",
                column: "ProjectRoleCodeFkeyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProjects_UserFkeyId",
                table: "UserProjects",
                column: "UserFkeyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectGroupProjects_ProjectGroups_GroupFkeyId",
                table: "ProjectGroupProjects",
                column: "GroupFkeyId",
                principalTable: "ProjectGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectGroupProjects_Projects_ProjectFkeyId",
                table: "ProjectGroupProjects",
                column: "ProjectFkeyId",
                principalTable: "Projects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectGroupProjects_ProjectGroups_GroupFkeyId",
                table: "ProjectGroupProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectGroupProjects_Projects_ProjectFkeyId",
                table: "ProjectGroupProjects");

            migrationBuilder.DropTable(
                name: "UserProjects");

            migrationBuilder.DropTable(
                name: "ProjectRoleCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectGroupProjects",
                table: "ProjectGroupProjects");

            migrationBuilder.RenameTable(
                name: "Projects",
                newName: "Project");

            migrationBuilder.RenameTable(
                name: "ProjectGroupProjects",
                newName: "ProjectGroupProject");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectGroupProjects_ProjectFkeyId",
                table: "ProjectGroupProject",
                newName: "IX_ProjectGroupProject_ProjectFkeyId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectGroupProjects_GroupFkeyId",
                table: "ProjectGroupProject",
                newName: "IX_ProjectGroupProject_GroupFkeyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Project",
                table: "Project",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectGroupProject",
                table: "ProjectGroupProject",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectGroupProject_ProjectGroups_GroupFkeyId",
                table: "ProjectGroupProject",
                column: "GroupFkeyId",
                principalTable: "ProjectGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectGroupProject_Project_ProjectFkeyId",
                table: "ProjectGroupProject",
                column: "ProjectFkeyId",
                principalTable: "Project",
                principalColumn: "Id");
        }
    }
}
