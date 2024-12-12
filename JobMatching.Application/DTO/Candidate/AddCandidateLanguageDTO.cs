using JobMatching.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace JobMatching.Application.DTO.Candidate
{
    public record AddCandidateLanguageDTO(
		Guid LanguageId,
		LanguageProficiencyLevel ProficiencyLevel = LanguageProficiencyLevel.NotSpecified) : IValidatableObject
	{
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (LanguageId == Guid.Empty)
				yield return new ValidationResult("Invalid language ID.",
					new[] { nameof(LanguageId) });
		}
	}
}
