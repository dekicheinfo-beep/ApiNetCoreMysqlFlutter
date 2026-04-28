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
    public class GarantiesController : ControllerBase
    {
        private readonly DbAssuranceContext _context;

        public GarantiesController(DbAssuranceContext context)
        {
            _context = context;
        }

        // GET: api/Garanties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Garantie>>> GetGaranties()
        {
            return await _context.Garanties.ToListAsync();
        }

        // GET: api/Garanties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Garantie>> GetGarantie(string id)
        {
            var garantie = await _context.Garanties.FindAsync(id);

            if (garantie == null)
            {
                return NotFound();
            }

            return garantie;
        }

        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<Garantie>>> GetList(string numepoli, string coderisq, string? type)
        {
            var query = _context.Garanties.Where(c => c.Numepoli.ToString() == numepoli && c.Coderisq.ToString() == coderisq);

            //if (!string.IsNullOrEmpty(type))
            //{
            //    query = query.Where(c => c.Libgara == type);
            //}

            return Ok(await query.ToListAsync());
        }

        // PUT: api/Garanties/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGarantie(string id, Garantie garantie)
        {
            if (id != garantie.Codagence)
            {
                return BadRequest();
            }

            _context.Entry(garantie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GarantieExists(id))
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

        // POST: api/Garanties
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Garantie>> PostGarantie(Garantie garantie)
        {
            _context.Garanties.Add(garantie);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GarantieExists(garantie.Codagence))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGarantie", new { id = garantie.Codagence }, garantie);
        }

        // DELETE: api/Garanties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGarantie(string id)
        {
            var garantie = await _context.Garanties.FindAsync(id);
            if (garantie == null)
            {
                return NotFound();
            }

            _context.Garanties.Remove(garantie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GarantieExists(string id)
        {
            return _context.Garanties.Any(e => e.Codagence == id);
        }
    }
}
