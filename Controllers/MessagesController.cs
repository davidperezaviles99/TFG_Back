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
    public class MessagesController : Controller
    {
        private readonly TFG_BackContext _context;
        private readonly IMapper _mapper;

        public MessagesController(TFG_BackContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //[HttpGet("getUserMensaje/{id}")]
        //public async Task<ActionResult<IEnumerable<MensajeDTO>>> GetUserMensaje(long id)
        //{
        //    var mensajeList = await _context.Mensaje.Include("User").Include("Equipo").ToListAsync();

        //    foreach(Mensaje mensaje in mensajeList)
        //    {
        //        mensaje.User = await _context.User.FirstOrDefaultAsync(u => u.Id == mensaje.User.Id);
        //        //diario.Equipo = await _context.Equipo.Include("Alumno").Include("Tutor").Include("Profesor").FirstOrDefaultAsync(e => e.Id == diario.Equipo.Id);
        //    }

        //    var mensajes = mensajeList.FindAll(m => m.User.Id == id);

        //    var mensajesDTO = _mapper.Map<List<MensajeDTO>>(mensajes);

        //    return mensajesDTO;
        //}


        //[HttpGet("getEquipoMensaje/{id}")]
        //public async Task<ActionResult<IEnumerable<MensajeDTO>>> GetEquipoMensaje(long id)
        //{
        //    var mensajedb = await _context.Mensaje.Include("User").Include("Equipo").FirstOrDefaultAsync(o => o.Equipo.Id == id);

        //    if (mensajedb == null)
        //    {
        //        return NotFound();
        //    }

        //    var MensajeDB = await _context.Mensaje.Include("User").Include("Equipo").ToListAsync();

        //    var MensajeList = MensajeDB.FindAll(o => o.Equipo.Id == id);

        //    foreach (Mensaje mensaje in MensajeList)
        //    {

        //        mensaje.User = await _context.User.FirstOrDefaultAsync(u => u.Id == mensaje.User.Id);
        //        mensaje.Equipo = await _context.Equipo.Include("Alumno").Include("Tutor").Include("Profesor").FirstOrDefaultAsync(e => e.Id == mensaje.Equipo.Id);

        //    }

        //    return _mapper.Map<List<MensajeDTO>>(MensajeList);

        // GET: api/Messages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessages()
        {
            return await _context.Message.ToListAsync();
        }

        // GET: api/Messages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Message>> GetMessage(long id)
        {
            var message = await _context.Message.FindAsync(id);

            if (message == null)
            {
                return NotFound();
            }

            return message;
        }

        // PUT: api/Messages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessage(long id, Message message)
        {
            if (id != message.Id)
            {
                return BadRequest();
            }

            _context.Entry(message).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageExists(id))
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

        // POST: api/Messages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Message>> PostMessage(Message message)
        {
            _context.Message.Add(message);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMessage), new { id = message.Id }, message);
        }

        // DELETE: api/Messages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(long id)
        {
            var message = await _context.Message.FindAsync(id);
            if (message == null)
            {
                return NotFound();
            }

            _context.Message.Remove(message);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MessageExists(long id)
        {
            return _context.Message.Any(e => e.Id == id);
        }
    }
}
