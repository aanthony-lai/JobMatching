using JobMatching.Common.Results;

namespace JobMatching.Domain.Errors
{
    public static class JobApplicationErrors
    {
        public static readonly Error InvalidCandidateId = new("An application must contain a valid candidate ID.");
        public static readonly Error InvalidJobId = new("An application must contain a valid job ID.");

    }
}
