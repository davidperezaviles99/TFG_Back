using Microsoft.EntityFrameworkCore.Migrations;

namespace TFG_Back.Migrations
{
    public partial class Mig8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Diario",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Diario_UserId",
                table: "Diario",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diario_User_UserId",
                table: "Diario",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diario_User_UserId",
                table: "Diario");

            migrationBuilder.DropIndex(
                name: "IX_Diario_UserId",
                table: "Diario");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Diario");
        }
    }
}
