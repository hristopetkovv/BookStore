using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BookStore.Migrations
{
    public partial class UpdateOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    createdon = table.Column<DateTime>(nullable: false),
                    updatedon = table.Column<DateTime>(nullable: false),
                    boughton = table.Column<DateTime>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    userid = table.Column<int>(nullable: false),
                    totalprice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.id);
                    table.ForeignKey(
                        name: "FK_Order_User_userid",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_userid",
                table: "Order",
                column: "userid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.AddColumn<int>(
                name: "bookid",
                table: "Book",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "boughton",
                table: "Book",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "Book",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "totalprice",
                table: "Book",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "userid",
                table: "Book",
                type: "integer",
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
    }
}
