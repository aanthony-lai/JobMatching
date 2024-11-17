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

		public Guid EmployerId { get; private set; }

		public Employer Employer { get; private set; } = null!;

		public List<Competence> Competences { get; private set; } = new List<Competence>();

		public List<JobApplication> Applications { get; private set; } = new List<JobApplication>();


		// public Job(string jobTitle, Guid employerId, SalaryRange? salaryRange)
		// {
		// 	if (employerId == Guid.Empty)
		// 		throw new ArgumentException("A job must contain a valid employer id.", nameof(employerId));
		//
		// 	JobId = Guid.NewGuid();
		// 	JobTitle = jobTitle;
		// 	JobEmployerId = employerId;
		//
		// 	if (salaryRange != null)
		// 		JobSalaryRange = salaryRange;
		// }

		public void AddCompetence(Competence competence)
		{
			Competences.Add(competence);
		}

		public void AddApplication(JobApplication jobApplication)
		{
			Applications.Add(jobApplication);
		} 
	}
}
