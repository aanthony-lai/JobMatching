using JobMatching.Common.Results;
using JobMatching.Domain.Errors;
using JobMatching.Domain.JobMatchGradeService;
using JobMatching.Domain.Repositories;
using MediatR;

namespace JobMatching.Application.Applicants
{
    public class ApplicantsMatchSummaryHandler : IRequestHandler<ApplicantsMatchSummaryRequest, Result<ApplicantsMatchSummaryDTO>>
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IJobRepository _jobRepository;
        private readonly IJobMatchService _jobMatchGradeService;
        private readonly IApplicantMapper _applicantMapper;

        public ApplicantsMatchSummaryHandler(
            ICandidateRepository candidateRepository,
            IJobRepository jobRepository,
            IJobMatchService jobMatchGradeService,
            IApplicantMapper applicantMapper)
        {
            _candidateRepository = candidateRepository;
            _jobRepository = jobRepository;
            _jobMatchGradeService = jobMatchGradeService;
            _applicantMapper = applicantMapper;
        }

        public async Task<Result<ApplicantsMatchSummaryDTO>> Handle(ApplicantsMatchSummaryRequest request, CancellationToken cancellationToken)
        {
            var job = await _jobRepository.GetByIdAsync(request.JobId);

            if (job is null)
                return Result<ApplicantsMatchSummaryDTO>.Failure(JobErrors.NotFound(request.JobId));

            var jobCriticalCompetences = job.JobCompetences.Where(jobComp => jobComp.IsCritical);

            var applicantIds = job.Applicants.Select(a => a.CandidateId);
            var applicants = await _candidateRepository.GetByIdsAsync(applicantIds);

            var applicantsDto = applicants.Select(applicant => _applicantMapper.ToApplicantsDto(
                applicant,
                _jobMatchGradeService.GetCriticalCompetencesMatchSummary(
                    jobCriticalCompetences.ToList(),
                    applicant.CandidateCompetences.ToList()),
                _jobMatchGradeService.CalculateOverallMatchGrade(
                    job.JobCompetences.ToList(),
                    applicant.CandidateCompetences.ToList()))).ToList();

            var applicantsMatchSummaryDto = _applicantMapper.ToApplicantsMatchSummaryDto(job, applicantsDto);

            return Result<ApplicantsMatchSummaryDTO>.Success(applicantsMatchSummaryDto);
        }
    }
}