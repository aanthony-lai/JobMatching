using JobMatching.Application.DTO.Candidate;
using JobMatching.Domain.Entities.Candidate;

namespace JobMatching.Application.Candidates
{
    public class CandidateMapper : ICandidateMapper
    {
        public CandidateDTO ToCandidateDto(Candidate candidate)
        {
            return new CandidateDTO(
                Id: candidate.Id,
                FullName: candidate.Name.ToString(),
                JobApplication: candidate.JobApplications.Select(a => new JobApplicationDTO(
                    JobId: a.JobId,
                    Status: a.Status,
                    ApplicationDate: a.ApplicationDate)).ToList(),
                LanguageSkills: candidate.CandidateLanguages.Select(lang => new CandidateLanguageDTO(
                    LanguageId: lang.LanguageId,
                    ProficiencyLevel: lang.ProficiencyLevel)).ToList(),
                Competences: candidate.CandidateCompetences.Select(comp => new CandidateCompetenceDTO(
                    CompetenceId: comp.CompetenceId,
                    CompetenceLevel: comp.CompetenceLevel)).ToList());
        }
    }
}
