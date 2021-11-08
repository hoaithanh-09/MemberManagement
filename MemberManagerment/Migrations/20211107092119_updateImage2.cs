using Microsoft.EntityFrameworkCore.Migrations;

namespace MemberManagement.Data.Migrations
{
    public partial class updateImage2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK__Image_Post__5535A963",
                table: "Image",
                column: "PostID",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Image_Post__5535A963",
                table: "Image");
        }
    }
}
