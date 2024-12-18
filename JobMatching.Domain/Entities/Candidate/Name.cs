using JobMatching.Common.Results;
using JobMatching.Domain.Errors;

namespace JobMatching.Domain.Entities.Candidate
{
    public record Name
    {
        public string FullName { get; } = null!;
        public string FirstName { get; } = null!;
        public string LastName { get; } = null!;

        private Name(string firstName, string lastName) 
        {
            FirstName = firstName;
            LastName = lastName;
            FullName = $"{firstName} {lastName}";
        }
        
        public static Result<Name> Create(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                return Result<Name>.Failure(CandidateErrors.InvalidFirstName);

            if (string.IsNullOrWhiteSpace(lastName))
                return Result<Name>.Failure(CandidateErrors.InvalidLastName);

            return Result<Name>.Success(new Name(firstName, lastName));
        }

        public override string ToString() => FullName;
    }
}
