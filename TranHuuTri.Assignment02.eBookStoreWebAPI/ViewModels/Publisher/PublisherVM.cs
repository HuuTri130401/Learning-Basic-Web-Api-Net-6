using TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.Book;
using TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.User;

namespace TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.Publisher
{
    public class PublisherVM
    {
        public int Id { get; set; }
        public string PublisherName { get; set; } = null!;
        public string? City { get; set; }
        public int State { get; set; }
        public string? Country { get; set;}
        public ICollection<BookInPublisherVM>? Books { get; set; }
        public ICollection<UserVM>? Users { get; set; }
    }
}
