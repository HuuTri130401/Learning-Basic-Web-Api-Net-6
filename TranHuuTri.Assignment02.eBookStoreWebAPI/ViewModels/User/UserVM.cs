namespace TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.User
{
    public class UserVM
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Source { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime HireDate { get; set; }
        public int Status { get; set; }
        public int? PubId { get; set; }
        public string? PubName { get; set; }
        public int? RoleId { get; set; }
        public string? RoleName { get; set; }
    }
}
