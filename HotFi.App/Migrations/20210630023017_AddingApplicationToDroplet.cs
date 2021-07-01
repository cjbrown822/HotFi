using Microsoft.EntityFrameworkCore.Migrations;

namespace HotFi.App.Migrations
{
    public partial class AddingApplicationToDroplet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "application_user_id",
                schema: "hotfi",
                table: "droplets",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "droplet_id",
                schema: "hotfi",
                table: "applications",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_droplets_application_user_id",
                schema: "hotfi",
                table: "droplets",
                column: "application_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_applications_droplet_id",
                schema: "hotfi",
                table: "applications",
                column: "droplet_id");

            migrationBuilder.AddForeignKey(
                name: "FK_applications_droplets_droplet_id",
                schema: "hotfi",
                table: "applications",
                column: "droplet_id",
                principalSchema: "hotfi",
                principalTable: "droplets",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_droplets_users_application_user_id",
                schema: "hotfi",
                table: "droplets",
                column: "application_user_id",
                principalSchema: "hotfi",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_applications_droplets_droplet_id",
                schema: "hotfi",
                table: "applications");

            migrationBuilder.DropForeignKey(
                name: "FK_droplets_users_application_user_id",
                schema: "hotfi",
                table: "droplets");

            migrationBuilder.DropIndex(
                name: "IX_droplets_application_user_id",
                schema: "hotfi",
                table: "droplets");

            migrationBuilder.DropIndex(
                name: "IX_applications_droplet_id",
                schema: "hotfi",
                table: "applications");

            migrationBuilder.DropColumn(
                name: "application_user_id",
                schema: "hotfi",
                table: "droplets");

            migrationBuilder.DropColumn(
                name: "droplet_id",
                schema: "hotfi",
                table: "applications");
        }
    }
}
