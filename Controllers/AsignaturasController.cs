using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
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
    public class AsignaturasController : Controller
    {
        private readonly TFG_BackContext _context;
        private readonly IMapper _mapper;

        public AsignaturasController(TFG_BackContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Asignaturas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asignaturas>>> GetAsignaturas()
        {
            return await _context.Asignaturas.Include("Profesor").ToListAsync();

        }

        // GET: api/Asignaturas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Asignaturas>> GetAsignatura(long id)
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
        [HttpPut]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Codigo,Curso,Asignatura")] AsignaturasDTO asignaturasDTO)
        {
            
            var asignatura = await _context.Asignaturas.FirstOrDefaultAsync(u => u.Id == asignaturasDTO.Id);

            if (asignatura == null)
            {
                return BadRequest();
            }

            _context.Entry(asignatura).CurrentValues.SetValues(asignaturasDTO);

            try
            {
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsignaturasExists(asignaturasDTO.Id))
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
        public async Task<HttpResponseMessage> Create([Bind("Id,Codigo,Curso,Asignatura")] AsignaturasDTO asignaturasDTO)
        {

            var asignaturas = _mapper.Map<Asignaturas>(asignaturasDTO);

            _context.Entry(asignaturas).State = EntityState.Unchanged;

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
