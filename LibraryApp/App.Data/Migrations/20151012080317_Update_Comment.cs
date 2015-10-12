using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace App.Data.Migrations
{
    public partial class Update_Comment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(isNullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Body = table.Column<string>(type: "nvarchar(65536)", isNullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", isNullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime", isNullable: true),
                    Description = table.Column<string>(type: "nvarchar(1024)", isNullable: true),
                    ParentCommentId = table.Column<int>(isNullable: true),
                    PostId = table.Column<int>(isNullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", isNullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Comment_ParentCommentId",
                        column: x => x.ParentCommentId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comment_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Comments");
        }
    }
}
