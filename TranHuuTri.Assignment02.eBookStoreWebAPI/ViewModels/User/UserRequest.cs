namespace TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.User
{
    public class UserRequest
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Source { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int? RoleId { get; set; }
        public int? PubId { get; set; }
        public DateTime HireDate { get; set; }
        public int Status { get; set; }
    }
}
