using JobMatching.Domain.Domain.Candidate.Entities;
using JobMatching.Domain.Domain.Job.Entities;
using JobMatching.Domain.DomainServices.CriticalCompetencesMatchService;
using JobMatching.Domain.DomainServices.OverallMatchGradeService;

namespace JobMatching.Application.Applicants.GetApplicants
{
    public sealed class ApplicantMatchSummaryService: IApplicantMatchSummaryService
    {
        private readonly IOverallMatchGradeService _overallMatchGradeService;
        private readonly ICriticalCompetencesMatchService _criticalCompetenceMatchService;
        private readonly IApplicantMapper _applicantMapper;

        public ApplicantMatchSummaryService(
            IOverallMatchGradeService overallMatchGradeService,
            ICriticalCompetencesMatchService criticalCompetencesMatchService,
            IApplicantMapper applicantMapper)
        {
            _overallMatchGradeService = overallMatchGradeService;
            _criticalCompetenceMatchService = criticalCompetencesMatchService;
            _applicantMapper = applicantMapper;
        }

        public IEnumerable<ApplicantMatchSummaryDTO> CreateApplicantsMatchSummary(
            IEnumerable<Candidate> applicants,
            Job job)
        {
            return applicants.Select(applicant =>
            {
                var matchingJobCriticalCompetences = _criticalCompetenceMatchService.GetCriticalCompetencesMatch(
                    job.JobCompetences.Where(jc => jc.IsCritical),
                    applicant.CandidateCompetences);

                var overallMatchGrade = _overallMatchGradeService.CalculateOverallMatchGrade(
                    job.JobCompetences,
                    applicant.CandidateCompetences);

                return _applicantMapper.ToApplicantMatchSummaryDto(
                    applicant, 
                    matchingJobCriticalCompetences, 
                    overallMatchGrade);
            });
        }
    }
}
