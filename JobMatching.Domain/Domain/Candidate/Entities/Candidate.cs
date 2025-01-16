using JobMatching.Common.Results;
using JobMatching.Domain.Entities;

namespace JobMatching.Domain.Domain.Candidate.Entities
{
    public class Candidate : DomainEntityBase
    {
        public Name Name { get; private set; } = null!;
        public Guid UserId { get; }
        public ICollection<Guid> JobApplicationIds { get; private set; }
        public ICollection<Guid> LanguageIds { get; private set; }
        public ICollection<Guid> CompetenceIds { get; private set; }

        //For creating a candidate
        private Candidate(Guid id, Name name, Guid userId)
        {
            base.Id = id;
            Name = name;
            UserId = userId;
            JobApplicationIds = new List<Guid>();
            LanguageIds = new List<Guid>();
            CompetenceIds = new List<Guid>();
        }

        //For loading a candidate from db
        private Candidate(
            Guid id,
            Name name,
            Guid userId,
            ICollection<Guid> jobApplicationIds,
            ICollection<Guid> languageIds,
            ICollection<Guid> competenceIds)
        {
            Id = id;
            Name = name;
            UserId = userId;
            JobApplicationIds = jobApplicationIds;
            LanguageIds = languageIds;
            CompetenceIds = competenceIds;
        }

        public static Result<Candidate> Create(Guid id, string firstName, 
            string lastName, Guid userId)
        {
            if (id == Guid.Empty) return Result<Candidate>.Failure(new Error("Invalid candidate ID."));

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName)) 
                return Result<Candidate>.Failure(new Error("First name and last name can't be empty."));

            if (userId == Guid.Empty)
                return Result<Candidate>.Failure(new Error("Invalid user ID"));

            return Result<Candidate>.Success(
                new Candidate(id, new Name(firstName, lastName), userId));
        }

        public static Candidate Load(
            Guid id,
            string firstName,
            string lastName,
            Guid userId,
            ICollection<Guid> jobApplicationIds,
            ICollection<Guid> languageIds,
            ICollection<Guid> competenceIds)
        {
            var name = new Name(firstName, lastName);   
            return new Candidate(id, name, userId, jobApplicationIds, 
                languageIds, competenceIds);
        }
    }
}
