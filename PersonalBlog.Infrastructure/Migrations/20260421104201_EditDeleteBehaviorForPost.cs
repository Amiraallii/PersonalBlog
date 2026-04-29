using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalBlog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditDeleteBehaviorForPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostContentBlocks_Posts_PostId",
                schema: "Post",
                table: "PostContentBlocks");

            migrationBuilder.AddForeignKey(
                name: "FK_PostContentBlocks_Posts_PostId",
                schema: "Post",
                table: "PostContentBlocks",
                column: "PostId",
                principalSchema: "Post",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostContentBlocks_Posts_PostId",
                schema: "Post",
                table: "PostContentBlocks");

            migrationBuilder.AddForeignKey(
                name: "FK_PostContentBlocks_Posts_PostId",
                schema: "Post",
                table: "PostContentBlocks",
                column: "PostId",
                principalSchema: "Post",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
