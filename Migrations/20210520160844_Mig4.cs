using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TFG_Back.Migrations
{
    public partial class Mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Curso_Asignaturas_AsignaturasId",
                table: "Curso");

            migrationBuilder.DropForeignKey(
                name: "FK_Diario_Asignaturas_AsignaturasId",
                table: "Diario");

            migrationBuilder.DropTable(
                name: "Asignaturas");

            migrationBuilder.RenameColumn(
                name: "AsignaturasId",
                table: "Curso",
                newName: "AsignaturaId");

            migrationBuilder.RenameIndex(
                name: "IX_Curso_AsignaturasId",
                table: "Curso",
                newName: "IX_Curso_AsignaturaId");

            migrationBuilder.CreateTable(
                name: "Asignatura",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Codigo = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    ProfesorId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignatura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asignatura_User_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asignatura_ProfesorId",
                table: "Asignatura",
                column: "ProfesorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Curso_Asignatura_AsignaturaId",
                table: "Curso",
                column: "AsignaturaId",
                principalTable: "Asignatura",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Diario_Asignatura_AsignaturasId",
                table: "Diario",
                column: "AsignaturasId",
                principalTable: "Asignatura",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Curso_Asignatura_AsignaturaId",
                table: "Curso");

            migrationBuilder.DropForeignKey(
                name: "FK_Diario_Asignatura_AsignaturasId",
                table: "Diario");

            migrationBuilder.DropTable(
                name: "Asignatura");

            migrationBuilder.RenameColumn(
                name: "AsignaturaId",
                table: "Curso",
                newName: "AsignaturasId");

            migrationBuilder.RenameIndex(
                name: "IX_Curso_AsignaturaId",
                table: "Curso",
                newName: "IX_Curso_AsignaturasId");

            migrationBuilder.CreateTable(
                name: "Asignaturas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Codigo = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    ProfesorId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignaturas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asignaturas_User_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asignaturas_ProfesorId",
                table: "Asignaturas",
                column: "ProfesorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Curso_Asignaturas_AsignaturasId",
                table: "Curso",
                column: "AsignaturasId",
                principalTable: "Asignaturas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Diario_Asignaturas_AsignaturasId",
                table: "Diario",
                column: "AsignaturasId",
                principalTable: "Asignaturas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
