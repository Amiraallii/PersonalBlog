using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalBlog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class checkmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Project");

            migrationBuilder.RenameTable(
                name: "Projects",
                newName: "Projects",
                newSchema: "Project");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Projects",
                schema: "Project",
                newName: "Projects");
        }
    }
}
