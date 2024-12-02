using JobMatching.Domain.Interfaces;
using JobMatching.Domain.ValueObjects;

namespace JobMatching.Domain.Entities
{
    public class Competence: IEntity
	{
		public Guid Id { get; init; }
		public string CompetenceName { get; private set; }
		public List<Candidate> Candidates { get; private set; } = new List<Candidate>();
		public MetaData MetaData { get; private set; } = null!;

		protected Competence() { }

		public Competence(string competenceName)
		{
			if (string.IsNullOrWhiteSpace(competenceName))
				throw new ArgumentException(nameof(competenceName), "Competence name can't empty.");
			
			Id = Guid.NewGuid();
			CompetenceName = competenceName;
			MetaData = new MetaData();
		}
	}
}
