using JobMatching.Common.Results;

namespace JobMatching.Common.Errors
{
    public static class SystemErrors
    {
        public static readonly Error SavingError = new("An error occured while trying to save the entity to the database.");
    }
}
