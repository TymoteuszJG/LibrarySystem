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

    public class ReturnBookHandler : IRequestHandler<ReturnBook, Books>
    {
        private readonly IBooksRepository _booksRepository;

        public ReturnBookHandler(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }
        public async Task<Books> Handle(ReturnBook request, CancellationToken cancellationToken)
        {
            var result = _booksRepository.ReturnBook(request.bookId, request.borrowerId);
            return result;
        }
    }
}
