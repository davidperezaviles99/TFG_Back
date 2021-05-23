using System;
using System.Collections.Generic;
using System.Linq;
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
    public class EquiposController : Controller
    {
        private readonly TFG_BackContext _context;
        private readonly IMapper _mapper;

        public EquiposController(TFG_BackContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Equipos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipo>>> GetEquipo()
        {
            return await _context.Equipo.ToListAsync();
        }

        // GET: api/Equipos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EquipoDTO>> GetEquipo(long id)
        {
            var equipo = await _context.Equipo.Include("Alumno").Include("Tutor").Include("Profesor").Where(o => o.Id == id).FirstOrDefaultAsync();

            if (equipo == null)
            {
                return NotFound();
            }

            return _mapper.Map<EquipoDTO>(equipo);
        }

        // PUT: api/Equipos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipo(long id, Equipo equipo)
        {
            if (id != equipo.Id)
            {
                return BadRequest();
            }

            _context.Entry(equipo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipoExists(id))
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


        // POST: api/Equipos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<ActionResult<Equipo>> Create([Bind("Id")] Equipo equipo)
        {
            _context.Equipo.Add(equipo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquipo", new { id = equipo.Id }, equipo);
        }

        // DELETE: api/Equipo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipo(long id)
        {
            var equipo = await _context.Equipo.FindAsync(id);
            if (equipo == null)
            {
                return NotFound();
            }

            _context.Equipo.Remove(equipo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipoExists(long id)
        {
            return _context.Equipo.Any(e => e.Id == id);
        }

        [HttpGet("Tutores")]
        public async Task<ActionResult<IEnumerable<TutorDTO>>> GetTutores()
        {
            return _mapper.Map<List<TutorDTO>>(await _context.Tutor.ToListAsync());
        }

        [HttpGet("Profesores")]
        public async Task<ActionResult<IEnumerable<ProfesorDTO>>> GetProfesores()
        {
            return _mapper.Map<List<ProfesorDTO>>(await _context.Profesor.ToListAsync());
        }

        [HttpGet("Equipos/{id}")]
        public async Task<ActionResult<IEnumerable<EquipoDTO>>> GetEquipos(long id)
        {

            var equiposDB = await _context.Equipo.Include("Alumno").Include("Tutor").Include("Profesor").ToListAsync();

            var equipos = equiposDB.FindAll(a => a.Alumno.Id == id);

            var equipoDTO = _mapper.Map<List<EquipoDTO>>(equipos);

            return equipoDTO;
        }

        [HttpPost("DeleteEquipo")]
        public async Task<ActionResult<EquipoDTO>> DeleteEquipo(EquipoDTO equipoDTO)
        {
            var equipo = await _context.Equipo.FindAsync(equipoDTO.Id);
            if (equipo == null)
            {
                return NotFound();
            }

            _context.Equipo.Remove(equipo);
            await _context.SaveChangesAsync();

            return equipoDTO;
        }

        [HttpPost("AsignarTutor")]
        public async Task<ActionResult<EquipoDTO>> AsignarTutor(EquipoDTO equipoDTO)
        {
            var alumno = await _context.Alumno.Include("Curso").Where(o => o.Id == equipoDTO.AlumnoId).FirstOrDefaultAsync();

            Equipo equipo = new();

            equipo.Alumno = alumno;
            equipo.Tutor = _mapper.Map<Tutor>(equipoDTO.Tutor);

            _context.Entry(equipo).State = EntityState.Unchanged;

            _context.Equipo.Add(equipo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEquipo), new { id = equipo.Id }, _mapper.Map<EquipoDTO>(equipo));
        }

        [HttpPost("AsignarProfesor")]
        public async Task<ActionResult<EquipoDTO>> AsignarProfesor(EquipoDTO equipoDTO)
        {
            var alumno = await _context.Alumno.Include("Curso").Where(o => o.Id == equipoDTO.AlumnoId).FirstOrDefaultAsync();

            Equipo equipo = new();

            equipo.Alumno = alumno;
            equipo.Profesor = _mapper.Map<Profesor>(equipoDTO.Profesor);

            _context.Entry(equipo).State = EntityState.Unchanged;

            _context.Equipo.Add(equipo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEquipo), new { id = equipo.Id }, _mapper.Map<EquipoDTO>(equipo));
        }

    }
}
