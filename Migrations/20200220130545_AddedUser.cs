using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace moment3_2.Migrations
{
    public partial class AddedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: false),
                    BorrowingDate = table.Column<DateTime>(nullable: false),
                    CDId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_CD_CDId",
                        column: x => x.CDId,
                        principalTable: "CD",
                        principalColumn: "CDId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_CDId",
                table: "User",
                column: "CDId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
