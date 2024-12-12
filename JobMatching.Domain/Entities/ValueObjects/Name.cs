using JobMatching.Common.Results;
using JobMatching.Domain.Errors;
using System.Runtime.CompilerServices;

namespace JobMatching.Domain.Entities.ValueObjects
{
    public class Name
    {
        public string FirstName { get; } = null!;
        public string LastName { get; } = null!;

        public Name() { }
        private Name(string firstName, string lastName)
        {
            FirstName = string.IsNullOrWhiteSpace(firstName)
                ? throw new ArgumentNullException(nameof(firstName), "First name can't be empty.")
                : firstName.Trim();

            LastName = string.IsNullOrWhiteSpace(lastName)
                ? throw new ArgumentNullException(nameof(firstName), "Last name can't be empty.")
                : lastName.Trim();
        }

        public static Result<Name> SetName(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                return NameErrors.FirstNameIsEmpty;

            if (string.IsNullOrWhiteSpace(lastName))
                return NameErrors.LastNameIsEmpty;

            return Result<Name>.Success(new Name(firstName, lastName));
        }
    }
}
