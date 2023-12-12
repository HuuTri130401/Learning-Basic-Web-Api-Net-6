using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranHuuTri.Assignment02.Repositories.Entities;

namespace TranHuuTri.Assignment02.Repositories.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IAuthorRepository _authorRepository;

        private IBookRepository _bookRepository;

        private IBookAuthorRepository _bookAuthorRepository;

        private IPublisherRepository _publisherRepository;

        private IRoleRepository _roleRepository;

        private IUserRepository _userRepository;

        private readonly EBookStoreContext _eBookStoreContext;

        public UnitOfWork(EBookStoreContext eBookStoreContext)
        {
            _eBookStoreContext = eBookStoreContext;
            _authorRepository = new AuthorRepository(eBookStoreContext);
            _bookRepository = new BookRepository(eBookStoreContext);
            _bookAuthorRepository = new BookAuthorRepository(eBookStoreContext);
            _publisherRepository = new PublisherRepository(eBookStoreContext);
            _roleRepository = new RoleRepository(eBookStoreContext);
            _userRepository = new UserRepository(eBookStoreContext);
        }
        public IAuthorRepository AuthorRepository
        {
            get { return _authorRepository; }
        }

        public IBookRepository BookRepository
        {
            get { return _bookRepository; }
        }

        public IBookAuthorRepository BookAuthorRepository
        {
            get { return _bookAuthorRepository; }
        }

        public IPublisherRepository PublisherRepository
        {
            get { return _publisherRepository; }
        }

        public IRoleRepository RoleRepository
        {
            get { return _roleRepository; }
        }

        public IUserRepository UserRepository
        {
            get { return _userRepository; }
        }

        public void Savechange()
        {
            _eBookStoreContext.SaveChanges();
        }
    }
}
