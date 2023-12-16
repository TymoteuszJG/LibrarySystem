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

    public class GetAuthorsHandler : IRequestHandler<GetAuthors, List<Authors>>
    {
        private readonly IAuthorsRepository _authorsRepository;
        public GetAuthorsHandler(IAuthorsRepository authorsRepository)
        {
            _authorsRepository = authorsRepository;
        }
        public async Task<List<Authors>> Handle(GetAuthors request, CancellationToken cancellationToken)
        {
            var result = _authorsRepository.GetAllAuthors();
            return result;
        }
    }
}
