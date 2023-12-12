using System;
using System.Collections.Generic;

namespace TranHuuTri.Assignment02.Repositories.Entities
{
    public partial class Publisher
    {
        public Publisher()
        {
            Books = new HashSet<Book>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string PublisherName { get; set; } = null!;
        public string? City { get; set; }
        public int State { get; set; }
        public string? Country { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
