using DataLibrary.Commands;
using DataLibrary.Models;
using DataLibrary.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("/GetAuthors")]
        public async Task<ActionResult> GetAuthors()
        {
            var result = await _mediator.Send(new GetAuthors());
            return Ok(result);
        }

    }
}
