using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Repositories
{
    public class BookRepository : IBooksRepository
    {
        private readonly DatabaseContext _context;
        public BookRepository(DatabaseContext context)
        {
            _context = context;
        }
        public Books AddBook(Books book)
        {
            _context.Add(book);
            _context.SaveChanges();
            return book;
        }

        public List<Books> GetAllBooks()
        {
            var results = _context.Books.ToList();
            return results;
        }

        public List<Books> GetBooksByAuthors(int authorId)
        {
            var result = _context.Books.Where(x => x.AuthorsId == authorId).ToList();
            return result;
        }

        public Books GetBooksById(int bookId)
        {
            var result = _context.Books.FirstOrDefault
       (x => x.BooksId == bookId);
            return result;
        }

        public Books ReserveBook(int bookId, int borrowerId)
        {
            var result = _context.Books.FirstOrDefault
        (x => x.BooksId == bookId);
            if (result == null) return null;
            result.Availability = false;
            DateTime dueDate = DateTime.Now.AddMonths(3);
            Lended newLend = new Lended(borrowerId,bookId,dueDate);


            _context.Lended.Add(newLend);
            _context.SaveChanges();
            return result; 
        }

        public Books ReturnBook(int bookId, int borrowerId)
        {
            var result = _context.Books.FirstOrDefault
        (x => x.BooksId == bookId);
      result.Availability = true;
            var result2 = _context.Lended.FirstOrDefault
           (x => x.BooksId == bookId && x.BorrowersId == borrowerId);


            _context.Lended.Remove(result2);
            _context.SaveChanges();
            return result;
        }
    }


}
