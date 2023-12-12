using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranHuuTri.Assignment02.Repositories.Entities;

namespace TranHuuTri.Assignment02.Repositories.Repositories
{
    public class BookAuthorRepository : GenericRepository<BookAuthor>, IBookAuthorRepository
    {
        public BookAuthorRepository(EBookStoreContext context) : base(context)
        {
        }

        public IQueryable<BookAuthor> GetAllBookAuthors()
        {
            return _context.BookAuthors
                .Include(b => b.Book)
                .Include(a => a.Author);
        }

        public IEnumerable<BookAuthor> GetBookAuthorsByAuthorId(int authorId)
        {
            return _context.BookAuthors
                .Include(b => b.Book)
                .Include(a => a.Author)
                .Where(auth => auth.AuthorId == authorId);
        }

        public IEnumerable<BookAuthor> GetBookAuthorsByBookId(int bookId)
        {
            return _context.BookAuthors
                .Include(b => b.Book)
                .Include(a => a.Author)
                .Where(bk => bk.BookId == bookId);
        }
    }
}
