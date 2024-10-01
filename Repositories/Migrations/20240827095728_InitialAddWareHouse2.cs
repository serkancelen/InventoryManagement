using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class InitialAddWareHouse2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WarehouseId_FK",
                table: "Inventories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_WarehouseId_FK",
                table: "Inventories",
                column: "WarehouseId_FK");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Warehouses_WarehouseId_FK",
                table: "Inventories",
                column: "WarehouseId_FK",
                principalTable: "Warehouses",
                principalColumn: "WarehouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Warehouses_WarehouseId_FK",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_WarehouseId_FK",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "WarehouseId_FK",
                table: "Inventories");
        }
    }
}
