using JobMatching.Domain.Entities.Candidate;
using JobMatching.Domain.Entities.Job;

namespace JobMatching.Application.Applicants.GetApplicants
{
    public interface IApplicantMatchSummaryService
    {
        IEnumerable<ApplicantMatchSummaryDTO> CreateApplicantsMatchSummary(
            IEnumerable<Candidate> applicants,
            Job job);
    }
}
