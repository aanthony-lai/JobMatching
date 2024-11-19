using JobMatching.Domain.Exceptions;
using JobMatching.Domain.ValueObjects;

namespace JobMatching.Domain.Entities
{
	public class User
	{
		public Guid UserId { get; init; }

		public Name UserName { get; private set; }

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
			if (competence is null)
				throw new ArgumentNullException(
					nameof(competence),
					"The competence that you're trying to add is null");

			if (Competences.Contains(competence))
				throw new DuplicateCompetenceException(
					nameof(competence),
					"The user already has this competence.");

			Competences.Add(competence);
		}
	}
}
