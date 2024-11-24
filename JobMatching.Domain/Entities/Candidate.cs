using JobMatching.Domain.Exceptions;
using JobMatching.Domain.ValueObjects;
using System.Runtime.CompilerServices;

namespace JobMatching.Domain.Entities
{
	public class Candidate
	{
		public Guid CandidateId { get; init; }
		public Name Name { get; private set; }
		public List<Competence> Competences { get; private set; } = new List<Competence>();

		protected Candidate() { }

		public Candidate(string firstName, string lastName)
		{
			CandidateId = Guid.NewGuid();
			Name = new Name(firstName, lastName);
		}

		public Candidate(Name name)
		{
			CandidateId = Guid.NewGuid();
			Name = name;
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
					"The candidate already has this competence.");

			Competences.Add(competence);
		}
	}
}
