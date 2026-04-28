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
    public class RisquesController : ControllerBase
    {
        private readonly DbAssuranceContext _context;

        public RisquesController(DbAssuranceContext context)
        {
            _context = context;
        }

        // GET: api/Risques
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Risque>>> GetRisques()
        {
            return await _context.Risques.ToListAsync();
        }

        // GET: api/Risques/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Risque>> GetRisque(string id)
        {
            var risque = await _context.Risques.FindAsync(id);

            if (risque == null)
            {
                return NotFound();
            }

            return risque;
        }

        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<Risque>>> GetList(string numepoli, string? type)
        {
            var query = _context.Risques.Where(c => c.Numepoli == numepoli);

            if (!string.IsNullOrEmpty(type))
            {
                query = query.Where(c => c.Liberisq == type);
            }

            return Ok(await query.ToListAsync());
        }

        // PUT: api/Risques/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRisque(string id, Risque risque)
        {
            if (id != risque.Codagence)
            {
                return BadRequest();
            }

            _context.Entry(risque).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RisqueExists(id))
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

        // POST: api/Risques
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Risque>> PostRisque(Risque risque)
        {
            _context.Risques.Add(risque);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RisqueExists(risque.Codagence))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRisque", new { id = risque.Codagence }, risque);
        }

        // DELETE: api/Risques/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRisque(string id)
        {
            var risque = await _context.Risques.FindAsync(id);
            if (risque == null)
            {
                return NotFound();
            }

            _context.Risques.Remove(risque);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RisqueExists(string id)
        {
            return _context.Risques.Any(e => e.Codagence == id);
        }
    }
}
