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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(EBookStoreContext context) : base(context)
        {
        }

        public IQueryable<User> GetAllUsers(UserParameters userParameters)
        {
            var users =  _context.Users
                .OrderByDescending(i => i.Id)
                .SearchUser(userParameters.SearchTerm)
                .Include(r => r.Role)
                .Include(p => p.Pub);
            var count = users.Count();
            return PagedList<User>
                .ToPagedList(users, count, userParameters.PageNumber, userParameters.PageSize)
                .AsQueryable();
        }

        public User GetUserById(int id)
        {
            return _context.Users
                .Include(r => r.Role)
                .Include(p => p.Pub)
                .FirstOrDefault(u => u.Id == id);
        }
    }
}
