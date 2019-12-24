using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShortUrl.Data.Migrations
{
    public partial class CreateTableItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", maxLength: 7, nullable: false),
                    OriginUrl = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Segment = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    ExpiredDate = table.Column<DateTimeOffset>(type: "datetimeoffset", maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");
        }
    }
}
