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
    public class ShapesController : ControllerBase
    {
        private readonly INamedService<Shape> _service;

        public ShapesController(INamedService<Shape> service)
        {
            _service = service;
        }

        // GET: api/Shapes
        [HttpGet]
        public async Task<IEnumerable<Shape>> GetShapes()
        {
            return await _service.GetEntity();
        }

        // GET: api/Shapes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shape>> GetShape(int id)
        {
            var shape = await _service.GetEntity(id);

            if (shape == null)
            {
                return NotFound();
            }

            return shape;
        }

        // PUT: api/Shapes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShape(int id, Shape shape)
        {
            if (id != shape.Id)
            {
                return BadRequest();
            }

            if (await _service.GetEntity(id) == null)
            {
                await _service.InsertEntity(shape);
            }
            else
            {
                await _service.UpdateEntity(shape);
            }

            return NoContent();
        }

        // POST: api/Shapes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Shape>> PostShape(Shape shape)
        {
            await _service.InsertEntity(shape);
            return CreatedAtAction("GetShape", new { id = shape.Id }, shape);
        }

        // DELETE: api/Shapes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShape(int id)
        {
            await _service.DeleteEntity(id);
            return NoContent();
        }

        private bool ShapeExists(int id)
        {
            return _service.GetEntity(id) != null;
        }
    }
}
