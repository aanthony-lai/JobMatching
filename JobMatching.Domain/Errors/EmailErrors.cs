using JobMatching.Common.Results;

namespace JobMatching.Domain.Errors
{
    public static class EmailErrors
    {
        public static readonly Error EmailIsEmpty = new("Email can't be empty.");
        public static readonly Error InvalidEmail = new("Invalid email.");

    }
}
