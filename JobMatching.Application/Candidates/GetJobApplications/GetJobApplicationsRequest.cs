using JobMatching.Common.Results;
using MediatR;

namespace JobMatching.Application.Candidates.GetJobApplications
{
    public sealed class GetJobApplicationsRequest: IRequest<Result<IEnumerable<JobApplicationDTO>>>
    {
        public Guid CandidateId { get; }
        public GetJobApplicationsRequest(Guid candidateId) { CandidateId = candidateId; }
    }
}
