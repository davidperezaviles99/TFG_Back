using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TFG_Back.Migrations
{
    public partial class Mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diario_Equipo_EquipoId",
                table: "Diario");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipo_User_AlumnoId",
                table: "Equipo");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipo_User_ProfesorId",
                table: "Equipo");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipo_User_TutorId",
                table: "Equipo");

            migrationBuilder.DropForeignKey(
                name: "FK_Mensaje_Equipo_EquipoId",
                table: "Mensaje");

            migrationBuilder.DropIndex(
                name: "IX_Mensaje_EquipoId",
                table: "Mensaje");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipo",
                table: "Equipo");

            migrationBuilder.DropIndex(
                name: "IX_Equipo_AlumnoId",
                table: "Equipo");

            migrationBuilder.DropIndex(
                name: "IX_Diario_EquipoId",
                table: "Diario");

            migrationBuilder.RenameColumn(
                name: "EquipoId",
                table: "Mensaje",
                newName: "EquipoTutorId");

            migrationBuilder.RenameColumn(
                name: "EquipoId",
                table: "Diario",
                newName: "EquipoTutorId");

            migrationBuilder.AddColumn<long>(
                name: "EquipoAlumnoId",
                table: "Mensaje",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "EquipoProfesorId",
                table: "Mensaje",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "TutorId",
                table: "Equipo",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ProfesorId",
                table: "Equipo",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AlumnoId",
                table: "Equipo",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Equipo",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<long>(
                name: "EquipoAlumnoId",
                table: "Diario",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "EquipoProfesorId",
                table: "Diario",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipo",
                table: "Equipo",
                columns: new[] { "AlumnoId", "TutorId", "ProfesorId" });

            migrationBuilder.CreateIndex(
                name: "IX_Mensaje_EquipoAlumnoId_EquipoTutorId_EquipoProfesorId",
                table: "Mensaje",
                columns: new[] { "EquipoAlumnoId", "EquipoTutorId", "EquipoProfesorId" });

            migrationBuilder.CreateIndex(
                name: "IX_Diario_EquipoAlumnoId_EquipoTutorId_EquipoProfesorId",
                table: "Diario",
                columns: new[] { "EquipoAlumnoId", "EquipoTutorId", "EquipoProfesorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Diario_Equipo_EquipoAlumnoId_EquipoTutorId_EquipoProfesorId",
                table: "Diario",
                columns: new[] { "EquipoAlumnoId", "EquipoTutorId", "EquipoProfesorId" },
                principalTable: "Equipo",
                principalColumns: new[] { "AlumnoId", "TutorId", "ProfesorId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipo_User_AlumnoId",
                table: "Equipo",
                column: "AlumnoId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipo_User_ProfesorId",
                table: "Equipo",
                column: "ProfesorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipo_User_TutorId",
                table: "Equipo",
                column: "TutorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mensaje_Equipo_EquipoAlumnoId_EquipoTutorId_EquipoProfesorId",
                table: "Mensaje",
                columns: new[] { "EquipoAlumnoId", "EquipoTutorId", "EquipoProfesorId" },
                principalTable: "Equipo",
                principalColumns: new[] { "AlumnoId", "TutorId", "ProfesorId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diario_Equipo_EquipoAlumnoId_EquipoTutorId_EquipoProfesorId",
                table: "Diario");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipo_User_AlumnoId",
                table: "Equipo");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipo_User_ProfesorId",
                table: "Equipo");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipo_User_TutorId",
                table: "Equipo");

            migrationBuilder.DropForeignKey(
                name: "FK_Mensaje_Equipo_EquipoAlumnoId_EquipoTutorId_EquipoProfesorId",
                table: "Mensaje");

            migrationBuilder.DropIndex(
                name: "IX_Mensaje_EquipoAlumnoId_EquipoTutorId_EquipoProfesorId",
                table: "Mensaje");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipo",
                table: "Equipo");

            migrationBuilder.DropIndex(
                name: "IX_Diario_EquipoAlumnoId_EquipoTutorId_EquipoProfesorId",
                table: "Diario");

            migrationBuilder.DropColumn(
                name: "EquipoAlumnoId",
                table: "Mensaje");

            migrationBuilder.DropColumn(
                name: "EquipoProfesorId",
                table: "Mensaje");

            migrationBuilder.DropColumn(
                name: "EquipoAlumnoId",
                table: "Diario");

            migrationBuilder.DropColumn(
                name: "EquipoProfesorId",
                table: "Diario");

            migrationBuilder.RenameColumn(
                name: "EquipoTutorId",
                table: "Mensaje",
                newName: "EquipoId");

            migrationBuilder.RenameColumn(
                name: "EquipoTutorId",
                table: "Diario",
                newName: "EquipoId");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Equipo",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "ProfesorId",
                table: "Equipo",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "TutorId",
                table: "Equipo",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "AlumnoId",
                table: "Equipo",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipo",
                table: "Equipo",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Mensaje_EquipoId",
                table: "Mensaje",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_AlumnoId",
                table: "Equipo",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Diario_EquipoId",
                table: "Diario",
                column: "EquipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diario_Equipo_EquipoId",
                table: "Diario",
                column: "EquipoId",
                principalTable: "Equipo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipo_User_AlumnoId",
                table: "Equipo",
                column: "AlumnoId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipo_User_ProfesorId",
                table: "Equipo",
                column: "ProfesorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipo_User_TutorId",
                table: "Equipo",
                column: "TutorId",
                principalTable: "User",
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
    }
}
