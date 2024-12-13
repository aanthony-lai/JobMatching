using JobMatching.Common.Results;
using JobMatching.Domain.Errors;

namespace JobMatching.Domain.Entities.Job
{
    public record JobDescription
    {
        public string Description { get; } = string.Empty;

        private JobDescription() { }
        private JobDescription(string description)
        {
            Description = description;
        }

        public static implicit operator string (JobDescription jobDescription) => jobDescription.Description;

        public static Result<JobDescription> SetDescription(string? description)
        {
            if (string.IsNullOrWhiteSpace(description))
                return Result<JobDescription>.Success(new JobDescription());

            if (description.Length > 300)
                return Result<JobDescription>.Failure(JobErrors.DescriptionLenghtLimit);

            return Result<JobDescription>.Success(new JobDescription(description));
        }
    }
}
