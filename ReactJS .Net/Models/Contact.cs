using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Contacts.Models
{
    [Table("Contacts")]
    public partial class Contact
    {
        public int IdContact { get; set; }
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
