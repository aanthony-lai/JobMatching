using JobMatching.Client.Types;

namespace JobMatching.Client.DTO
{
    public sealed record RegisterUserDTO
    {
        public string? FirstName { get; }
        public string? LastName { get; } 
        public string? EmployerName { get; } 
        public string? Email { get; } 
        public UserType UserType { get; }

        public RegisterUserDTO(
            UserType userType,
            string? firstName = null,
            string? lastName = null,
            string? employerName = null,
            string? email = null)
        {
            FirstName = firstName; 
            LastName = lastName;
            EmployerName = employerName;
            Email = email;
            UserType = userType;
        }
    }
}
