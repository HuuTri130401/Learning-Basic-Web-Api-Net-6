namespace TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.Publisher
{
    public class PublisherRequest
    {
        public string PublisherName { get; set; } = null!;
        public string? City { get; set; }
        public int State { get; set; }
        public string? Country { get; set; }
    }
}
