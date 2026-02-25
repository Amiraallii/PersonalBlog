using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Personal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addpostSummary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Summary",
                schema: "Post",
                table: "Posts",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Summary",
                schema: "Post",
                table: "Posts");
        }
    }
}
