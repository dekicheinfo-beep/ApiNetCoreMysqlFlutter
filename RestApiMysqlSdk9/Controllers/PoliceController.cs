using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiMysqlSdk.Data;
using RestApiMysqlSdk.Models;

namespace RestApiMysqlSdk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliceController : ControllerBase
    {
        private readonly DbAssuranceContext _context;

        public PoliceController(DbAssuranceContext context)
        {
            _context = context;
        }

        // GET: api/Police
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Police>>> GetPolices()
        {
            return await _context.Polices.ToListAsync();
        }

        // GET: api/Police/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Police>> GetPolice(string id)
        {
            var police = await _context.Polices.FindAsync(id);

            if (police == null)
            {
                return NotFound();
            }

            return police;
        }

        [HttpGet("counts/{codeassu}")]
        public async Task<ActionResult<object>> GetCountsByAssure(string codeassu)
        {
            var result = await _context.Polices
                .Where(c => c.Codeassu == codeassu)
                .GroupBy(c => c.LibCate)
                .Select(g => new
                {
                    type = g.Key,
                    count = g.Count()
                })
                .ToListAsync();

            return Ok(result);
        }

        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<Police>>> GetList(string codeassu, string? type)
        {
            var query = _context.Polices.Where(c => c.Codeassu == codeassu);

            if (!string.IsNullOrEmpty(type))
            {
                query = query.Where(c => c.LibCate == type);
            }

            return Ok(await query.ToListAsync());
        }

        // PUT: api/Police/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPolice(string id, Police police)
        {
            if (id != police.Agence)
            {
                return BadRequest();
            }

            _context.Entry(police).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoliceExists(id))
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

        // POST: api/Police
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Police>> PostPolice(Police police)
        {
            _context.Polices.Add(police);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PoliceExists(police.Agence))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPolice", new { id = police.Agence }, police);
        }

        // DELETE: api/Police/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolice(string id)
        {
            var police = await _context.Polices.FindAsync(id);
            if (police == null)
            {
                return NotFound();
            }

            _context.Polices.Remove(police);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PoliceExists(string id)
        {
            return _context.Polices.Any(e => e.Agence == id);
        }
    }
}
