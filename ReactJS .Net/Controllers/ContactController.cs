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
    public class ContactController : ControllerBase
    {
        private readonly DB_DevTestContext _dbcontext;

        public ContactController(DB_DevTestContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet("/contacts")]
        public async Task<ActionResult<IEnumerable<Contact>>> GetAllContacts()
        {
            return await _dbcontext.Contacts.ToListAsync();
        }

        [HttpGet("/contacts/{IdContact}")]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContact(int IdContact)
        {
            var Contact = await _dbcontext.Contacts.FindAsync(IdContact);
            if (Contact == null || object.ReferenceEquals(null, Contact))
            {
                return NotFound();
            }
            return Ok(Contact);
        }

        [HttpPost("/contacts")]
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

        [HttpPut("/contacts/{IdContact}")]
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

        [HttpDelete("/contacts/{IdContact}")]
        public async Task<ActionResult<Contact>> DeleteContact(int IdContact)
        {
            var Contact = await _dbcontext.Contacts.FindAsync(IdContact);
            if (Contact == null)
            {
                return NotFound();
            }
            _dbcontext.Contacts.Remove(Contact);
            try
            {
                await _dbcontext.SaveChangesAsync();
            }
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
