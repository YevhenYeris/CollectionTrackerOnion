using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT.Data.Models;
using CT.Services;

namespace CT.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionsController : ControllerBase
    {
        private readonly ICollectionService<Collection> _service;

        public CollectionsController(ICollectionService<Collection> service)
        {
            _service = service;
        }

        // GET: api/Collections
        [HttpGet]
        public async Task<IEnumerable<Collection>> GetCollections()
        {
            return await _service.GetEntity();
        }

        // GET: api/Collections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Collection>> GetCollection(int id)
        {
            var Country = await _service.GetEntity(id);

            if (Country == null)
            {
                return NotFound();
            }

            return Country;
        }

        // PUT: api/Collections/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCollection(int id, Collection folder)
        {
            if (id != folder.Id)
            {
                return BadRequest();
            }

            if (await _service.GetEntity(id) == null)
            {
                await _service.InsertEntity(folder);
            }
            else
            {
                await _service.UpdateEntity(folder);
            }

            return NoContent();
        }

        // POST: api/Collections
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Collection>> PostCollection(Collection folder)
        {
            await _service.InsertEntity(folder);
            return CreatedAtAction("GetCollection", new { id = folder.Id }, folder);
        }

        // DELETE: api/Collections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCollection(int id)
        {
            await _service.DeleteEntity(id);
            return NoContent();
        }

        private bool CollectionExists(int id)
        {
            return _service.GetEntity(id) != null;
        }
    }
}
