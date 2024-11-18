﻿using JobMatching.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobMatching.Domain.Entities
{
	public class Job
	{
		private string _jobTitle = null!;

		public Guid JobId { get; init; }
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
		
		protected Job() { }

		public Job(string jobTitle, Guid employerId, SalaryRange? salaryRange)
		{
			if (employerId == Guid.Empty)
				throw new ArgumentException("A job must contain a valid employer id.", nameof(employerId));

			JobId = Guid.NewGuid();
			JobTitle = jobTitle;
			EmployerId = employerId;

			if (salaryRange != null)
				JobSalaryRange = salaryRange;
		}

		public void AddCompetence(Competence competence)
		{
			if (competence is null)
				throw new ArgumentNullException(
					"The competence that you're trying to add is null", 
					nameof(competence));

			Competences.Add(competence);
		}

		public void AddApplication(JobApplication jobApplication)
		{
			if (jobApplication is null)
				throw new ArgumentNullException(
					"The job application that you're trying to add is null",
					nameof(jobApplication));

			Applications.Add(jobApplication);
		} 
	}
}
