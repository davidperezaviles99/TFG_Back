using Microsoft.EntityFrameworkCore.Migrations;

namespace TFG_Back.Migrations
{
    public partial class Mig9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EvaluacionP",
                table: "Diario",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EvaluacionT",
                table: "Diario",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EvaluacionP",
                table: "Diario");

            migrationBuilder.DropColumn(
                name: "EvaluacionT",
                table: "Diario");
        }
    }
}
