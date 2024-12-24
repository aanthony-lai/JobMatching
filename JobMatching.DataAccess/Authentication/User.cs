using Microsoft.AspNetCore.Identity;

namespace JobMatching.Infrastructure.Authentication
{
    public class User : IdentityUser
    {
        public string Name { get; } = string.Empty;
        public string PassWord { get; } = string.Empty;
    }
}
