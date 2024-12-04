using System.ComponentModel.DataAnnotations;

namespace JobMatching.Application.DTO.Candidate
{
	public record CreateCandidateDTO(
		string FirstName,
		string LastName,
		string Email,
		bool? HasDriversLicense) : IValidatableObject
	{
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (string.IsNullOrEmpty(FirstName))
				yield return new ValidationResult("First name can't be empty", 
					new[] { nameof(FirstName) });

			if (string.IsNullOrEmpty(LastName))
				yield return new ValidationResult("Last name can't be empty",
					new[] { nameof(LastName) });

			if (string.IsNullOrEmpty(Email) || !Email.Contains("@"))
				yield return new ValidationResult("Invalid email.",
					new[] { nameof(Email) });
		}
	}
}
