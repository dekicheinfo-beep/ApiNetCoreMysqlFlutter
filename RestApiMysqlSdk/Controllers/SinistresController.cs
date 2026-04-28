using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiMysqlSdk.Data;
using RestApiMysqlSdk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiMysqlSdk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinistresController : ControllerBase
    {
        private readonly DbAssuranceContext _context;

        public SinistresController(DbAssuranceContext context)
        {
            _context = context;
        }

        // GET: api/Sinistres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sinistre>>> GetSinistres()
        {
            return await _context.Sinistres.ToListAsync();
        }

        // GET: api/Sinistres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sinistre>> GetSinistre(string id)
        {
            var sinistre = await _context.Sinistres.FindAsync(id);

            if (sinistre == null)
            {
                return NotFound();
            }

            return sinistre;
        }

        // PUT: api/Sinistres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSinistre(string id, Sinistre sinistre)
        {
            if (id != sinistre.Codesini)
            {
                return BadRequest();
            }

            _context.Entry(sinistre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SinistreExists(id))
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

        // POST: api/Sinistres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sinistre>> PostSinistre(Sinistre sinistre)
        {
            _context.Sinistres.Add(sinistre);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SinistreExists(sinistre.Codesini))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSinistre", new { id = sinistre.Codesini }, sinistre);
        }

        // DELETE: api/Sinistres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSinistre(string id)
        {
            var sinistre = await _context.Sinistres.FindAsync(id);
            if (sinistre == null)
            {
                return NotFound();
            }

            _context.Sinistres.Remove(sinistre);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SinistreExists(string id)
        {
            return _context.Sinistres.Any(e => e.Codesini == id);
        }

        [HttpGet("counts/{codeassu}")]
        public async Task<ActionResult<object>> GetCountsByAssure(string codeassu)
        {
            var result = await _context.Sinistres
                .Where(c => c.Codeassu == codeassu)
                //.GroupBy(c => c.l)
                //.Select(g => new
                //{
                //    type = g.Key,
                //    count = g.Count()
                //})
                .ToListAsync();

            return Ok(result);
        }

        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<Sinistre>>> GetList(string codeassu, string? type)
        {
            var query = _context.Sinistres.Where(c => c.Codeassu == codeassu);

            //if (!string.IsNullOrEmpty(type))
            //{
            //    query = query.Where(c => c.Liberisq == type);
            //}

            return Ok(await query.ToListAsync());
        }
    }
}
