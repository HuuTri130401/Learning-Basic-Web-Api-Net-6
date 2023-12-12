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
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateUser(User user)
        {
            _unitOfWork.UserRepository.Add(user);
        }

        public void DeleteUser(int id)
        {
            User user = _unitOfWork.UserRepository.GetById(id);
            if(user != null)
            {
                user.Status = 0;
                _unitOfWork.UserRepository.Update(user);
            }
        }

        public IQueryable<User> GetAllUsers(UserParameters userParameters)
        {
            return _unitOfWork.UserRepository.GetAllUsers(userParameters);
        }

        public User GetUserById(int id)
        {
            return _unitOfWork.UserRepository.GetUserById(id);
        }

        public void UpdateUser(User user)
        {
            _unitOfWork.UserRepository.Update(user);
        }
    }
}
