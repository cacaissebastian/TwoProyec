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
    public class AnimalesController : ControllerBase
    {
        private readonly MySqlContext _context;

        public AnimalesController(MySqlContext context)
        {
            _context = context;
        }

        // GET: api/Animales
        [HttpGet]
        public async Task<IActionResult> GetAnimales()
        {
            var animales = await _context.Animales.Include(a => a.Raza).Include(a => a.Usuario).ToListAsync();
            return Ok(animales);
        }

        // GET: api/Animales/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnimale(int id)
        {
            var animale = await _context.Animales
                .Include(a => a.Raza)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (animale == null)
            {
                return NotFound();
            }

            return Ok(animale);
        }

        // POST: api/Animales
        [HttpPost]
        public async Task<IActionResult> CreateAnimale([FromBody] Animale animale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Animales.Add(animale);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAnimale), new { id = animale.Id }, animale);
        }

        // PUT: api/Animales/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditAnimale(int id, [FromBody] Animale animale)
        {
            if (id != animale.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(animale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimaleExists(id))
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

        // DELETE: api/Animales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimale(int id)
        {
            var animale = await _context.Animales.FindAsync(id);
            if (animale == null)
            {
                return NotFound();
            }

            _context.Animales.Remove(animale);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimaleExists(int id)
        {
            return _context.Animales.Any(e => e.Id == id);
        }
    }
}
