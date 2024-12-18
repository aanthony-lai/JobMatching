using JobMatching.Domain.Entities.Candidate;
using JobMatching.Domain.Entities.Job;
using JobMatching.Domain.JobMatchService;

namespace JobMatching.Application.Applicants
{
    public interface IApplicantMapper
    {
        ApplicantsMatchSummaryDTO ToApplicantsMatchSummaryDto(
            Job job,
            List<ApplicantDTO> applicantsDto);

        List<ApplicantDTO> ToApplicantsDto(
            List<Candidate> applicants,
            List<CriticalCompetenceMatch> matchedCriticalCompetences,
            decimal matchGrade);
    }
}
