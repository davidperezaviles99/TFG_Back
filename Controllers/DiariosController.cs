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
    public class DiariosController : Controller
    {
        private readonly TFG_BackContext _context;
        private readonly IMapper _mapper;

        public DiariosController(TFG_BackContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Diarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Diario>>> GetDiario()
        {
            var diario = await _context.Diario.Include("Equipo").Include("Asignaturas").ToListAsync();

            return diario;

        }

        // GET: api/Diarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Diario>> GetDiario(long id)
        {
            var diario = await _context.Diario.Include("Equipo").Include("Asignaturas").FirstOrDefaultAsync(u => u.Id == id);

            if (diario == null)
            {
                return NotFound();
            }

            return diario;
        }

        // PUT: api/Diarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Date,Horas,Descripcion,LinkExterno,EvaluacionT,EvaluacionP")] DiarioDTO diarioDTO)
        {
            var DiarioDTO = await _context.Diario.Include("Equipo").Include("Asignaturas").FirstOrDefaultAsync(u => u.Id == diarioDTO.Id);

            if (DiarioDTO == null)
            {
                return NotFound();
            }


            _context.Entry(DiarioDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetDiario), new { id = diarioDTO.Id }, diarioDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiarioExists(diarioDTO.Id))
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
        public async Task<HttpResponseMessage> Create([Bind("Id,Date,Horas,Descripcion,LinkExterno,EvaluacionT,EvaluacionP")] DiarioDTO diarioDTO)
        {
            var diario = _mapper.Map<Diario>(diarioDTO);

            _context.Entry(diario).State = EntityState.Unchanged;

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
