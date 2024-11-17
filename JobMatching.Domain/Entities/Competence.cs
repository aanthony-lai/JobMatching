namespace JobMatching.Domain.Entities
{
	public class Competence
	{
		public Guid CompetenceId { get; private set; }
		public string CompetenceName { get; private set; } = null!;
		public List<Job> Jobs { get; private set; } = new List<Job>();
		public List<User> Users { get; private set; } = new List<User>();
	}
}
