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
    public class CollectionFoldersController : ControllerBase
    {
        private readonly IFolderService<CollectionFolder> _service;

        public CollectionFoldersController(IFolderService<CollectionFolder> service)
        {
            _service = service;
        }

        // GET: api/CollectionFolders
        [HttpGet]
        public async Task<IEnumerable<CollectionFolder>> GetCollectionFolders()
        {
            return await _service.GetEntity();
        }

        // GET: api/CollectionFolders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CollectionFolder>> GetCollectionFolder(int id)
        {
            var Country = await _service.GetEntity(id);

            if (Country == null)
            {
                return NotFound();
            }

            return Country;
        }

        // PUT: api/CollectionFolders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCollectionFolder(int id, CollectionFolder folder)
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

        // POST: api/CollectionFolders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CollectionFolder>> PostCollectionFolder(CollectionFolder folder)
        {
            await _service.InsertEntity(folder);
            return CreatedAtAction("GetCollectionFolder", new { id = folder.Id }, folder);
        }

        // DELETE: api/CollectionFolders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCollectionFolder(int id)
        {
            await _service.DeleteEntity(id);
            return NoContent();
        }

        private bool CollectionFolderExists(int id)
        {
            return _service.GetEntity(id) != null;
        }
    }
}
