using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class test3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    InviteCode = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NumParticipants = table.Column<int>(type: "integer", nullable: false),
                    Approved = table.Column<bool>(type: "boolean", nullable: false),
                    Grade = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ProfessorFkeyId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectGroups_Professors_ProfessorFkeyId",
                        column: x => x.ProfessorFkeyId,
                        principalTable: "Professors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectGroupProject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GroupFkeyId = table.Column<int>(type: "integer", nullable: true),
                    ProjectFkeyId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectGroupProject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectGroupProject_ProjectGroups_GroupFkeyId",
                        column: x => x.GroupFkeyId,
                        principalTable: "ProjectGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectGroupProject_Project_ProjectFkeyId",
                        column: x => x.ProjectFkeyId,
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectGroupProject_GroupFkeyId",
                table: "ProjectGroupProject",
                column: "GroupFkeyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectGroupProject_ProjectFkeyId",
                table: "ProjectGroupProject",
                column: "ProjectFkeyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectGroups_ProfessorFkeyId",
                table: "ProjectGroups",
                column: "ProfessorFkeyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectGroupProject");

            migrationBuilder.DropTable(
                name: "ProjectGroups");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
