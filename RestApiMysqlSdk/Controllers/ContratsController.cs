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
    public class ContratsController : ControllerBase
    {
        private readonly DbAssuranceContext _context;

        public ContratsController(DbAssuranceContext context)
        {
            _context = context;
        }

        // GET: api/Contrats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contrat>>> GetContrats()
        {
            return await _context.Contrats.ToListAsync();
        }

        //// GET: api/Contrats/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Contrat>> Get(string numepoli, string coderisq)
        //{
        //    var contrat = await _context.Contrats.FindAsync(id);

        //    if (contrat == null)
        //    {
        //        return NotFound();
        //    }

        //    return contrat;
        //}

        [HttpGet("{numepoli}/{coderisq}")]
        public async Task<ActionResult<Contrat>> Get(string numepoli, string coderisq)
        {
            var contrat = await _context.Contrats
                .FirstOrDefaultAsync(c => c.Numepoli == numepoli && c.Coderisq == coderisq);

            if (contrat == null)
            {
                return NotFound();
            }

            return contrat;
        }

        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<Contrat>>> GetList(string codeassu, string? type)
        {
            var query = _context.Contrats.Where(c => c.Codeassu == codeassu);

            if (!string.IsNullOrEmpty(type))
            {
                query = query.Where(c => c.Liberisq == type);
            }

            return Ok(await query.ToListAsync());
        }

        // PUT: api/Contrats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContrat(string id, Contrat contrat)
        {
            if (id != contrat.Codagence)
            {
                return BadRequest();
            }

            _context.Entry(contrat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContratExists(id))
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

        // POST: api/Contrats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Contrat>> PostContrat(Contrat contrat)
        {
            _context.Contrats.Add(contrat);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ContratExists(contrat.Codagence))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetContrat", new { id = contrat.Codagence }, contrat);
        }

        // DELETE: api/Contrats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContrat(string id)
        {
            var contrat = await _context.Contrats.FindAsync(id);
            if (contrat == null)
            {
                return NotFound();
            }

            _context.Contrats.Remove(contrat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContratExists(string id)
        {
            return _context.Contrats.Any(e => e.Codagence == id);
        }

        [HttpGet("counts/{codeassu}")]
        public async Task<ActionResult<object>> GetCountsByAssure(string codeassu)
        {
            var result = await _context.Contrats
                .Where(c => c.Codeassu == codeassu)
                .GroupBy(c => c.Liberisq)
                .Select(g => new
                {
                    type = g.Key,
                    count = g.Count()
                })
                .ToListAsync();

            return Ok(result);
        }

        //[HttpGet("list")]
        //public async Task<ActionResult<IEnumerable<Contrat>>> GetList(string codeassu, string? type)
        //{
        //    var query = _context.Contrats.Where(c => c.Codeassu == codeassu);

        //    if (!string.IsNullOrEmpty(type))
        //    {
        //        query = query.Where(c => c.Liberisq == type);
        //    }

        //    return Ok(await query.ToListAsync());
        //}


    }
}
