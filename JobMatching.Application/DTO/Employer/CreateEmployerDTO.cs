using System.ComponentModel.DataAnnotations;

namespace JobMatching.Application.DTO.Employer
{
    public record CreateEmployerDTO(
        string Name,
        string Email) : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Name))
                yield return new ValidationResult("Employer name can't be empty",
                    new[] { nameof(Name) });

            if (string.IsNullOrWhiteSpace(Email) ||
                !Email.Contains("@"))
                yield return new ValidationResult("Invalid email.",
                    new[] { nameof(Email) });
        }
    }
}
