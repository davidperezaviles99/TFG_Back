using Microsoft.EntityFrameworkCore.Migrations;

namespace TFG_Back.Migrations
{
    public partial class Mig6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diario_Asignatura_AsignaturasId",
                table: "Diario");

            migrationBuilder.RenameColumn(
                name: "AsignaturasId",
                table: "Diario",
                newName: "AsignaturaId");

            migrationBuilder.RenameIndex(
                name: "IX_Diario_AsignaturasId",
                table: "Diario",
                newName: "IX_Diario_AsignaturaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diario_Asignatura_AsignaturaId",
                table: "Diario",
                column: "AsignaturaId",
                principalTable: "Asignatura",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diario_Asignatura_AsignaturaId",
                table: "Diario");

            migrationBuilder.RenameColumn(
                name: "AsignaturaId",
                table: "Diario",
                newName: "AsignaturasId");

            migrationBuilder.RenameIndex(
                name: "IX_Diario_AsignaturaId",
                table: "Diario",
                newName: "IX_Diario_AsignaturasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diario_Asignatura_AsignaturasId",
                table: "Diario",
                column: "AsignaturasId",
                principalTable: "Asignatura",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
