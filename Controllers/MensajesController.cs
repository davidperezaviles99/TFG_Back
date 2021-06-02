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
    public class MensajesController : Controller
    {
        private readonly TFG_BackContext _context;
        private readonly IMapper _mapper;

        public MensajesController(TFG_BackContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Mensajes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mensaje>>> GetMensaje()
        {
            return await _context.Mensaje.Include("Equipo").Include("User").ToListAsync();

        }

        [HttpGet("getUserMensaje/{id}")]
        public async Task<ActionResult<IEnumerable<MensajeDTO>>> GetUserMensaje(long id)
        {
            var mensajeList = await _context.Mensaje.Include("User").Include("Equipo").ToListAsync();

            foreach(Mensaje mensaje in mensajeList)
            {
                mensaje.User = await _context.User.FirstOrDefaultAsync(u => u.Id == mensaje.User.Id);
                //diario.Equipo = await _context.Equipo.Include("Alumno").Include("Tutor").Include("Profesor").FirstOrDefaultAsync(e => e.Id == diario.Equipo.Id);
            }

            var mensajes = mensajeList.FindAll(m => m.User.Id == id);

            var mensajesDTO = _mapper.Map<List<MensajeDTO>>(mensajes);

            return mensajesDTO;
        }


        [HttpGet("getEquipoMensaje/{id}")]
        public async Task<ActionResult<IEnumerable<MensajeDTO>>> GetEquipoMensaje(long id)
        {
            var mensajedb = await _context.Mensaje.Include("User").Include("Equipo").FirstOrDefaultAsync(o => o.Equipo.Id == id);

            if (mensajedb == null)
            {
                return NotFound();
            }

            var MensajeDB = await _context.Mensaje.Include("User").Include("Equipo").ToListAsync();

            var MensajeList = MensajeDB.FindAll(o => o.Equipo.Id == id);

            foreach (Mensaje mensaje in MensajeList)
            {

                mensaje.User = await _context.User.FirstOrDefaultAsync(u => u.Id == mensaje.User.Id);
                mensaje.Equipo = await _context.Equipo.Include("Alumno").Include("Tutor").Include("Profesor").FirstOrDefaultAsync(e => e.Id == mensaje.Equipo.Id);

            }

            return _mapper.Map<List<MensajeDTO>>(MensajeList);

        }

        // GET: api/Mensajes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MensajeDTO>> GetMensaje(long id)
        {
            var mensaje = await _context.Mensaje.Include("Equipo").Include("User").FirstOrDefaultAsync(u => u.Id == id);

            var mensajeDTO = _mapper.Map<MensajeDTO>(mensaje);

            if (mensaje == null)
            {
                return NotFound();
            }

            return mensajeDTO;
        }

        // PUT: api/Mensajes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Comentario")] MensajeDTO mensajeDTO)
        {
            var MensajeDTO = await _context.Mensaje.Include("Equipo").Include("User").FirstOrDefaultAsync(u => u.Id == mensajeDTO.Id);

            if (MensajeDTO == null)
            {
                return NotFound();
            }

            _context.Entry(MensajeDTO).CurrentValues.SetValues(mensajeDTO);

            try
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetMensaje), new { id = mensajeDTO.Id }, mensajeDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MensajeExists(mensajeDTO.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Mensajes/create
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("create")]
        public async Task<ActionResult<MensajeDTO>> Create([Bind("Id,Comentario")] MensajeDTO mensajeDTO)
        {
            var user = await _context.User.FindAsync(mensajeDTO.UserId);

            var mensaje = _mapper.Map<Mensaje>(mensajeDTO);

            mensaje.User = user;

            _context.Entry(mensaje).State = EntityState.Added;
            _context.Entry(user).State = EntityState.Unchanged;

            _context.Mensaje.Add(mensaje);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMensaje), new { id = mensaje.Id }, _mapper.Map<MensajeDTO>(mensaje));
        }

        // DELETE: api/Mensajes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMensaje(long id)
        {
            var mensaje = await _context.Mensaje.FindAsync(id);
            if (mensaje == null)
            {
                return NotFound();
            }

            _context.Mensaje.Remove(mensaje);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool MensajeExists(long id)
        {
            return _context.Mensaje.Any(e => e.Id == id);
        }
    }
}
