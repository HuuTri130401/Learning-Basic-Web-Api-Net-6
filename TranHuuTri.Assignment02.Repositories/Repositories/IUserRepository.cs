﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranHuuTri.Assignment02.Repositories.Entities;
using TranHuuTri.Assignment02.Repositories.RequestFeatures;

namespace TranHuuTri.Assignment02.Repositories.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetUserById(int id);
        IQueryable<User> GetAllUsers(UserParameters userParameters);
    }
}
