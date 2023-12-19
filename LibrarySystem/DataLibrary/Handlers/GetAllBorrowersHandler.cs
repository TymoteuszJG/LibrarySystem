using DataLibrary.Commands;
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

  public class GetAllBorrowersHandler : IRequestHandler<GetAllBorrowers, List<Borrowers>>
  {
    private readonly IBorrowersRepository _borrowersRepository;

    public GetAllBorrowersHandler(IBorrowersRepository borrowersRepository)
    {
      _borrowersRepository = borrowersRepository;
    }
    public async Task<List<Borrowers>> Handle(GetAllBorrowers request, CancellationToken cancellationToken)
    {
      var result = _borrowersRepository.GetAllBorrowers();
      return result;
    }
  }
}
