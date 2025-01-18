using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElliottEvansApp.Migrations
{
    /// <inheritdoc />
    public partial class FixedClosingDateToDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ClosingDate",
                table: "JobApplicationsTrackers",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ClosingDate",
                table: "JobApplicationsTrackers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
