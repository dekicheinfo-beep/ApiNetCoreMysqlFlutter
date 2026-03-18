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
        private readonly AppDbContext1 _context;

        private readonly IConfiguration _config;

        public ContratsController(AppDbContext1 context, IConfiguration config)
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
    }
}
