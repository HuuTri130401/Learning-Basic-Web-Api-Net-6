namespace TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.Author
{
    public class AuthorVM
    {
        public int Id { get; set; }
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public int Phone { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public int State { get; set; }
        public int Zip { get; set; }
        public string EmailAddress { get; set; } = null!;
    }
}
