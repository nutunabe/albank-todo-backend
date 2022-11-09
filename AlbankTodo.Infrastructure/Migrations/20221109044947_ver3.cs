using Microsoft.EntityFrameworkCore.Migrations;

namespace AlbankTodo.Infrastructure.Migrations
{
    public partial class ver3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRecycled",
                table: "AlbankTask",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRecycled",
                table: "AlbankTask");
        }
    }
}
