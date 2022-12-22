using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingitemApi.Models;
using ShoppingitemApi.Models.ShoppingitemApi.Models;

namespace ShoppingitemApi.Controllers
{
    [Route("api/Items")]
    [ApiController]
    public class ShoppingitemItemsController : ControllerBase
    {
        private readonly ShoppingitemContext _context;

        public ShoppingitemItemsController(ShoppingitemContext context)
        {
            _context = context;
        }

        // GET: api/ShoppingitemItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoppingitemItemDTO>>> GetShoppingitemItems()
        {
            return await _context.ShoppingitemItems
                .Select(x => ItemToDTO(x))
                .ToListAsync();
        }

        // GET: api/ShoppingitemItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingitemItemDTO>> GetShoppingitemItem(long id)
        {
            var shoppingitemItem = await _context.ShoppingitemItems.FindAsync(id);

            if (shoppingitemItem == null)
            {
                return NotFound();
            }

            return ItemToDTO(shoppingitemItem);
        }
        // PUT: api/ShoppingitemItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShoppingitemItem(long id, ShoppingitemItemDTO shoppingitemItemDTO)
        {
            if (id != shoppingitemItemDTO.Id)
            {
                return BadRequest();
            }

            var shoppingitemItem = await _context.ShoppingitemItems.FindAsync(id);
            if (shoppingitemItem == null)
            {
                return NotFound();
            }

            shoppingitemItem.Name = shoppingitemItemDTO.Name;
            shoppingitemItem.IsComplete = shoppingitemItemDTO.IsComplete;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!ShoppingitemItemExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }
        // POST: api/ShoppingitemItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShoppingitemItemDTO>> CreateShoppingitemItem(ShoppingitemItemDTO shoppingitemItemDTO)
        {
            var shoppingitemItem = new ShoppingitemItem
            {
                IsComplete = shoppingitemItemDTO.IsComplete,
                Name = shoppingitemItemDTO.Name
            };

            _context.ShoppingitemItems.Add(shoppingitemItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetShoppingitemItem),
                new { id = shoppingitemItem.Id },
                ItemToDTO(shoppingitemItem));
        }

        // DELETE: api/ShoppingitemItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShoppingitemItem(long id)
        {
            var shoppingitemItem = await _context.ShoppingitemItems.FindAsync(id);

            if (shoppingitemItem == null)
            {
                return NotFound();
            }

            _context.ShoppingitemItems.Remove(shoppingitemItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShoppingitemItemExists(long id)
        {
            return _context.ShoppingitemItems.Any(e => e.Id == id);
        }

        private static ShoppingitemItemDTO ItemToDTO(ShoppingitemItem shoppingitemItem) =>
            new ShoppingitemItemDTO
            {
                Id = shoppingitemItem.Id,
                Name = shoppingitemItem.Name,
                IsComplete = shoppingitemItem.IsComplete
            };
    }
}