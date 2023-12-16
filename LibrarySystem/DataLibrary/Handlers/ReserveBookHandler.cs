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

    public class ReserveBookHandler : IRequestHandler<ReserveBook, Books>
    {
        private readonly IBooksRepository _booksRepository;

        public ReserveBookHandler(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }
        public async Task<Books> Handle(ReserveBook request, CancellationToken cancellationToken)
        {
            var result = _booksRepository.ReserveBook(request.bookId,request.borrowerId);
            return result;
        }
    }
}
