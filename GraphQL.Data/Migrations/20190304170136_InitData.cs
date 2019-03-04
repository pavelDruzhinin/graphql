using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GraphQL.Data.Migrations
{
    public partial class InitData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "BlogPosts",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "BlogCategories",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.InsertData(
                table: "BlogCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Category 1" },
                    { 2, "Category 2" },
                    { 3, "Category 3" },
                    { 4, "Category 4" },
                    { 5, "Category 5" },
                    { 6, "Category 6" },
                    { 7, "Category 7" }
                });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "Body", "CreatedUtcDateTime", "Title" },
                values: new object[,]
                {
                    { 8, "Body 8", new DateTime(2019, 3, 4, 17, 1, 36, 584, DateTimeKind.Utc).AddTicks(7680), "Title 8" },
                    { 7, "Body 7", new DateTime(2019, 3, 4, 17, 1, 36, 584, DateTimeKind.Utc).AddTicks(7680), "Title 7" },
                    { 6, "Body 6", new DateTime(2019, 3, 4, 17, 1, 36, 584, DateTimeKind.Utc).AddTicks(7680), "Title 6" },
                    { 5, "Body 5", new DateTime(2019, 3, 4, 17, 1, 36, 584, DateTimeKind.Utc).AddTicks(7680), "Title 5" },
                    { 2, "Body 2", new DateTime(2019, 3, 4, 17, 1, 36, 584, DateTimeKind.Utc).AddTicks(7670), "Title 2" },
                    { 3, "Body 3", new DateTime(2019, 3, 4, 17, 1, 36, 584, DateTimeKind.Utc).AddTicks(7680), "Title 3" },
                    { 9, "Body 9", new DateTime(2019, 3, 4, 17, 1, 36, 584, DateTimeKind.Utc).AddTicks(7680), "Title 9" },
                    { 1, "Body 1", new DateTime(2019, 3, 4, 17, 1, 36, 584, DateTimeKind.Utc).AddTicks(7220), "Title 1" },
                    { 4, "Body 4", new DateTime(2019, 3, 4, 17, 1, 36, 584, DateTimeKind.Utc).AddTicks(7680), "Title 4" },
                    { 10, "Body 10", new DateTime(2019, 3, 4, 17, 1, 36, 584, DateTimeKind.Utc).AddTicks(7680), "Title 10" }
                });

            migrationBuilder.InsertData(
                table: "BlogsCategories",
                columns: new[] { "BlogPostId", "CategoryId", "BlogPostId1" },
                values: new object[,]
                {
                    { 1, 2, null },
                    { 1, 3, null },
                    { 1, 4, null },
                    { 1, 5, null },
                    { 2, 1, null },
                    { 2, 2, null },
                    { 2, 4, null },
                    { 2, 6, null },
                    { 2, 7, null },
                    { 3, 2, null },
                    { 9, 7, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "BlogsCategories",
                keyColumns: new[] { "BlogPostId", "CategoryId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "BlogsCategories",
                keyColumns: new[] { "BlogPostId", "CategoryId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "BlogsCategories",
                keyColumns: new[] { "BlogPostId", "CategoryId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "BlogsCategories",
                keyColumns: new[] { "BlogPostId", "CategoryId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "BlogsCategories",
                keyColumns: new[] { "BlogPostId", "CategoryId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "BlogsCategories",
                keyColumns: new[] { "BlogPostId", "CategoryId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "BlogsCategories",
                keyColumns: new[] { "BlogPostId", "CategoryId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "BlogsCategories",
                keyColumns: new[] { "BlogPostId", "CategoryId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "BlogsCategories",
                keyColumns: new[] { "BlogPostId", "CategoryId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "BlogsCategories",
                keyColumns: new[] { "BlogPostId", "CategoryId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "BlogsCategories",
                keyColumns: new[] { "BlogPostId", "CategoryId" },
                keyValues: new object[] { 9, 7 });

            migrationBuilder.DeleteData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "BlogPosts",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "BlogCategories",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);
        }
    }
}
