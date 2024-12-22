using System.ComponentModel.DataAnnotations;

namespace JobMatching.Application.DTO.Candidate
{
    public record CreateCandidateDTO(
        string FirstName,
        string LastName,
        string Email) : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(FirstName) ||
                string.IsNullOrWhiteSpace(LastName))
                yield return new ValidationResult("First name and last name can't be empty", 
                    new[] { nameof(FirstName), nameof(LastName) });

            if (string.IsNullOrEmpty(Email) ||
                !Email.Contains("@"))
                yield return new ValidationResult("Invalid email.", new[] { nameof(Email) });
        }
    }
}
