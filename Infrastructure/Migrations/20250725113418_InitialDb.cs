using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Personal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Post");

            migrationBuilder.EnsureSchema(
                name: "Account");

            migrationBuilder.CreateTable(
                name: "Posts",
                schema: "Post",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CoverImageAdd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Account",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Commnets",
                schema: "Post",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthorName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commnets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commnets_Posts_PostId",
                        column: x => x.PostId,
                        principalSchema: "Post",
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostContentBlocks",
                schema: "Post",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    BlockType = table.Column<byte>(type: "tinyint", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostContentBlocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostContentBlocks_Posts_PostId",
                        column: x => x.PostId,
                        principalSchema: "Post",
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Account",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Account",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Account",
                table: "Roles",
                columns: new[] { "Id", "CreateDate", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2025, 7, 8, 0, 0, 0, 0, DateTimeKind.Utc), "User" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2025, 7, 8, 0, 0, 0, 0, DateTimeKind.Utc), "Admin" }
                });

            migrationBuilder.InsertData(
                schema: "Account",
                table: "Users",
                columns: new[] { "Id", "CreateDate", "Email", "FullName", "PasswordHash", "RoleId", "UserName" },
                values: new object[] { new Guid("10000000-0000-0000-0000-000000000001"), new DateTime(2025, 7, 8, 0, 0, 0, 0, DateTimeKind.Utc), "amiraliaghaei69@gmail.com", "Amirali", "$2a$11$4LXh430wl/OwVD2LZ6M81OsxLK1MHjFS1j5kS.SzvQgRzucn3FL7y", new Guid("00000000-0000-0000-0000-000000000002"), "Amirali" });

            migrationBuilder.CreateIndex(
                name: "IX_Commnets_PostId",
                schema: "Post",
                table: "Commnets",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostContentBlocks_PostId",
                schema: "Post",
                table: "PostContentBlocks",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                schema: "Account",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                schema: "Account",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                schema: "Account",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commnets",
                schema: "Post");

            migrationBuilder.DropTable(
                name: "PostContentBlocks",
                schema: "Post");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Account");

            migrationBuilder.DropTable(
                name: "Posts",
                schema: "Post");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Account");
        }
    }
}
