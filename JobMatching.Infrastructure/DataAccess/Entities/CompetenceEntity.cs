using JobMatching.Domain.Enums;

namespace JobMatching.Infrastructure.DataAccess.Entities
{
    public class CompetenceEntity: EntityBase
    {
        public string Name { get; set; } = null!;
        public CompetenceLevel CompetenceLevel { get; set; }
    }
}
