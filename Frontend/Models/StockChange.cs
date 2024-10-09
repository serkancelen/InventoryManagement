using System.ComponentModel.DataAnnotations;

namespace Frontend.Models
{
    public class StockChange
    {
        [Key]
        public int StockChangeId { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public bool IsTransfer { get; set; }

        [Required]
        public int WarehouseId_FK { get; set; }
        public Warehouse Warehouse { get; set; }

        [Required]
        public int InventoryId_FK { get; set; }
        public Inventory Inventory { get; set; }
    }
}
