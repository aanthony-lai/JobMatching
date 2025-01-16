namespace JobMatching.Infrastructure.DataAccess.Entities
{
    public class JobEntity: AuditableEntityBase
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int MaxSalary { get; set; }
        public int MinSalary { get; set; }
        public Guid EmployerId { get; set; }
        public EmployerEntity Employer { get; set; } = null!;
        public ICollection<JobApplicationEntity> Applications { get; set; } = new List<JobApplicationEntity>();
        public ICollection<JobCompetence> Competences { get; set; } = new List<JobCompetence>();
    }
}
