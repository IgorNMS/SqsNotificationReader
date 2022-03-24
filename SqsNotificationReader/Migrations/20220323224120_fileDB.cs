using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SqsNotificationReader.Migrations
{
    public partial class fileDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SqsFiles",
                columns: table => new
                {
                    FileName = table.Column<string>(type: "varchar(767)", nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SqsFiles", x => x.FileName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SqsFiles");
        }
    }
}
