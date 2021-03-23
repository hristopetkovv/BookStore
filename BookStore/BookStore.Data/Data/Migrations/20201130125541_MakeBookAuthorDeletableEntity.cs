using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Data.Migrations
{
    public partial class MakeBookAuthorDeletableEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fullname",
                table: "Author");

            migrationBuilder.AddColumn<DateTime>(
                name: "createdon",
                table: "BookAuthor",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "deletedon",
                table: "BookAuthor",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "isdeleted",
                table: "BookAuthor",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "updatedon",
                table: "BookAuthor",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createdon",
                table: "BookAuthor");

            migrationBuilder.DropColumn(
                name: "deletedon",
                table: "BookAuthor");

            migrationBuilder.DropColumn(
                name: "isdeleted",
                table: "BookAuthor");

            migrationBuilder.DropColumn(
                name: "updatedon",
                table: "BookAuthor");

            migrationBuilder.AddColumn<string>(
                name: "fullname",
                table: "Author",
                type: "text",
                nullable: true);
        }
    }
}
