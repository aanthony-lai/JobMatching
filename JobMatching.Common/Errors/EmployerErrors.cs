using JobMatching.Common.Results;

namespace JobMatching.Domain.Errors
{
    public static class EmployerErrors
    {
        public static readonly Error InvalidName = new("Employer name can't be empty.");
        public static readonly Error InvalidJob = new("Invalid job ID.");
        public static readonly Error NotFound = new("Employer was not found.");
    }
}
