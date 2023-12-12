using AutoMapper;
using TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.Author;
using TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.Book;
using TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.BookAuthor;
using TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.Publisher;
using TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.Role;
using TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.User;
using TranHuuTri.Assignment02.Repositories.Entities;

namespace TranHuuTri.Assignment02.eBookStoreWebAPI.AutoMappers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<BookAuthor, BookAuthorVM>().ReverseMap();

            CreateMap<Book, BookVM>().ReverseMap();
            CreateMap<Book, BookRequest>().ReverseMap();
            CreateMap<Book, BookInPublisherVM>().ReverseMap();

            CreateMap<Author, AuthorVM>().ReverseMap();
            CreateMap<Author, AuthorRequest>().ReverseMap();

            CreateMap<Publisher, PublisherVM>().ReverseMap();
            CreateMap<Publisher, PublisherRequest>().ReverseMap();

            CreateMap<Role, RoleVM>().ReverseMap();
            CreateMap<Role, RoleRequest>().ReverseMap();

            CreateMap<User, UserVM>().ReverseMap();
            CreateMap<User, UserRequest>().ReverseMap();
        }
    }
}
