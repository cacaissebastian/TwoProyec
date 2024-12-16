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
    public class EnfermedadesController : ControllerBase
    {
        private readonly MySqlContext _context;

        public EnfermedadesController(MySqlContext context)
        {
            _context = context;
        }

        // GET: api/Enfermedades
        [HttpGet]
        public async Task<IActionResult> GetEnfermedades()
        {
            var enfermedades = await _context.Enfermedades.ToListAsync();
            return Ok(enfermedades);
        }

        // GET: api/Enfermedades/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEnfermedad(int id)
        {
            var enfermedade = await _context.Enfermedades.FindAsync(id);

            if (enfermedade == null)
            {
                return NotFound();
            }

            return Ok(enfermedade);
        }

        // POST: api/Enfermedades
        [HttpPost]
        public async Task<IActionResult> CreateEnfermedad([FromBody] Enfermedade enfermedade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Enfermedades.Add(enfermedade);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEnfermedad), new { id = enfermedade.Id }, enfermedade);
        }

        // PUT: api/Enfermedades/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditEnfermedad(int id, [FromBody] Enfermedade enfermedade)
        {
            if (id != enfermedade.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(enfermedade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnfermedadeExists(id))
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

        // DELETE: api/Enfermedades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnfermedad(int id)
        {
            var enfermedade = await _context.Enfermedades.FindAsync(id);
            if (enfermedade == null)
            {
                return NotFound();
            }

            _context.Enfermedades.Remove(enfermedade);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnfermedadeExists(int id)
        {
            return _context.Enfermedades.Any(e => e.Id == id);
        }
    }
}
