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
  public class LockBookHandler : IRequestHandler<LockBookCommand, bool>
  {
    private readonly IBookAccessRepository _bookAccessRepository;

    public LockBookHandler(IBookAccessRepository bookAccessRepository)
    {
      _bookAccessRepository = bookAccessRepository;
    }

    public async Task<bool> Handle(LockBookCommand request, CancellationToken cancellationToken)
    {
      return _bookAccessRepository.TryLockBook(request.BookId, request.UserId);
    }
  }
}
