
using Contacts.Models;
using System.Collections.Generic;

namespace Contacts.Repository
{ 
    public interface IContactRepository : BasicRepository<Models.Contact, long> 
    {
        Models.Contact FindByEmail(string email);

        IEnumerable<Models.Contact> FindByName(string name);
    }
}