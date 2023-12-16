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
 
    public class GetBooksByAuthrosHandler : IRequestHandler<GetBooksByAuthors, List<Books>>
    {
        private readonly IBooksRepository _booksRepository;
        public GetBooksByAuthrosHandler(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }
        public async Task<List<Books>> Handle(GetBooksByAuthors request, CancellationToken cancellationToken)
        {
            var result = _booksRepository.GetBooksByAuthors(request.authorId);
            return result;
        }
    }
}
