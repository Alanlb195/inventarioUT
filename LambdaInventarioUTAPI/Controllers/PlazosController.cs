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
    public class PlazosController : ControllerBase
    {
        private readonly InventarioUTDBContext _context;

        public PlazosController(InventarioUTDBContext context)
        {
            _context = context;
        }

        // GET: api/Plazos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plazo>>> GetPlazos()
        {
            return await _context.Plazos.ToListAsync();
        }

        // GET: api/Plazos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Plazo>> GetPlazo(int id)
        {
            var plazo = await _context.Plazos.FindAsync(id);

            if (plazo == null)
            {
                return NotFound();
            }

            return plazo;
        }

        // PUT: api/Plazos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlazo(int id, Plazo plazo)
        {
            if (id != plazo.IdPlazo)
            {
                return BadRequest();
            }

            _context.Entry(plazo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlazoExists(id))
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

        // POST: api/Plazos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Plazo>> PostPlazo(Plazo plazo)
        {
            _context.Plazos.Add(plazo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlazo", new { id = plazo.IdPlazo }, plazo);
        }

        // DELETE: api/Plazos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlazo(int id)
        {
            var plazo = await _context.Plazos.FindAsync(id);
            if (plazo == null)
            {
                return NotFound();
            }

            _context.Plazos.Remove(plazo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlazoExists(int id)
        {
            return _context.Plazos.Any(e => e.IdPlazo == id);
        }
    }
}
