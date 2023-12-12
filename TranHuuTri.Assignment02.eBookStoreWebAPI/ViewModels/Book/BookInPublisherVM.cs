namespace TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.Book
{
    public class BookInPublisherVM
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Type { get; set; } = null!;
        public decimal Price { get; set; }
        public DateTime PublishedDate { get; set; }
        public int Status { get; set; }
    }
}
