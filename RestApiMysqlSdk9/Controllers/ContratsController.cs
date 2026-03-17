using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiMysqlSdk9.Data;
using RestApiMysqlSdk9.Models;

namespace RestApiMysqlSdk9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContratsController(AppDbContext context)
        {
            _context = context;
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
