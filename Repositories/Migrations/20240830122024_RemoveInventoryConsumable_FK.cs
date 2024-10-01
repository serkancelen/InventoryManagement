using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class RemoveInventoryConsumable_FK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Consumables_ConsumableId_FK",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_ConsumableId_FK",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "ConsumableId_FK",
                table: "Inventories");

            migrationBuilder.AddColumn<int>(
                name: "InventoryStockId",
                table: "Consumables",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consumables_InventoryStockId",
                table: "Consumables",
                column: "InventoryStockId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consumables_Inventories_InventoryStockId",
                table: "Consumables",
                column: "InventoryStockId",
                principalTable: "Inventories",
                principalColumn: "InventoryStockId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consumables_Inventories_InventoryStockId",
                table: "Consumables");

            migrationBuilder.DropIndex(
                name: "IX_Consumables_InventoryStockId",
                table: "Consumables");

            migrationBuilder.DropColumn(
                name: "InventoryStockId",
                table: "Consumables");

            migrationBuilder.AddColumn<int>(
                name: "ConsumableId_FK",
                table: "Inventories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_ConsumableId_FK",
                table: "Inventories",
                column: "ConsumableId_FK",
                unique: true,
                filter: "[ConsumableId_FK] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Consumables_ConsumableId_FK",
                table: "Inventories",
                column: "ConsumableId_FK",
                principalTable: "Consumables",
                principalColumn: "ConsumableId");
        }
    }
}
