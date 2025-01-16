using JobMatching.Common.Results;
using JobMatching.Domain.Errors;

namespace JobMatching.Domain.Domain.Job.Entities
{
    public class JobCompetence
    {
        public Guid CompetenceId { get; private set; }
        public string CompetenceName { get; private set; } = string.Empty;
        public bool IsCritical { get; private set; }

        protected JobCompetence() { }
        private JobCompetence(
            Guid competenceId,
            string competenceName,
            bool isCritical)
        {
            CompetenceId = competenceId;
            CompetenceName = competenceName;
            IsCritical = isCritical;
        }

        public static Result<JobCompetence> Create(
            Guid competenceId,
            string competenceName,
            bool isCritical)
        {
            if (competenceId == Guid.Empty)
                return Result<JobCompetence>.Failure(JobErrors.InvalidCompetence);

            if (string.IsNullOrWhiteSpace(competenceName))
                return Result<JobCompetence>.Failure(new Error("Competence name can't be empty."));

            return Result<JobCompetence>.Success(
                new JobCompetence(competenceId, competenceName, isCritical));
        }

        public static JobCompetence Load( 
            Guid competenceId, 
            string competenceName, 
            bool isCritical) => new JobCompetence(competenceId, competenceName, isCritical);
    }
}
