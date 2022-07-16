using DevTest.Models;
using Microsoft.EntityFrameworkCore;

namespace DevTest.Services
{
    public class ContactService : IContact
    {
        /*
        private readonly DB_DevTestContext _context;

        public ContactService(DB_DevTestContext context)
        {
            _context = context;
        }

        public async Task<List<Contact>> GetByEmail(string Email)
        {
            return await _context.Contacts.ToListAsync();
        }
        public async Task SaveContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
        }     
        */
    }
}
