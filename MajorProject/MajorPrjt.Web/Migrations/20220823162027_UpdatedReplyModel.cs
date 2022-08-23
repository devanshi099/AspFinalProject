using Microsoft.EntityFrameworkCore.Migrations;

namespace MajorPrjt.Web.Migrations
{
    public partial class UpdatedReplyModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RepliedBy",
                table: "Replies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RepliedBy",
                table: "Replies");
        }
    }
}
