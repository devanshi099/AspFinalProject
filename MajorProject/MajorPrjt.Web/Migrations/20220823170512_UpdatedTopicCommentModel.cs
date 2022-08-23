using Microsoft.EntityFrameworkCore.Migrations;

namespace MajorPrjt.Web.Migrations
{
    public partial class UpdatedTopicCommentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Topics",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CommentedBy",
                table: "Comments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "CommentedBy",
                table: "Comments");
        }
    }
}
