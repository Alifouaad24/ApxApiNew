using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apxApi.Migrations
{
    /// <inheritdoc />
    public partial class editTbLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InputParamiter",
                table: "tbl_log",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OutputParamiter",
                table: "tbl_log",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Result",
                table: "tbl_log",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDt",
                table: "tbl_log",
                type: "datetime",
                nullable: false,
                defaultValue: DateTime.Now);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "InputParamiter", table: "tbl_log");
            migrationBuilder.DropColumn(name: "OutputParamiter", table: "tbl_log");
            migrationBuilder.DropColumn(name: "Result", table: "tbl_log");
            migrationBuilder.DropColumn(name: "InsertDt", table: "tbl_log");
        }

    }
}
