using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace App.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<short>(isNullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(isNullable: false),
                    DeletedAt = table.Column<DateTime>(isNullable: true),
                    Description = table.Column<string>(isNullable: true),
                    Name = table.Column<string>(isNullable: true),
                    UpdatedAt = table.Column<DateTime>(isNullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Libraries",
                columns: table => new
                {
                    Id = table.Column<short>(isNullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "char(3)", isNullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", isNullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime", isNullable: true),
                    Description = table.Column<string>(type: "nvarchar(1024)", isNullable: true),
                    Name = table.Column<string>(type: "nvarchar(128)", isNullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", isNullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Library", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "FAQ",
                columns: table => new
                {
                    Id = table.Column<short>(isNullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Answer = table.Column<string>(isNullable: true),
                    CreatedAt = table.Column<DateTime>(isNullable: false),
                    DeletedAt = table.Column<DateTime>(isNullable: true),
                    Description = table.Column<string>(isNullable: true),
                    LibraryId = table.Column<short>(isNullable: false),
                    Question = table.Column<string>(isNullable: true),
                    UpdatedAt = table.Column<DateTime>(isNullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQ", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FAQ_Library_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "Libraries",
                        principalColumn: "Id");
                });
            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<int>(isNullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Body = table.Column<string>(isNullable: true),
                    CreatedAt = table.Column<DateTime>(isNullable: false),
                    DeletedAt = table.Column<DateTime>(isNullable: true),
                    Description = table.Column<string>(isNullable: true),
                    LibraryId = table.Column<short>(isNullable: false),
                    Synopsis = table.Column<string>(isNullable: true),
                    Title = table.Column<string>(isNullable: true),
                    UpdatedAt = table.Column<DateTime>(isNullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Library_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "Libraries",
                        principalColumn: "Id");
                });
            migrationBuilder.CreateTable(
                name: "PostCategories",
                columns: table => new
                {
                    PostId = table.Column<int>(isNullable: false),
                    CategoryId = table.Column<short>(isNullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategory", x => new { x.PostId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_PostCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PostCategory_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("FAQ");
            migrationBuilder.DropTable("PostCategories");
            migrationBuilder.DropTable("Category");
            migrationBuilder.DropTable("Post");
            migrationBuilder.DropTable("Libraries");
        }
    }
}
