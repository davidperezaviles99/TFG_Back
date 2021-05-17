using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TFG_Back.Migrations
{
    public partial class Migration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_User_ProfesorId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ProfesorId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ProfesorId",
                table: "User");

            migrationBuilder.CreateTable(
                name: "ProfesorTutor",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProfesorId = table.Column<long>(type: "bigint", nullable: true),
                    TutorId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfesorTutor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfesorTutor_User_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfesorTutor_User_TutorId",
                        column: x => x.TutorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfesorTutor_ProfesorId",
                table: "ProfesorTutor",
                column: "ProfesorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfesorTutor_TutorId",
                table: "ProfesorTutor",
                column: "TutorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfesorTutor");

            migrationBuilder.AddColumn<long>(
                name: "ProfesorId",
                table: "User",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_ProfesorId",
                table: "User",
                column: "ProfesorId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_ProfesorId",
                table: "User",
                column: "ProfesorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
