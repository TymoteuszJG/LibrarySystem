using DataLibrary.Models;
using System;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Queries
{

    public record GetBooksByAuthors(int authorId) : IRequest<List<Books>>;
}

