using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Data
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Passwd { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
    }
}
