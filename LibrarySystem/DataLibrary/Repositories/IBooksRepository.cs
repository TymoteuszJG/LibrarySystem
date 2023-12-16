
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Repositories
{
    public interface IBooksRepository
    {
        public Books ReserveBook(int bookId, int borrowerId);
        public Books ReturnBook(int bookId, int borrowerId);
        Books GetBooksById(int bookId);
        Books AddBook(Books book);
        List<Books> GetAllBooks();
        List<Books> GetBooksByAuthors(int authorId);
    }
}
