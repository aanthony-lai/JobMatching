using JobMatching.Common.Results;
using JobMatching.Domain.BaseClasses;

namespace JobMatching.Domain.Entities.Job
{
    public sealed class Job : AuditableEntityBase
    {
        private readonly List<JobCompetence> _jobCompetences = new();
        private readonly List<Applicant> _applicants = new();
        private readonly List<JobEmployer> _jobEmployers = new();

        public JobTitle Title { get; private set; } = null!;
        public JobDescription? Description { get; private set; } = null;
        public Salary? Salary { get; private set; } = null;
        public IReadOnlyList<JobCompetence> JobCompetences => _jobCompetences.AsReadOnly();
        public IReadOnlyList<Applicant> Applicants => _applicants.AsReadOnly();
        public IReadOnlyList<JobEmployer> JobEmployers => _jobEmployers.AsReadOnly();

        protected Job() { }
        private Job(
            JobTitle title, 
            Salary salary, 
            JobDescription? description) : base()
        {
            base.Id = Guid.NewGuid();
            Title = title;
            Salary = salary;
            Description = description;
        }

        public static Result<Job> Create(
            string title,
            int maxSalary,
            int minSalary,
            string? desription = null)
        {
            var titleResult = JobTitle.SetTitle(title);
            if (!titleResult.IsSuccess)
                return Result<Job>.Failure(titleResult.Error);

            var salaryResult = Salary.SetSalary(maxSalary, minSalary);
            if (!salaryResult.IsSuccess)
                return Result<Job>.Failure(salaryResult.Error);

            var descriptionResult = JobDescription.SetDescription(desription);
            if (!descriptionResult.IsSuccess)
                return Result<Job>.Failure(descriptionResult.Error);

            return Result<Job>.Success(
                new Job(
                    titleResult.Value,
                    salaryResult.Value,
                    descriptionResult.Value));
        }
    }
}
