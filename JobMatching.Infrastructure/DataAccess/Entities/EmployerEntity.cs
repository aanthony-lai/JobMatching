namespace JobMatching.Infrastructure.DataAccess.Entities
{
    public class EmployerEntity: AuditableEntityBase
    {
        public string Name { get; set; } = null!;
        public Guid UserId { get; set; }
        public UserEntity User { get; set; } = null!;
        public ICollection<JobEntity> Jobs { get; set; } = new List<JobEntity>(); 
    }
}
