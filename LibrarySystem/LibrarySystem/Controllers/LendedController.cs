using DataLibrary.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{
  public class LendedController : ControllerBase
  {
    private readonly IMediator _mediator;
    public LendedController(IMediator mediator)
    {
      _mediator = mediator;
    }
    [HttpGet("/GetLendedByBorrowerId")]
    public async Task<ActionResult> GetLendedByBorrowerId(int borrowerId)
    {
      var result = await _mediator.Send(new GetLendedByBorrowerId(borrowerId));
      return Ok(result);
    }
  }

 
  

  
}
