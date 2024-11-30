using JobMatching.Domain.Exceptions;
using JobMatching.Domain.ValueObjects.Name;

namespace JobMatching.Domain.Entities
{
	public class Candidate : User
	{
		public Name Name { get; private set; } = null!;
		public List<Competence> Competences { get; private set; } = new List<Competence>();

		protected Candidate() { }

		public Candidate(string firstName, string lastName, string email) :
			base(email, isEmployer: false)
		{
			Name = new Name(firstName, lastName);
		}

		public void AddCompetence(Competence competence)
		{
			if (competence is null)
				throw new ArgumentNullException(
					nameof(competence),
					"The competence that you're trying to add is null");

			if (Competences.Contains(competence))
				throw new DuplicateCompetenceException(
					"The candidate already has this competence.");

			Competences.Add(competence);
		}
	}
}
