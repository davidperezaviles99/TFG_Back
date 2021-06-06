using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TFG_Back.Data;
using TFG_Back.DTOs;
using TFG_Back.Models;

namespace TFG_Back.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : Controller
    {
        private readonly TFG_BackContext _context;
        private readonly IMapper _mapper;

        public AlumnosController(TFG_BackContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Alumnos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alumno>>> GetAlumno()
        {
            return await _context.Alumno.Include("Curso").ToListAsync();

        }

        // GET: api/Alumnos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alumno>> GetAlumno(long id)
        {
            var alumno = await _context.Alumno.Include("Curso").FirstOrDefaultAsync(u => u.Id == id);

            if (alumno == null)
            {
                return NotFound();
            }

            return alumno;
        }

        // PUT: api/Alumnos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Lastname,Email,Role")] AlumnoDTO alumnoDTO)
        {
            var AlumnoDTO = await _context.Alumno.Include("Curso").FirstOrDefaultAsync(u => u.Id == alumnoDTO.Id);

            if (AlumnoDTO == null)
            {
                return NotFound();
            }

            _context.Entry(AlumnoDTO).CurrentValues.SetValues(alumnoDTO);

            try
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetAlumno), new { id = alumnoDTO.Id }, alumnoDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlumnoExists(alumnoDTO.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Alumnos/create
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("create")]
        public async Task<ActionResult<AlumnoDTO>> Create([Bind("Id,Name,Lastname,Email,Password,Role")] Alumno alumno)
        {

            var hashed = BCrypt.Net.BCrypt.HashPassword(alumno.Password, 10);
            alumno.Password = hashed;

            _context.Entry(alumno).State = EntityState.Unchanged;
            _context.Alumno.Add(alumno);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAlumno), new { id = alumno.Id }, _mapper.Map<AlumnoDTO>(alumno));
        }

        // DELETE: api/Alumnos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlumno(long id)
        {
            var alumno = await _context.Alumno.FindAsync(id);
            if (alumno == null)
            {
                return NotFound();
            }

            _context.Alumno.Remove(alumno);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool AlumnoExists(long id)
        {
            return _context.Alumno.Any(e => e.Id == id);
        }
    }
}
