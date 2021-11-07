using Microsoft.EntityFrameworkCore.Migrations;

namespace MemberManagement.Data.Migrations
{
    public partial class crate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__FundGr__Membe__403A8C7D",
                table: "FundMember");

            migrationBuilder.DropForeignKey(
                name: "FK__FundGroups__FundI__412EB0B6",
                table: "FundMember");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FundMember",
                table: "FundMember");

            migrationBuilder.RenameTable(
                name: "FundMember",
                newName: "FundGroup");

            migrationBuilder.RenameIndex(
                name: "IX_FundMember_GroupId",
                table: "FundGroup",
                newName: "IX_FundGroup_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_FundMember_FundId",
                table: "FundGroup",
                newName: "IX_FundGroup_FundId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FundGroup",
                table: "FundGroup",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__FundGr1__Membe__403A8C7D",
                table: "FundGroup",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__FundGroups1__FundI__412EB0B6",
                table: "FundGroup",
                column: "FundId",
                principalTable: "Fund",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__FundGr1__Membe__403A8C7D",
                table: "FundGroup");

            migrationBuilder.DropForeignKey(
                name: "FK__FundGroups1__FundI__412EB0B6",
                table: "FundGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FundGroup",
                table: "FundGroup");

            migrationBuilder.RenameTable(
                name: "FundGroup",
                newName: "FundMember");

            migrationBuilder.RenameIndex(
                name: "IX_FundGroup_GroupId",
                table: "FundMember",
                newName: "IX_FundMember_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_FundGroup_FundId",
                table: "FundMember",
                newName: "IX_FundMember_FundId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FundMember",
                table: "FundMember",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__FundGr__Membe__403A8C7D",
                table: "FundMember",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__FundGroups__FundI__412EB0B6",
                table: "FundMember",
                column: "FundId",
                principalTable: "Fund",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
