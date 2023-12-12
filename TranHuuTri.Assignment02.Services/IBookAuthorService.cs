using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranHuuTri.Assignment02.Repositories.Entities;

namespace TranHuuTri.Assignment02.Services
{
    public interface IBookAuthorService
    {
        IQueryable<BookAuthor> GetAllBookAuthors();
        IEnumerable<BookAuthor> GetBookAuthorsByBookId(int bookId);
        IEnumerable<BookAuthor> GetBookAuthorsByAuthorId(int authorId);
    }
}
