using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranHuuTri.Assignment02.Repositories.Entities;
using TranHuuTri.Assignment02.Repositories.RequestFeatures;

namespace TranHuuTri.Assignment02.Repositories.Repositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(EBookStoreContext context) : base(context)
        {
        }

        public IQueryable<Author> GetAll(AuthorParameters authorParameters)
        {
            var authors = _context.Authors
                .OrderByDescending(i => i.Id)
                .SearchAuthor(authorParameters.SearchTerm);
            var count = authors.Count();
            return PagedList<Author>
                .ToPagedList(authors, count, authorParameters.PageNumber, authorParameters.PageSize)
                .AsQueryable();
        }
    }
}
