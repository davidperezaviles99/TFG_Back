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
    public class EvaluacionsController : Controller
    {
        private readonly TFG_BackContext _context;
        private readonly IMapper _mapper;

        public EvaluacionsController(TFG_BackContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Evaluacions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evaluacion>>> GetEvaluacion()
        {
            var evaluacion = await _context.Evaluacion.Include("Equipo").ToListAsync();

            return evaluacion;
        }

        // GET: api/Evaluacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Evaluacion>> GetEvaluacion(long id)
        {
            var evaluacion = await _context.Evaluacion.Include("Equipo").FirstOrDefaultAsync(u => u.Id == id);

            if (evaluacion == null)
            {
                return NotFound();
            }

            return evaluacion;
        }

        // PUT: api/Evaluacions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Date,EvaluacionT,EvaluacionP")] EvaluacionDTO evaluacionDTO)
        {

            var EvaluacionDTO = await _context.Evaluacion.Include("Equipo").FirstOrDefaultAsync(u => u.Id == evaluacionDTO.Id);

            if (EvaluacionDTO == null)
            {
                return NotFound();
            }

            _context.Entry(EvaluacionDTO).CurrentValues.SetValues(evaluacionDTO);

            try
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetEvaluacion), new { id = evaluacionDTO.Id }, evaluacionDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EvaluacionExists(evaluacionDTO.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Evaluacions/create
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("create")]
        public async Task<HttpResponseMessage> Create([Bind("Id,Date,EvaluacionT,EvaluacionP")] EvaluacionDTO evaluacionDTO)
        {

            var evaluacion = _mapper.Map<Evaluacion>(evaluacionDTO);

            _context.Entry(evaluacion).State = EntityState.Unchanged;

            _context.Evaluacion.Add(evaluacion);
            await _context.SaveChangesAsync();

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        // DELETE: api/Evaluacions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvaluacion(long id)
        {
            var evaluacion = await _context.Evaluacion.FindAsync(id);
            if (evaluacion == null)
            {
                return NotFound();
            }

            _context.Evaluacion.Remove(evaluacion);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool EvaluacionExists(long id)
        {
            return _context.Evaluacion.Any(e => e.Id == id);
        }
    }
}
