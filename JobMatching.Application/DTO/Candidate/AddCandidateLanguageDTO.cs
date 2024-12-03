using JobMatching.Domain.Types;
using System.ComponentModel.DataAnnotations;

namespace JobMatching.Application.DTO.Candidate
{
	public record AddCandidateLanguageDTO(
		Guid CandidateId,
		Guid LanguageId,
		LanguageProficiencyLevel? ProficiencyLevel) : IValidatableObject
	{
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (CandidateId == Guid.Empty)
				yield return new ValidationResult("Invalid candidate ID.",
					new[] {nameof(CandidateId)});
			if (LanguageId == Guid.Empty)
				yield return new ValidationResult("Invalid language ID.",
					new[] { nameof(LanguageId) });
		}
	}
}
