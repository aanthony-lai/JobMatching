using JobMatching.Common.Results;
using JobMatching.Domain.BaseClasses;
using JobMatching.Domain.Entities.Users;

namespace JobMatching.Domain.Entities.Candidate
{
    public class Candidate : AuditableEntityBase
    {
        private readonly List<CandidateLanguage> _candidateLanguages = new();
        private readonly List<CandidateCompetence> _candidateCompetence = new();

        public Name Name { get; private set; } = null!;
        public List<CandidateApplication> Applications { get; private set; } = new();
        public IReadOnlyList<CandidateLanguage> CandidateLanguages => _candidateLanguages.AsReadOnly();
        public IReadOnlyList<CandidateCompetence> CandidateCompetences => _candidateCompetence.AsReadOnly();
        public Guid UserId { get; private set; }
        public User User { get; private set; }
        

        protected Candidate() { }
        private Candidate(Name name, User user) : base()
        {
            base.Id = Guid.NewGuid();
            Name = name;
            UserId = user.Id;
            User = user;
        }

        public static Result<Candidate> Create(
            string firstName,
            string lastName,
            string email)
        {
            var nameResult = Name.Create(firstName, lastName);
            if (!nameResult.IsSuccess)
                return Result<Candidate>.Failure(nameResult.Error);

            var userResult = User.CreateUserAsCandidate($"{firstName} {lastName}", email);
            if (!userResult.IsSuccess)
                return Result<Candidate>.Failure(userResult.Error);

            return Result<Candidate>.Success(new Candidate(nameResult.Value, userResult.Value));
        }
    }
}
