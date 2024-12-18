namespace JobMatching.Domain.Entities
{
    public abstract class AuditableEntityBase : EntityBase
    {
        public DateTime Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime LastModified { get; set; }
        public string? ModifiedBy { get; set; }
        public bool? IsDeleted { get; set; }

        protected AuditableEntityBase()
        {
            Created = DateTime.UtcNow;
            LastModified = DateTime.UtcNow;
        }
    }
}
