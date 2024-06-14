using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImagesWebService.Migrations
{
    public partial class InitialCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // FIRST MIGRATION COMMENTED STUFF OUT, SO ITS A FULL BACKUP

            //migrationBuilder.CreateTable(
            //    name: "Images",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
            //        IsBack = table.Column<bool>(type: "bit", nullable: true),
            //        Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Images");
        }
    }
}
