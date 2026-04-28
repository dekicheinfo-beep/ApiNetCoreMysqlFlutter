using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
    public class AssuresController : ControllerBase
    {
        private readonly DbAssuranceContext _context;

        public AssuresController(DbAssuranceContext context)
        {
            _context = context;
        }

        // GET: api/Assures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assure>>> GetAssures()
        {
            return await _context.Assures.ToListAsync();
        }

        //GET: api/Assures/5
        [HttpGet("{codeassu}")]
        public async Task<ActionResult<Assure>> Getby(long codeassu)
        {
            var assure = await _context.Assures.FindAsync(codeassu);

            if (assure == null)
            {
                return NotFound();
            }

            return assure;
        }

        // GET: api/EntUsers/5
        //[HttpGet("{user},{passe}")]
        [HttpPost("GetAssure")]

        public async Task<ActionResult<Assure>> GetAssure([FromBody] LoginRequest request)
        {
            var entUser = await _context.Assures
                .FirstOrDefaultAsync(x => x.Userassu == request.User && x.Passassu == request.Passe);

            if (entUser == null)
            {
                return NotFound();
            }

            return entUser;
        }

        // PUT: api/Assures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssure(long id, Assure assure)
        {
            if (id != assure.Codeassu)
            {
                return BadRequest();
            }

            _context.Entry(assure).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssureExists(id))
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

        // POST: api/Assures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Assure>> PostAssure(Assure assure)
        {
            _context.Assures.Add(assure);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AssureExists(assure.Codeassu))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAssure", new { id = assure.Codeassu }, assure);
        }

        // DELETE: api/Assures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssure(long id)
        {
            var assure = await _context.Assures.FindAsync(id);
            if (assure == null)
            {
                return NotFound();
            }

            _context.Assures.Remove(assure);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AssureExists(long id)
        {
            return _context.Assures.Any(e => e.Codeassu == id);
        }

        //[HttpPost("login")] // developpement
        //public async Task<IActionResult> Login(string user, string passe)
        //{
        //    var assure = await _context.Assures
        //        .FirstOrDefaultAsync(x => x.Userassu == user);

        //    if (assure == null)
        //        return Unauthorized(new { message = "Utilisateur introuvable" });

        //    if (assure.Passassu != passe)
        //        return Unauthorized(new { message = "Mot de passe incorrect" });

        //    return Ok(new
        //    {
        //        token = "dummy-jwt-token-example",
        //        message = "Connexion réussie"
        //    });
        //}


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                if (request == null || string.IsNullOrEmpty(request.User) || string.IsNullOrEmpty(request.Passe))
                    return BadRequest(new { message = "Paramètres invalides" });

                var assure = await _context.Assures
                    .FirstOrDefaultAsync(x => x.Userassu == request.User);

                if (assure == null)
                    return Unauthorized(new { message = "Utilisateur introuvable" });

                if (assure.Passassu != request.Passe)
                    return Unauthorized(new { message = "Mot de passe incorrect" });

                return Ok(new
                {
                    codeassu = assure.Codeassu.ToString(),
                    token = "dummy-jwt-token-example",
                    message = "Connexion réussie"
                });
            }
            catch (Exception)
            {
                throw;
            }
            
            
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(string Userassu)
        {
            var assure = await _context.Assures
                .FirstOrDefaultAsync(u => u.Userassu == Userassu);

            if (assure == null)
                return NotFound("Utilisateur introuvable");

            // 🔐 Générer un token
            var token = Guid.NewGuid().ToString();

            // 👉 Stocker le token (ajoute ces champs dans ta table si besoin)
            assure.ResetToken = token;
            assure.ResetTokenExpiry = DateTime.UtcNow.AddMinutes(30);

            await _context.SaveChangesAsync();

            // 📧 Envoyer email
            var resetLink = $"https://ton-site.com/reset-password?token={token}";

            await SendEmail(assure.Mailassu, resetLink);

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
            var Assure = await _context.Assures
                .FirstOrDefaultAsync(u => u.ResetToken == token);

            if (Assure == null || Assure.ResetTokenExpiry < DateTime.UtcNow)
                return BadRequest("Token invalide ou expiré");

            Assure.Passassu = newPassword; // ⚠️ à hasher en prod !
            Assure.ResetToken = null;

            await _context.SaveChangesAsync();

            return Ok("Mot de passe modifié");
        }
    }
}
