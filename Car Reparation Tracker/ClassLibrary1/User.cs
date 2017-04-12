using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRT.Models
{
    public class User
    {
        public int userId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
