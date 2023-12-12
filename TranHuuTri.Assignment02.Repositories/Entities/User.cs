using System;
using System.Collections.Generic;

namespace TranHuuTri.Assignment02.Repositories.Entities
{
    public partial class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Source { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int? RoleId { get; set; }
        public int? PubId { get; set; }
        public DateTime HireDate { get; set; }
        public int Status { get; set; }

        public virtual Publisher? Pub { get; set; }
        public virtual Role? Role { get; set; }
    }
}
