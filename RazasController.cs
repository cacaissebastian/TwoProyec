using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiproyectoMySql.Models;

namespace MiproyectoMySql.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RazasController : ControllerBase
    {
        private readonly MySqlContext _context;

        public RazasController(MySqlContext context)
        {
            _context = context;
        }

        // GET: api/Razas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Raza>>> GetRazas()
        {
            return Ok(await _context.Razas.ToListAsync());
        }

        // GET: api/Razas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Raza>> GetRaza(int id)
        {
            var raza = await _context.Razas.FirstOrDefaultAsync(m => m.Id == id);

            if (raza == null)
            {
                return NotFound();
            }

            return Ok(raza);
        }

        // POST: api/Razas
        [HttpPost]
        public async Task<ActionResult<Raza>> CreateRaza([FromBody] Raza raza)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Razas.Add(raza);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRaza), new { id = raza.Id }, raza);
        }

        // PUT: api/Razas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditRaza(int id, [FromBody] Raza raza)
        {
            if (id != raza.Id)
            {
                return BadRequest("El ID de la URL no coincide con el ID del cuerpo.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(raza).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RazaExists(id))
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

        // DELETE: api/Razas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRaza(int id)
        {
            var raza = await _context.Razas.FindAsync(id);
            if (raza == null)
            {
                return NotFound();
            }

            _context.Razas.Remove(raza);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RazaExists(int id)
        {
            return _context.Razas.Any(e => e.Id == id);
        }
    }
}
