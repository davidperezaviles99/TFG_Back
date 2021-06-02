using Microsoft.EntityFrameworkCore.Migrations;

namespace TFG_Back.Migrations
{
    public partial class Mig7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Mensaje",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mensaje_UserId",
                table: "Mensaje",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mensaje_User_UserId",
                table: "Mensaje",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mensaje_User_UserId",
                table: "Mensaje");

            migrationBuilder.DropIndex(
                name: "IX_Mensaje_UserId",
                table: "Mensaje");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Mensaje");
        }
    }
}
