using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Personal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPersonalInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Info");

            migrationBuilder.CreateTable(
                name: "PersonalInformation",
                schema: "Info",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    AboutMe = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactInfo",
                schema: "Info",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalInformationId = table.Column<byte>(type: "tinyint", nullable: false),
                    ContactWayType = table.Column<byte>(type: "tinyint", nullable: false),
                    ContactWay = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactInfo_PersonalInformation_PersonalInformationId",
                        column: x => x.PersonalInformationId,
                        principalSchema: "Info",
                        principalTable: "PersonalInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfo_PersonalInformationId",
                schema: "Info",
                table: "ContactInfo",
                column: "PersonalInformationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactInfo",
                schema: "Info");

            migrationBuilder.DropTable(
                name: "PersonalInformation",
                schema: "Info");
        }
    }
}
