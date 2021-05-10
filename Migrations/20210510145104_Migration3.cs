using Microsoft.EntityFrameworkCore.Migrations;

namespace TFG_Back.Migrations
{
    public partial class Migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
