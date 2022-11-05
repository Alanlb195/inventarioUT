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
    public class HerramientasController : ControllerBase
    {
        private readonly InventarioUTDBContext _context;

        public HerramientasController(InventarioUTDBContext context)
        {
            _context = context;
        }

        // GET: api/Herramientas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Herramienta>>> GetHerramientas()
        {
            return await _context.Herramientas.ToListAsync();
        }

        // GET: api/Herramientas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Herramienta>> GetHerramienta(int id)
        {
            var herramienta = await _context.Herramientas.FindAsync(id);

            if (herramienta == null)
            {
                return NotFound();
            }

            return herramienta;
        }

        // GET: api/Herramientas/Taller/5
        [HttpGet("Taller/{id:int}")]
        public async Task<ActionResult<IEnumerable<Herramienta>>> GetHerramientaPorIdTaller(int id)
        {
            var query = await _context.Herramientas
                .FromSqlInterpolated($"EXEC obtenerHerramientasPorId @id = {id}")
                .ToListAsync();

            if (query.Count > 0)
            {
                return Ok(query);
            }
            return NotFound();
        }

        // PUT: api/Herramientas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHerramienta(int id, Herramienta herramienta)
        {
            if (id != herramienta.IdHerramienta)
            {
                return BadRequest();
            }

            _context.Entry(herramienta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HerramientaExists(id))
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

        // POST: api/Herramientas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Herramienta>> PostHerramienta(Herramienta herramienta)
        {
            _context.Herramientas.Add(herramienta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHerramienta", new { id = herramienta.IdHerramienta }, herramienta);
        }

        // DELETE: api/Herramientas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHerramienta(int id)
        {
            var herramienta = await _context.Herramientas.FindAsync(id);
            if (herramienta == null)
            {
                return NotFound();
            }

            _context.Herramientas.Remove(herramienta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HerramientaExists(int id)
        {
            return _context.Herramientas.Any(e => e.IdHerramienta == id);
        }
    }
}
