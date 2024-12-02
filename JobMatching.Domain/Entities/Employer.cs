using JobMatching.Domain.Interfaces;
using JobMatching.Domain.ValueObjects;
using JobMatching.Domain.ValueObjects.Name;

namespace JobMatching.Domain.Entities
{
	public class Employer: IEntity
	{
		public Guid Id { get; init; }
		public Name Name { get; private set; }
		public List<Job> Jobs { get; private set; } = new List<Job>();
		public User User { get; init; }
		public Guid UserId { get; init; }
		public MetaData MetaData { get; private set; }

		protected Employer() { }
		public Employer(string employerName, string email)
		{
			Id = Guid.NewGuid();
			Name = Name.SetEmployerName(employerName);
			User = User.CreateUserAsEmployer(email, name: employerName);
			UserId = User.Id;
			MetaData = new MetaData();
		}

		public string GetName() => Name.EmployerName!;

		public void SetEmployerName(string employerName) => 
			Name.SetEmployerName(employerName);

		public void CreateJob(Job job) => Jobs.Add(job);
	}
}
