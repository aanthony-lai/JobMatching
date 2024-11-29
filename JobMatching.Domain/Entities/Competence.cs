namespace JobMatching.Domain.Entities
{
	public class Competence
	{
		public Guid CompetenceId { get; init; }
		public string CompetenceName { get; private set; }
		public List<Candidate> Candidates { get; private set; } = new List<Candidate>();

		protected Competence() { }

		public Competence(string competenceName)
		{
			if (string.IsNullOrWhiteSpace(competenceName))
				throw new ArgumentException(nameof(competenceName), "Competence name can't empty.");

			CompetenceId = Guid.NewGuid();
			CompetenceName = competenceName;
		}
	}
}
