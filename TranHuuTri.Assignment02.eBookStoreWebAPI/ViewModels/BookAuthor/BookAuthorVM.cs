using TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.Author;
using TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.Book;

namespace TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.BookAuthor
{
    public class BookAuthorVM
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int BookId { get; set; }
        public string? AuthorOrder { get; set; }
        public int? RoyalityPercentage { get; set; }
        public int Status { get; set; }
        public AuthorVM? Author { get; set; }
        public BookVM? Book { get; set; }
    }
}
