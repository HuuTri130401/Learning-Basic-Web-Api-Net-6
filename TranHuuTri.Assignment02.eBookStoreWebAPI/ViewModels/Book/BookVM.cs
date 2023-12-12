namespace TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.Book
{
    public class BookVM
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Type { get; set; } = null!;
        public int? PubId { get; set; }
        public decimal Price { get; set; }
        public string? Advance { get; set; }
        public string? Royalty { get; set; }
        public string? Notes { get; set; }
        public DateTime PublishedDate { get; set; }
        public int Status { get; set; }
        public string? PublisherName { get; set; }
    }
}
