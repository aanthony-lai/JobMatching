using JobMatching.Common.Results;
using JobMatching.Domain.Errors;
using JobMatching.Domain.Repositories;
using MediatR;

namespace JobMatching.Application.Applicants.GetApplicants
{
    public sealed class GetApplicantsMatchSummaryHandler(
        IJobRepository jobRepository,
        ICandidateRepository candidateRepository,
        IApplicantMatchSummaryService matchSummaryService) : IRequestHandler<GetApplicantsMatchSummaryRequest, Result<IEnumerable<ApplicantMatchSummaryDTO>>>
    {
        public async Task<Result<IEnumerable<ApplicantMatchSummaryDTO>>> Handle(
            GetApplicantsMatchSummaryRequest request, 
            CancellationToken cancellationToken)
        {
            var job = await jobRepository.GetByIdAsync(request.JobId);

            if (job is null)
                return Result<IEnumerable<ApplicantMatchSummaryDTO>>.Failure(JobErrors.NotFound(request.JobId));

            var applicantIds = job.ApplicantIds;
            var applicants = await Task.WhenAll(applicantIds.Select(id => candidateRepository.GetByIdAsync(id)));

            var applicantsMatchSummaryDto = matchSummaryService
                .CreateApplicantsMatchSummary(applicants!, job);

            return Result<IEnumerable<ApplicantMatchSummaryDTO>>.Success(applicantsMatchSummaryDto);
        }
    }
}
