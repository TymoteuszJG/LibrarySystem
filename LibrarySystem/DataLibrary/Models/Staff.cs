using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class Staff
    {
        [Key]
        public int Staff_ID { get; set; }
        public string Login { get; set; }
        public bool Admin { get; set; }
        public string Password { get; set; }
        public Staff() { }
        public Staff( string login,bool admin, string password)
        {
            Login = login;
            Admin = admin;
            Password = password;
        }
    }
}
