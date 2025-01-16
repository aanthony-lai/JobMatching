using JobMatching.Common.Results;
using JobMatching.Domain.Entities;
using JobMatching.Domain.Errors;

namespace JobMatching.Domain.Domain.Job.Entities
{
    public class Job : DomainEntityBase
    {
        public JobTitle JobTitle { get; private set; } = null!;
        public JobDescription? Description { get; private set; } = null;
        public Salary Salary { get; private set; } = null!;
        public Guid EmployerId { get; private set; }

        public ICollection<Guid> ApplicantIds { get; }
        public ICollection<JobCompetence> JobCompetences { get; }

        //For creating a job
        private Job(JobTitle title, Salary salary, JobDescription? description, 
            Guid employerId) : base()
        {
            base.Id = Guid.NewGuid();
            JobTitle = title;
            Description = description;
            Salary = salary;
            EmployerId = employerId;
            ApplicantIds = new List<Guid>();
            JobCompetences = new List<JobCompetence>();
        }

        //For loading a job
        private Job(
            Guid id,
            string title,
            string jobDescription,
            int maxSalary,
            int minSalary,
            Guid employerId,
            ICollection<Guid> applicantIds,
            ICollection<JobCompetence> jobCompetences)
        {
            base.Id = id;
            JobTitle = JobTitle.Load(title);
            Description = JobDescription.Load(jobDescription);
            Salary = Salary.Load(maxSalary, minSalary);
            EmployerId = employerId;
            ApplicantIds = applicantIds;
            JobCompetences = jobCompetences;
        }

        public static Result<Job> Create(string title, int maxSalary, int minSalary,
            Guid employerId, string? description = null)
        {
            var jobTitle = JobTitle.Create(title);
            if (!jobTitle.IsSuccess)
                return Result<Job>.Failure(jobTitle.Error);
            
            var salary = Salary.Create(maxSalary, minSalary);
            if (!salary.IsSuccess)
                return Result<Job>.Failure(salary.Error);

            if (employerId == Guid.Empty)
                return Result<Job>.Failure(JobErrors.InvalidEmployer);

            var jobDescription = JobDescription.Set(description);
            if (!jobDescription.IsSuccess)
                return Result<Job>.Failure(jobDescription.Error);

            return Result<Job>.Success(
                new Job(jobTitle.Value, salary.Value, jobDescription.Value, employerId));
        }

        public static Job Load(
            Guid id, 
            string title, 
            string jobDescription,
            int maxSalary, 
            int minSalary, 
            Guid employerId, 
            ICollection<Guid> applicantIds,
            ICollection<JobCompetence> jobCompetences)
        {
            return new Job(id, title, jobDescription, maxSalary, minSalary, employerId,
                applicantIds, jobCompetences);
        }
                
    }
}
