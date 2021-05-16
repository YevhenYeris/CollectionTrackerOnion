using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CT.Data.Models;
using CT.Repo;
using CT.Services;

namespace CT.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlloysController : ControllerBase
    {
        private readonly IBaseService<Alloy> _service;

        public AlloysController(IBaseService<Alloy> service)
        {
            _service = service;
        }

        // GET: api/Alloys
        [HttpGet]
        public async Task<IEnumerable<Alloy>> GetAlloys()
        {
            return await _service.GetEntity();
        }

        // GET: api/Alloys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alloy>> GetAlloy(int id)
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
        public async Task<IActionResult> PutAlloy(int id, Alloy alloy)
        {
            if (id != alloy.Id)
            {
                return BadRequest();
            }

            if (await _service.GetEntity(id) == null)
            {
                await _service.InsertEntity(alloy);
            }
            else
            {
                await _service.UpdateEntity(alloy);
            }

            return NoContent();
        }

        // POST: api/Alloys
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Alloy>> PostAlloy(Alloy alloy)
        {
            await _service.InsertEntity(alloy);

            return CreatedAtAction("GetAlloy", new { id = alloy.Id }, alloy);
        }

        // DELETE: api/Alloys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlloy(int id)
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
