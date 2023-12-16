using DataLibrary.Commands;
using DataLibrary.Models;
using DataLibrary.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{

    public class BorrowerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BorrowerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("/AddBorrower")]
        public async Task<ActionResult> AddBorrower(Borrowers borrower)
        {
            var result = await _mediator.Send(new AddBorrower(borrower));
            return Ok(result);
        }
    }
}
