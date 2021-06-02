using Microsoft.EntityFrameworkCore.Migrations;

namespace TFG_Back.Migrations
{
    public partial class Mig10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Asunto",
                table: "Mensaje",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Mensaje",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Asunto",
                table: "Mensaje");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Mensaje");
        }
    }
}
