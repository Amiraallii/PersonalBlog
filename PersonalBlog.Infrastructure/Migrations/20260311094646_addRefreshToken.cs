using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalBlog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                schema: "Account",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpireDate",
                schema: "Account",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Account",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000001"),
                columns: new[] { "RefreshToken", "RefreshTokenExpireDate" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                schema: "Account",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpireDate",
                schema: "Account",
                table: "Users");
        }
    }
}
