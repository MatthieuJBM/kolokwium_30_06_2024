using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kolokwium_30_06_2024_w66049.Data;

namespace Kolokwium_30_06_2024_w66049.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeczsController : ControllerBase
    {
        private readonly KolokwiumDbContext _context;

        public MeczsController(KolokwiumDbContext context)
        {
            _context = context;
        }

        // GET: api/Meczs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mecz>>> GetMeczs()
        {
            return await _context.Meczs.ToListAsync();
        }

        // GET: api/Meczs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mecz>> GetMecz(int id)
        {
            var mecz = await _context.Meczs.FindAsync(id);

            if (mecz == null)
            {
                return NotFound();
            }

            return mecz;
        }

        // PUT: api/Meczs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMecz(int id, Mecz mecz)
        {
            if (id != mecz.Id)
            {
                return BadRequest();
            }

            _context.Entry(mecz).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeczExists(id))
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

        // POST: api/Meczs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mecz>> PostMecz(Mecz mecz)
        {
            _context.Meczs.Add(mecz);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMecz", new { id = mecz.Id }, mecz);
        }

        // DELETE: api/Meczs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMecz(int id)
        {
            var mecz = await _context.Meczs.FindAsync(id);
            if (mecz == null)
            {
                return NotFound();
            }

            _context.Meczs.Remove(mecz);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MeczExists(int id)
        {
            return _context.Meczs.Any(e => e.Id == id);
        }
    }
}
