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
    public class SubjectsController : ControllerBase
    {
        private readonly INamedService<Subject> _service;

        public SubjectsController(INamedService<Subject> service)
        {
            _service = service;
        }

        // GET: api/subjects
        [HttpGet]
        public async Task<IEnumerable<Subject>> GetSubjects()
        {
            return await _service.GetEntity();
        }

        // GET: api/subjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> GetSubject(int id)
        {
            var subject = await _service.GetEntity(id);

            if (subject == null)
            {
                return NotFound();
            }

            return subject;
        }

        // PUT: api/subjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubject(int id, Subject subject)
        {
            if (id != subject.Id)
            {
                return BadRequest();
            }

            if (await _service.GetEntity(id) == null)
            {
                await _service.InsertEntity(subject);
            }
            else
            {
                await _service.UpdateEntity(subject);
            }

            return NoContent();
        }

        // POST: api/subjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Subject>> PostSubject(Subject subject)
        {
            await _service.InsertEntity(subject);
            return CreatedAtAction("GetSubject", new { id = subject.Id }, subject);
        }

        // DELETE: api/subjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            await _service.DeleteEntity(id);

            return NoContent();
        }

        private bool SubjectExists(int id)
        {
            return _service.GetEntity(id) != null;
        }
    }
}
