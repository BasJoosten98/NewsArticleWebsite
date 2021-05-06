using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsSite.Migrations
{
    public partial class SeedArticlesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Author", "Content", "Title" },
                values: new object[] { 1, "Henk Smits", "Local bank gave away all its money. Big software bug was probably the cause of it! Very sad...", "Big mistake at local bank" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Author", "Content", "Title" },
                values: new object[] { 2, "Maya Bee", "The nature club located in Someren has planted over a thousand flowers in Vendoven Central park. Locals say that it looks beautiful. ", "Flower power" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Author", "Content", "Title" },
                values: new object[] { 3, "Cindy Smave", "Tesla is going to announce their new truck in the upcoming weeks. It should be one of the most powerful trucks yet in existence!", "New Tesla Truck" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
