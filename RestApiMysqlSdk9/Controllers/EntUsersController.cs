using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiMysqlSdk9.Data;
using RestApiMysqlSdk9.Models;

namespace RestApiMysqlSdk9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntUsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EntUsersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/EntUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntUser>>> GetEntUsers()
        {
            return await _context.EntUsers.ToListAsync();
        }

        // GET: api/EntUsers/5
        //[HttpGet("{user},{passe}")]
        [HttpPost("GetEntUser")]

        public async Task<ActionResult<EntUser>> GetEntUser(string user,string passe)
        {
            var entUser = await _context.EntUsers
                .FirstOrDefaultAsync(x => x.User == user && x.Password == passe);

            if (entUser == null)
            {
                return NotFound();
            }

            return entUser;
        }

        // PUT: api/EntUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntUser(string id, EntUser entUser)
        {
            if (id != entUser.User)
            {
                return BadRequest();
            }

            _context.Entry(entUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntUserExists(id))
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

        // POST: api/EntUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EntUser>> PostEntUser(EntUser entUser)
        {
            _context.EntUsers.Add(entUser);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EntUserExists(entUser.User))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEntUser", new { id = entUser.User }, entUser);
        }

        // DELETE: api/EntUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntUser(string id)
        {
            var entUser = await _context.EntUsers.FindAsync(id);
            if (entUser == null)
            {
                return NotFound();
            }

            _context.EntUsers.Remove(entUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EntUserExists(string id)
        {
            return _context.EntUsers.Any(e => e.User == id);
        }

        //("login/{user}/{password}")]

        //[HttpPost("login")]
        //public async Task<IActionResult> Login([FromRoute] string User, [FromRoute] string Password)
        //{
        //    var user = await _context.EntUsers
        //        .FirstOrDefaultAsync(x => x.User == User);

        //    if (user == null || user.Password != Password)
        //        return Unauthorized();

        //    // Normally return JWT token
        //    return Ok(new { token = "dummy-jwt-token-example" });
        //}

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] EntUser User)
        {
            var user = await _context.EntUsers
                .FirstOrDefaultAsync(x => x.User == User.User && x.Password==User.Password);

            if (user == null || user.Password != user.Password)
                return Unauthorized();

            // Normally return JWT token
            return Ok(new { token = "dummy-jwt-token-example" });
        }


    }
}
