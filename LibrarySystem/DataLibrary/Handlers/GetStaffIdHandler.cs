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

  public class GetStaffIdHandler : IRequestHandler<GetStaffId, int>
  {
    private readonly IStaffRepository _staffRepository;
    public GetStaffIdHandler(IStaffRepository staffRepository)
    {
      _staffRepository = staffRepository;
    }
    public async Task<int> Handle(GetStaffId request, CancellationToken cancellationToken)
    {
      var result = _staffRepository.GetStaffId(request.login, request.password);
      return result;
    }
  }
}
