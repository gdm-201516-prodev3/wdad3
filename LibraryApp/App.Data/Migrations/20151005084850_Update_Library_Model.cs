using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace App.Data.Migrations
{
    public partial class Update_Library_Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Libraries",
                type: "nvarchar(512)",
                isNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Url", table: "Libraries");
        }
    }
}
