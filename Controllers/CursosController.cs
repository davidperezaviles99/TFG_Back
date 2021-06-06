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
using AutoMapper;
using TFG_Back.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace TFG_Back.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : Controller
    {
        private readonly TFG_BackContext _context;
        private readonly IMapper _mapper;

        public CursosController(TFG_BackContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Cursos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> GetCurso()
        {
            var curso = await _context.Curso.Include("Asignatura").ToListAsync();

            return curso;
            
        }

        // GET: api/Cursos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetCurso(long id)
        {
            var curso = await _context.Curso.Include("Asignatura").FirstOrDefaultAsync(u => u.Id == id);

            if (curso == null)
            {
                return NotFound();
            }

            return curso;
        }

        // PUT: api/Cursos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> Edit(CursoDTO cursoDTO)
        {
            var CursoDTO = await _context.Curso.Include("Asignatura").FirstOrDefaultAsync(u => u.Id == cursoDTO.Id);

            var asignatura = await _context.Asignatura.FindAsync(cursoDTO.Asignatura.Id);

            if (CursoDTO == null)
            {
                return NotFound();
            }

            CursoDTO.Asignatura = asignatura;

            _context.Entry(CursoDTO).CurrentValues.SetValues(cursoDTO);

            try
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetCurso), new { id = cursoDTO.Id }, cursoDTO);

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursoExists(cursoDTO.Id))
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
        public async Task<HttpResponseMessage> Create([Bind("Id,Numero,Name")] CursoDTO cursoDTO)
        {
            var curso = _mapper.Map<Curso>(cursoDTO);

            _context.Entry(curso).State = EntityState.Unchanged;

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
