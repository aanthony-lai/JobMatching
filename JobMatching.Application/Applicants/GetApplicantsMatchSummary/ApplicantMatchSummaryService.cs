using JobMatching.Domain.Domain.Candidate.Entities;
using JobMatching.Domain.Domain.Job.Entities;
using JobMatching.Domain.DomainServices.CriticalCompetencesMatchService;
using JobMatching.Domain.DomainServices.OverallMatchGradeService;

namespace JobMatching.Application.Applicants.GetApplicants
{
    public sealed class ApplicantMatchSummaryService(
        IOverallMatchGradeService overallMatchGradeService,
        ICriticalCompetencesMatchService criticalCompetencesMatchService,
        IApplicantMapper applicantMapper): IApplicantMatchSummaryService
    {
        public IEnumerable<ApplicantMatchSummaryDTO> CreateApplicantsMatchSummary(
            IEnumerable<Candidate> applicants,
            Job job)
        {
            return applicants.Select(applicant =>
            {
                var matchingJobCriticalCompetences = criticalCompetencesMatchService.GetCriticalCompetencesMatch(
                    job.JobCompetences.Where(jc => jc.IsCritical),
                    applicant.Competences);

                var overallMatchGrade = overallMatchGradeService.CalculateOverallMatchGrade(
                    job.JobCompetences,
                    applicant.Competences);

                return applicantMapper.ToApplicantMatchSummaryDto(
                    applicant, 
                    matchingJobCriticalCompetences, 
                    overallMatchGrade);
            });
        }
    }
}
