using JobMatching.Common.Results;

namespace JobMatching.Domain.Errors
{
    public static class JobErrors
    {
        public static readonly Error InvalidEmployerId = new("A job must contain a valid employer ID.");
        public static readonly Error EmptyTitle = new("Job title can't be empty.");
        public static readonly Error InvalidCompetence = new("The competence that you are to add is invalid.");
        public static readonly Error NotFound = new("Job was not found.");
    }
}
