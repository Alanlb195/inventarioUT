using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.Models;

namespace LambdaInventarioUTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MultasController : ControllerBase
    {
        private readonly InventarioUTDBContext _context;

        public MultasController(InventarioUTDBContext context)
        {
            _context = context;
        }

        // GET: api/Multas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Multa>>> GetMultas()
        {
            return await _context.Multas.ToListAsync();
        }

        // GET: api/Multas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Multa>> GetMulta(int id)
        {
            var multa = await _context.Multas.FindAsync(id);

            if (multa == null)
            {
                return NotFound();
            }

            return multa;
        }

        // PUT: api/Multas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMulta(int id, Multa multa)
        {
            if (id != multa.IdMulta)
            {
                return BadRequest();
            }

            _context.Entry(multa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MultaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Multas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Multa>> PostMulta(Multa multa)
        {
            _context.Multas.Add(multa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMulta", new { id = multa.IdMulta }, multa);
        }

        // DELETE: api/Multas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMulta(int id)
        {
            var multa = await _context.Multas.FindAsync(id);
            if (multa == null)
            {
                return NotFound();
            }

            _context.Multas.Remove(multa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MultaExists(int id)
        {
            return _context.Multas.Any(e => e.IdMulta == id);
        }
    }
}
