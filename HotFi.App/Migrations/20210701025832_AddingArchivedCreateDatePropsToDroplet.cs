using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotFi.App.Migrations
{
    public partial class AddingArchivedCreateDatePropsToDroplet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "archived",
                schema: "hotfi",
                table: "droplets",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "archived_date",
                schema: "hotfi",
                table: "droplets",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                schema: "hotfi",
                table: "droplets",
                type: "timestamp without time zone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "archived",
                schema: "hotfi",
                table: "droplets");

            migrationBuilder.DropColumn(
                name: "archived_date",
                schema: "hotfi",
                table: "droplets");

            migrationBuilder.DropColumn(
                name: "created_date",
                schema: "hotfi",
                table: "droplets");
        }
    }
}
