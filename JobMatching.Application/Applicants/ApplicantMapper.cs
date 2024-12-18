using JobMatching.Domain.Entities.Candidate;
using JobMatching.Domain.Entities.Job;
using JobMatching.Domain.JobMatchService;

namespace JobMatching.Application.Applicants
{
    public class ApplicantMapper : IApplicantMapper
    {
        public ApplicantsMatchSummaryDTO ToApplicantsMatchSummaryDto(
            Job job, 
            List<ApplicantDTO> applicantsDto)
        {
            return new ApplicantsMatchSummaryDTO(
                job.Id,
                job.JobTitle,
                PreferredCompetences: job.JobCompetences
                    .Where(comp => !comp.IsCritical)
                    .Select(comp => comp.CompetenceName)
                    .ToList(),
                CriticalCompetences: job.JobCompetences
                    .Where(comp => comp.IsCritical)
                    .Select(comp => comp.CompetenceName)
                    .ToList(),
                Applicants: applicantsDto);
            //Applicants: applicants.Select(applicant => new ApplicantDTO(
            //    ApplicantId: applicant.Id,
            //    FullName: applicant.Name.FullName,
            //    Competences: applicant.CandidateCompetences.Select(comp => comp.CompetenceName).ToList(),
            //    MatchedCriticalCompetences: matchedCriticalCompetences,
            //    MatchGrade: matchGrade)).ToList());
        }

        public List<ApplicantDTO> ToApplicantsDto(
            List<Candidate> applicants,
            List<CriticalCompetenceMatch> matchedCriticalCompetences,
            decimal matchGrade)
        {
            return applicants.Select(applicant => new ApplicantDTO(
                    ApplicantId: applicant.Id,
                    FullName: applicant.Name.FullName,
                    Competences: applicant.CandidateCompetences.Select(comp => comp.CompetenceName).ToList(),
                    MatchedCriticalCompetences: matchedCriticalCompetences,
                    MatchGrade: matchGrade)).ToList();
        }
    }
}
