namespace EFCore.Data
{
    public class User
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public byte[]? ProfilePicture { get; set; }
        public DateTime DateJoin { get; set; }
        public string? Bio { get; set; }
    }
}
