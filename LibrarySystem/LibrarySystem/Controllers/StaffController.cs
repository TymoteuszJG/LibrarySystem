using DataLibrary.Commands;
using DataLibrary.Models;
using DataLibrary.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{

    public class StaffController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StaffController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("/AddStaff")]
        public async Task<ActionResult> AddStaff(Staff staff)
        {
            var result = await _mediator.Send(new AddStaff(staff));
            return Ok(result);
        }
        [HttpGet("/GetStaff")]
        public async Task<ActionResult> GetStaff()
        {
            var result = await _mediator.Send(new GetStaff());
            return Ok(result);
        }
    }
}
