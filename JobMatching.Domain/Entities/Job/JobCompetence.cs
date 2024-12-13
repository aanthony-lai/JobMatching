using JobMatching.Common.Results;
using JobMatching.Domain.Errors;

namespace JobMatching.Domain.Entities.Job
{
    public class JobCompetence : IEquatable<JobCompetence>
    {
        public Guid JobId { get; private set; }
        public Guid CompetenceId { get; private set; }
        public bool IsCritical { get; private set; }

        protected JobCompetence() { }
        private JobCompetence(
            Guid jobId,
            Guid competenceId,
            bool isCritical)
        {
            JobId = jobId;
            CompetenceId = competenceId;
            IsCritical = isCritical;
        } 

        public static Result<JobCompetence> Create(
            Guid jobId,
            Guid competenceId,
            bool isCritical)
        {
            if (competenceId == Guid.Empty)
                return Result<JobCompetence>.Failure(JobErrors.InvalidCompetence);

            return Result<JobCompetence>.Success(
                new JobCompetence(jobId, competenceId, isCritical));
        }

        public bool Equals(JobCompetence other) =>
            this.JobId == other.JobId && 
            this.CompetenceId == other.CompetenceId;
    }
}
