using Microsoft.EntityFrameworkCore.Migrations;

namespace MemberManagement.Data.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdMember",
                table: "Family",
                type: "int",
                unicode: false,
                maxLength: 450,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "varchar(450)",
                oldUnicode: false,
                oldMaxLength: 450,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IdMember",
                table: "Family",
                type: "varchar(450)",
                unicode: false,
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldUnicode: false,
                oldMaxLength: 450);
        }
    }
}
