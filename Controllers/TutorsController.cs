using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TFG_Back.Data;
using TFG_Back.DTOs;
using TFG_Back.Models;

namespace TFG_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorsController : Controller
    {
        private readonly TFG_BackContext _context;

        public TutorsController(TFG_BackContext context)
        {
            _context = context;
        }

        // GET: api/Tutors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tutor>>> GetTutor()
        {
            return await _context.Tutor.Include("Alumno").ToListAsync();

        }

        // GET: api/Tutors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tutor>> GetTutor(long id)
        {
            var tutor = await _context.Tutor.Include("Alumno").FirstOrDefaultAsync(u => u.Id == id);

            if (tutor == null)
            {
                return NotFound();
            }

            return tutor;
        }

        // PUT: api/Tutors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Lastname,Email,Role")] TutorDTO tutorDTO)
        {
            var tutors = await _context.Tutor.Include("Alumno").FirstOrDefaultAsync(u => u.Id == tutorDTO.Id);

            if (tutors == null)
            {
                return NotFound();
            }

            _context.Entry(tutors).CurrentValues.SetValues(tutorDTO);

            try
            {
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TutorExists(tutorDTO.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Tutors/create
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("create")]
        public async Task<HttpResponseMessage> Create([Bind("Id,Name,Lastname,Email,Password,Role")] Tutor tutor)
        {

            var hashed = BCrypt.Net.BCrypt.HashPassword(tutor.Password, 10);
            tutor.Password = hashed;

            _context.Tutor.Add(tutor);
            await _context.SaveChangesAsync();

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        // DELETE: api/Tutors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTutor(long id)
        {
            var tutor = await _context.Tutor.FindAsync(id);
            if (tutor == null)
            {
                return NotFound();
            }

            _context.Tutor.Remove(tutor);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool TutorExists(long id)
        {
            return _context.Tutor.Any(e => e.Id == id);
        }
    }
}
