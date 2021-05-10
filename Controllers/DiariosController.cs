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
    public class DiariosController : Controller
    {
        private readonly TFG_BackContext _context;

        public DiariosController(TFG_BackContext context)
        {
            _context = context;
        }

        // GET: api/Diarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Diario>>> GetDiarios()
        {
            return await _context.Diario.Include("Alumno").Include("Asignaturas").ToListAsync();

        }

        // GET: api/Diarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Diario>> GetDiarios(long id)
        {
            var diario = await _context.Diario.Include("Alumno").Include("Asignaturas").FirstOrDefaultAsync(u => u.Id == id);

            if (diario == null)
            {
                return NotFound();
            }

            return diario;
        }

        // PUT: api/Diarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Date,Horas,Descripcion,LinkExterno,EvaluacionT,EvaluacionP")] Diario diario)
        {
            var diarios = await _context.Diario.Include("Alumno").Include("Asignaturas").FirstOrDefaultAsync(u => u.Id == diario.Id);

            if (id != diario.Id)
            {
                return BadRequest();
            }

            _context.Entry(diario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Diarios/create
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("create")]
        public async Task<HttpResponseMessage> Create([Bind("Id,Date,Horas,Descripcion,LinkExterno,EvaluacionT,EvaluacionP")] Diario diario)
        {
            var diarios = await _context.Diario.Include("Alumno").Include("Asignaturas").FirstOrDefaultAsync(u => u.Id == diario.Id);

            _context.Diario.Add(diario);
            await _context.SaveChangesAsync();

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        // DELETE: api/Diarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiarios(long id)
        {
            var diario = await _context.Diario.FindAsync(id);
            if (diario == null)
            {
                return NotFound();
            }

            _context.Diario.Remove(diario);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool DiarioExists(long id)
        {
            return _context.Diario.Any(e => e.Id == id);
        }
    }
}
