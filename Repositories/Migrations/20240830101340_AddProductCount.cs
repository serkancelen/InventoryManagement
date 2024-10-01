using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class AddProductCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Inventories_ConsumableId_FK",
                table: "Inventories");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InventoryStockId_FK",
                table: "Consumables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_ConsumableId_FK",
                table: "Inventories",
                column: "ConsumableId_FK",
                unique: true,
                filter: "[ConsumableId_FK] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Inventories_ConsumableId_FK",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "InventoryStockId_FK",
                table: "Consumables");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_ConsumableId_FK",
                table: "Inventories",
                column: "ConsumableId_FK");
        }
    }
}
