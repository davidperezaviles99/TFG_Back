using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TFG_Back.Migrations
{
    public partial class Mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EvaluacionP",
                table: "Diario");

            migrationBuilder.DropColumn(
                name: "EvaluacionT",
                table: "Diario");

            migrationBuilder.RenameColumn(
                name: "LinkExterno",
                table: "Diario",
                newName: "Link");

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
                name: "IX_Evaluacion_EquipoId",
                table: "Evaluacion",
                column: "EquipoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evaluacion");

            migrationBuilder.RenameColumn(
                name: "Link",
                table: "Diario",
                newName: "LinkExterno");

            migrationBuilder.AddColumn<string>(
                name: "EvaluacionP",
                table: "Diario",
                type: "character varying(2)",
                maxLength: 2,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EvaluacionT",
                table: "Diario",
                type: "character varying(2)",
                maxLength: 2,
                nullable: true);
        }
    }
}
