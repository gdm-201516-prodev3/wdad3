using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace App.Data.Migrations
{
    public partial class Add_Post_Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(isNullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Body = table.Column<string>(type: "nvarchar(65536)", isNullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", isNullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime", isNullable: true),
                    Description = table.Column<string>(type: "nvarchar(1024)", isNullable: true),
                    Synopsis = table.Column<string>(type: "nvarchar(1024)", isNullable: false),
                    Title = table.Column<string>(type: "nvarchar(128)", isNullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", isNullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Posts");
        }
    }
}
