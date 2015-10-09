using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace App.Data.Migrations
{
    public partial class Add_PostCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PostCategories",
                columns: table => new
                {
                    PostId = table.Column<short>(isNullable: false),
                    CategoryId = table.Column<short>(isNullable: false),
                    PostId1 = table.Column<int>(isNullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategory", x => new { x.PostId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_PostCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PostCategory_Post_PostId1",
                        column: x => x.PostId1,
                        principalTable: "Posts",
                        principalColumn: "Id");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("PostCategories");
        }
    }
}
