using JobMatching.Common.Results;
using JobMatching.Domain.Errors;

namespace JobMatching.Domain.Entities.Job
{
    public class JobCompetence : IEquatable<JobCompetence>
    {
        public Guid JobId { get; private set; }
        public Guid CompetenceId { get; private set; }
        public string CompetenceName { get; private set; } = null!;
        public bool IsCritical { get; private set; }

        protected JobCompetence() { }
        private JobCompetence(
            Guid jobId,
            Guid competenceId,
            string competenceName,
            bool isCritical)
        {
            JobId = jobId;
            CompetenceId = competenceId;
            CompetenceName = competenceName;
            IsCritical = isCritical;
        } 

        public static Result<JobCompetence> Create(
            Guid jobId,
            Guid competenceId,
            string competenceName,
            bool isCritical)
        {
            if (competenceId == Guid.Empty)
                return Result<JobCompetence>.Failure(JobErrors.InvalidCompetence);

            return Result<JobCompetence>.Success(
                new JobCompetence(jobId, competenceId, competenceName, isCritical));
        }

        public bool Equals(JobCompetence other) =>
            this.JobId == other.JobId && 
            this.CompetenceId == other.CompetenceId;
    }
}
