using DataLibrary.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataLibrary.Queries
{

    public record GetBookById(int bookId) : IRequest<Books>;
}

