using DataLibrary.Models;
using DataLibrary.Queries;
using DataLibrary.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Handlers
{
 
    public class GetBookByIdHandler : IRequestHandler<GetBookById, Books>
    {
        private readonly IBooksRepository _booksRepository;
        public GetBookByIdHandler(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }
        public async Task<Books> Handle(GetBookById request, CancellationToken cancellationToken)
        {
            var result = _booksRepository.GetBooksById(request.bookId);
            return result;
        }
    }
}
