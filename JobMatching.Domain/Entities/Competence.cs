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
		public List<User> Users { get; private set; } = new List<User>();

		protected Competence() { }

		public Competence(string competenceName)
		{
			CompetenceId = Guid.NewGuid();
			CompetenceName = competenceName;
		}
	}
}
