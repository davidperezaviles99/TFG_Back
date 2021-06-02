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
        public async Task<ActionResult<IEnumerable<Asignatura>>> GetAsignatura()
        {
            var asignatura = await _context.Asignatura.Include("Profesor").ToListAsync();

            return asignatura;
        }

        // GET: api/Asignaturas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AsignaturaDTO>> GetAsignatura(long id)
        {
            var asignatura = await _context.Asignatura.Include("Profesor").Where(o => o.Id == id).FirstOrDefaultAsync();

            if (asignatura == null)
            {
                return NotFound();
            }

            var asignaturaDTO = _mapper.Map<AsignaturaDTO>(asignatura);

            return asignaturaDTO;
        }
           
        // PUT: api/Asignaturas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> Edit(AsignaturaDTO asignaturaDTO)
        {
            var AsignaturaDTO = await _context.Asignatura.Include("Profesor").FirstOrDefaultAsync(o => o.Id == asignaturaDTO.Id);

            var profesor = await _context.Profesor.FindAsync(asignaturaDTO.Profesor.Id);

            if (AsignaturaDTO == null)
            {
                return NotFound();
            }

            AsignaturaDTO.Profesor = profesor;
            //if (@asignatura.Profesor.Id != asignaturaDTO.Profesor.Id)
            //{
            //    @asignatura.Profesor = asignaturaDTO.Profesor.Id;
            //}

            _context.Entry(AsignaturaDTO).CurrentValues.SetValues(asignaturaDTO);

            try
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetAsignatura), new { id = asignaturaDTO.Id }, asignaturaDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsignaturaExists(asignaturaDTO.Id))
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
        public async Task<HttpResponseMessage> Create([Bind("Id,Codigo,Nombre")] AsignaturaDTO asignaturaDTO)
        {

            var asignatura = _mapper.Map<Asignatura>(asignaturaDTO);

            _context.Entry(asignatura).State = EntityState.Unchanged;

            _context.Asignatura.Add(asignatura);
            await _context.SaveChangesAsync();

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        // DELETE: api/Asignaturas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsignatura(long id)
        {
            var asignatura = await _context.Asignatura.FindAsync(id);
            if (asignatura == null)
            {
                return NotFound();
            }

            _context.Asignatura.Remove(asignatura);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool AsignaturaExists(long id)
        {
            return _context.Asignatura.Any(e => e.Id == id);
        }
    }
}
