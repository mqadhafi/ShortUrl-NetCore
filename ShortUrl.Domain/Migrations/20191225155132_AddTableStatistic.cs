using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShortUrl.Domain.Migrations
{
    public partial class AddTableStatistic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Statistic",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", maxLength: 7, nullable: false),
                    IpAddress = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    ItemId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistic", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_Segment",
                table: "Item",
                column: "Segment",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Statistic");

            migrationBuilder.DropIndex(
                name: "IX_Item_Segment",
                table: "Item");
        }
    }
}
