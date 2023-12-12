using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranHuuTri.Assignment02.Repositories.Entities;
using TranHuuTri.Assignment02.Repositories.Repositories;
using TranHuuTri.Assignment02.Repositories.RequestFeatures;

namespace TranHuuTri.Assignment02.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateBook(Book book)
        {
            _unitOfWork.BookRepository.Add(book);
        }

        public void DeleteBook(int id)
        {
            Book book = _unitOfWork.BookRepository.GetById(id);
            if(book != null)
            {
                book.Status = 0;
                _unitOfWork.BookRepository.Update(book);
            }
        }

        public void UpdateBook(Book book)
        {
            _unitOfWork.BookRepository.Update(book);
        }

        public IQueryable<Book> GetAllBooks(BookParameters bookParameters)
        {
            return _unitOfWork.BookRepository.GetAllBooks(bookParameters);
        }

        public Book GetBookById(int id)
        {
            return _unitOfWork.BookRepository.GetBookById(id);
        }

        public IQueryable<Book> GetBooksByPublisherId(int publisherId)
        {
            return _unitOfWork.BookRepository.GetBooksByPublisherId(publisherId);
        }
    }
}
