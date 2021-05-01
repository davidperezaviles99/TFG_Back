using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TFG_Back.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asignaturas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Codigo = table.Column<long>(type: "bigint", maxLength: 30, nullable: false),
                    Curso = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Asignatura = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignaturas", x => x.Id);
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
                    ProfesorId = table.Column<long>(type: "bigint", nullable: true),
                    TutorId1 = table.Column<long>(type: "bigint", nullable: true),
                    TutorId = table.Column<long>(type: "bigint", nullable: true),
                    AlumnoId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_User_AlumnoId",
                        column: x => x.AlumnoId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_User_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_User_TutorId",
                        column: x => x.TutorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_User_TutorId1",
                        column: x => x.TutorId1,
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
                    Horas = table.Column<long>(type: "bigint", maxLength: 3, nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    LinkExterno = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    EvaluacionT = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    EvaluacionP = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    AlumnoId = table.Column<long>(type: "bigint", nullable: true),
                    AsignaturasId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diario_Asignaturas_AsignaturasId",
                        column: x => x.AsignaturasId,
                        principalTable: "Asignaturas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diario_User_AlumnoId",
                        column: x => x.AlumnoId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mensaje",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    Comentario = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensaje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mensaje_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diario_AlumnoId",
                table: "Diario",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Diario_AsignaturasId",
                table: "Diario",
                column: "AsignaturasId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensaje_UserId",
                table: "Mensaje",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_AlumnoId",
                table: "User",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ProfesorId",
                table: "User",
                column: "ProfesorId");

            migrationBuilder.CreateIndex(
                name: "IX_User_TutorId",
                table: "User",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_User_TutorId1",
                table: "User",
                column: "TutorId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diario");

            migrationBuilder.DropTable(
                name: "Mensaje");

            migrationBuilder.DropTable(
                name: "Asignaturas");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
