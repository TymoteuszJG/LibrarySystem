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
    public class AddBorrowerHandler : IRequestHandler<AddBorrower, Borrowers>
    {
        private readonly IBorrowersRepository _borrowersRepository;

        public AddBorrowerHandler(IBorrowersRepository borrowersRepository)
        {
            _borrowersRepository = borrowersRepository;
        }
        public async Task<Borrowers> Handle(AddBorrower request, CancellationToken cancellationToken)
        {
            var result = _borrowersRepository.AddBorrowers(request.borrower);
            return result;
        }
    }
}
