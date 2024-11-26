using JobMatching.Application.DTO.Applicant;

namespace JobMatching.Application.Interfaces;

public interface IApplicantService
{
	Task<List<ApplicantDTO>> GetApplicantsByJobIdAsync(Guid jobId);
}
