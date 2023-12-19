using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Commands
{
  public class LockBookCommand : IRequest<bool>
  {
    public int BookId { get; set; }
    public int UserId { get; set; }
  }
}
