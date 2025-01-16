using JobMatching.Common.Results;
using JobMatching.Domain.Errors;

namespace JobMatching.Domain.Domain.Candidate.Entities
{
    public record Name
    {
        public string FullName { get; } = null!;
        public string FirstName { get; } = null!;
        public string LastName { get; } = null!;

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            FullName = $"{firstName} {lastName}";
        }

        public override string ToString() => FullName;
    }
}
