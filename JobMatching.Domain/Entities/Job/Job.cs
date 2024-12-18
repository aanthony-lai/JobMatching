using JobMatching.Common.Results;
using JobMatching.Domain.Errors;

namespace JobMatching.Domain.Entities.Job
{
    public class Job : AuditableEntityBase
    {
        private readonly List<JobCompetence> _jobCompetences = new();
        private readonly List<Applicant> _applicants = new();

        public JobTitle JobTitle { get; private set; } = null!;
        public JobDescription? Description { get; private set; } = null;
        public Salary? Salary { get; private set; } = null;
        public Guid EmployerId { get; private set; }
        public IReadOnlyList<JobCompetence> JobCompetences => _jobCompetences.AsReadOnly();
        public IReadOnlyList<Applicant> Applicants => _applicants.AsReadOnly();

        protected Job() { }
        private Job(
            JobTitle title, 
            Salary salary, 
            JobDescription? description,
            Guid employerId) : base()
        {
            base.Id = Guid.NewGuid();
            JobTitle = title;
            Salary = salary;
            Description = description;
            EmployerId = employerId;
        }

        public static Result<Job> Create(
            string title,
            int maxSalary,
            int minSalary,
            Guid employerId,
            string? desription = null)
        {
            var titleResult = JobTitle.SetTitle(title);
            if (!titleResult.IsSuccess)
                return Result<Job>.Failure(titleResult.Error);

            var salaryResult = Salary.SetSalary(maxSalary, minSalary);
            if (!salaryResult.IsSuccess)
                return Result<Job>.Failure(salaryResult.Error);

            if (employerId == Guid.Empty)
                return Result<Job>.Failure(JobErrors.InvalidEmployer);

            var descriptionResult = JobDescription.SetDescription(desription);
            if (!descriptionResult.IsSuccess)
                return Result<Job>.Failure(descriptionResult.Error);

            return Result<Job>.Success(
                new Job(
                    titleResult.Value,
                    salaryResult.Value,
                    descriptionResult.Value,
                    employerId));
        }
    }
}
