using JobMatching.Common.Exceptions;
using JobMatching.Domain.Entities.JunctionEntities;
using JobMatching.Domain.Interfaces;
using JobMatching.Domain.ValueObjects;

namespace JobMatching.Domain.Entities
{
    public class Job: IEntity
    {
        public Guid Id { get; init; }
        public string JobTitle { get; private set; } = null!;
        public SalaryRange? SalaryRange { get; private set; }
        public Guid EmployerId { get; private set; }
        public Employer Employer { get; private set; } = null!;
        public List<JobCompetence> JobCompetences { get; private set; } = new();
        public List<JobApplication> Applicants { get; private set; } = new();
        public MetaData MetaData { get; private set; } = null!;

        protected Job() { }

        public Job(string jobTitle, Guid employerId, SalaryRange? salaryRange = null)
        {
            if (employerId == Guid.Empty)
                throw new ArgumentException("A job must contain a valid employer id.", nameof(employerId));

            if (string.IsNullOrWhiteSpace(jobTitle))
                throw new ArgumentException("Job title can't be empty.", nameof(JobTitle));

            if (salaryRange != null)
                SalaryRange = new SalaryRange(
                    salaryRange.SalaryRangeTop,
                    salaryRange.SalaryRangeBottom);

            Id = Guid.NewGuid();
            JobTitle = jobTitle;
            EmployerId = employerId;
            MetaData = new MetaData();
        }

        public void AddCompetence(Guid competenceId, bool isCritical)
        {
            if (competenceId == Guid.Empty)
                throw new ArgumentException("Invalid competence ID.", nameof(competenceId));

            if (JobCompetences.Where(jc => jc.JobId == this.Id)
                    .Any(jc => jc.CompetenceId == competenceId))
            {
                throw new EntityAlreadyExistException(
                    "The competence has already been added.");
            }

            JobCompetences.Add(new JobCompetence(competenceId, this.Id, isCritical));
        }
    }
}
