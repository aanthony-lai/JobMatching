using JobMatching.Common.Results;
using JobMatching.Domain.Errors;
using JobMatching.Domain.Repositories;
using MediatR;

namespace JobMatching.Application.Applicants.GetApplicants
{
    public sealed class GetApplicantsMatchSummaryHandler : IRequestHandler<GetApplicantsMatchSummaryRequest, Result<IEnumerable<ApplicantMatchSummaryDTO>>>
    {
        private readonly IJobRepository _jobRepository;
        private readonly ICandidateRepository _candidateRepository;
        private readonly IApplicantMatchSummaryService _applicantMatchSummaryService;

        public GetApplicantsMatchSummaryHandler(
            IJobRepository jobRepository,
            ICandidateRepository candidateRepository,
            IApplicantMatchSummaryService applicantMatchSummaryService)
        {
            _jobRepository = jobRepository;
            _candidateRepository = candidateRepository;
            _applicantMatchSummaryService = applicantMatchSummaryService;
        }

        public async Task<Result<IEnumerable<ApplicantMatchSummaryDTO>>> Handle(GetApplicantsMatchSummaryRequest request, CancellationToken cancellationToken)
        {
            var job = await _jobRepository.GetByIdAsync(request.JobId);

            if (job is null)
                return Result<IEnumerable<ApplicantMatchSummaryDTO>>.Failure(JobErrors.NotFound(request.JobId));

            var applicantIds = job.Applicants.Select(a => a.CandidateId);
            var applicants = await _candidateRepository.GetByIdsAsync(applicantIds);

            var applicantsMatchSummaryDto = _applicantMatchSummaryService
                .CreateApplicantsMatchSummary(applicants, job);

            return Result<IEnumerable<ApplicantMatchSummaryDTO>>.Success(applicantsMatchSummaryDto);
        }
    }
}
