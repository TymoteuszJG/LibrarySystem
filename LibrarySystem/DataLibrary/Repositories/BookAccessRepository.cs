using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Repositories
{
  /*
  public class BookAccessRepository : IBookAccessRepository
  {
    private readonly Dictionary<int, BookAccess> _bookAccessState = new Dictionary<int, BookAccess>();

    public bool TryLockBook(int bookId, int userId)
    {
      if (_bookAccessState.TryGetValue(bookId, out var currentAccess) && currentAccess.IsLocked)
      {
        // Book is already locked
        return false;
      }

      // Lock the book
  
       _bookAccessState[bookId] = new BookAccess { BookId = bookId, UserId = userId, IsLocked = true };
      return true;
    }

    public void ReleaseBookLock(int bookId)
    {
      if (_bookAccessState.ContainsKey(bookId))
      {
        // Release the lock on the book
        _bookAccessState.Remove(bookId);
      }
    }
  }*/

  public class BookAccessRepository : IBookAccessRepository
  {
    private readonly Dictionary<int, List<BookAccess>> _bookAccessState = new Dictionary<int, List<BookAccess>>();

    public bool TryLockBook(int bookId, int userId)
    {
      if (!_bookAccessState.TryGetValue(bookId, out var accessList))
      {
        // If the book is not in the dictionary, create a new entry
        accessList = new List<BookAccess>();
        _bookAccessState[bookId] = accessList;
      }

      // Check if any user is already accessing the book
      if (accessList.Any(access => access.IsLocked))
      {
        // Book is already locked
        return false;
      }

      // Lock the book for the current user
      accessList.Add(new BookAccess { BookId = bookId, UserId = userId, IsLocked = true });
      return true;
    }

    public void ReleaseBookLock(int bookId)
    {
      if (_bookAccessState.TryGetValue(bookId, out var accessList))
      {
        // Release the lock on the book for all users
        accessList.RemoveAll(access => access.IsLocked);
      }
    }
  }
}
