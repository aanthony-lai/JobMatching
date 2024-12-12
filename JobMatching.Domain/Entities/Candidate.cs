using JobMatching.Common.Results;
using JobMatching.Domain.Entities.JunctionEntities;
using JobMatching.Domain.Entities.ValueObjects;
using JobMatching.Domain.Enums;
using JobMatching.Domain.Errors;
using JobMatching.Domain.Interfaces;

namespace JobMatching.Domain.Entities
{
    public class Candidate : IEntity
    {
        public Guid Id { get; init; }
        public Name Name { get; private set; } = null!;
        public List<Competence> Competences { get; } = new();
        public List<JobApplication> JobApplications { get; private set; } = new();
        public List<CandidateLanguage> Languages { get; } = new();
        public bool? HasDriversLicence { get; }
        public User User { get; init; } = null!;
        public Guid UserId { get; init; }
        public MetaData MetaData { get; } = null!;

        protected Candidate() { }
        private Candidate(Name name, User user, bool? hasDriversLicense)
        {
            Id = Guid.NewGuid();
            Name = name;
            User = user;
            UserId = User.Id;
            HasDriversLicence = hasDriversLicense;
            MetaData = new MetaData();
        }

        public static Result<Candidate> Create(string firstName, string lastName, string email, bool? hasDriversLicense)
        {
            var nameResult = Name.SetName(firstName, lastName);
            if (!nameResult.IsSuccess)
                return Result<Candidate>.Failure(nameResult.Error);

            var userResult = User.Create(email, $"{firstName} {lastName}", UserType.Candidate);
            if (!userResult.IsSuccess)
                return Result<Candidate>.Failure(userResult.Error);

            return Result<Candidate>.Success(new Candidate(nameResult.Value, userResult.Value, hasDriversLicense));
        }

        public Result AddCompetence(Competence competence)
        {
            if (competence is null)
                return Result.Failure(CompetenceErrors.Invalid);

            if (Competences.Any(comp => comp.Id == competence.Id))
                return Result.Failure(CompetenceErrors.AlreadyExists);

            Competences.Add(competence);
            return Result.Success();
        }

        public Result AddJobApplication(JobApplication jobApplication)
        {
            if (JobApplications.Any(ja => ja.JobId == jobApplication.JobId))
                return Result.Failure(CandidateErrors.HaveAlreadyApplied);

            JobApplications.Add(jobApplication);
            return Result.Success();
        }
    }
}
