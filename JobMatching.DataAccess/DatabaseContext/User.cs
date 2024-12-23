using Microsoft.AspNetCore.Identity;

namespace JobMatching.Infrastructure.DatabaseContext
{
    public class User: IdentityUser
    {
        public string Name { get; }
        public string PassWord { get; }
        public string Email { get; }
    }
}
