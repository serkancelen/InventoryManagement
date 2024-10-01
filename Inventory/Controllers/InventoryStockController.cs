using Entities.ModelDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Inventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryStockController : ControllerBase
    {
        private readonly ILogger<InventoryStockController> _logger;
        private readonly IServiceInventory _serviceInventory;
        public InventoryStockController(ILogger<InventoryStockController> logger, IServiceInventory serviceInventory)
        {

            _logger = logger;
           _serviceInventory = serviceInventory;
        }
        [HttpGet("get-inventories")]
        public async Task<IActionResult> GetInventories()
        {
            var inventories = await _serviceInventory.GetInventoryList();
            return Ok(inventories);
        }
        [HttpGet("get-inventory-by-id")]
        public async Task<IActionResult> GetInventoryById(int id)
        {
            var inventory = await _serviceInventory.GetInventoryById(id);
            return Ok(inventory);
        }
        [HttpDelete("delete-inventory/{id}")]
        public async Task<IActionResult> DeleteInventory(int id)
        {
            await _serviceInventory.DeleteInventory(id);
            return Ok();
        }
        [HttpPost("create-inventory")]
        public async Task<IActionResult> PostInventory(InventoryDto inventoryDto)
        {
            await _serviceInventory.CreateInventory(inventoryDto);
            return Ok();
        }
        [HttpPut("update-inventory")]
        public async Task<IActionResult> PutInventory(InventoryDto inventoryDto)
        {
            var inventory = _serviceInventory.GetInventoryById(inventoryDto.InventoryStockId);
            if (inventory is not null)
            {
                await _serviceInventory.UpdateInventory(inventoryDto);
                return Ok();
            }
            return BadRequest();
        }
    }
}
