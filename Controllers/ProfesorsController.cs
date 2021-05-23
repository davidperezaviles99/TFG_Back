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
    public class ProfesorsController : Controller
    {
        private readonly TFG_BackContext _context;

        public ProfesorsController(TFG_BackContext context)
        {
            _context = context;
        }

        // GET: api/Profesor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profesor>>> GetProfesor()
        {
            return await _context.Profesor.ToListAsync();
            
        }

        // GET: api/Profesor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Profesor>> GetProfesor(long id)
        {
            var profesor = await _context.Profesor.FirstOrDefaultAsync(u => u.Id == id);

            if (profesor == null)
            {
                return NotFound();
            }

            return profesor;
        }

        // PUT: api/Profesor/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Lastname,Email,Role")] ProfesorDTO profesorDTO)
        {
            var ProfesorDTO = await _context.Profesor.FirstOrDefaultAsync(u => u.Id == profesorDTO.Id);

            if(ProfesorDTO == null)
            {
                return NotFound();
            }

            _context.Entry(ProfesorDTO).CurrentValues.SetValues(profesorDTO);

            try
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetProfesor), new { id = profesorDTO.Id }, profesorDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfesorExists(profesorDTO.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Profesor/create
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("create")]
        public async Task<HttpResponseMessage> Create([Bind("Id,Name,Lastname,Email,Password,Role")] Profesor profesor)
        {

            var hashed = BCrypt.Net.BCrypt.HashPassword(profesor.Password, 10);
            profesor.Password = hashed;

            _context.Entry(profesor).State = EntityState.Unchanged;
            _context.Profesor.Add(profesor);
            await _context.SaveChangesAsync();

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        // DELETE: api/Profesor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfesor(long id)
        {
            var profesor = await _context.Profesor.FindAsync(id);
            if (profesor == null)
            {
                return NotFound();
            }

            _context.Profesor.Remove(profesor);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool ProfesorExists(long id)
        {
            return _context.Profesor.Any(e => e.Id == id);
        }
    }
}
