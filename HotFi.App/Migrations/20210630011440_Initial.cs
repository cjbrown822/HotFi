using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotFi.App.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "hotfi");

            migrationBuilder.CreateTable(
                name: "droplets",
                schema: "hotfi",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    droplet_id = table.Column<string>(type: "text", nullable: true),
                    droplet_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_droplets", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "hotfi",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    given_name = table.Column<string>(type: "text", nullable: true),
                    family_name = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    can_contact = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "applications",
                schema: "hotfi",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: true),
                    application_name = table.Column<string>(type: "text", nullable: true),
                    domain = table.Column<string>(type: "text", nullable: true),
                    git_hub_url = table.Column<string>(type: "text", nullable: true),
                    port_number = table.Column<int>(type: "integer", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    archived_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applications", x => x.id);
                    table.ForeignKey(
                        name: "FK_applications_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "hotfi",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_applications_user_id",
                schema: "hotfi",
                table: "applications",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "applications",
                schema: "hotfi");

            migrationBuilder.DropTable(
                name: "droplets",
                schema: "hotfi");

            migrationBuilder.DropTable(
                name: "users",
                schema: "hotfi");
        }
    }
}
