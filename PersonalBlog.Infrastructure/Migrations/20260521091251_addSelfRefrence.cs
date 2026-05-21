using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalBlog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addSelfRefrence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commnets_Posts_PostId",
                schema: "Post",
                table: "Commnets");

            migrationBuilder.DropForeignKey(
                name: "FK_Commnets_Users_AuthorId",
                schema: "Post",
                table: "Commnets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Commnets",
                schema: "Post",
                table: "Commnets");

            migrationBuilder.DropIndex(
                name: "IX_Commnets_PostId",
                schema: "Post",
                table: "Commnets");

            migrationBuilder.RenameTable(
                name: "Commnets",
                schema: "Post",
                newName: "Comments",
                newSchema: "Post");

            migrationBuilder.RenameIndex(
                name: "IX_Commnets_AuthorId",
                schema: "Post",
                table: "Comments",
                newName: "IX_Comments_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                schema: "Post",
                table: "Comments",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParentId",
                schema: "Post",
                table: "Comments",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId_ParentId",
                schema: "Post",
                table: "Comments",
                columns: new[] { "PostId", "ParentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_ParentId",
                schema: "Post",
                table: "Comments",
                column: "ParentId",
                principalSchema: "Post",
                principalTable: "Comments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostId",
                schema: "Post",
                table: "Comments",
                column: "PostId",
                principalSchema: "Post",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_AuthorId",
                schema: "Post",
                table: "Comments",
                column: "AuthorId",
                principalSchema: "Account",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_ParentId",
                schema: "Post",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostId",
                schema: "Post",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_AuthorId",
                schema: "Post",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                schema: "Post",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ParentId",
                schema: "Post",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PostId_ParentId",
                schema: "Post",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Comments",
                schema: "Post",
                newName: "Commnets",
                newSchema: "Post");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_AuthorId",
                schema: "Post",
                table: "Commnets",
                newName: "IX_Commnets_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commnets",
                schema: "Post",
                table: "Commnets",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Commnets_PostId",
                schema: "Post",
                table: "Commnets",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commnets_Posts_PostId",
                schema: "Post",
                table: "Commnets",
                column: "PostId",
                principalSchema: "Post",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Commnets_Users_AuthorId",
                schema: "Post",
                table: "Commnets",
                column: "AuthorId",
                principalSchema: "Account",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
