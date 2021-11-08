using Microsoft.EntityFrameworkCore.Migrations;

namespace MemberManagement.Data.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__FundGr1__Membe__403A8C7D",
                table: "FundGroup");

            migrationBuilder.AddForeignKey(
                name: "FK__FundGr1__Group__403A8C7D",
                table: "FundGroup",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__FundGr1__Group__403A8C7D",
                table: "FundGroup");

            migrationBuilder.AddForeignKey(
                name: "FK__FundGr1__Membe__403A8C7D",
                table: "FundGroup",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
