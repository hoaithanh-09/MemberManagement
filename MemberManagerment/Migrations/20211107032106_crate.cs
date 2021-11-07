using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MemberManagement.Data.Migrations
{
    public partial class crate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__FundMembe__FundI__412EB0B6",
                table: "FundMember");

            migrationBuilder.DropForeignKey(
                name: "FK__FundMembe__Membe__403A8C7D",
                table: "FundMember");

            migrationBuilder.DropForeignKey(
                name: "FK_FundMember_Member_MemberId1",
                table: "FundMember");

            migrationBuilder.DropPrimaryKey(
                name: "PK__FundMemb__B4C094DDE6A8989C",
                table: "FundMember");

            migrationBuilder.DropIndex(
                name: "IX_FundMember_MemberId1",
                table: "FundMember");

            migrationBuilder.DropColumn(
                name: "Action",
                table: "FundMember");

            migrationBuilder.DropColumn(
                name: "MemberId1",
                table: "FundMember");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "FundMember");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "FundMember",
                newName: "GroupId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "FundMember",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "FundMember",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FundMember",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Finish",
                table: "FundMember",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Money",
                table: "FundMember",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "FundMember",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FundMember",
                table: "FundMember",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "FundMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: true),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    FundId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FundMembers_Fund_FundId",
                        column: x => x.FundId,
                        principalTable: "Fund",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FundMembers_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FundMember_GroupId",
                table: "FundMember",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_FundMembers_FundId",
                table: "FundMembers",
                column: "FundId");

            migrationBuilder.CreateIndex(
                name: "IX_FundMembers_MemberId",
                table: "FundMembers",
                column: "MemberId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__FundGr__Membe__403A8C7D",
                table: "FundMember");

            migrationBuilder.DropForeignKey(
                name: "FK__FundGroups__FundI__412EB0B6",
                table: "FundMember");

            migrationBuilder.DropTable(
                name: "FundMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FundMember",
                table: "FundMember");

            migrationBuilder.DropIndex(
                name: "IX_FundMember_GroupId",
                table: "FundMember");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FundMember");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "FundMember");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "FundMember");

            migrationBuilder.DropColumn(
                name: "Finish",
                table: "FundMember");

            migrationBuilder.DropColumn(
                name: "Money",
                table: "FundMember");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "FundMember");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "FundMember",
                newName: "MemberId");

            migrationBuilder.AddColumn<string>(
                name: "Action",
                table: "FundMember",
                type: "char(10)",
                unicode: false,
                fixedLength: true,
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MemberId1",
                table: "FundMember",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Total",
                table: "FundMember",
                type: "float",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK__FundMemb__B4C094DDE6A8989C",
                table: "FundMember",
                columns: new[] { "MemberId", "FundId" });

            migrationBuilder.CreateIndex(
                name: "IX_FundMember_MemberId1",
                table: "FundMember",
                column: "MemberId1");

            migrationBuilder.AddForeignKey(
                name: "FK__FundMembe__FundI__412EB0B6",
                table: "FundMember",
                column: "FundId",
                principalTable: "Fund",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__FundMembe__Membe__403A8C7D",
                table: "FundMember",
                column: "MemberId",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FundMember_Member_MemberId1",
                table: "FundMember",
                column: "MemberId1",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
