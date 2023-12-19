using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
  public class BookAccess
  {
    public int BookId { get; set; }
    public int UserId { get; set; }
    public bool IsLocked { get; set; }
  }
}
