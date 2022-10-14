using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.API;
using WebApp.API.Entities;

namespace WebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CareersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CareersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Careers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Career>>> GetCareer()
        {
            return await _context.Career.ToListAsync();
        }

        // GET: api/Careers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Career>> GetCareer(int id)
        {
            var career = await _context.Career.FindAsync(id);

            if (career == null)
            {
                return NotFound();
            }

            return career;
        }

        // PUT: api/Careers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCareer(int id, Career career)
        {
            if (id != career.Id)
            {
                return BadRequest();
            }

            _context.Entry(career).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CareerExists(id))
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

        // POST: api/Careers
        [HttpPost]
        public async Task<ActionResult<Career>> PostCareer(Career career)
        {
            _context.Career.Add(career);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCareer", new { id = career.Id }, career);
        }

        // DELETE: api/Careers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCareer(int id)
        {
            var career = await _context.Career.FindAsync(id);
            if (career == null)
            {
                return NotFound();
            }

            _context.Career.Remove(career);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CareerExists(int id)
        {
            return _context.Career.Any(e => e.Id == id);
        }
    }
}
