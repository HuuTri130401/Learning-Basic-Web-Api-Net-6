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
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateAuthor(Author author)
        {
            _unitOfWork.AuthorRepository.Add(author);
        }

        public void DeleteAuthor(int id)
        {
            Author author = _unitOfWork.AuthorRepository.GetById(id);
            if(author != null)
            {
                author.State = 0;
                _unitOfWork.AuthorRepository.Update(author);
            }
        }

        public IEnumerable<Author> GetAllAuthors(AuthorParameters authorParameters)
        {
            return _unitOfWork.AuthorRepository.GetAll(authorParameters);
        }

        public Author GetAuthorById(int id)
        {
            return _unitOfWork.AuthorRepository.GetById(id);
        }

        public void UpdateAuthor(Author author)
        {
            _unitOfWork.AuthorRepository.Update(author);
        }
    }
}
