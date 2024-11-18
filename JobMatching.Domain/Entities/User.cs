using JobMatching.Domain.ValueObjects;

namespace JobMatching.Domain.Entities
{
	public class User
	{
		public Guid UserId { get; init; }

		public Name UserName { get; private set; } = null!;

		public List<Competence> Competences { get; private set; } = new List<Competence>();

		public List<JobApplication> Applications { get; private set; } = new List<JobApplication>();

		protected User() { }

		public User(string firstName, string lastName)
		{
			UserId = Guid.NewGuid();
			UserName = new Name(firstName, lastName);
		}

		public User(Name name)
		{
			UserId = Guid.NewGuid();
			UserName = name;
		}

		public void AddCompetence(Competence competence)
		{
			Competences.Add(competence);
		}
	}
}
