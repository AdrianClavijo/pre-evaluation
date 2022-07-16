
using Contacts.Models;
using System.Collections.Generic;
using System.Linq;

namespace Contacts.Repository
{ 
    public class ContactRepository : IContactRepository
    {
        public ContactRepository() 
        {
        }

        public bool ExistsById(long id)
        {
            // TODO: Implement missing logic here
            return false;
        }

        public IEnumerable<Models.Contact> FindAll()
        {
            // TODO: Implement missing logic here
            return new List<Models.Contact>();
        }

        public Models.Contact FindByEmail(string email) 
        {
            // TODO: Implement missing logic here
            return null;
        }

        public Models.Contact FindById(long id)
        {
            // TODO: Implement missing logic here
            return null;
        }

        public Models.Contact Save(Models.Contact entity)
        {
            // TODO: Implement missing logic here
            return null;
        }

        public IEnumerable<Models.Contact> FindByName(string name) 
        {
            // TODO: Implement missing logic here
            return null;
        }        
    }
}