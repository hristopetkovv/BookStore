using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BookStore.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    createdon = table.Column<DateTime>(nullable: false),
                    updatedon = table.Column<DateTime>(nullable: false),
                    firstname = table.Column<string>(maxLength: 50, nullable: false),
                    lastname = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    createdon = table.Column<DateTime>(nullable: false),
                    updatedon = table.Column<DateTime>(nullable: false),
                    title = table.Column<string>(maxLength: 100, nullable: false),
                    description = table.Column<string>(maxLength: 1000, nullable: false),
                    price = table.Column<decimal>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    isavailable = table.Column<bool>(nullable: false),
                    publishhouse = table.Column<string>(maxLength: 100, nullable: false),
                    imageurl = table.Column<string>(nullable: true),
                    genreid = table.Column<int>(nullable: false),
                    publishedon = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    createdon = table.Column<DateTime>(nullable: false),
                    updatedon = table.Column<DateTime>(nullable: false),
                    isdeleted = table.Column<bool>(nullable: false),
                    deletedon = table.Column<DateTime>(nullable: false),
                    firstname = table.Column<string>(maxLength: 50, nullable: false),
                    lastname = table.Column<string>(maxLength: 50, nullable: false),
                    email = table.Column<string>(maxLength: 100, nullable: false),
                    username = table.Column<string>(maxLength: 30, nullable: false),
                    telephonenumber = table.Column<int>(maxLength: 20, nullable: true),
                    password = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthor",
                columns: table => new
                {
                    bookid = table.Column<int>(nullable: false),
                    authorid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthor", x => new { x.authorid, x.bookid });
                    table.ForeignKey(
                        name: "FK_BookAuthor_Author_authorid",
                        column: x => x.authorid,
                        principalTable: "Author",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthor_Book_bookid",
                        column: x => x.bookid,
                        principalTable: "Book",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    createdon = table.Column<DateTime>(nullable: false),
                    updatedon = table.Column<DateTime>(nullable: false),
                    text = table.Column<string>(maxLength: 200, nullable: false),
                    username = table.Column<string>(nullable: false),
                    bookid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.id);
                    table.ForeignKey(
                        name: "FK_Comment_Book_bookid",
                        column: x => x.bookid,
                        principalTable: "Book",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    bookid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.id);
                    table.ForeignKey(
                        name: "FK_Genre_Book_bookid",
                        column: x => x.bookid,
                        principalTable: "Book",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBook",
                columns: table => new
                {
                    userid = table.Column<int>(nullable: false),
                    bookid = table.Column<int>(nullable: false),
                    pieces = table.Column<int>(nullable: false),
                    boughton = table.Column<DateTime>(nullable: false),
                    status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBook", x => new { x.bookid, x.userid });
                    table.ForeignKey(
                        name: "FK_UserBook_Book_bookid",
                        column: x => x.bookid,
                        principalTable: "Book",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBook_User_userid",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthor_bookid",
                table: "BookAuthor",
                column: "bookid");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_bookid",
                table: "Comment",
                column: "bookid");

            migrationBuilder.CreateIndex(
                name: "IX_Genre_bookid",
                table: "Genre",
                column: "bookid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserBook_userid",
                table: "UserBook",
                column: "userid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthor");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "UserBook");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
