namespace API.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public required string UserName { get; set; }
        public required byte[] PassordHash { get; set; }
        public required byte[] PasswordSalt { get; set; }
    }
}