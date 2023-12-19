using DataLibrary.Commands;
using DataLibrary.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Handlers
{

  public class ReleaseBookLockHandler : IRequestHandler<ReleaseBookLock, Unit>
  {
    private readonly IBookAccessRepository _bookAccessService;

    public ReleaseBookLockHandler(IBookAccessRepository bookAccessService)
    {
      _bookAccessService = bookAccessService;
    }

    public async Task<Unit> Handle(ReleaseBookLock request, CancellationToken cancellationToken)
    {
      _bookAccessService.ReleaseBookLock(request.BookId);
      return Unit.Value;
    }
  }
}
