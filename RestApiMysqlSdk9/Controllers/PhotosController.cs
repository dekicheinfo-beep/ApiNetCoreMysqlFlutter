using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiMysqlSdk9.Data;
using RestApiMysqlSdk9.Models;

namespace RestApiMysqlSdk9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly AppDbContext _db;

        public PhotosController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: api/Photos
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Photo>>> GetPhotos()
        //{
        //    return await _context.Photos.ToListAsync();
        //}

        // GET: api/Photos/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Photo>> GetPhoto(int id)
        //{
        //    var photo = await _context.Photos.FindAsync(id);

        //    if (photo == null)
        //    {
        //        return NotFound();
        //    }

        //    return photo;
        //}

        // PUT: api/Photos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        //public async Task<IActionResult> PutPhoto(int id, Photo photo)
        //{
        //    if (id != photo.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(photo).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PhotoExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Photos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        //public async Task<ActionResult<Photo>> PostPhoto(Photo photo)
        //{
        //    _context.Photos.Add(photo);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPhoto", new { id = photo.Id }, photo);
        //}

        // DELETE: api/Photos/5
        [HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePhoto(int id)
        //{
        //    var photo = await _context.Photos.FindAsync(id);
        //    if (photo == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Photos.Remove(photo);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool PhotoExists(int id)
        //{
        //    return _context.Photos.Any(e => e.Id == id);
        //}

        [HttpPost("multi")]
        public async Task<IActionResult> UploadMultiple(List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
                return BadRequest("No files received");

            var uploadPath = Path.Combine(_env.WebRootPath, "uploads");
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            List<Photo> savedPhotos = new();

            foreach (var file in files)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                var fullPath = Path.Combine(uploadPath, fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var photo = new Photo
                {
                    FileName = fileName,
                    FilePath = "/uploads/" + fileName,
                    //UploadDate = DateTime.UtcNow
                };

                savedPhotos.Add(photo);
                //_db.Photos.Add(photo);
            }

            await _db.SaveChangesAsync();

            return Ok(savedPhotos);
        }
    
}
}
