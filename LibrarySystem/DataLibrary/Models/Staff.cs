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
        public bool Admin { get; set; }
        public string Password { get; set; }
        public Staff() { }
        public Staff( bool admin, string password)
        {
            Admin = admin;
            Password = password;
        }
    }
}
