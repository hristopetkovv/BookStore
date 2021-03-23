using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Data.Migrations
{
    public partial class CreateTableOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "boughton",
                table: "UserBook");

            migrationBuilder.DropColumn(
                name: "status",
                table: "UserBook");

            migrationBuilder.AddColumn<int>(
                name: "bookid",
                table: "Book",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "boughton",
                table: "Book",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "Book",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "totalprice",
                table: "Book",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "userid",
                table: "Book",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_userid",
                table: "Book",
                column: "userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_User_userid",
                table: "Book",
                column: "userid",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_User_userid",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_userid",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "bookid",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "boughton",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "totalprice",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "userid",
                table: "Book");

            migrationBuilder.AddColumn<DateTime>(
                name: "boughton",
                table: "UserBook",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "UserBook",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
