using JobMatching.Common.Results;
using MediatR;

namespace JobMatching.Application.Applicants
{
    public record ApplicantsMatchSummaryRequest(Guid JobId): IRequest<Result<ApplicantsMatchSummaryDTO>>
    {
    
    }
}
