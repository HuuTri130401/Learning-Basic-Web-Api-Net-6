using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranHuuTri.Assignment02.Repositories.Entities;
using TranHuuTri.Assignment02.Repositories.RequestFeatures;

namespace TranHuuTri.Assignment02.Repositories.Repositories
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Book GetBookById(int id);
        IQueryable<Book> GetBooksByPublisherId(int publisherId);
        IQueryable<Book> GetAllBooks(BookParameters bookParameters);
    }
}
