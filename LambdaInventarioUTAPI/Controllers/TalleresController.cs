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
    public class TalleresController : ControllerBase
    {
        private readonly InventarioUTDBContext _context;

        public TalleresController(InventarioUTDBContext context)
        {
            _context = context;
        }

        // GET: api/Talleres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Taller>>> GetTalleres()
        {
            return await _context.Talleres.ToListAsync();
        }

        // GET: api/Talleres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Taller>> GetTaller(int id)
        {
            var taller = await _context.Talleres.FindAsync(id);

            if (taller == null)
            {
                return NotFound();
            }

            return taller;
        }

        // GET: api/Talleres/Edificio/5
        [HttpGet("Edificio/{id:int}")]
        public async Task<ActionResult<IEnumerable<Taller>>> GetHerramientaPorIdTaller(int id)
        {
            var query = await _context.Talleres
                .FromSqlInterpolated($"EXEC getTalleresPorEdificioId @id = {id}")
                .ToListAsync();

            if (query.Count > 0)
            {
                return Ok(query);
            }
            return NotFound();
        }

        // PUT: api/Talleres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaller(int id, Taller taller)
        {
            if (id != taller.IdTaller)
            {
                return BadRequest();
            }

            _context.Entry(taller).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TallerExists(id))
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

        // POST: api/Talleres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Taller>> PostTaller(Taller taller)
        {
            _context.Talleres.Add(taller);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaller", new { id = taller.IdTaller }, taller);
        }

        // DELETE: api/Talleres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaller(int id)
        {
            var taller = await _context.Talleres.FindAsync(id);
            if (taller == null)
            {
                return NotFound();
            }

            _context.Talleres.Remove(taller);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TallerExists(int id)
        {
            return _context.Talleres.Any(e => e.IdTaller == id);
        }
    }
}
