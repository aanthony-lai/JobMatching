using JobMatching.Common.Results;

namespace JobMatching.Domain.Entities.Candidate
{
    public class Candidate : AuditableEntityBase
    {
        private readonly List<JobApplication> _jobApplications = new();
        private readonly List<CandidateLanguage> _candidateLanguages = new();
        private readonly List<CandidateCompetence> _candidateCompetence = new();

        public Name Name { get; private set; } = null!;
        public Guid UserId { get; }
        public IReadOnlyList<JobApplication> JobApplications => _jobApplications.AsReadOnly();
        public IReadOnlyList<CandidateLanguage> CandidateLanguages => _candidateLanguages.AsReadOnly();
        public IReadOnlyList<CandidateCompetence> CandidateCompetences => _candidateCompetence.AsReadOnly();

        protected Candidate() { }
        private Candidate(Name name, Guid userId) : base()
        {
            base.Id = Guid.NewGuid();
            UserId = userId;
            Name = name;
            UserId = userId;
        }

        public static Result<Candidate> Create(
            string firstName,
            string lastName,
            Guid userId)
        {
            var nameResult = Name.Create(firstName, lastName);
            
            if (!nameResult.IsSuccess)
                return Result<Candidate>.Failure(nameResult.Error);

            if (userId == Guid.Empty)
                return Result<Candidate>.Failure(new Error("You have provided an invalid user ID"));

            return Result<Candidate>.Success(new Candidate(nameResult.Value, userId));
        }
    }
}
