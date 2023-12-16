using DataLibrary.Commands;
using DataLibrary.Models;
using DataLibrary.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Exam_App.Controllers
{
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("/GetAllBooks")]
        public async Task<ActionResult> GetAllBooks()
        {
            var result = await _mediator.Send(new GetAllBooks());
            return Ok(result);
        }
        [HttpGet("/GetBookById")]
        public async Task<ActionResult> GetBookById(int bookId)
        {
            var result = await _mediator.Send(new GetBookById(bookId));
            return Ok(result);
        }
        [HttpGet("/GetBookByAuthors")]
        public async Task<ActionResult> GetBooksByAuthors(int authorId)
        {
            var result = await _mediator.Send(new GetBooksByAuthors(authorId));
            return Ok(result);
        }
        [HttpGet("/AddBook")]
        public async Task<ActionResult> AddBook(Books book)
        {
            var result = await _mediator.Send(new AddBook(book));
            return Ok(result);
        }
        [HttpGet("/ReserveBook")]
        public async Task<ActionResult> ReserveBook(int bookId, int borrowerId)
        {
            var result = await _mediator.Send(new ReserveBook(bookId,borrowerId));
            return Ok(result);
        }
        [HttpGet("/ReturnBook")]
        public async Task<ActionResult> ReturnBook(int bookId, int borrowerId)
        {
            var result = await _mediator.Send(new ReturnBook(bookId, borrowerId));
            return Ok(result);
        }

    }
}

