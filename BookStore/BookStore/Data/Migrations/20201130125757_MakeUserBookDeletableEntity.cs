using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Migrations
{
    public partial class MakeUserBookDeletableEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "createdon",
                table: "UserBook",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "deletedon",
                table: "UserBook",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "isdeleted",
                table: "UserBook",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "updatedon",
                table: "UserBook",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createdon",
                table: "UserBook");

            migrationBuilder.DropColumn(
                name: "deletedon",
                table: "UserBook");

            migrationBuilder.DropColumn(
                name: "isdeleted",
                table: "UserBook");

            migrationBuilder.DropColumn(
                name: "updatedon",
                table: "UserBook");

            migrationBuilder.AddColumn<DateTime>(
                name: "createdon",
                table: "BookAuthor",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "deletedon",
                table: "BookAuthor",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "isdeleted",
                table: "BookAuthor",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "updatedon",
                table: "BookAuthor",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
