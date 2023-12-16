using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class Books
    {
        [Key]
        public int BooksId { get; set; }
        public string BookName { get; set; }
        public int AuthorsId { get; set; }
        public int PublicationYear { get; set; }
        public bool Availability { get; set; }
        public Books( string bookName, int authorsId, int publicationYear, bool availability)
        {
            BookName = bookName;
            AuthorsId = authorsId;
            PublicationYear = publicationYear;
            Availability = availability;
        }
        public Books() { }
    }
}
