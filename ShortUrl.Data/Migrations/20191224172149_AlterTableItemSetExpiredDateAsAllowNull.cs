using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShortUrl.Data.Migrations
{
    public partial class AlterTableItemSetExpiredDateAsAllowNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ExpiredDate",
                table: "Item",
                type: "datetimeoffset",
                maxLength: 7,
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldMaxLength: 7);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ExpiredDate",
                table: "Item",
                type: "datetimeoffset",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldMaxLength: 7,
                oldNullable: true);
        }
    }
}
