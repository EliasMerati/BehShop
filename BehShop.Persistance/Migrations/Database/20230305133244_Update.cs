using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BehShop.Persistance.Migrations.Database
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_catalogTypes_catalogTypes_ParentCatalogTypeId",
                table: "catalogTypes");

            migrationBuilder.DropColumn(
                name: "ParentTypeCatalogId",
                table: "catalogTypes");

            migrationBuilder.AlterColumn<int>(
                name: "ParentCatalogTypeId",
                table: "catalogTypes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_catalogTypes_catalogTypes_ParentCatalogTypeId",
                table: "catalogTypes",
                column: "ParentCatalogTypeId",
                principalTable: "catalogTypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_catalogTypes_catalogTypes_ParentCatalogTypeId",
                table: "catalogTypes");

            migrationBuilder.AlterColumn<int>(
                name: "ParentCatalogTypeId",
                table: "catalogTypes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentTypeCatalogId",
                table: "catalogTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_catalogTypes_catalogTypes_ParentCatalogTypeId",
                table: "catalogTypes",
                column: "ParentCatalogTypeId",
                principalTable: "catalogTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
