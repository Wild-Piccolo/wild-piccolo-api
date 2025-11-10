using Microsoft.AspNetCore.Mvc;
// You will likely need this using statement to access the Item and Rating classes
using Wild.Piccolo.Domain.Catalog;
using Wild.Piccolo.Data;

namespace Wild.Piccolo.Api.Controllers // The namespace for your controller
{
    [ApiController] // Marks the class as an API controller
    [Route("[controller]")] // Sets the base route (e.g., /catalog)
    public class CatalogController : ControllerBase // Inherits from ControllerBase
    {
        private readonly StoreContext _db;

        public CatalogController(StoreContext db)
        {
            _db = db;
        }
        
        [HttpGet]
        public IActionResult GetItems()
        {
            return Ok(_db.Items);
        }

        [HttpPost]
        public IActionResult Post(Item item)
        {
            _db.Items.Add(item);
            _db.SaveChanges();
            return Created($"/catalog/{item.Id}", item);
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