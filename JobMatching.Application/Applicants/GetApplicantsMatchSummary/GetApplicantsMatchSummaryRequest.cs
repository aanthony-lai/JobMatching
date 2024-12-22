using JobMatching.Common.Results;
using MediatR;

namespace JobMatching.Application.Applicants.GetApplicants
{
    public sealed class GetApplicantsMatchSummaryRequest : IRequest<Result<IEnumerable<ApplicantMatchSummaryDTO>>>
    {
        public Guid JobId { get; }
        public GetApplicantsMatchSummaryRequest(Guid jobId) { JobId = jobId; }
    }
}
