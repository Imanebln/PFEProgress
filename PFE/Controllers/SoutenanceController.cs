using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PFE.Data;
using PFE.Models;

namespace PFE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoutenanceController : ControllerBase
    {
        private readonly PFEContext _context;

        public SoutenanceController(PFEContext context)
        {
            _context = context;
        }

        // GET: api/Soutenance
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Soutenance>>> GetSoutenance()
        {
            return await _context.Soutenance.ToListAsync();
        }

        // GET: api/Soutenance/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Soutenance>> GetSoutenance(int id)
        {
            var Soutenance = await _context.Soutenance.FindAsync(id);

            if (Soutenance == null)
            {
                return NotFound();
            }

            return Soutenance;
        }

        // PUT: api/Soutenance/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSoutenance(int id, Soutenance soutenance)
        {
            if (id != soutenance.Id)
            {
                return BadRequest();
            }

            _context.Entry(soutenance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoutenanceExists(id))
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

        // POST: api/Soutenance
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Soutenance>> PostSoutenance(Soutenance soutenance)
        {
            _context.Soutenance.Add(soutenance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSoutenance", new { id = soutenance.Id }, soutenance);
        }

        // DELETE: api/Soutenance/5
        [HttpDelete("{id}")]



        public async Task<IActionResult> DeleteSoutenance(int id)
        {
            var soutenance = await _context.Soutenance.FindAsync(id);
            if (soutenance == null)
            {
                return NotFound();
            }

            _context.Soutenance.Remove(soutenance);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SoutenanceExists(int id)
        {
            return _context.Soutenance.Any(e => e.Id == id);
        }
    }
}
