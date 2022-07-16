
using Contacts.Models;

namespace Contacts.Repository
{
    public interface IUserRepository : BasicRepository<Users, long> 
    { 
        Users FindByCode(string code);
    }
}