using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MemberManagement.Data.Migrations
{
    public partial class updateData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Contact_R__asdasd__534D60F1",
                table: "Contact_Member");

            migrationBuilder.DropColumn(
                name: "Nickname",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "HousldRepre",
                table: "Family");

            migrationBuilder.DropColumn(
                name: "MumberMembers",
                table: "Family");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Family");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Family");

            migrationBuilder.DropColumn(
                name: "YearBirth",
                table: "Family");

            migrationBuilder.AddColumn<string>(
                name: "TypeRole",
                table: "Roles",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_Member_RoleId",
                table: "Contact_Member",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK__Contact_R1__asdasd__534D60F1",
                table: "Contact_Member",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Contact_R1__asdasd__534D60F1",
                table: "Contact_Member");

            migrationBuilder.DropIndex(
                name: "IX_Contact_Member_RoleId",
                table: "Contact_Member");

            migrationBuilder.DropColumn(
                name: "TypeRole",
                table: "Roles");

            migrationBuilder.AddColumn<string>(
                name: "Nickname",
                table: "Member",
                type: "nvarchar(254)",
                maxLength: 254,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HousldRepre",
                table: "Family",
                type: "nvarchar(254)",
                maxLength: 254,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MumberMembers",
                table: "Family",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Family",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Family",
                type: "varchar(15)",
                unicode: false,
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "YearBirth",
                table: "Family",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK__Contact_R__asdasd__534D60F1",
                table: "Contact_Member",
                column: "ContactId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
