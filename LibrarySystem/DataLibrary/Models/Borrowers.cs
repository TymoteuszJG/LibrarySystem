using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class Borrowers
    {
        [Key]
        public int BorrowersId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public Borrowers()
        {
        }

        // Additional constructor with parameters
        public Borrowers(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
        public Borrowers(string name, string surname, string contactNumber, string email)
        {
            Name = name;
            Surname = surname;
            ContactNumber = contactNumber;
            Email = email;

        }
    }
}
