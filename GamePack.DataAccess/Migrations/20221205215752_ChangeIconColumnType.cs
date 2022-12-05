using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamePack.DataAccess.Migrations
{
    public partial class ChangeIconColumnType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IconPath",
                table: "Games",
                newName: "Base64Icon");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Base64Icon",
                table: "Games",
                newName: "IconPath");
        }
    }
}
