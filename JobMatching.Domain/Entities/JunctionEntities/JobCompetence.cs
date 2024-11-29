namespace JobMatching.Domain.Entities.JunctionEntities
{
	public class JobCompetence
	{
		public Guid CompetenceId { get; private set; }
		public Competence Competence { get; private set; }
		public Guid JobId { get; private set; }
		public Job Job { get; private set; }
		public bool IsCritical { get; private set; }

		protected JobCompetence() { }
		public JobCompetence(Competence competence, Job job, bool isCritical)
		{
			Competence = competence;
			Job = job;
			IsCritical = isCritical;
		}
	}
}
