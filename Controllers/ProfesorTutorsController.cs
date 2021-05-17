using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TFG_Back.Data;
using TFG_Back.Models;

namespace TFG_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorTutorsController : Controller
    {
        private readonly TFG_BackContext _context;

        public ProfesorTutorsController(TFG_BackContext context)
        {
            _context = context;
        }

        // GET: ProfesorTutors
        [HttpGet]

        public async Task<ActionResult<IEnumerable<ProfesorTutor>>> GetProfesorTutors()
        {
            return await _context.ProfesorTutor.ToListAsync();
        }

        // GET: api/ProfesorTutors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfesorTutor>> GetProfesorTutor(long id)
        {
            var profesortutor = await _context.ProfesorTutor.Include("Profesor").Include("Tutor").Where(o => o.Id == id).FirstOrDefaultAsync();

            if (profesortutor == null)
            {
                return NotFound();
            }

            return profesortutor;
        }

        // PUT: api/ProfesorTutors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(long id, [Bind("Id")] ProfesorTutor profesorTutor)
        {
            if (id != profesorTutor.Id)
            {
                return BadRequest();
            }

            _context.Entry(profesorTutor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfesorTutorExists(id))
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

        // POST: api/ProfesorTutors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProfesorTutor>> Create([Bind("Id")] ProfesorTutor profesorTutor)
        {
            _context.ProfesorTutor.Add(profesorTutor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfesorTutor", new { id = profesorTutor.Id }, profesorTutor);
        }

        // DELETE: api/ProfesorTutors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfesorTutor(long id)
        {
            var profesorTutor = await _context.ProfesorTutor.FindAsync(id);
            if (profesorTutor == null)
            {
                return NotFound();
            }

            _context.ProfesorTutor.Remove(profesorTutor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfesorTutorExists(long id)
        {
            return _context.ProfesorTutor.Any(e => e.Id == id);
        }

        //Profesor
        [HttpGet("Profesors")]
        public async Task<ActionResult<IEnumerable<Profesor>>> GetProfesors()
        {
            return await _context.Profesor.ToListAsync();
        }

        [HttpGet("Tutors")]
        public async Task<ActionResult<IEnumerable<Tutor>>> GetTutors()
        {
            return await _context.Tutor.ToListAsync();
        }


        [HttpGet("Profesors/{id}")]
        public async Task<ActionResult<IEnumerable<ProfesorTutor>>> GetProfesorTutors(long id)
        {

            var profesorTutors = await _context.ProfesorTutor.Include("Profesor").Include("Tutor").ToListAsync();

            var profesorTutor = profesorTutors.FindAll(o => o.Tutor.Id == id);

            return profesorTutors;
        }

        [HttpPost("DeleteProfesorTutor")]
        public async Task<ActionResult<ProfesorTutor>> DeleteProfesorTutor(ProfesorTutor profesorTutor)
        {
            var profesorTutors = await _context.ProfesorTutor.FindAsync(profesorTutor.Id);
            if (profesorTutor == null)
            {
                return NotFound();
            }

            _context.ProfesorTutor.Remove(profesorTutor);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("AsignarTutor")]
        public async Task<ActionResult<ProfesorTutor>> AsignarTutor(ProfesorTutor profesorTutor)
        {
            var profesor = await _context.Profesor.Include("Asignaturas").Where(o => o.Id == profesorTutor.Profesor.Id).FirstOrDefaultAsync();
            var tutor = await _context.Tutor.Include("Alumnos").Where(o => o.Id == profesorTutor.Tutor.Id).FirstOrDefaultAsync();

            ProfesorTutor profesorTutors = new();

            profesorTutors.Profesor = profesor;
            profesorTutors.Tutor = tutor ;

            _context.Entry(profesorTutor).State = EntityState.Unchanged;

            _context.ProfesorTutor.Add(profesorTutor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProfesorTutor), new { id = profesorTutor.Id }, profesorTutor);

        }

        [HttpPost("AsignarProfesor")]
        public async Task<ActionResult<ProfesorTutor>> AsignarProfesor(ProfesorTutor profesorTutor)
        {   
            var tutor = await _context.Tutor.Include("Alumnos").Where(o => o.Id == profesorTutor.Tutor.Id).FirstOrDefaultAsync();
            var profesor = await _context.Profesor.Include("Asignaturas").Where(o => o.Id == profesorTutor.Profesor.Id).FirstOrDefaultAsync();  

            ProfesorTutor profesorTutors = new();

            profesorTutors.Tutor = tutor;
            profesorTutors.Profesor = profesor;
           

            _context.Entry(profesorTutor).State = EntityState.Unchanged;

            _context.ProfesorTutor.Add(profesorTutor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProfesorTutor), new { id = profesorTutor.Id }, profesorTutor);

        }
    }
}
