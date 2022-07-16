using System;
using System.Collections.Generic;

namespace DevTest.Models
{
    public partial class Contact
    {
        public int IdContact { get; set; }
        public int IdUser { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
