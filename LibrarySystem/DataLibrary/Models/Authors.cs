using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class Authors
    {
        [Key]
        public int AuthorsId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Authors( string name, string surname)
        {    
            Name = name;
            Surname = surname;
        }
        public Authors() { }
    }
}
