using System;
using System.Collections.Generic;

namespace TranHuuTri.Assignment02.Repositories.Entities
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string? RoleDesc { get; set; }
        public int Status { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
