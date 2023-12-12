using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranHuuTri.Assignment02.Repositories.Entities;
using TranHuuTri.Assignment02.Repositories.RequestFeatures;

namespace TranHuuTri.Assignment02.Repositories.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(EBookStoreContext context) : base(context)
        {
        }
        public IQueryable<Book> GetBooksByPublisherId(int publisherId)
        {
            return _context.Books
                .Include(pub => pub.Pub)
                .Where(p => p.PubId == publisherId);
        }
        public IQueryable<Book> GetAllBooks(BookParameters bookParameters)
        {
            //return _context.Books.Include(p => p.Pub);
            var books = _context.Books
                .SearchBook(bookParameters.SearchTerm)
                .OrderByDescending(i => i.Id)
                .Include(p => p.Pub);
            var count = books.Count();
            return PagedList<Book>
                .ToPagedList(books, count, bookParameters.PageNumber, bookParameters.PageSize)
                .AsQueryable();
        }

        public Book GetBookById(int bookId)
        {
            var book = _context.Books
                .Include(pub => pub.Pub)
                .FirstOrDefault(p => p.Id == bookId);
            return book;
        }
    }
}
