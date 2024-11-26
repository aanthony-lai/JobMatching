namespace JobMatching.Domain.Entities
{
	public class Competence
	{
		private string _competenceName = string.Empty;
		
		public Guid CompetenceId { get; init; }
		public string CompetenceName
		{
			get => _competenceName;
			private set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentException("Competence name can't empty.", nameof(CompetenceName));

				_competenceName = value;
			}
		}
		public List<Job> Jobs { get; private set; } = new List<Job>();
		public List<Candidate> Candidates { get; private set; } = new List<Candidate>();

		protected Competence() { }

		public Competence(string competenceName)
		{
			CompetenceId = Guid.NewGuid();
			CompetenceName = competenceName;
		}
	}
}
