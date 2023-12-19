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

    public class AddStaffHandler : IRequestHandler<AddStaff, Boolean>
    {
        private readonly IStaffRepository _staffRepository;

        public AddStaffHandler(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }
        public async Task<Boolean> Handle(AddStaff request, CancellationToken cancellationToken)
        {
            var result = _staffRepository.AddStaff(request.staff);
            return result;
        }
    }
}
