using Microsoft.AspNetCore.Mvc;
using WiredBrainApi.Services;

namespace WiredBrainApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly ILogger<InventoryController> _logger;
        private readonly InventoryService _inventoryService;

        public InventoryController(InventoryService inventoryService, ILogger<InventoryController> logger)
        {
            _inventoryService = inventoryService;
            _logger = logger;
        }

        [HttpGet("/{id}")]
        public ActionResult<LocationInventory> Get(int id)
        {
            var inventory = _inventoryService.GetLocationInventory(id);
            if (inventory == null)
            {
                return NotFound();
            }

            return inventory;
        }
    }
}
