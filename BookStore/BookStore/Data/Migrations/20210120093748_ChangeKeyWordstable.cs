using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Migrations
{
    public partial class ChangeKeyWordstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "keywords",
                table: "BookKeyword");

            migrationBuilder.AddColumn<string>(
                name: "keyword",
                table: "BookKeyword",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "keyword",
                table: "BookKeyword");

            migrationBuilder.AddColumn<string[]>(
                name: "keywords",
                table: "BookKeyword",
                type: "text[]",
                nullable: true);
        }
    }
}
