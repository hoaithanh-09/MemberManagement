using Microsoft.EntityFrameworkCore.Migrations;

namespace MemberManagement.Data.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Post");

            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "Post",
                newName: "Titel");

            migrationBuilder.CreateTable(
                name: "Post_Image",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Post_Image__B45FE7F9811444D9", x => new { x.PostId, x.ImageId });
                    table.ForeignKey(
                        name: "FK__Role_Image__PostI__59063A47",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Role_Post__Image__5812160E",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_Image_ImageId",
                table: "Post_Image",
                column: "ImageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Post_Image");

            migrationBuilder.RenameColumn(
                name: "Titel",
                table: "Post",
                newName: "Longitude");

            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "Post",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
