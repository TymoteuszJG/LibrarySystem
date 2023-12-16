using DataLibrary.Commands;
using DataLibrary.Models;
using DataLibrary.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Handlers
{

    public class AddBookHandler : IRequestHandler<AddBook, Books>
    {
        private readonly IBooksRepository _booksRepository;
        
        public AddBookHandler(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }
        public async Task<Books> Handle(AddBook request, CancellationToken cancellationToken)
        {
            var result = _booksRepository.AddBook(request.book);
            return result;
        }
    }
}
