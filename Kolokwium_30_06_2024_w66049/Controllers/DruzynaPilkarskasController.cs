using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Kolokwium_30_06_2024_w66049.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kolokwium_30_06_2024_w66049.Data;
using Kolokwium_30_06_2024_w66049.Models.DruzynaPilkarska;

namespace Kolokwium_30_06_2024_w66049.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DruzynaPilkarskasController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDruzynaPilkarskasRepository _druzynaPilkarskasRepository;

        public DruzynaPilkarskasController(IMapper mapper, IDruzynaPilkarskasRepository druzynaPilkarskasRepository)
        {
            _mapper = mapper;
            _druzynaPilkarskasRepository = druzynaPilkarskasRepository;
        }

        // GET: api/DruzynaPilkarskas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DruzynaPilkarskaDto>>> GetDruzynaPilkarskas()
        {
            var druzynyPilkarskie = await _druzynaPilkarskasRepository.GetAllAsync();
            var records = _mapper.Map<List<DruzynaPilkarskaDto>>(druzynyPilkarskie);
            return Ok(records);
        }

        // GET: api/DruzynaPilkarskas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DruzynaPilkarskaDto>> GetDruzynaPilkarska(int id)
        {
            var druzynaPilkarska = await _druzynaPilkarskasRepository.GetAsync(id);

            if (druzynaPilkarska == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<DruzynaPilkarskaDto>(druzynaPilkarska));
        }

        // PUT: api/DruzynaPilkarskas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDruzynaPilkarska(int id, DruzynaPilkarskaDto druzynaPilkarskaDto)
        {
            if (id != druzynaPilkarskaDto.Id)
            {
                return BadRequest();
            }

            var druzynaPilkarska = await _druzynaPilkarskasRepository.GetAsync(id);
            if (druzynaPilkarska == null)
            {
                return NotFound();
            }

            _mapper.Map(druzynaPilkarskaDto, druzynaPilkarska);

            try
            {
                await _druzynaPilkarskasRepository.UpdateAsync(druzynaPilkarska);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await DruzynaPilkarskaExists(id))
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
        public async Task<ActionResult<DruzynaPilkarska>> PostDruzynaPilkarska(DruzynaPilkarskaDto druzynaPilkarskaDto)
        {
            var druzynaPilkarska = _mapper.Map<DruzynaPilkarska>(druzynaPilkarskaDto);
            await _druzynaPilkarskasRepository.AddAsync(druzynaPilkarska);

            return CreatedAtAction("GetDruzynaPilkarska", new { id = druzynaPilkarska.Id }, druzynaPilkarska);
        }

        // DELETE: api/DruzynaPilkarskas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDruzynaPilkarska(int id)
        {
            var druzynaPilkarska = await _druzynaPilkarskasRepository.GetAsync(id);
            if (druzynaPilkarska == null)
            {
                return NotFound();
            }

            await _druzynaPilkarskasRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> DruzynaPilkarskaExists(int id)
        {
            return await _druzynaPilkarskasRepository.Exists(id);
        }
    }
}