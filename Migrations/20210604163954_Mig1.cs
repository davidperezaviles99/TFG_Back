using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TFG_Back.Migrations
{
    public partial class Mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Numero = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    AsignaturaId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    Lastname = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    CursoId = table.Column<long>(type: "bigint", nullable: true),
                    NombreEmpresa = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "Equipo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AlumnoId = table.Column<long>(type: "bigint", nullable: false),
                    TutorId = table.Column<long>(type: "bigint", nullable: true),
                    ProfesorId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipo_User_AlumnoId",
                        column: x => x.AlumnoId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipo_User_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipo_User_TutorId",
                        column: x => x.TutorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Diario",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Horas = table.Column<long>(type: "bigint", maxLength: 2, nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Link = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    EvaluacionT = table.Column<string>(type: "text", nullable: true),
                    EvaluacionP = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    EquipoId = table.Column<long>(type: "bigint", nullable: true),
                    AsignaturaId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diario_Asignatura_AsignaturaId",
                        column: x => x.AsignaturaId,
                        principalTable: "Asignatura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diario_Equipo_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diario_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EquipoMensaje",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    EquipoId = table.Column<long>(type: "bigint", nullable: true),
                    MessageId = table.Column<long>(type: "bigint", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipoMensaje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipoMensaje_Equipo_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipoMensaje_Message_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Message",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipoMensaje_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Evaluacion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EvaluacionT = table.Column<string>(type: "text", nullable: true),
                    EvaluacionP = table.Column<string>(type: "text", nullable: true),
                    EquipoId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evaluacion_Equipo_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asignatura_ProfesorId",
                table: "Asignatura",
                column: "ProfesorId");

            migrationBuilder.CreateIndex(
                name: "IX_Curso_AsignaturaId",
                table: "Curso",
                column: "AsignaturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Diario_AsignaturaId",
                table: "Diario",
                column: "AsignaturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Diario_EquipoId",
                table: "Diario",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Diario_UserId",
                table: "Diario",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_AlumnoId",
                table: "Equipo",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_ProfesorId",
                table: "Equipo",
                column: "ProfesorId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_TutorId",
                table: "Equipo",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipoMensaje_EquipoId",
                table: "EquipoMensaje",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipoMensaje_MessageId",
                table: "EquipoMensaje",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipoMensaje_UserId",
                table: "EquipoMensaje",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluacion_EquipoId",
                table: "Evaluacion",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CursoId",
                table: "User",
                column: "CursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Curso_Asignatura_AsignaturaId",
                table: "Curso",
                column: "AsignaturaId",
                principalTable: "Asignatura",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asignatura_User_ProfesorId",
                table: "Asignatura");

            migrationBuilder.DropTable(
                name: "Diario");

            migrationBuilder.DropTable(
                name: "EquipoMensaje");

            migrationBuilder.DropTable(
                name: "Evaluacion");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Equipo");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Asignatura");
        }
    }
}
