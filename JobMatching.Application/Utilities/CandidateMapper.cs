using JobMatching.Application.DTO.Candidate;
using JobMatching.Application.Interfaces.Mappers;
using JobMatching.Domain.Entities.Candidate;

namespace JobMatching.Application.Utilities
{
    public class CandidateMapper : ICandidateMapper
    {
        public CandidateDTO ToDto(Candidate candidate)
        {
            return new CandidateDTO(
                Id: candidate.Id,
                FullName: candidate.Name.ToString(),
                JobApplication: candidate.Applications.Select(a => new JobApplicationDTO(
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
