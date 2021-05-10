using Microsoft.EntityFrameworkCore.Migrations;

namespace TFG_Back.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ProfesorId",
                table: "Asignaturas",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Asignaturas_ProfesorId",
                table: "Asignaturas",
                column: "ProfesorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Asignaturas_User_ProfesorId",
                table: "Asignaturas",
                column: "ProfesorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asignaturas_User_ProfesorId",
                table: "Asignaturas");

            migrationBuilder.DropIndex(
                name: "IX_Asignaturas_ProfesorId",
                table: "Asignaturas");

            migrationBuilder.DropColumn(
                name: "ProfesorId",
                table: "Asignaturas");
        }
    }
}
