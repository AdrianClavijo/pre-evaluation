using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Contacts.Models
{
    [Table("Users")]
    public partial class Users
    {
        [Key]
        public int IdUser { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public Guid TempCode { get; set; }
    }
}
