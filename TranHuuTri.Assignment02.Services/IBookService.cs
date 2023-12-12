using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranHuuTri.Assignment02.Repositories.Entities;
using TranHuuTri.Assignment02.Repositories.RequestFeatures;

namespace TranHuuTri.Assignment02.Services
{
    public interface IBookService
    {
        IQueryable<Book> GetAllBooks(BookParameters bookParameters);
        Book GetBookById(int id);
        IQueryable<Book> GetBooksByPublisherId(int publisherId);
        void CreateBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
    }
}
