using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    

namespace DataLibrary.Repositories
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly DatabaseContext _context;
        public AuthorsRepository(DatabaseContext context)
        {
            _context = context;
        }

        public List<Authors> GetAllAuthors()
        {
            var results = _context.Authors.ToList();
            return results;
        }



    }


}
