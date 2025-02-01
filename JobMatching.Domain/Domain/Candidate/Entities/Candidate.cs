using JobMatching.Common.Results;
using JobMatching.Domain.Entities;

namespace JobMatching.Domain.Domain.Candidate.Entities
{
    public class Candidate : DomainEntityBase
    {
        private readonly List<CandidateApplication> _applications = new();
        private readonly List<Guid> _languageIds = new();
        private readonly List<CandidateCompetence> _competences = new();

        public Name Name { get; private set; } = null!;
        public Guid UserId { get; }
        public IReadOnlyCollection<CandidateApplication> Applications => _applications;
        public IReadOnlyCollection<Guid> LanguageIds => _languageIds;
        public IReadOnlyCollection<CandidateCompetence> Competences => _competences;

        //Create candidate
        private Candidate(Name name, Guid userId)
        {
            base.Id = Guid.NewGuid();
            Name = name;
            UserId = userId;
        }

        //Load candidate
        private Candidate(
            Guid id, 
            Name name, 
            Guid userId,
            List<CandidateApplication> applications,
            List<Guid> languageIds,
            List<CandidateCompetence> competences)
        {
            Id = id;
            Name = name;
            UserId = userId;
            _applications = applications;
            _languageIds = languageIds;
            _competences = competences;
        }

        public static Result<Candidate> Create(string firstName, string lastName, Guid userId)
        {
            var name = Name.Create(firstName, lastName);

            if (!name.IsSuccess)
                return Result<Candidate>.Failure(new Error("First name and last name can't be empty."));

            if (userId == Guid.Empty)
                return Result<Candidate>.Failure(new Error("Invalid user ID"));

            return Result<Candidate>.Success(
                new Candidate(name.Value, userId));
        }

        public static Candidate Load(
            Guid id, 
            string firstName, 
            string lastName, 
            Guid userId,
            List<CandidateApplication> applications,
            List<Guid> languageIds,
            List<CandidateCompetence> competences)
        {
            var name = Name.Load(firstName, lastName);   

            return new Candidate(id, name, userId, applications, 
                languageIds, competences);
        }
    }
}
