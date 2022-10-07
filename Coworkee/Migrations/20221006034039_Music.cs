using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Coworkee.Migrations
{
    public partial class Music : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Music",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(type: "varchar(250)", nullable: false),
                    author = table.Column<string>(type: "varchar(250)", nullable: false),
                    link = table.Column<string>(type: "varchar(250)", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_music", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Music");
        }
    }
}
