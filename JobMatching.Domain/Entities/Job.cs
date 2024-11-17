using JobMatching.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobMatching.Domain.Entities
{
	public class Job
	{
		private string _jobTitle = null!;

		public Guid JobId { get; private set; }

		public string JobTitle 
		{
			get => _jobTitle; 
			private set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentException(nameof(JobTitle));
				_jobTitle = value;
			} 
		}

		public SalaryRange? JobSalaryRange { get; private set; }

		public Guid JobEmployerId { get; private set; }

		public Employer JobEmployer { get; private set; } = null!;

		public List<Competence> JobCompetences { get; private set; } = new List<Competence>();

		public List<Application> JobApplications { get; private set; } = new List<Application>();


		public Job(string jobTitle, Guid employerId, SalaryRange? salaryRange)
		{
			if (employerId == Guid.Empty)
				throw new ArgumentException("A job must contain a valid employer id.", nameof(employerId));

			JobId = Guid.NewGuid();
			JobTitle = jobTitle;
			JobEmployerId = employerId;

			if (salaryRange != null)
				JobSalaryRange = salaryRange;
		}

		public void AddCompetence(Competence competence)
		{
			JobCompetences.Add(competence);
		}

		public void AddApplication(Application application)
		{
			JobApplications.Add(application);
		} 
	}
}
