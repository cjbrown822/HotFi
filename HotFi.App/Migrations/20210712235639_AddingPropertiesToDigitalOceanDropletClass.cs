using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotFi.App.Migrations
{
    public partial class AddingPropertiesToDigitalOceanDropletClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_applications_droplets_droplet_id",
                schema: "hotfi",
                table: "applications");

            migrationBuilder.DropForeignKey(
                name: "FK_server_information_droplets_droplet_id",
                schema: "hotfi",
                table: "server_information");

            migrationBuilder.DropIndex(
                name: "IX_server_information_droplet_id",
                schema: "hotfi",
                table: "server_information");

            migrationBuilder.DropIndex(
                name: "IX_applications_droplet_id",
                schema: "hotfi",
                table: "applications");

            migrationBuilder.AddColumn<string>(
                name: "digital_ocean_droplet_id",
                schema: "hotfi",
                table: "server_information",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "backups",
                schema: "hotfi",
                table: "droplets",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "domain",
                schema: "hotfi",
                table: "droplets",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "image_slug",
                schema: "hotfi",
                table: "droplets",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ipv6",
                schema: "hotfi",
                table: "droplets",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "monitoring",
                schema: "hotfi",
                table: "droplets",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "public_networking",
                schema: "hotfi",
                table: "droplets",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "region",
                schema: "hotfi",
                table: "droplets",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "scripts_completed_date",
                schema: "hotfi",
                table: "droplets",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "size",
                schema: "hotfi",
                table: "droplets",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string[]>(
                name: "ssh_keys",
                schema: "hotfi",
                table: "droplets",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<string[]>(
                name: "tags",
                schema: "hotfi",
                table: "droplets",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "user_data",
                schema: "hotfi",
                table: "droplets",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string[]>(
                name: "volumes",
                schema: "hotfi",
                table: "droplets",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "vpc_uuid",
                schema: "hotfi",
                table: "droplets",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "digital_ocean_droplet_id",
                schema: "hotfi",
                table: "applications",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_server_information_digital_ocean_droplet_id",
                schema: "hotfi",
                table: "server_information",
                column: "digital_ocean_droplet_id");

            migrationBuilder.CreateIndex(
                name: "IX_applications_digital_ocean_droplet_id",
                schema: "hotfi",
                table: "applications",
                column: "digital_ocean_droplet_id");

            migrationBuilder.AddForeignKey(
                name: "FK_applications_droplets_digital_ocean_droplet_id",
                schema: "hotfi",
                table: "applications",
                column: "digital_ocean_droplet_id",
                principalSchema: "hotfi",
                principalTable: "droplets",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_server_information_droplets_digital_ocean_droplet_id",
                schema: "hotfi",
                table: "server_information",
                column: "digital_ocean_droplet_id",
                principalSchema: "hotfi",
                principalTable: "droplets",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_applications_droplets_digital_ocean_droplet_id",
                schema: "hotfi",
                table: "applications");

            migrationBuilder.DropForeignKey(
                name: "FK_server_information_droplets_digital_ocean_droplet_id",
                schema: "hotfi",
                table: "server_information");

            migrationBuilder.DropIndex(
                name: "IX_server_information_digital_ocean_droplet_id",
                schema: "hotfi",
                table: "server_information");

            migrationBuilder.DropIndex(
                name: "IX_applications_digital_ocean_droplet_id",
                schema: "hotfi",
                table: "applications");

            migrationBuilder.DropColumn(
                name: "digital_ocean_droplet_id",
                schema: "hotfi",
                table: "server_information");

            migrationBuilder.DropColumn(
                name: "backups",
                schema: "hotfi",
                table: "droplets");

            migrationBuilder.DropColumn(
                name: "domain",
                schema: "hotfi",
                table: "droplets");

            migrationBuilder.DropColumn(
                name: "image_slug",
                schema: "hotfi",
                table: "droplets");

            migrationBuilder.DropColumn(
                name: "ipv6",
                schema: "hotfi",
                table: "droplets");

            migrationBuilder.DropColumn(
                name: "monitoring",
                schema: "hotfi",
                table: "droplets");

            migrationBuilder.DropColumn(
                name: "public_networking",
                schema: "hotfi",
                table: "droplets");

            migrationBuilder.DropColumn(
                name: "region",
                schema: "hotfi",
                table: "droplets");

            migrationBuilder.DropColumn(
                name: "scripts_completed_date",
                schema: "hotfi",
                table: "droplets");

            migrationBuilder.DropColumn(
                name: "size",
                schema: "hotfi",
                table: "droplets");

            migrationBuilder.DropColumn(
                name: "ssh_keys",
                schema: "hotfi",
                table: "droplets");

            migrationBuilder.DropColumn(
                name: "tags",
                schema: "hotfi",
                table: "droplets");

            migrationBuilder.DropColumn(
                name: "user_data",
                schema: "hotfi",
                table: "droplets");

            migrationBuilder.DropColumn(
                name: "volumes",
                schema: "hotfi",
                table: "droplets");

            migrationBuilder.DropColumn(
                name: "vpc_uuid",
                schema: "hotfi",
                table: "droplets");

            migrationBuilder.DropColumn(
                name: "digital_ocean_droplet_id",
                schema: "hotfi",
                table: "applications");

            migrationBuilder.CreateIndex(
                name: "IX_server_information_droplet_id",
                schema: "hotfi",
                table: "server_information",
                column: "droplet_id");

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
                name: "FK_server_information_droplets_droplet_id",
                schema: "hotfi",
                table: "server_information",
                column: "droplet_id",
                principalSchema: "hotfi",
                principalTable: "droplets",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
