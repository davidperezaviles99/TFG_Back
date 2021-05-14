using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TFG_Back.Migrations
{
    public partial class Migration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlumnoProfesor");

            migrationBuilder.DropColumn(
                name: "Asignatura",
                table: "Asignaturas");

            migrationBuilder.RenameColumn(
                name: "Curso",
                table: "Asignaturas",
                newName: "Name");

            migrationBuilder.AddColumn<long>(
                name: "CursoId",
                table: "User",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CursoId",
                table: "Asignaturas",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Numero = table.Column<int>(type: "integer", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_CursoId",
                table: "User",
                column: "CursoId");

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
                name: "FK_User_Curso_CursoId",
                table: "User",
                column: "CursoId",
                principalTable: "Curso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asignaturas_Curso_CursoId",
                table: "Asignaturas");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Curso_CursoId",
                table: "User");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropIndex(
                name: "IX_User_CursoId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Asignaturas_CursoId",
                table: "Asignaturas");

            migrationBuilder.DropColumn(
                name: "CursoId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CursoId",
                table: "Asignaturas");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Asignaturas",
                newName: "Curso");

            migrationBuilder.AddColumn<string>(
                name: "Asignatura",
                table: "Asignaturas",
                type: "character varying(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AlumnoProfesor",
                columns: table => new
                {
                    AlumnoId = table.Column<long>(type: "bigint", nullable: false),
                    ProfesorId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlumnoProfesor", x => new { x.AlumnoId, x.ProfesorId });
                    table.ForeignKey(
                        name: "FK_AlumnoProfesor_User_AlumnoId",
                        column: x => x.AlumnoId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlumnoProfesor_User_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoProfesor_ProfesorId",
                table: "AlumnoProfesor",
                column: "ProfesorId");
        }
    }
}
