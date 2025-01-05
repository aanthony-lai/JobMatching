namespace JobMatching.Domain.Authentication
{
    public class DomainUser
    {
        public string Id { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LasName { get; set; } = string.Empty;
        public string EmployerName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public UserType UserType { get; set; }
    }
}
