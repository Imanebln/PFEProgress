#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PFE.Data;
using PFE.Models;

namespace PFE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class EncadrantsController : ControllerBase
    {
        private readonly PFEContext _context;

        public EncadrantsController(PFEContext context)
        {
            _context = context;
        }

        // GET: api/Encadrants
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Encadrant>>> GetEncadrants()
        {
            return await _context.Encadrants.ToListAsync();
        }

        // GET: api/Encadrants/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Encadrant>> GetEncadrant(int id)
        {
            var encadrant = await _context.Encadrants.FindAsync(id);

            if (encadrant == null)
            {
                return NotFound();
            }

            return encadrant;
        }

        // PUT: api/Encadrants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutEncadrant(int id, Encadrant encadrant)
        {
            if (id != encadrant.Id)
            {
                return BadRequest();
            }

            _context.Entry(encadrant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EncadrantExists(id))
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

        // POST: api/Encadrants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Encadrant>> PostEncadrant(Encadrant encadrant)
        {
            _context.Encadrants.Add(encadrant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEncadrant", new { id = encadrant.Id }, encadrant);
        }

        // DELETE: api/Encadrants/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteEncadrant(int id)
        {
            var encadrant = await _context.Encadrants.FindAsync(id);
            if (encadrant == null)
            {
                return NotFound();
            }

            _context.Encadrants.Remove(encadrant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EncadrantExists(int id)
        {
            return _context.Encadrants.Any(e => e.Id == id);
        }
    }
}
