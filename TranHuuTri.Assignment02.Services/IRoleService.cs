using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranHuuTri.Assignment02.Repositories.Entities;

namespace TranHuuTri.Assignment02.Services
{
    public interface IRoleService
    {
        IEnumerable<Role> GetAllRoles();
        Role GetRoleById(int id);
        //IEnumerable<Author> GetAuthorsByCategoryId(int categoryId);
        void CreateRole(Role role);
        void UpdateRole(Role role);
        void DeleteRole(int id);
    }
}
