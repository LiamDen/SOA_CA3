/*using Microsoft.AspNetCore.Mvc;
using ShoppingitemApi.Models.ShoppingitemApi.Models;
using ShoppingitemApi.Models;

namespace MyMicroservice
{
    public interface IShoppingitemItemsController
    {
        Task<ActionResult<IEnumerable<ShoppingitemItemDTO>>> GetShoppingitemItems();
        Task<ActionResult<ShoppingitemItemDTO>> GetShoppingitemItem(long id);
        Task<IActionResult> UpdateShoppingitemItem(long id, ShoppingitemItemDTO shoppingitemItemDTO);
        Task<ActionResult<ShoppingitemItemDTO>> CreateShoppingitemItem(ShoppingitemItemDTO shoppingitemItemDTO);
        Task<IActionResult> DeleteShoppingitemItem(long id);
    }

    [Route("api/Items")]
    [ApiController]
    public class ShoppingitemItemsController : ControllerBase, IShoppingitemItemsController
    {
        private readonly ShoppingitemContext _context;

        public ShoppingitemItemsController(ShoppingitemContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<ShoppingitemItemDTO>>> GetShoppingitemItems()
        {
            return await _context.ShoppingitemItems
                .Select(x => ItemToDTO(x))
                .ToListAsync();
        }

        public async Task<ActionResult<ShoppingitemItemDTO>> GetShoppingitemItem(long id)
        {
            var shoppingitemItem = await _context.ShoppingitemItems.FindAsync(id);

            if (shoppingitemItem == null)
            {
                return NotFound();
            }

            return ItemToDTO(shoppingitemItem);
        }

        public async Task<IActionResult> UpdateShoppingitemItem(long id, ShoppingitemItemDTO shoppingitemItemDTO)
        {
            if (id != shoppingitemItemDTO.Id)
            {
                return BadRequest();
            }

            var shoppingitemItem = await _context.ShoppingitemItems.Find
        }

    }
}
*/