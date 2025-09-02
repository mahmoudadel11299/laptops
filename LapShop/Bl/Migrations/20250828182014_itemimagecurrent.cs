using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bl.Migrations
{
    /// <inheritdoc />
    public partial class itemimagecurrent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "createdby",
                table: "TbItemImages",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "createddate",
                table: "TbItemImages",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "currentstate",
                table: "TbItemImages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "updatedby",
                table: "TbItemImages",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updateddate",
                table: "TbItemImages",
                type: "DateTime",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createdby",
                table: "TbItemImages");

            migrationBuilder.DropColumn(
                name: "createddate",
                table: "TbItemImages");

            migrationBuilder.DropColumn(
                name: "currentstate",
                table: "TbItemImages");

            migrationBuilder.DropColumn(
                name: "updatedby",
                table: "TbItemImages");

            migrationBuilder.DropColumn(
                name: "updateddate",
                table: "TbItemImages");
        }
    }
}
