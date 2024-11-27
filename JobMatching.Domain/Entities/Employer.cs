namespace JobMatching.Domain.Entities
{
	public class Employer : User
	{
		private string _name;

		public string Name
		{
			get => _name;
			private set
			{
				if (value is null || string.IsNullOrEmpty(value))
					throw new ArgumentException(nameof(Name),
						"Employer name cannot be null or empty.");

				_name = value;
			}
		}
		public List<Job> Jobs { get; private set; } = new List<Job>();

		protected Employer() { }

		public Employer(string employerName, string email) :
			base(email, isEmployer: true)
		{
			Name = employerName;
		}

		public void UpdateEmployerName(string updatedEmployerName)
		{
			if (string.IsNullOrEmpty(updatedEmployerName))
				throw new ArgumentException(nameof(updatedEmployerName),
					"Employer name can't be empty.");

			_name = updatedEmployerName;
		}

		public void CreateJob(Job job) => Jobs.Add(job);
	}
}
