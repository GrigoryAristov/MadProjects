using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Repositories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProjectFkeyId = table.Column<int>(type: "integer", nullable: true),
                    URL = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repositories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Repositories_Projects_ProjectFkeyId",
                        column: x => x.ProjectFkeyId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sprints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    DateStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateExpect = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    ProjectFkeyId = table.Column<int>(type: "integer", nullable: true),
                    UserFkeyId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sprints_Projects_ProjectFkeyId",
                        column: x => x.ProjectFkeyId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sprints_Users_UserFkeyId",
                        column: x => x.UserFkeyId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SprintFkeyId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statuses_Sprints_SprintFkeyId",
                        column: x => x.SprintFkeyId,
                        principalTable: "Sprints",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StatusFkeyId = table.Column<int>(type: "integer", nullable: true),
                    UserFkeyId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Statuses_StatusFkeyId",
                        column: x => x.StatusFkeyId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cards_Users_UserFkeyId",
                        column: x => x.UserFkeyId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StatusOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StatusFkeyId = table.Column<int>(type: "integer", nullable: true),
                    SprintFkeyId = table.Column<int>(type: "integer", nullable: true),
                    Order = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatusOrders_Sprints_SprintFkeyId",
                        column: x => x.SprintFkeyId,
                        principalTable: "Sprints",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StatusOrders_Statuses_StatusFkeyId",
                        column: x => x.StatusFkeyId,
                        principalTable: "Statuses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CardOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CardFkeyId = table.Column<int>(type: "integer", nullable: true),
                    SprintFkeyId = table.Column<int>(type: "integer", nullable: true),
                    Order = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardOrders_Cards_CardFkeyId",
                        column: x => x.CardFkeyId,
                        principalTable: "Cards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CardOrders_Sprints_SprintFkeyId",
                        column: x => x.SprintFkeyId,
                        principalTable: "Sprints",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SprintCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SprintFkeyId = table.Column<int>(type: "integer", nullable: true),
                    CardFkeyId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SprintCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SprintCards_Cards_CardFkeyId",
                        column: x => x.CardFkeyId,
                        principalTable: "Cards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SprintCards_Sprints_SprintFkeyId",
                        column: x => x.SprintFkeyId,
                        principalTable: "Sprints",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardOrders_CardFkeyId",
                table: "CardOrders",
                column: "CardFkeyId");

            migrationBuilder.CreateIndex(
                name: "IX_CardOrders_SprintFkeyId",
                table: "CardOrders",
                column: "SprintFkeyId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_StatusFkeyId",
                table: "Cards",
                column: "StatusFkeyId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_UserFkeyId",
                table: "Cards",
                column: "UserFkeyId");

            migrationBuilder.CreateIndex(
                name: "IX_Repositories_ProjectFkeyId",
                table: "Repositories",
                column: "ProjectFkeyId");

            migrationBuilder.CreateIndex(
                name: "IX_SprintCards_CardFkeyId",
                table: "SprintCards",
                column: "CardFkeyId");

            migrationBuilder.CreateIndex(
                name: "IX_SprintCards_SprintFkeyId",
                table: "SprintCards",
                column: "SprintFkeyId");

            migrationBuilder.CreateIndex(
                name: "IX_Sprints_ProjectFkeyId",
                table: "Sprints",
                column: "ProjectFkeyId");

            migrationBuilder.CreateIndex(
                name: "IX_Sprints_UserFkeyId",
                table: "Sprints",
                column: "UserFkeyId");

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_SprintFkeyId",
                table: "Statuses",
                column: "SprintFkeyId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusOrders_SprintFkeyId",
                table: "StatusOrders",
                column: "SprintFkeyId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusOrders_StatusFkeyId",
                table: "StatusOrders",
                column: "StatusFkeyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardOrders");

            migrationBuilder.DropTable(
                name: "Repositories");

            migrationBuilder.DropTable(
                name: "SprintCards");

            migrationBuilder.DropTable(
                name: "StatusOrders");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Sprints");
        }
    }
}
