using Microsoft.EntityFrameworkCore.Migrations;

namespace HotFi.App.Migrations
{
    public partial class AddingServerInformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "server_information",
                schema: "hotfi",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    username = table.Column<string>(type: "text", nullable: true),
                    user_ssh_vault_key = table.Column<string>(type: "text", nullable: true),
                    application_username = table.Column<string>(type: "text", nullable: true),
                    application_ssh_vault_key = table.Column<string>(type: "text", nullable: true),
                    application_service_name = table.Column<string>(type: "text", nullable: true),
                    droplet_id = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_server_information", x => x.id);
                    table.ForeignKey(
                        name: "FK_server_information_droplets_droplet_id",
                        column: x => x.droplet_id,
                        principalSchema: "hotfi",
                        principalTable: "droplets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_server_information_droplet_id",
                schema: "hotfi",
                table: "server_information",
                column: "droplet_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "server_information",
                schema: "hotfi");
        }
    }
}
