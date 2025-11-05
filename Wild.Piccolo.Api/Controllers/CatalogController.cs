using Microsoft.AspNetCore.Mvc;
// You will likely need this using statement to access the Item and Rating classes
using Wild.Piccolo.Domain.Catalog; 

namespace Wild.Piccolo.Api.Controllers // The namespace for your controller
{
    [ApiController] // Marks the class as an API controller
    [Route("[controller]")] // Sets the base route (e.g., /catalog)
    public class CatalogController : ControllerBase // Inherits from ControllerBase
    {
        // This class is currently empty, but you will add methods (like GET, POST) here.

        [HttpGet]
        public IActionResult GetItems()
        {
            var items = new List<Item>()
            {
                new Item("Shirt", "Ohio State shirt.", "Nike", 29.99m),
                new Item("Shorts", "Ohio State shorts.", "Nike", 44.99m)
            };

            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetItem(int id)
        {
            // The image code assumes Item has a public property named Id.
            var item = new Item("Shirt", "Ohio State shirt.", "Nike", 29.99m);
            item.Id = id;

            return Ok(item);
        }

        [HttpPost]
        public IActionResult Post(Item item)
        {
            return Created("/catalog/42", item);
        }

        [HttpPost("{id:int}/ratings")]
        public IActionResult PostRating(int id, [FromBody] Rating rating)
        {
            var item = new Item("Shirt", "Ohio State shirt.", "Nike", 29.99m);
            item.Id = id;
            item.AddRating(rating);

            return Ok(item);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, Item item)
        {
            return NoContent();
        }
        
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}