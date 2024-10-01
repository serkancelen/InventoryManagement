using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class InitialAddProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId_FK",
                table: "Inventories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_ProductId_FK",
                table: "Inventories",
                column: "ProductId_FK");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Products_ProductId_FK",
                table: "Inventories",
                column: "ProductId_FK",
                principalTable: "Products",
                principalColumn: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Products_ProductId_FK",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_ProductId_FK",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "ProductId_FK",
                table: "Inventories");
        }
    }
}
