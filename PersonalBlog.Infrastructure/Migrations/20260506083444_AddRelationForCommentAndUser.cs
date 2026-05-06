using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalBlog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationForCommentAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commnets_Users_UserId",
                schema: "Post",
                table: "Commnets");

            migrationBuilder.DropIndex(
                name: "IX_Commnets_UserId",
                schema: "Post",
                table: "Commnets");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Post",
                table: "Commnets");

            migrationBuilder.CreateIndex(
                name: "IX_Commnets_AuthorId",
                schema: "Post",
                table: "Commnets",
                column: "AuthorId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commnets_Users_AuthorId",
                schema: "Post",
                table: "Commnets");

            migrationBuilder.DropIndex(
                name: "IX_Commnets_AuthorId",
                schema: "Post",
                table: "Commnets");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "Post",
                table: "Commnets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Commnets_UserId",
                schema: "Post",
                table: "Commnets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commnets_Users_UserId",
                schema: "Post",
                table: "Commnets",
                column: "UserId",
                principalSchema: "Account",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
