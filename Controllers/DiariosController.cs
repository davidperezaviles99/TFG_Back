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
            //var diario = await _context.Diario.Include("Equipo").Include("Asignatura").Include("User").ToListAsync();

            var diario = await _context.Diario.ToListAsync();
            return diario;

        }

        // GET: api/Diarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DiarioDTO>> GetDiario(long id)
        {
            var diario = await _context.Diario.Include("Equipo").Include("Asignatura").Include("User").FirstOrDefaultAsync(d => d.Id == id);

            var diarioDTO = _mapper.Map<DiarioDTO>(diario);

            if (diario == null)
            {
                return NotFound();
            }

            return diarioDTO;

            //if (diario == null)
            // {
            //    return NotFound();
            //}

            //return diario;
        }

        [HttpGet("getUserDiario/{id}")]
        public async Task<ActionResult<IEnumerable<DiarioDTO>>> GetUserDiario(long id)
        {
            var diarioList = await _context.Diario.Include("User").Include("Equipo").Include("Asignatura").ToListAsync();

            foreach (Diario diario in diarioList)
            {
                 diario.User = await _context.User.FirstOrDefaultAsync(u => u.Id == diario.User.Id);
                 //diario.Equipo = await _context.Equipo.Include("Alumno").Include("Tutor").Include("Profesor").FirstOrDefaultAsync(e => e.Id == diario.Equipo.Id);
                 //diario.Asignatura = await _context.Asignatura.Include("Profesor").FirstOrDefaultAsync(a => a.Id == diario.Asignatura.Id);
            }

            var diarios = diarioList.FindAll(d => d.User.Id == id);
            
            var diariosdto = _mapper.Map<List<DiarioDTO>>(diarios);

            return diariosdto;

            // var diario = await _context.Diario.Include("Equipo").Include("Asignatura").Include("User").FirstOrDefaultAsync(u => u.User.Id == id);

            //if (diario == null)
            //{
            //    return NotFound();
            //}

            //return diario;
        }

        [HttpGet("getEquipoDiario/{id}")]
        public async Task<ActionResult<IEnumerable<DiarioDTO>>> GetEquipoDiario(long id)
        {
            var diariodb = await _context.Diario.Include("User").Include("Equipo").Include("Asignatura").FirstOrDefaultAsync(o => o.Equipo.Id == id);

            if (diariodb == null)
            {
                return NotFound();
            }

            var DiarioDB = await _context.Diario.Include("User").Include("Equipo").Include("Asignatura").ToListAsync();

            var DiarioList = DiarioDB.FindAll(o => o.Equipo.Id == id);

            foreach (Diario diario in DiarioList)
            {

                diario.User = await _context.User.FirstOrDefaultAsync(u => u.Id == diario.User.Id);
                diario.Equipo = await _context.Equipo.Include("Alumno").Include("Tutor").Include("Profesor").FirstOrDefaultAsync(e => e.Id == diario.Equipo.Id);
                diario.Asignatura = await _context.Asignatura.Include("Profesor").FirstOrDefaultAsync(a => a.Id == diario.Asignatura.Id);
            }

            return _mapper.Map<List<DiarioDTO>>(DiarioList);
        }


        // [HttpGet("getEquipoDiario/{id}")]
        //public async Task<ActionResult<Diario>> GetEquipoDiario(long id)
        //{
        //   var diario = await _context.Diario.Include("Equipo").Include("Asignatura").Include("User").FirstOrDefaultAsync(u => u.Equipo.Id == id);

        //  if (diario == null)
        // {
        //   return NotFound();
        // }

        // return diario;
        //}

        // PUT: api/Diarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Date,Horas,Descripcion,Link,EvaluacionT,EvaluacionP")] DiarioDTO diarioDTO)
        {
            var DiarioDTO = await _context.Diario.Include("Equipo").Include("Asignatura").Include("User").FirstOrDefaultAsync(u => u.Id == diarioDTO.Id);

            var asignatura = await _context.Asignatura.FindAsync(diarioDTO.Asignatura.Id);

            if (DiarioDTO == null)
            {
                return NotFound();
            }

            DiarioDTO.Asignatura = asignatura;

            _context.Entry(DiarioDTO).CurrentValues.SetValues(diarioDTO);

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
        public async Task<ActionResult<DiarioDTO>> Create([Bind("Id,Date,Horas,Descripcion,Link,EvaluacionT,EvaluacionP")] DiarioDTO diarioDTO)
        {
            var user = await _context.User.FindAsync(diarioDTO.UserId);

            var diario = _mapper.Map<Diario>(diarioDTO);

            diario.User = user;

            _context.Entry(diario).State = EntityState.Added;
            _context.Entry(user).State = EntityState.Unchanged;

            _context.Diario.Add(diario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDiario), new { id = diario.Id }, _mapper.Map<DiarioDTO>(diario));
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
