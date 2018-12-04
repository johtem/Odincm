using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OdinCM.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Topic = table.Column<string>(maxLength: 100, nullable: false),
                    Slug = table.Column<string>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    AuthorId = table.Column<Guid>(nullable: false),
                    AuthorName = table.Column<string>(nullable: false),
                    Published = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    ViewCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerName = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "ArticleHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArticleId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<Guid>(nullable: false),
                    AuthorName = table.Column<string>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    Topic = table.Column<string>(maxLength: 100, nullable: false),
                    Slug = table.Column<string>(nullable: true),
                    Published = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleHistories_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdArticle = table.Column<int>(nullable: false),
                    ArticleId = table.Column<int>(nullable: true),
                    DisplayName = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    AuthorId = table.Column<Guid>(nullable: false),
                    Submitted = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SlugHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArticleId = table.Column<int>(nullable: true),
                    OldSlug = table.Column<string>(nullable: true),
                    Added = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlugHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SlugHistories_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "AuthorId", "AuthorName", "Content", "Published", "Slug", "Topic", "Version", "ViewCount" },
                values: new object[] { 1, new Guid("c00bf840-b676-4083-a4f2-7d81c2607a38"), "Unknown", "This is the default home page.  Please change me!", new DateTime(2018, 12, 3, 13, 15, 16, 739, DateTimeKind.Utc), "home-page", "HomePage", 1, 0 });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerID", "CreatedAt", "CustomerName", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2018, 12, 3, 13, 15, 16, 745, DateTimeKind.Utc), "Skf", new DateTime(2018, 12, 3, 13, 15, 16, 745, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerID", "CreatedAt", "CustomerName", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2018, 12, 3, 13, 15, 16, 745, DateTimeKind.Utc), "ABB", new DateTime(2018, 12, 3, 13, 15, 16, 745, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerID", "CreatedAt", "CustomerName", "UpdatedAt" },
                values: new object[] { 3, new DateTime(2018, 12, 3, 13, 15, 16, 745, DateTimeKind.Utc), "Yara", new DateTime(2018, 12, 3, 13, 15, 16, 745, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerID", "CreatedAt", "CustomerName", "UpdatedAt" },
                values: new object[] { 4, new DateTime(2018, 12, 3, 13, 15, 16, 745, DateTimeKind.Utc), "Ericsson", new DateTime(2018, 12, 3, 13, 15, 16, 745, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "ArticleHistories",
                columns: new[] { "Id", "ArticleId", "AuthorId", "AuthorName", "Content", "Published", "Slug", "Topic", "Version" },
                values: new object[] { 1, 1, new Guid("c00bf840-b676-4083-a4f2-7d81c2607a38"), "Unknown", "This is the default home page.  Please change me!", new DateTime(2018, 12, 3, 13, 15, 16, 739, DateTimeKind.Utc), "home-page", "HomePage", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleHistories_ArticleId",
                table: "ArticleHistories",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_Slug",
                table: "Articles",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ArticleId",
                table: "Comments",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_SlugHistories_ArticleId",
                table: "SlugHistories",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_SlugHistories_OldSlug_Added",
                table: "SlugHistories",
                columns: new[] { "OldSlug", "Added" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleHistories");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "SlugHistories");

            migrationBuilder.DropTable(
                name: "Articles");
        }
    }
}
