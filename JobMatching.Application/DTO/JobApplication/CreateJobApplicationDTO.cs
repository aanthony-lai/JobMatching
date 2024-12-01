using System.ComponentModel.DataAnnotations;

namespace JobMatching.Application.DTO.JobApplication
{
	public record CreateJobApplicationDTO(Guid CandidateId, Guid JobId): IValidatableObject
	{
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (CandidateId == Guid.Empty)
				yield return new ValidationResult("Invalid candidate ID.", 
					new[] {nameof(CandidateId)});
			
			if (JobId == Guid.Empty)
				yield return new ValidationResult("Invalid candidate ID.", 
					new[] {nameof(JobId)});
		}
	}
}
