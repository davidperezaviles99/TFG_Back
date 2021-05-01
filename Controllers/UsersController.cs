using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TFG_Back.Data;
using TFG_Back.Models;
using System.Net.Http;
using System.Net;
using TFG_Back.DTOs;
using TFG_Back.Helpers;
using AutoMapper;

namespace TFG_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly TFG_BackContext _context;
        private readonly IMapper _mapper;

        public UsersController(TFG_BackContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersDTO>>> GetUsers()
        {
            var users = await _context.User.ToListAsync();
            var usersDTO = _mapper.Map<List<UsersDTO>>(users);
            return usersDTO;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsersDTO>> GetUser(long id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var usersDTO = _mapper.Map<UsersDTO>(user);

            return usersDTO;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(long id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            var hashed = BCrypt.Net.BCrypt.HashPassword(user.Password, 10);
            user.Password = hashed;
            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users/create
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("create")]
        public async Task<HttpResponseMessage> CreateUser(User user)
        {

            var hashed = BCrypt.Net.BCrypt.HashPassword(user.Password, 10);
            user.Password = hashed;

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        // POST: api/Users/login
        [HttpPost("login")]
        public async Task<ActionResult<UsersDTO>> LoginUser(LoginDTO loginDTO)
        {
            var user = await _context.User.Where(u => u.Email == loginDTO.Email).FirstOrDefaultAsync();

            if (user == null)
            {
                return BadRequest();
            }

            if (BCrypt.Net.BCrypt.Verify(loginDTO.Password, user.Password))
            {
                var usersDTO = _mapper.Map<UsersDTO>(user);
                return usersDTO;
            }
            else
            {
                return Unauthorized();
            }

        }
    

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool UserExists(long id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
