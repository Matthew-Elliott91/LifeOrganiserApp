using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElliottEvansApp.Migrations
{
    /// <inheritdoc />
    public partial class updatedtablevalues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WhereApplied",
                table: "JobApplicationsTrackers",
                newName: "Location");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationPlatform",
                table: "JobApplicationsTrackers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateApplied",
                table: "JobApplicationsTrackers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "JobSpecification",
                table: "JobApplicationsTrackers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationPlatform",
                table: "JobApplicationsTrackers");

            migrationBuilder.DropColumn(
                name: "DateApplied",
                table: "JobApplicationsTrackers");

            migrationBuilder.DropColumn(
                name: "JobSpecification",
                table: "JobApplicationsTrackers");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "JobApplicationsTrackers",
                newName: "WhereApplied");
        }
    }
}
