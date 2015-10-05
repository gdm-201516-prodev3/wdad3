using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace App.Data.Migrations
{
    public partial class Add_FAQ_Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faqs",
                columns: table => new
                {
                    Id = table.Column<short>(isNullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Answer = table.Column<string>(type: "nvarchar(4096)", isNullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", isNullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime", isNullable: true),
                    Description = table.Column<string>(type: "nvarchar(1024)", isNullable: true),
                    Question = table.Column<string>(type: "nvarchar(1024)", isNullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", isNullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQ", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Faqs");
        }
    }
}
