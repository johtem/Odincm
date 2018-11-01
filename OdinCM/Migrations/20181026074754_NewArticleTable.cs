﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OdinCM.Migrations
{
    public partial class NewArticleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
    name: "Articles",
    columns: table => new
    {
        Id = table.Column<int>(nullable: false)
            .Annotation("Sqlite:Autoincrement", true),
        Content = table.Column<string>(nullable: true),
        Published = table.Column<DateTime>(nullable: false),
        Slug = table.Column<string>(nullable: true),
        Topic = table.Column<string>(nullable: false)
    },
    constraints: table =>
    {
        table.PrimaryKey("PK_Articles", x => x.Id);
 
    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");
        }
    }
}
