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
    public class DruzynaPilkarskasController : ControllerBase
    {
        private readonly KolokwiumDbContext _context;

        public DruzynaPilkarskasController(KolokwiumDbContext context)
        {
            _context = context;
        }

        // GET: api/DruzynaPilkarskas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DruzynaPilkarska>>> GetDruzynaPilkarskas()
        {
            return await _context.DruzynaPilkarskas.ToListAsync();
        }

        // GET: api/DruzynaPilkarskas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DruzynaPilkarska>> GetDruzynaPilkarska(int id)
        {
            var druzynaPilkarska = await _context.DruzynaPilkarskas.FindAsync(id);

            if (druzynaPilkarska == null)
            {
                return NotFound();
            }

            return druzynaPilkarska;
        }

        // PUT: api/DruzynaPilkarskas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDruzynaPilkarska(int id, DruzynaPilkarska druzynaPilkarska)
        {
            if (id != druzynaPilkarska.Id)
            {
                return BadRequest();
            }

            _context.Entry(druzynaPilkarska).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DruzynaPilkarskaExists(id))
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

        // POST: api/DruzynaPilkarskas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DruzynaPilkarska>> PostDruzynaPilkarska(DruzynaPilkarska druzynaPilkarska)
        {
            _context.DruzynaPilkarskas.Add(druzynaPilkarska);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDruzynaPilkarska", new { id = druzynaPilkarska.Id }, druzynaPilkarska);
        }

        // DELETE: api/DruzynaPilkarskas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDruzynaPilkarska(int id)
        {
            var druzynaPilkarska = await _context.DruzynaPilkarskas.FindAsync(id);
            if (druzynaPilkarska == null)
            {
                return NotFound();
            }

            _context.DruzynaPilkarskas.Remove(druzynaPilkarska);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DruzynaPilkarskaExists(int id)
        {
            return _context.DruzynaPilkarskas.Any(e => e.Id == id);
        }
    }
}
