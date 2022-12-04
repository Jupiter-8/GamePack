using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamePack.DataAccess.Migrations
{
    public partial class AddCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Action" });

            migrationBuilder.InsertData(
                "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Adventure" });

            migrationBuilder.InsertData(
                "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Casual" });

            migrationBuilder.InsertData(
                "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Indie" });

            migrationBuilder.InsertData(
                "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Massively Multiplayer" });

            migrationBuilder.InsertData(
                "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "Racing" });

            migrationBuilder.InsertData(
                "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 7, "RPG" });

            migrationBuilder.InsertData(
                "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 8, "Simulation" });

            migrationBuilder.InsertData(
                "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 9, "Sports" });

            migrationBuilder.InsertData(
                "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 10, "Strategy" });

            migrationBuilder.InsertData(
                "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 11, "Other" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                "Categories",
                "Id",
                new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 });
        }
    }
}
