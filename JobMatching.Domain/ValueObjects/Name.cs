using JobMatching.Common.Results;

namespace JobMatching.Domain.Domain.Candidate.Entities
{
    public record Name
    {
        public string FullName { get; }
        public string FirstName { get; }
        public string LastName { get; }

        private Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            FullName = $"{firstName} {lastName}";
        }

        public static Result<Name> Create(string firstName, string lastName) =>
            string.IsNullOrWhiteSpace(firstName)
            || string.IsNullOrWhiteSpace(lastName)
                ? Result<Name>.Failure(new Error("First and last name can't be empty."))
                : Result<Name>.Success(new Name(firstName, lastName));

        public static Name Load(string firstName, string lastName) => new Name(firstName, lastName);
        public override string ToString() => FullName;
    }
}
