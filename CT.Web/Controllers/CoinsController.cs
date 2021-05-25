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
    public class CoinsController : Controller
    {
        private readonly ICoinService<Coin> _service;

            public CoinsController(ICoinService<Coin> service)
            {
                _service = service;
            }

            // GET: api/Alloys
            [HttpGet]
            public async Task<IEnumerable<Coin>> GetCoins()
            {
                return await _service.GetEntity();
            }

            // GET: api/Alloys/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Coin>> GetCoin(int id)
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
            public async Task<IActionResult> PutCoin(int id, Coin coin)
            {
                if (id != coin.Id)
                {
                    return BadRequest();
                }

                if (await _service.GetEntity(id) == null)
                {
                    await _service.InsertEntity(coin);
                }
                else
                {
                    await _service.UpdateEntity(coin);
                }

                return NoContent();
            }

            // POST: api/Alloys
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPost]
            public async Task<ActionResult<Coin>> PostCoin(Coin coin)
            {
                await _service.InsertEntity(coin);

                return CreatedAtAction("GetCoin", new { id = coin.Id }, coin);
            }

            // DELETE: api/Alloys/5
            [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoin(int id)
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
