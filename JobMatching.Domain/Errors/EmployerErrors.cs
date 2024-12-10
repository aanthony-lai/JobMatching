using JobMatching.Common.Results;

namespace JobMatching.Domain.Errors
{
    public static class EmployerErrors
    {
        public static readonly Error NotFound = new("Employer was not found.");
    }
}
