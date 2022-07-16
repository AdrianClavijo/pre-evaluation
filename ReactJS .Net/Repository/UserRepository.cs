using Contacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contacts.Repository
{
    public class UserRepository : IUserRepository
    {
        private HashSet<Users> allUsers;

        public UserRepository() 
        {
            allUsers = new HashSet<Users>();
        }

        public bool ExistsById(long id)
        {
            return allUsers.Any(x => x.IdUser == id);
        }

        Users IUserRepository.FindByCode(string code)
        {
            return allUsers.FirstOrDefault(x => x.TempCode.ToString().Substring(0, 6).Equals(code));
        }

        public IEnumerable<Users> FindAll()
        {
            return allUsers;
        }

        public Users FindById(long id)
        {
            return allUsers.FirstOrDefault(x => x.IdUser == id);
        }

        public Users Save(Users entity)
        {
            var existentUser = FindById(entity.IdUser);
            if (existentUser != null) 
            {
                allUsers.RemoveWhere(x => x.IdUser == entity.IdUser);                
            }
            else 
            {
                entity.IdUser = allUsers.Count + 1;
                entity.TempCode = Guid.NewGuid();
            }

            allUsers.Add(entity);

            return entity;
        }

        
    }
}