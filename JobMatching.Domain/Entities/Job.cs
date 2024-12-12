using JobMatching.Common.Exceptions;
using JobMatching.Common.Results;
using JobMatching.Domain.Entities.JunctionEntities;
using JobMatching.Domain.Entities.ValueObjects;
using JobMatching.Domain.Errors;
using JobMatching.Domain.Interfaces;

namespace JobMatching.Domain.Entities
{
    public class Job: IEntity
    {
        public Guid Id { get; init; }
        public string Title { get; private set; } = null!;
        public Salary? Salary { get; private set; }
        public Guid EmployerId { get; private set; }
        public Employer Employer { get; private set; } = null!;
        public List<JobCompetence> JobCompetences { get; private set; } = new();
        public List<JobApplication> Applicants { get; private set; } = new();
        public MetaData MetaData { get; private set; } = null!;

        protected Job() { }
        private Job(string title, Guid employerId, Salary? salary)
        {
            if (salary != null) { Salary = salary; }

            Id = Guid.NewGuid();
            Title = title;
            EmployerId = employerId;
            MetaData = new MetaData();
        }

        public static Result<Job> Create(Guid employerId, string title, Salary? salary = null)
        {
            if (employerId == Guid.Empty)
                return Result<Job>.Failure(JobErrors.InvalidEmployerId);

            if (string.IsNullOrWhiteSpace(title))
                return Result<Job>.Failure(JobErrors.EmptyTitle);

            return Result<Job>.Success(new Job(title, employerId, salary));
        }
    }
}
