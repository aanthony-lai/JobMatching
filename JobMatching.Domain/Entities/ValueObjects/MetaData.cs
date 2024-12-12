namespace JobMatching.Domain.Entities.ValueObjects
{
    public class MetaData
    {
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; private set; }
        public bool IsDeleted { get; private set; }

        public MetaData()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            IsDeleted = false;
        }

        public void SetUpdatedAt() => UpdatedAt = DateTime.UtcNow;
        public void DeleteRow() => IsDeleted = true;
    }
}
