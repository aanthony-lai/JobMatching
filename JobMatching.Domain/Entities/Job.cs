using JobMatching.Domain.Entities.JunctionEntities;
using JobMatching.Domain.Exceptions;
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
				throw new ArgumentException(nameof(JobTitle));
			if (salaryRange != null)
				SalaryRange = salaryRange;

			Id = Guid.NewGuid();
			JobTitle = jobTitle;
			EmployerId = employerId;
			MetaData = new MetaData();
		}

		public void AddCompetence(Competence competence, bool isCritical)
		{
			if (competence is null)
				throw new ArgumentNullException(
					"The competence that you're trying to add is null",
					nameof(competence));
			if (JobCompetences.Any(comp => comp.CompetenceId == competence.Id))
				throw new DuplicateCompetenceException("The competence has already been added.");

			JobCompetences.Add(new JobCompetence(competence, this, isCritical));
		}
	}
}
