using Microsoft.EntityFrameworkCore.Migrations;

namespace ShortUrl.Domain.Migrations
{
    public partial class AddIpAddressOnTableItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "Item",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "Item");
        }
    }
}
