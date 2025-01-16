using JobMatching.Common.Results;
using JobMatching.Domain.Errors;

namespace JobMatching.Domain.Domain.Job.Entities
{
    public record JobTitle
    {
        public string Title { get; } = null!;

        private JobTitle(string title) => Title = title;

        public static implicit operator string(JobTitle jobTitle) => jobTitle.Title;

        public static Result<JobTitle> Create(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return Result<JobTitle>.Failure(JobErrors.InvalidJobTitle);

            return Result<JobTitle>.Success(new JobTitle(title));
        }

        public static JobTitle Load(string title) => new JobTitle(title);
    }
}
