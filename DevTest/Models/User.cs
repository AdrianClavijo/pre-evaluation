using System;
using System.Collections.Generic;

namespace DevTest.Models
{
    public partial class User
    {
        public int IdUser { get; set; }
        public string FullName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public Guid TempCode { get; set; }
    }
}
