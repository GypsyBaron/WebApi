using Microsoft.EntityFrameworkCore.Migrations;

namespace HugDb.Migrations
{
    public partial class updatedatabse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Committees_Users_UserId",
                table: "Committees");

            migrationBuilder.DropIndex(
                name: "IX_Committees_UserId",
                table: "Committees");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Committees");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Hugs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hugs_UserId",
                table: "Hugs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hugs_Users_UserId",
                table: "Hugs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hugs_Users_UserId",
                table: "Hugs");

            migrationBuilder.DropIndex(
                name: "IX_Hugs_UserId",
                table: "Hugs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Hugs");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Committees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Committees_UserId",
                table: "Committees",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Committees_Users_UserId",
                table: "Committees",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
