namespace TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.Book
{
    public class BookRequest
    {
        public string Title { get; set; } = null!;
        public string Type { get; set; } = null!;
        public int PubId { get; set; }
        public decimal Price { get; set; }
        public string? Advance { get; set; }
        public string? Royalty { get; set; }
        public string? Notes { get; set; }
        public DateTime PublishedDate { get; set; } = DateTime.UtcNow;
        public int Status { get; set; } = 1;
    }
}
