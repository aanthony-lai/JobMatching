namespace JobMatching.Infrastructure.DataAccess.Entities
{
    public class JobCompetence
    {
        public Guid JobId { get; set; }
        public Guid CompetenceId { get; set; }
        public bool IsCritical { get; set; }
        public JobEntity Job { get; set; } = null!;
        public CompetenceEntity Competence { get; set; } = null!;
    }
}
