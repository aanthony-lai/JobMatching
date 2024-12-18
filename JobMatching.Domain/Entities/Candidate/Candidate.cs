using JobMatching.Common.Results;

namespace JobMatching.Domain.Entities.Candidate
{
    public class Candidate : AuditableEntityBase
    {
        private readonly List<CandidateLanguage> _candidateLanguages = new();
        private readonly List<CandidateCompetence> _candidateCompetence = new();

        public Name Name { get; private set; } = null!;
        public List<JobApplication> Applications { get; private set; } = new();
        public IReadOnlyList<CandidateLanguage> CandidateLanguages => _candidateLanguages.AsReadOnly();
        public IReadOnlyList<CandidateCompetence> CandidateCompetences => _candidateCompetence.AsReadOnly();

        protected Candidate() { }
        private Candidate(Name name) : base()
        {
            base.Id = Guid.NewGuid();
            Name = name;
        }

        public static Result<Candidate> Create(
            string firstName,
            string lastName)
        {
            var nameResult = Name.Create(firstName, lastName);
            if (!nameResult.IsSuccess)
                return Result<Candidate>.Failure(nameResult.Error);

            return Result<Candidate>.Success(new Candidate(nameResult.Value));
        }
    }
}
