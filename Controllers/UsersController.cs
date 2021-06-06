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
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TFG_Back.Auth;

namespace TFG_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly TFG_BackContext _context;
        private readonly IMapper _mapper;
        private readonly IJwtAuthenticationService _authService;

        public UsersController(TFG_BackContext context, IMapper mapper, IJwtAuthenticationService authService)
        {
            _context = context;
            _mapper = mapper;
            _authService = authService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var users = await _context.User.ToListAsync();
            var userDTO = _mapper.Map<List<UserDTO>>(users);
            return userDTO;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(long id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var userDTO = _mapper.Map<UserDTO>(user);

            return userDTO;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutUser(long id, UserDTO userDTO)
        {
            var UserDTO = await _context.User.FirstOrDefaultAsync(u => u.Id == userDTO.Id);

            if (UserDTO == null)
            {
                return NotFound();
            }

            _context.Entry(UserDTO).CurrentValues.SetValues(userDTO);

            try
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetUser), new { id = userDTO.Id }, userDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(userDTO.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
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

        //// POST: api/Users/login
        //[HttpPost("login")]
        //public async Task<ActionResult<UserDTO>> LoginUser(LoginDTO loginDTO)
        //{
        //    var user = await _context.User.Where(u => u.Email == loginDTO.Email).FirstOrDefaultAsync();

        //    if (user == null)
        //    {
        //        return BadRequest();
        //    }

        //    if (BCrypt.Net.BCrypt.Verify(loginDTO.Password, user.Password))
        //    {
        //        var userDTO = _mapper.Map<UserDTO>(user);
        //        return userDTO;
        //    }
        //    else
        //    {
        //        return Unauthorized();
        //    }
        //}

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Authenticate([FromBody] LoginDTO user)
        {
            var token = _authService.Authenticate(user.Email, user.Password);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
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
