using System.ComponentModel.DataAnnotations;

namespace JobMatching.Application.DTO.Job
{
    public record AddJobCompetenceDTO(
        Guid CompetenceId,
        bool IsCritical) : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (CompetenceId == Guid.Empty)
                yield return new ValidationResult("Invalid candidate ID.",
                    new[] { nameof(CompetenceId) });
        }
    }
}
