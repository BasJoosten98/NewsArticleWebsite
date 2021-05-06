using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsSite.Migrations
{
    public partial class FKUserIdInArticles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Author",
                table: "Articles");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Articles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_AspNetUsers_UserId",
                table: "Articles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AspNetUsers_UserId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_UserId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Articles");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Articles",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

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
    }
}
