using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranHuuTri.Assignment02.Repositories.Entities;
using TranHuuTri.Assignment02.Repositories.Repositories;

namespace TranHuuTri.Assignment02.Services
{
    public class BookAuthorService : IBookAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookAuthorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IQueryable<BookAuthor> GetAllBookAuthors()
        {
            return _unitOfWork.BookAuthorRepository.GetAllBookAuthors();
        }

        public IEnumerable<BookAuthor> GetBookAuthorsByAuthorId(int authorId)
        {
            return _unitOfWork.BookAuthorRepository.GetBookAuthorsByAuthorId(authorId);
        }

        public IEnumerable<BookAuthor> GetBookAuthorsByBookId(int bookId)
        {
            return _unitOfWork.BookAuthorRepository.GetBookAuthorsByBookId(bookId);
        }
    }
}
