using DevTest.Models;
using DevTest.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly DB_DevTestContext _dbcontext;
       // private readonly ContactService _contactservice;
        public ContactController(DB_DevTestContext dbcontext)
        {
            _dbcontext = dbcontext;
            //_contactservice = contactservice;
        }

        [HttpGet("/IdUser/IdContact/{IdUser}")]
        public ActionResult<List<User>> GetAllContacts(int IdUser)
        {
            List<Contact> Contact = _dbcontext.Contacts.Where(Contact => Contact.IdUser.Equals(IdUser)).ToList();
            if (Contact == null || object.ReferenceEquals(null, Contact))
            {
                return NotFound();
            }
            return Ok(Contact);
        }

        [HttpGet("/IdContact/{IdContact}")]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContact(int IdContact)
        {
            var Contact = await _dbcontext.Contacts.FindAsync(IdContact);
            if (Contact == null || object.ReferenceEquals(null, Contact))
            {
                return NotFound();
            }
            return Ok(Contact);
        }

        [HttpGet("/Email/{Email}")]
        public ActionResult<List<User>> GetByEmail(string Email)
        {
            Email = Email.Replace("%40","@");
            var Contact = _dbcontext.Contacts.Where(Contact => Contact.Email.Equals(Email)).ToList();
            
            if (Contact.Count == 0 || object.ReferenceEquals(null, Contact))
            {
                return NotFound();
            }
            return Ok(Contact);
        }

        [HttpPost("/Save")]
        public async Task<ActionResult<Contact>> SaveContact(Contact contact)
        {
            if (ContactExist(contact.Email))
            {
                return BadRequest("Email Already Exists");
            }
            _dbcontext.Contacts.Add(contact);
            await _dbcontext.SaveChangesAsync();
            return Created("", contact);
        }

        [HttpPut("/IdContact/{IdContact}")]
        public async Task<IActionResult> UpdateContact(int IdContact, Contact contact)
        {
            if (IdContact != contact.IdContact)
            {
                return BadRequest();
            }
            _dbcontext.Entry(contact).State = EntityState.Modified;
            try
            {
                await _dbcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IdContactExist(IdContact))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(contact);
        }

        [HttpDelete("/IdContact/{IdContact}")]
        public async Task<ActionResult<Contact>> DeleteContact(int IdContact)
        {
            var Contact = await _dbcontext.Contacts.FindAsync(IdContact);
            if (Contact == null || object.ReferenceEquals(null, Contact))
            {
                return NotFound();
            }
            _dbcontext.Contacts.Remove(Contact);
            await _dbcontext.SaveChangesAsync();

            return Ok();
        }
        private bool IdContactExist(int IdContact)
        {
            return _dbcontext.Contacts.Any(e => e.IdContact == IdContact);
        }
        private bool ContactExist(string Email)
        {
            return _dbcontext.Contacts.Any(e => e.Email == Email);
        }
    }
}
