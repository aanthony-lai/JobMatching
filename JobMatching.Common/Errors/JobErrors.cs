using JobMatching.Common.Results;

namespace JobMatching.Domain.Errors
{
    public static class JobErrors
    {
        public static readonly Error InvalidJobTitle = new("Job title can't be empty.");
        public static readonly Error DescriptionLenghtLimit = new("Job description can contain a maximum of 300 characters.");
        public static readonly Error InvalidSalaryRange = new("Maximum salary can't be lower than minimum salary.");
        public static readonly Error SalaryNegativeValue = new("Salary can't contain a negative value.");
        public static readonly Error InvalidCompetence = new("The selected competence is invalid.");
        public static readonly Error InvalidCandidate = new("Invalid candidate ID.");
        public static readonly Error InvalidEmployer = new("Invalid employer ID.");
        public static Error NotFound(Guid jobId) => new($"Job with ID: {jobId}, was not found.");
    }
}
