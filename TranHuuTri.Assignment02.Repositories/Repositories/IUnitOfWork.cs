using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranHuuTri.Assignment02.Repositories.Repositories
{
    public interface IUnitOfWork 
    {
        IAuthorRepository AuthorRepository { get; }
        IBookRepository BookRepository { get; }
        IBookAuthorRepository BookAuthorRepository { get; }
        IPublisherRepository PublisherRepository { get; }
        IRoleRepository RoleRepository { get; }
        IUserRepository UserRepository { get; }
        void Savechange();
    }
}
