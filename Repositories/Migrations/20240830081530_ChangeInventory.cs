using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class ChangeInventory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Consumables_ConsumableId_FK",
                table: "Inventories");

            migrationBuilder.AlterColumn<int>(
                name: "ConsumableId_FK",
                table: "Inventories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Consumables_ConsumableId_FK",
                table: "Inventories",
                column: "ConsumableId_FK",
                principalTable: "Consumables",
                principalColumn: "ConsumableId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Consumables_ConsumableId_FK",
                table: "Inventories");

            migrationBuilder.AlterColumn<int>(
                name: "ConsumableId_FK",
                table: "Inventories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Consumables_ConsumableId_FK",
                table: "Inventories",
                column: "ConsumableId_FK",
                principalTable: "Consumables",
                principalColumn: "ConsumableId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
