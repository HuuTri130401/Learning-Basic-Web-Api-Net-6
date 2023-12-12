using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranHuuTri.Assignment02.Repositories.Entities;
using TranHuuTri.Assignment02.Repositories.RequestFeatures;
using static System.Reflection.Metadata.BlobBuilder;

namespace TranHuuTri.Assignment02.Repositories.Repositories
{
    public class PublisherRepository : GenericRepository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(EBookStoreContext context) : base(context)
        {
        }

        public IQueryable<Publisher> GetAllPublishers(PublisherParameters publisherParameters)
        {
            var publishers = _context.Publishers
                .OrderByDescending(i => i.Id)
                .SearchPublisher(publisherParameters.SearchTerm)
                .Include(b => b.Books)
                .Include(u => u.Users);
            var count = publishers.Count();
            return PagedList<Publisher>
                .ToPagedList(publishers, count, publisherParameters.PageNumber, publisherParameters.PageSize)
                .AsQueryable();
        }
        public Publisher GetPublisherById(int id)
        {
            return _context.Publishers
                .Include(b => b.Books)
                .Include(u => u.Users)
                .FirstOrDefault(p => p.Id == id);
        }
    }
}
