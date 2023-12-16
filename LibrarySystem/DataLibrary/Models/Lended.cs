using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class Lended
    {
        [Key]
        public int LendedId { get; set; }
        public int BorrowersId { get; set; }
        public int BooksId { get; set; }
        public DateTime DueDate { get; set; }
        public Lended()
        {
        }

        // Additional constructor with parameters
        public Lended(int borrowersId, int booksId, DateTime dueDate)
        {
            BorrowersId = borrowersId;
            BooksId = booksId;
            DueDate = dueDate;
        }
    }
}
