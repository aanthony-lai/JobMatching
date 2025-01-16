using JobMatching.Domain.Domain.Candidate.Entities;
using JobMatching.Domain.Domain.Job.Entities;

namespace JobMatching.Application.Applicants.GetApplicants
{
    public interface IApplicantMatchSummaryService
    {
        IEnumerable<ApplicantMatchSummaryDTO> CreateApplicantsMatchSummary(
            IEnumerable<Candidate> applicants,
            Job job);
    }
}
