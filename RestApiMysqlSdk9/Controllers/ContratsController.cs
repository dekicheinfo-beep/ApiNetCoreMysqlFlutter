using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using RestApiMysqlSdk9.Data;
using RestApiMysqlSdk9.Models;

namespace RestApiMysqlSdk9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratsController : ControllerBase
    {
        private readonly AppDbContext _context;

        private readonly IConfiguration _config;

        public ContratsController(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpGet("connect")]
        public async Task<IActionResult> TestConnection()
        {
            var connStr = _config.GetConnectionString("DefaultConnection");

            try
            {
                await using var conn = new MySqlConnection(connStr);
                await conn.OpenAsync();
                return Ok("✅ Connexion réussie !");
            }
            catch (Exception ex)
            {
                return BadRequest($"❌ Connexion échouée : {ex.Message}");
            }
        }

        [HttpGet("testdb")]
        public async Task<IActionResult> TestDb()
        {
            try
            {
                var count = await _context.EntContrats.CountAsync();
                return Ok(count);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        

        // GET: api/Photos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntContrat>>> GetContrats()
        {
            return await _context.EntContrats.ToListAsync();
        }

        [HttpGet("{clientId}")]
        public IActionResult GetContrats(int clientId)
        {
            var contrats = _context.EntContrats
                .Where(c => c.Clientid == clientId)
                .ToList();

            return Ok(contrats);
        }

        // 🔥 GET: api/contrats/count
        [HttpGet("countTableau")]
        public async Task<ActionResult<IEnumerable<ContratCountDto>>> GetContratCounts()
        {
            var result = await _context.EntContrats
                .GroupBy(c => new { c.Clientid, c.Typecontrat })
                .Select(g => new ContratCountDto
                {
                    ClientId = g.Key.Clientid,
                    Typecontrat = g.Key.Typecontrat,
                    Nombre = g.Count()
                })
                .ToListAsync();

            return Ok(result);
        }


        //[HttpGet("count/{clientId}/{type}")]
        //public async Task<ActionResult<int>> GetCount(int clientId, string type)
        //{
        //    var count = await _context.EntContrats
        //        .Where(c => c.Clientid == clientId && c.Typecontrat == type)
        //        .CountAsync();

        //    return Ok(count);
        //}

        [HttpGet("count")]
        public async Task<ActionResult<int>> GetCount(int clientId, string? type)
        {
            var query = _context.EntContrats.Where(c => c.Clientid == clientId);

            if (!string.IsNullOrEmpty(type))
            {
                query = query.Where(c => c.Typecontrat == type);
            }

            var count = await query.CountAsync();

            return Ok(count);
        }

        [HttpGet("counts/{clientId}")]
        public async Task<ActionResult<object>> GetCountsByClient(int clientId)
        {
            var result = await _context.EntContrats
                .Where(c => c.Clientid == clientId)
                .GroupBy(c => c.Typecontrat)
                .Select(g => new
                {
                    type = g.Key,
                    count = g.Count()
                })
                .ToListAsync();

            return Ok(result);
        }

        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<EntContrat>>> GetList(int clientId, string? type)
        {
            var query = _context.EntContrats.Where(c => c.Clientid == clientId);

            if (!string.IsNullOrEmpty(type))
            {
                query = query.Where(c => c.Typecontrat == type);
            }

            return Ok(await query.ToListAsync());
        }
    }
}
