using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiMysqlSdk9.Data;
using RestApiMysqlSdk9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

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

        //[HttpPost("login")]  //production
        //public async Task<IActionResult> Login([FromBody] EntUser User)
        //{
        //    var user = await _context.EntUsers
        //        .FirstOrDefaultAsync(x => x.User == User.User && x.Password==User.Password);

        //    if (user == null || user.Password != user.Password)
        //        return Unauthorized();

        //    // Normally return JWT token
        //    return Ok(new { token = "dummy-jwt-token-example" });
        //}

        [HttpPost("login")] // developpement
        public async Task<IActionResult> Login([FromBody] EntUser User)
        {
            var user = await _context.EntUsers
                .FirstOrDefaultAsync(x => x.User == User.User);

            if (user == null)
                return Unauthorized(new { message = "Utilisateur introuvable" });

            if (user.Password != User.Password)
                return Unauthorized(new { message = "Mot de passe incorrect" });

            return Ok(new
            {
                token = "dummy-jwt-token-example",
                message = "Connexion réussie"
            });
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(string username)
        {
            var user = await _context.EntUsers
                .FirstOrDefaultAsync(u => u.User == username);

            if (user == null)
                return NotFound("Utilisateur introuvable");

            // 🔐 Générer un token
            var token = Guid.NewGuid().ToString();

            // 👉 Stocker le token (ajoute ces champs dans ta table si besoin)
            user.ResetToken = token;
            user.ResetTokenExpiry = DateTime.UtcNow.AddMinutes(30);

            await _context.SaveChangesAsync();

            // 📧 Envoyer email
            var resetLink = $"https://ton-site.com/reset-password?token={token}";

            await SendEmail(user.Email, resetLink);

            return Ok("Email envoyé");
        }

    

        private async Task SendEmail(string toEmail, string resetLink)
        {
            using (var smtpClient = new SmtpClient("smtp.gmail.com"))
            {
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential(
                    "dekiche.info@gmail.com",
                    "fbkd zwis zhnn hbew"
                );
                smtpClient.EnableSsl = true;

                var mail = new MailMessage
                {
                    From = new MailAddress("dekiche.info@gmail.com"),
                    Subject = "changement de mot de passe",
                    Body = $"Cliquez ici pour réinitialiser : {resetLink}",
                    IsBodyHtml = false,
                };

                mail.To.Add(toEmail);

                await smtpClient.SendMailAsync(mail);
            }
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(string token, string newPassword)
        {
            var user = await _context.EntUsers
                .FirstOrDefaultAsync(u => u.ResetToken == token);

            if (user == null || user.ResetTokenExpiry < DateTime.UtcNow)
                return BadRequest("Token invalide ou expiré");

            user.Password = newPassword; // ⚠️ à hasher en prod !
            user.ResetToken = null;

            await _context.SaveChangesAsync();

            return Ok("Mot de passe modifié");
        }


    }
}
