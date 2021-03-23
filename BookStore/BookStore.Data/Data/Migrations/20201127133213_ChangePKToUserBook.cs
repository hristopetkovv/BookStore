using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Data.Migrations
{
    public partial class ChangePKToUserBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBook",
                table: "UserBook");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "UserBook",
                nullable: false,
                defaultValue: 2);

            migrationBuilder.AddColumn<string>(
                name: "fullname",
                table: "Author",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBook",
                table: "UserBook",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_UserBook_bookid",
                table: "UserBook",
                column: "bookid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBook",
                table: "UserBook");

            migrationBuilder.DropIndex(
                name: "IX_UserBook_bookid",
                table: "UserBook");

            migrationBuilder.DropColumn(
                name: "id",
                table: "UserBook");

            migrationBuilder.DropColumn(
                name: "fullname",
                table: "Author");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBook",
                table: "UserBook",
                columns: new[] { "bookid", "userid" });
        }
    }
}
