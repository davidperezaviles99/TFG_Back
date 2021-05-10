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
    public class AsignaturasController : Controller
    {
        private readonly TFG_BackContext _context;

        public AsignaturasController(TFG_BackContext context)
        {
            _context = context;
        }

        // GET: api/Asignaturas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asignaturas>>> GetAsignaturas()
        {
            return await _context.Asignaturas.Include("Profesor").ToListAsync();

        }

        // GET: api/Asignaturas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Asignaturas>> GetAsignaturas(long id)
        {
            var asignaturas = await _context.Asignaturas.Include("Profesor").FirstOrDefaultAsync(u => u.Id == id);

            if (asignaturas == null)
            {
                return NotFound();
            }

            return asignaturas;
        }

        // PUT: api/Asignaturas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Codigo,Curso,Asignatura")] Asignaturas asignaturas)
        {
            var asignatura = await _context.Asignaturas.Include("Profesor").FirstOrDefaultAsync(u => u.Id == asignaturas.Id);

            if (id != asignaturas.Id)
            {
                return BadRequest();
            }

            _context.Entry(asignaturas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsignaturasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Asignaturas/create
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("create")]
        public async Task<HttpResponseMessage> Create([Bind("Id,Codigo,Curso,Asignatura")] Asignaturas asignaturas)
        {
            var asignatura = await _context.Asignaturas.Include("Profesor").FirstOrDefaultAsync(u => u.Id == asignaturas.Id);

            _context.Asignaturas.Add(asignaturas);
            await _context.SaveChangesAsync();

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        // DELETE: api/Asignaturas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsignaturas(long id)
        {
            var asignaturas = await _context.Asignaturas.FindAsync(id);
            if (asignaturas == null)
            {
                return NotFound();
            }

            _context.Asignaturas.Remove(asignaturas);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool AsignaturasExists(long id)
        {
            return _context.Asignaturas.Any(e => e.Id == id);
        }
    }
}
