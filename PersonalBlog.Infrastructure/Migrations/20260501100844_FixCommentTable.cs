using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalBlog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixCommentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorName",
                schema: "Post",
                table: "Commnets");

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                schema: "Post",
                table: "Commnets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "AuthorId",
                schema: "Post",
                table: "Commnets");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Post",
                table: "Commnets");

            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                schema: "Post",
                table: "Commnets",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
