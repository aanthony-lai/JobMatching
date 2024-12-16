using JobMatching.Common.Results;

namespace JobMatching.Domain.Errors
{
    public static class JobApplicationErrors
    {
        public static readonly Error InvalidCandidateId = new("Invalid candidate ID.");
        public static readonly Error InvalidJobId = new("Invalid job ID.");

    }
}
