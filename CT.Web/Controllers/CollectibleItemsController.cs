using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT.Data.Models;
using CT.Services;

namespace CT.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectibleItemsController : ControllerBase
    {
        protected readonly ICollectibleService<CollectibleItem> _service;

        public CollectibleItemsController(ICollectibleService<CollectibleItem> service)
        {
            _service = service;
        }

        // GET: api/Alloys
        [HttpGet]
        public async Task<IEnumerable<CollectibleItem>> GetCollectibleItems()
        {
            return await _service.GetEntity();
        }

        // GET: api/Alloys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CollectibleItem>> GetCollectibleItem(int id)
        {
            var alloy = await _service.GetEntity(id);

            if (alloy == null)
            {
                return NotFound();
            }

            return alloy;
        }

        // PUT: api/Alloys/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCollectibleItem(int id, CollectibleItem collectibleItem)
        {
            if (id != collectibleItem.Id)
            {
                return BadRequest();
            }

            if (await _service.GetEntity(id) == null)
            {
                await _service.InsertEntity(collectibleItem);
            }
            else
            {
                await _service.UpdateEntity(collectibleItem);
            }

            return NoContent();
        }

        // POST: api/Alloys
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CollectibleItem>> PostCollectibleItem(CollectibleItem collectibleItem)
        {
            await _service.InsertEntity(collectibleItem);

            return CreatedAtAction("GetCollectibleItem", new { id = collectibleItem.Id }, collectibleItem);
        }

        // DELETE: api/Alloys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCollectibleItem(int id)
        {
            await _service.DeleteEntity(id);

            return NoContent();
        }

        private bool AlloyExists(int id)
        {
            return _service.GetEntity(id) != null;
        }
    }
}
