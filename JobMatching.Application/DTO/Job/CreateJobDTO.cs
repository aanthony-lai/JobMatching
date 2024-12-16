using System.ComponentModel.DataAnnotations;

namespace JobMatching.Application.DTO.Job
{
    public record CreateJobDTO(
        string Title,
        int MaxSalary,
        int MinSalary,
        string? Description = null) : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Title))
                yield return new ValidationResult("Job title can't be empty",
                    new[] { nameof(Title) } );

            if (MaxSalary < MinSalary)
                yield return new ValidationResult("Maximum salary can't be lower than minimum salary",
                    new[] { nameof(MaxSalary) });
        }
    }
}
