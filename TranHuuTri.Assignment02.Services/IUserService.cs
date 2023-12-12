using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranHuuTri.Assignment02.Repositories.Entities;
using TranHuuTri.Assignment02.Repositories.RequestFeatures;

namespace TranHuuTri.Assignment02.Services
{
    public interface IUserService
    {
        IQueryable<User> GetAllUsers(UserParameters userParameters);
        User GetUserById(int id);
        //IEnumerable<Author> GetAuthorsByCategoryId(int categoryId);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
