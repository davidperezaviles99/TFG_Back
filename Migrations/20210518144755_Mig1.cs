using Microsoft.EntityFrameworkCore.Migrations;

namespace TFG_Back.Migrations
{
    public partial class Mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asignaturas_Curso_CursoId",
                table: "Asignaturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Mensaje_User_UserId",
                table: "Mensaje");

            migrationBuilder.DropIndex(
                name: "IX_Asignaturas_CursoId",
                table: "Asignaturas");

            migrationBuilder.DropColumn(
                name: "CursoId",
                table: "Asignaturas");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Mensaje",
                newName: "EquipoId");

            migrationBuilder.RenameIndex(
                name: "IX_Mensaje_UserId",
                table: "Mensaje",
                newName: "IX_Mensaje_EquipoId");

            migrationBuilder.AddColumn<long>(
                name: "AsignaturasId",
                table: "Curso",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Curso_AsignaturasId",
                table: "Curso",
                column: "AsignaturasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Curso_Asignaturas_AsignaturasId",
                table: "Curso",
                column: "AsignaturasId",
                principalTable: "Asignaturas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mensaje_Equipo_EquipoId",
                table: "Mensaje",
                column: "EquipoId",
                principalTable: "Equipo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Curso_Asignaturas_AsignaturasId",
                table: "Curso");

            migrationBuilder.DropForeignKey(
                name: "FK_Mensaje_Equipo_EquipoId",
                table: "Mensaje");

            migrationBuilder.DropIndex(
                name: "IX_Curso_AsignaturasId",
                table: "Curso");

            migrationBuilder.DropColumn(
                name: "AsignaturasId",
                table: "Curso");

            migrationBuilder.RenameColumn(
                name: "EquipoId",
                table: "Mensaje",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Mensaje_EquipoId",
                table: "Mensaje",
                newName: "IX_Mensaje_UserId");

            migrationBuilder.AddColumn<long>(
                name: "CursoId",
                table: "Asignaturas",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Asignaturas_CursoId",
                table: "Asignaturas",
                column: "CursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Asignaturas_Curso_CursoId",
                table: "Asignaturas",
                column: "CursoId",
                principalTable: "Curso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mensaje_User_UserId",
                table: "Mensaje",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
