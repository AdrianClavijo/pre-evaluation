using System;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Contacts.Models
{
    [Table("Users")]
    public partial class Users
    {
        public int IdUser { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid TempCode { get; set; }
    }
}
