using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BehShop.Persistance.Migrations.Database
{
    public partial class CatalogType_Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.AddColumn<int>(
                name: "ParentCatalogTypeId",
                table: "catalogTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParentTypeCatalogId",
                table: "catalogTypes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_catalogTypes_ParentCatalogTypeId",
                table: "catalogTypes",
                column: "ParentCatalogTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_catalogTypes_catalogTypes_ParentCatalogTypeId",
                table: "catalogTypes",
                column: "ParentCatalogTypeId",
                principalTable: "catalogTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_catalogTypes_catalogTypes_ParentCatalogTypeId",
                table: "catalogTypes");

            migrationBuilder.DropIndex(
                name: "IX_catalogTypes_ParentCatalogTypeId",
                table: "catalogTypes");

            migrationBuilder.DropColumn(
                name: "ParentCatalogTypeId",
                table: "catalogTypes");

            migrationBuilder.DropColumn(
                name: "ParentTypeCatalogId",
                table: "catalogTypes");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    ProfilePicture = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }
    }
}
