using DataLibrary.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{

  public class BookAccessController : ControllerBase
  {
    private readonly IMediator _mediator;

    public BookAccessController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost("/lock")]
    public async Task<ActionResult<bool>> LockBook([FromBody] LockBookCommand command)
    {
      var result = await _mediator.Send(command);
      return Ok(result);
    }

    [HttpPost("/release")]
    public async Task<ActionResult> ReleaseBook([FromBody] ReleaseBookLock command)
    {
      await _mediator.Send(command);
      return NoContent();
    }
  }
}
