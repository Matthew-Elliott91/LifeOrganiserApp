using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElliottEvansApp.Migrations
{
    /// <inheritdoc />
    public partial class addedApplicationUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationURL",
                table: "JobApplicationsTrackers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationURL",
                table: "JobApplicationsTrackers");
        }
    }
}
