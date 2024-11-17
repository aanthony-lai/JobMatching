namespace JobMatching.Domain.Entities
{
	public class Employer
	{
		private string _employerName = null!;
		
		public Guid EmployerId { get; private set; }

		public string EmployerName
		{
			get => _employerName;
			private set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentException("Employer name can't be empty.", nameof(EmployerName));
				_employerName = value;
			}
		}

		public List<Job> EmployerJobs { get; private set; } = new List<Job>();

		// public Employer(string employerName) 
		// {
		// 	EmployerId = Guid.NewGuid();
		// 	EmployerName = employerName.Trim();
		// }

		public void UpdateEmployerName(string employerName)
		{
			EmployerName = employerName;
		}

		public void CreateJob(Job job)
		{
			EmployerJobs.Add(job);
		}
	}
}
