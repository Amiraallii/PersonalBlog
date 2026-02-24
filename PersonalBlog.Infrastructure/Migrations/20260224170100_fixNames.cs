using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Personal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BlockType",
                schema: "Post",
                table: "PostContentBlocks",
                newName: "ContentType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContentType",
                schema: "Post",
                table: "PostContentBlocks",
                newName: "BlockType");
        }
    }
}
