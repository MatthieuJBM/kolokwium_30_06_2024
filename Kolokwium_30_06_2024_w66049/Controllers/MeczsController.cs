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
using Kolokwium_30_06_2024_w66049.Models.Mecz;

namespace Kolokwium_30_06_2024_w66049.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeczsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMeczsRepository _meczsRepository;

        public MeczsController(IMapper mapper, IMeczsRepository meczsRepository)
        {
            _mapper = mapper;
            _meczsRepository = meczsRepository;
        }

        // GET: api/Meczs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MeczDto>>> GetMeczs()
        {
            var mecze = await _meczsRepository.GetAllAsync();
            var records = _mapper.Map<List<MeczDto>>(mecze);
            return Ok(records);
        }

        // GET: api/Meczs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mecz>> GetMecz(int id)
        {
            var mecz = await _meczsRepository.GetAsync(id);

            if (mecz == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<MeczDto>(mecz));
        }

        // PUT: api/Meczs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMecz(int id, MeczDto meczDto)
        {
            if (id != meczDto.Id)
            {
                return BadRequest();
            }

            var obecnyMecz = await _meczsRepository.GetAsync(id);
            if (obecnyMecz == null)
            {
                return NotFound();
            }

            // Walidacja czasu
            if (meczDto.GodzinaMeczuOd > meczDto.GodzinaMeczuDo)
            {
                return BadRequest("Godzina rozpoczęcia nie może być później niż godzina zakończenia");
            }

            _mapper.Map(meczDto, obecnyMecz);

            try
            {
                await _meczsRepository.UpdateAsync(obecnyMecz);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await MeczExists(id))
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
        public async Task<ActionResult<Mecz>> PostMecz(MeczDto meczDto)
        {
            // Walidacja czasu
            if (meczDto.GodzinaMeczuOd > meczDto.GodzinaMeczuDo)
            {
                return BadRequest("Godzina rozpoczęcia nie może być później niż godzina zakończenia");
            }

            // Sprawdzenie czy istnieje konflikt pomiędzy meczami
            if (await jestKonfliktMeczy(meczDto))
            {
                return BadRequest("Jakaś drużyna już ma mecz w tym czasie.");
            }


            var mecz = _mapper.Map<Mecz>(meczDto);
            await _meczsRepository.AddAsync(mecz);

            return CreatedAtAction("GetMecz", new { id = mecz.Id }, mecz);
        }

        // DELETE: api/Meczs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMecz(int id)
        {
            var mecz = await _meczsRepository.GetAsync(id);
            if (mecz == null)
            {
                return NotFound();
            }

            // Sprawdzenie czy data meczu jest późniejsza niż dzisiaj.
            if (mecz.DataMeczu <= DateTime.Today)
            {
                return BadRequest("Nie można usunąć meczu, który już się odbył.");
            }

            await _meczsRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> MeczExists(int id)
        {
            return await _meczsRepository.Exists(id);
        }

        private async Task<bool> jestKonfliktMeczy(MeczDto meczDto)
        {
            var konfliktoweMecze = await _meczsRepository.GetKonfliktoweMecze(meczDto.Druzyna1Id, meczDto.Druzyna2Id,
                meczDto.DataMeczu, meczDto.GodzinaMeczuOd, meczDto.GodzinaMeczuDo);
            return konfliktoweMecze.Any();
        }
    }
}