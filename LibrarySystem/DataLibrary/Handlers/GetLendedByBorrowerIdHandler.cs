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

  public class GetLendedByBorrowerIdHandler : IRequestHandler<GetLendedByBorrowerId, List<Lended>>
  {
    private readonly ILendedRepository _lendedRepository;
    public GetLendedByBorrowerIdHandler(ILendedRepository lendedRepository)
    {
      _lendedRepository = lendedRepository;
    }
    public async Task<List<Lended>> Handle(GetLendedByBorrowerId request, CancellationToken cancellationToken)
    {
      var result = _lendedRepository.GetLendedByBorrowerId(request.borrowerId);
      return result;
    }
  }
}
