using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BookStore.Data.Migrations
{
    public partial class IdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "User",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<int>(
                name: "accessfailedcount",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "concurrencystamp",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "emailconfirmed",
                table: "User",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "lockoutenabled",
                table: "User",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "lockoutend",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "normalizedemail",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "normalizedusername",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "passwordhash",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "phonenumber",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "phonenumberconfirmed",
                table: "User",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "securitystamp",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "twofactorenabled",
                table: "User",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    roleid = table.Column<string>(nullable: true),
                    claimtype = table.Column<string>(nullable: true),
                    claimvalue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    normalizedname = table.Column<string>(nullable: true),
                    concurrencystamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<string>(nullable: true),
                    claimtype = table.Column<string>(nullable: true),
                    claimvalue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    loginprovider = table.Column<string>(nullable: true),
                    providerkey = table.Column<string>(nullable: true),
                    providerdisplayname = table.Column<string>(nullable: true),
                    userid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    userid = table.Column<string>(nullable: true),
                    roleid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    userid = table.Column<string>(nullable: true),
                    loginprovider = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropColumn(
                name: "accessfailedcount",
                table: "User");

            migrationBuilder.DropColumn(
                name: "concurrencystamp",
                table: "User");

            migrationBuilder.DropColumn(
                name: "emailconfirmed",
                table: "User");

            migrationBuilder.DropColumn(
                name: "lockoutenabled",
                table: "User");

            migrationBuilder.DropColumn(
                name: "lockoutend",
                table: "User");

            migrationBuilder.DropColumn(
                name: "normalizedemail",
                table: "User");

            migrationBuilder.DropColumn(
                name: "normalizedusername",
                table: "User");

            migrationBuilder.DropColumn(
                name: "passwordhash",
                table: "User");

            migrationBuilder.DropColumn(
                name: "phonenumber",
                table: "User");

            migrationBuilder.DropColumn(
                name: "phonenumberconfirmed",
                table: "User");

            migrationBuilder.DropColumn(
                name: "securitystamp",
                table: "User");

            migrationBuilder.DropColumn(
                name: "twofactorenabled",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "User",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
