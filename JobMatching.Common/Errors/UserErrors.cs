using JobMatching.Common.Results;

namespace JobMatching.Domain.Errors
{
    public static class UserErrors
    {
        public static readonly Error InvalidName = new("User name can't be empty.");
        public static readonly Error InvalidEmail = new("You have provided an invalid email address.");
    }
}
