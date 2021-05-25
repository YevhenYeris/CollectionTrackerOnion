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
    public class CurrenciesController : ControllerBase
    {
        private readonly INamedService<Currency> _service;

        public CurrenciesController(INamedService<Currency> service)
        {
            _service = service;
        }

        // GET: api/Currencies
        [HttpGet]
        public async Task<IEnumerable<Currency>> GetCurrencies()
        {
            return await _service.GetEntity();
        }

        // GET: api/Currencies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Currency>> GetCurrency(int id)
        {
            var currency = await _service.GetEntity(id);

            if (currency == null)
            {
                return NotFound();
            }

            return currency;
        }

        // PUT: api/Currencies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurrency(int id, Currency currency)
        {
            if (id != currency.Id)
            {
                return BadRequest();
            }

            if (await _service.GetEntity(id) == null)
            {
                await _service.InsertEntity(currency);
            }
            else
            {
                await _service.UpdateEntity(currency);
            }

            return NoContent();
        }

        // POST: api/Currencies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Currency>> PostCurrency(Currency currency)
        {
            await _service.InsertEntity(currency);

            return CreatedAtAction("GetCurrency", new { id = currency.Id }, currency);
        }

        // DELETE: api/Currencies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurrency(int id)
        {
            await _service.DeleteEntity(id);

            return NoContent();
        }

        private bool CurrencyExists(int id)
        {
            return _service.GetEntity(id) != null;
        }
    }
}
