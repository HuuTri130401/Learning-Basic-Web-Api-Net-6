using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranHuuTri.Assignment02.Repositories.Entities;
using TranHuuTri.Assignment02.Repositories.Repositories;

namespace TranHuuTri.Assignment02.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateRole(Role role)
        {
            _unitOfWork.RoleRepository.Add(role);
        }

        public void DeleteRole(int id)
        {
            Role role = _unitOfWork.RoleRepository.GetById(id);
            if(role != null)
            {
                _unitOfWork.RoleRepository.Delete(role);
            }
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return _unitOfWork.RoleRepository.GetAll();
        }

        public Role GetRoleById(int id)
        {
            return _unitOfWork.RoleRepository.GetById(id);
        }

        public void UpdateRole(Role role)
        {
            _unitOfWork.RoleRepository.Update(role);
        }
    }
}
