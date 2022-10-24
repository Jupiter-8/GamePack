using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamePack.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastRun = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IconPath = table.Column<string>(type: "TEXT", nullable: false),
                    ExePath = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
