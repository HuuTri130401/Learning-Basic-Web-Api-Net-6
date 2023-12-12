using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranHuuTri.Assignment02.Repositories.Entities;
using TranHuuTri.Assignment02.Repositories.RequestFeatures;

namespace TranHuuTri.Assignment02.Services
{
    public interface IAuthorService
    {
        IEnumerable<Author> GetAllAuthors(AuthorParameters authorParameters);
        Author GetAuthorById(int id);
        //IEnumerable<Author> GetAuthorsByCategoryId(int categoryId);
        void CreateAuthor(Author author);
        void UpdateAuthor(Author author);
        void DeleteAuthor(int id);
    }
}
