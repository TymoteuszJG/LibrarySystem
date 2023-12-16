using DataLibrary.Models;
using DataLibrary.Repositories;
using DataLibrary.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataLibrary.Handlers
{
    public class GetAllBooksHandler : IRequestHandler<GetAllBooks, List<Books>>
    {
        private readonly IBooksRepository _booksRepository;
        public GetAllBooksHandler(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }
        public async Task<List<Books>> Handle(GetAllBooks request, CancellationToken cancellationToken)
        {
            var result = _booksRepository.GetAllBooks();
            return result;
        }
    }
}
