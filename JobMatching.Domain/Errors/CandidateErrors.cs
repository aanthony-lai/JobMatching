using JobMatching.Common.Results;

namespace JobMatching.Domain.Errors
{
    public static class CandidateErrors
    {
        public static readonly Error HaveAlreadyApplied = new("The candidate has already applied for this job.");
        public static readonly Error NotFound = new("Candidate was not found.");
    }
}
