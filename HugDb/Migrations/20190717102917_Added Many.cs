using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HugDb.Migrations
{
    public partial class AddedMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommitteeId",
                table: "Hugs",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Committees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Committees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Committees_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserCommittee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    CommitteeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCommittee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCommittee_Committees_CommitteeId",
                        column: x => x.CommitteeId,
                        principalTable: "Committees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCommittee_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hugs_CommitteeId",
                table: "Hugs",
                column: "CommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_Committees_UserId",
                table: "Committees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCommittee_CommitteeId",
                table: "UserCommittee",
                column: "CommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCommittee_UserId",
                table: "UserCommittee",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hugs_Committees_CommitteeId",
                table: "Hugs",
                column: "CommitteeId",
                principalTable: "Committees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hugs_Committees_CommitteeId",
                table: "Hugs");

            migrationBuilder.DropTable(
                name: "UserCommittee");

            migrationBuilder.DropTable(
                name: "Committees");

            migrationBuilder.DropIndex(
                name: "IX_Hugs_CommitteeId",
                table: "Hugs");

            migrationBuilder.DropColumn(
                name: "CommitteeId",
                table: "Hugs");
        }
    }
}
