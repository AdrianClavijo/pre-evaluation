using DevTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevTest.Controllers
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            return await _dbcontext.Users.ToListAsync();
        }

        [HttpGet("/{IdUser}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUser(int IdUser)
        {
            var users = await _dbcontext.Users.FindAsync(IdUser);
            if (users == null || object.ReferenceEquals(null, users))
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpGet("/Username/{Username}")]
        public ActionResult<List<User>> GetUserId(string Username)
        {
            var users = _dbcontext.Users.Where(user => user.Username.Equals(Username)).ToList();
            if (users == null || object.ReferenceEquals(null, users))
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<User>> SaveUser([FromBody] User user)
        {
            if (UserExist(user.Username))
            {
                return BadRequest("Username Already Exists");
            }
            _dbcontext.Users.Add(user);
            await _dbcontext.SaveChangesAsync();
            return Created("", user);
        }

        [HttpPut("/{IdUser}")]
        public async Task<IActionResult> UpdateUser(int IdUser, User user)
        {
            if (IdUser != user.IdUser)
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

        [HttpDelete("/{IdUser}")]
        public async Task<ActionResult<User>> DeleteUser(int IdUser)
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
        public ActionResult<List<User>> Login(string username, string password)
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