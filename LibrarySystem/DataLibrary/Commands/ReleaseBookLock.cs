using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Commands
{

 // public record ReleaseBookLock(int BookId) : IRequest
 // {
   // public int BookId { get; set; }
 // }
  public class ReleaseBookLock : IRequest<Unit>
  {
    public int BookId { get; set; }
  }
}
