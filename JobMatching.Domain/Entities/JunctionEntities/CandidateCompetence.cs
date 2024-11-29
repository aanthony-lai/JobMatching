using System.ComponentModel.DataAnnotations;

namespace JobMatching.Domain.Entities.JunctionTables
{
    public class CandidateCompetence
    {
        public Guid CandidateId { get; private set; }
        public Guid CompetenceId { get; private set; }
    }
}
