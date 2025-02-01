using JobMatching.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace JobMatching.Infrastructure.DataAccess.Entities
{
    public class UserEntity : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LasName { get; set; } = string.Empty;
        public string EmployerName { get; set; } = string.Empty;
        public required UserType UserType { get; set; }
    }
}
