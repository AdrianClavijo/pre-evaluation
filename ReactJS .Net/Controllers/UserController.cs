using Contacts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DB_DevTestContext _dbcontext;

        public UserController(DB_DevTestContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet("/users")]
        public async Task<ActionResult<IEnumerable<Users>>> GetAllUsers()
        {
            return await _dbcontext.Users.ToListAsync();
        }

        [HttpGet("/users/{IdUser}")]
        public async Task<ActionResult<IEnumerable<Users>>> GetUser(int IdUser)
        {
            var users = await _dbcontext.Users.FindAsync(IdUser);
            if (users == null || object.ReferenceEquals(null,users))
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpGet("/users/{Username}/Username")]
        public ActionResult<List<Users>> GetUserId(string Username)
        {
            var users =  _dbcontext.Users.Where(user => user.Username.Equals(Username)).ToList();
            if (users == null || object.ReferenceEquals(null, users))
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpPost("/users")]
        public async Task<ActionResult<Users>> SaveUser([FromBody]Users user)
        {
            if (UserExist(user.Username))
            {
                return BadRequest("Username Already Exists");
            }
            _dbcontext.Users.Add(user);
            await _dbcontext.SaveChangesAsync();
            return Created("",user);
        }

        [HttpPut("/users/{IdUser}")]
        public async Task<IActionResult> UpdateUser(int IdUser,Users user)
        {
            if (IdUser !=user.IdUser)
            {
                return BadRequest();
            }
            _dbcontext.Entry(user).State = EntityState.Modified;
            try
            {
                await _dbcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IdUserExist(IdUser))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(user);
        }

        [HttpDelete("/users/{IdUser}")]
        public async Task<ActionResult<Users>> DeleteUser(int IdUser)  
        {
            var users = await _dbcontext.Users.FindAsync(IdUser);
            if (users == null || object.ReferenceEquals(null, users))
            {
                return NotFound();
            }
            _dbcontext.Users.Remove(users);
            await _dbcontext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("{username}/{password}")]
        public ActionResult<List<Users>> Login (string username,string password)
        {
            var users = _dbcontext.Users.Where(user => user.Username.Equals(username) && user.Password.Equals(password)).ToList();
            if (users == null || object.ReferenceEquals(null, users))
            {
                return NotFound();
            }
            return Ok(users);
        }

        private bool IdUserExist(int IdUser)
        {
            return _dbcontext.Users.Any(e => e.IdUser == IdUser);
        }
        private bool UserExist(string Username)
        {
            return _dbcontext.Users.Any(e => e.Username == Username);
        }
    }
}
