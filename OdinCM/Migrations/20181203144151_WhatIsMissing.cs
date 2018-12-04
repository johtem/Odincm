using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OdinCM.Migrations
{
    public partial class WhatIsMissing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ArticleHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AuthorId", "Published" },
                values: new object[] { new Guid("43c5ac64-0d71-4880-9d38-feefbf2fa277"), new DateTime(2018, 12, 3, 14, 41, 51, 354, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AuthorId", "Published" },
                values: new object[] { new Guid("43c5ac64-0d71-4880-9d38-feefbf2fa277"), new DateTime(2018, 12, 3, 14, 41, 51, 354, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2018, 12, 3, 14, 41, 51, 366, DateTimeKind.Utc), new DateTime(2018, 12, 3, 14, 41, 51, 366, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2018, 12, 3, 14, 41, 51, 366, DateTimeKind.Utc), new DateTime(2018, 12, 3, 14, 41, 51, 366, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2018, 12, 3, 14, 41, 51, 366, DateTimeKind.Utc), new DateTime(2018, 12, 3, 14, 41, 51, 366, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2018, 12, 3, 14, 41, 51, 366, DateTimeKind.Utc), new DateTime(2018, 12, 3, 14, 41, 51, 366, DateTimeKind.Utc) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ArticleHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AuthorId", "Published" },
                values: new object[] { new Guid("c00bf840-b676-4083-a4f2-7d81c2607a38"), new DateTime(2018, 12, 3, 13, 15, 16, 739, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AuthorId", "Published" },
                values: new object[] { new Guid("c00bf840-b676-4083-a4f2-7d81c2607a38"), new DateTime(2018, 12, 3, 13, 15, 16, 739, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2018, 12, 3, 13, 15, 16, 745, DateTimeKind.Utc), new DateTime(2018, 12, 3, 13, 15, 16, 745, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2018, 12, 3, 13, 15, 16, 745, DateTimeKind.Utc), new DateTime(2018, 12, 3, 13, 15, 16, 745, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2018, 12, 3, 13, 15, 16, 745, DateTimeKind.Utc), new DateTime(2018, 12, 3, 13, 15, 16, 745, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2018, 12, 3, 13, 15, 16, 745, DateTimeKind.Utc), new DateTime(2018, 12, 3, 13, 15, 16, 745, DateTimeKind.Utc) });
        }
    }
}
