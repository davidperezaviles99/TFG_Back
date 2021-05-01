using Microsoft.EntityFrameworkCore.Migrations;

namespace TFG_Back.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_User_AlumnoId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_User_ProfesorId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_User_TutorId1",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_AlumnoId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ProfesorId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_TutorId1",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AlumnoId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ProfesorId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "TutorId1",
                table: "User");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlumnoProfesor");

            migrationBuilder.AddColumn<long>(
                name: "AlumnoId",
                table: "User",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProfesorId",
                table: "User",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TutorId1",
                table: "User",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_AlumnoId",
                table: "User",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ProfesorId",
                table: "User",
                column: "ProfesorId");

            migrationBuilder.CreateIndex(
                name: "IX_User_TutorId1",
                table: "User",
                column: "TutorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_AlumnoId",
                table: "User",
                column: "AlumnoId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_ProfesorId",
                table: "User",
                column: "ProfesorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_TutorId1",
                table: "User",
                column: "TutorId1",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
