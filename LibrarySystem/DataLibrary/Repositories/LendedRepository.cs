using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Repositories
{

  public class LendedRepository : ILendedRepository
  {
    private readonly DatabaseContext _context;
    public LendedRepository(DatabaseContext context)
    {
      _context = context;
    }
   


    public List<Lended> GetLendedByBorrowerId(int borrowerId)
    {
      var result = _context.Lended.Where(x => x.BorrowersId == borrowerId).ToList();
      return result;
    }
  }
}
