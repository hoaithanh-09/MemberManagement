using Microsoft.EntityFrameworkCore.Migrations;

namespace MemberManagement.Data.Migrations
{
    public partial class CreateAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdAccount",
                table: "Member",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdAccount",
                table: "Member");
        }
    }
}
