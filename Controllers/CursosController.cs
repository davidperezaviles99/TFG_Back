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
using TFG_Back.Models;

namespace TFG_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : Controller
    {
        private readonly TFG_BackContext _context;

        public CursosController(TFG_BackContext context)
        {
            _context = context;
        }

        // GET: Cursos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> GetCursos()
        {
            return await _context.Curso.Include("Asignaturas").Include("Alumno").ToListAsync();

        }

        // GET: api/Cursos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetCurso(long id)
        {
            var cursos = await _context.Curso.Include("Asignaturas").Include("Alumno").FirstOrDefaultAsync(u => u.Id == id);

            if (cursos == null)
            {
                return NotFound();
            }

            return cursos;
        }

        // PUT: api/Cursos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Numero,Name")] Curso curso)
        {
            var cursos = await _context.Curso.Include("Asignaturas").Include("Alumno").FirstOrDefaultAsync(u => u.Id == curso.Id);

            if (id != curso.Id)
            {
                return BadRequest();
            }

            _context.Entry(curso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Cursos/create
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("create")]
        public async Task<HttpResponseMessage> Create([Bind("Id,Numero,Name")] Curso curso)
        {
            var cursos = await _context.Curso.Include("Asignaturas").Include("Alumno").FirstOrDefaultAsync(u => u.Id == curso.Id);

            _context.Curso.Add(curso);
            await _context.SaveChangesAsync();

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        // DELETE: api/Cursos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCursos(long id)
        {
            var curso = await _context.Curso.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }

            _context.Curso.Remove(curso);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool CursoExists(long id)
        {
            return _context.Curso.Any(e => e.Id == id);
        }
    }
}
