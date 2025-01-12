namespace JobMatching.Infrastructure.DataAccess.Entities
{
    public class CandidateEntity: AuditableEntityBase
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public Guid UserId { get; set; }
        public UserEntity User { get; set; } = null!;
        public ICollection<JobApplicationEntity> JobApplications { get; set; } = new List<JobApplicationEntity>();
        public ICollection<CandidateLanguage> Languages { get; set; } = new List<CandidateLanguage>();
        public ICollection<CandidateCompetence> Competences { get; set; } = new List<CandidateCompetence>();
    }
}
