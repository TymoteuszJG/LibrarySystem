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

    public class GetStaffHandler : IRequestHandler<GetStaff, List<Staff>>
    {
        private readonly IStaffRepository _staffRepository;
        public GetStaffHandler(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }
        public async Task<List<Staff>> Handle(GetStaff request, CancellationToken cancellationToken)
        {
            var result = _staffRepository.GetStaff();
            return result;
        }
    }
}
