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
           //var equipo = await _context.Equipo.Include("Alumno").Include("Tutor").Include("Profesor").ToListAsync();

            //return equipo;
            return await _context.Equipo.Include("Alumno").Include("Tutor").Include("Profesor").ToListAsync();
        }

        // GET: api/Equipos/5
        [HttpPost("consultaequipo")]
        public async Task<ActionResult<IEnumerable<EquipoDTO>>> GetConsulta(ConsultaequipoDTO consultaequipoDTO)
        {
            //var equipos = await _context.Equipo.Include("Alumno").Include("Profesor").Include("Tutor").FirstOrDefaultAsync(o => o.Profesor.Id == id || o.Tutor.Id == id);

            //var equipos = await _context.Equipo.Include("Alumno").Include("Tutor").Include("Profesor").ToListAsync();

            //var equipod = await _context.Equipo.Include("Alumno").Include("Profesor").Include("Tutor").FirstOrDefaultAsync(o => o.Profesor.Id == id || o.Tutor.Id == id);

            //if (equipod == null)
            //{
            //    return NotFound();
            //}

            List<Equipo> equipos = new();

            if (consultaequipoDTO.Role == "Profesor")
            {
                var equipo = await _context.Equipo.FirstOrDefaultAsync(e => e.Profesor.Id == consultaequipoDTO.Id);
                if(equipo == null)
                {
                    return _mapper.Map<List<EquipoDTO>>(equipos);
                }
                var equipodb = await _context.Equipo.Include("Alumno").Include("Tutor").Include("Profesor").ToListAsync();
                equipos = equipodb.FindAll(e => e.Profesor.Id == consultaequipoDTO.Id);
            }

            if (consultaequipoDTO.Role == "Tutor")
            {
                var equipo = await _context.Equipo.FirstOrDefaultAsync(e => e.Tutor.Id == consultaequipoDTO.Id);
                if (equipo == null)
                {
                    return _mapper.Map<List<EquipoDTO>>(equipos);
                }
                var equipodb = await _context.Equipo.Include("Alumno").Include("Profesor").Include("Tutor").ToListAsync();
                equipos = equipodb.FindAll(e => e.Tutor.Id == consultaequipoDTO.Id);
            }

            return _mapper.Map<List<EquipoDTO>>(equipos);
        }

        // GET: api/Equipos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EquipoDTO>> GetEquipo(long id)
        {
            var equipo = await _context.Equipo.Include("Alumno").Include("Tutor").Include("Profesor").Where(e => e.Id == id).FirstOrDefaultAsync();

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
        [HttpPost("create")]
        public async Task<ActionResult<Equipo>> Create(AlumnoDTO alumnoDTO)
        {
            var alumno = await _context.Alumno.FindAsync(alumnoDTO.Id);

            Equipo equipo = new ();

            equipo.Alumno = alumno;

            _context.Entry(equipo).State = EntityState.Unchanged;

            _context.Equipo.Add(equipo);
            await _context.SaveChangesAsync();

            return Ok();
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
            
            var alumno = await _context.Alumno.Include("Curso").Where(a => a.Id == equipoDTO.AlumnoId).FirstOrDefaultAsync();

            var equipo = await _context.Equipo.Include("Alumno").Include("Tutor").Include("Profesor").FirstOrDefaultAsync(e => e.Alumno.Id == alumno.Id);

            if (equipoDTO.Tutor != null)
            {
                var tutor = await _context.Tutor.FindAsync(equipoDTO.Tutor.Id);
                
            if (equipo.Tutor == null)
            {
                equipo.Tutor = tutor;
            }

            if (equipo.Tutor.Id != tutor.Id)
            {
                equipo.Tutor = tutor;
            }
            }
            
            equipoDTO.Id = equipo.Id;
            
            if(equipo == null)
            {
                return NotFound();
            }

            if (equipoDTO.Tutor == null)
            {
                equipo.Tutor = null;
            }

            _context.Entry(equipo).CurrentValues.SetValues(equipoDTO);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEquipo), new { id = equipo.Id }, _mapper.Map<EquipoDTO>(equipo));
        }

        [HttpPost("AsignarProfesor")]
        public async Task<ActionResult<EquipoDTO>> AsignarProfesor(EquipoDTO equipoDTO)
        {
            var alumno = await _context.Alumno.Include("Curso").Where(a => a.Id == equipoDTO.AlumnoId).FirstOrDefaultAsync();

            var equipo = await _context.Equipo.Include("Alumno").Include("Tutor").Include("Profesor").FirstOrDefaultAsync(e => e.Alumno.Id == alumno.Id);

            if (equipoDTO.Profesor != null)
            {
                var profesor = await _context.Profesor.FindAsync(equipoDTO.Profesor.Id);

                if (equipo.Profesor == null)
                {
                    equipo.Profesor = profesor;
                }

                if (equipo.Profesor.Id != profesor.Id)
                {
                    equipo.Profesor = profesor;
                }
            }

            equipoDTO.Id = equipo.Id;

            if (equipo == null)
            {
                return NotFound();
            }

            if (equipoDTO.Profesor == null)
            {
                equipo.Profesor = null;
            }

            _context.Entry(equipo).CurrentValues.SetValues(equipoDTO);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEquipo), new { id = equipo.Id }, _mapper.Map<EquipoDTO>(equipo));
        }

    }
}
