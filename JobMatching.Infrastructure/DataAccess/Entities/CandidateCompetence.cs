namespace JobMatching.Infrastructure.DataAccess.Entities
{
    public class CandidateCompetence
    {
        public Guid CandidateId { get; set; }
        public Guid CompetenceId { get; set; }
        public CandidateEntity Candidate { get; set; } = null!;
        public CompetenceEntity Competence { get; set; } = null!;
    }
}
