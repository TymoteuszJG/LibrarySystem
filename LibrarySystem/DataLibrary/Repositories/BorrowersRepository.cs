using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;



namespace DataLibrary.Repositories
{
    public class BorrowersRepository : IBorrowersRepository
    {
        private readonly DatabaseContext _context;
        public BorrowersRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Borrowers AddBorrowers(Borrowers borrowers)
        {
            _context.Borrowers.Add(borrowers);
            _context.SaveChanges();
            return borrowers;
        }


    }


}
