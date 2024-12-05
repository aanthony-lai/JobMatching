using JobMatching.Application.DTO.Candidate;
using JobMatching.Domain.Entities;

namespace JobMatching.Application.Utilities
{
    public static class CandidateMapper
	{
		public static CandidateDTO MapCandidate(Candidate candidate)
		{
			if (candidate is null)
				throw new ArgumentNullException("Cannot map null to CandidateDTO.", nameof(candidate));

			return new CandidateDTO(
				CandidateId: candidate.Id,
				FirstName: candidate.Name.FirstName,
				LastName: candidate.Name.LastName,
				//Competences: CompetenceMapper.MapCompetences(candidate.Competences),
				Competences: candidate.Competences.Select(comp => comp.CompetenceName).ToArray(),
				JobApplications: candidate.JobApplications.Select(
					ja => new CandidateJobApplicationsDTO(
						ja.Id, 
						ja.Job.Employer.GetName(), 
						ja.Job.JobTitle)).ToList(),
				Languages: candidate.Languages.Select(
					language => new CandidateLanguageDTO(
						language.Language.Name, 
						language.ProficiencyLevel.ToString())).ToList(),
				HasDriversLicense: candidate.HasDriversLicence);
		}

		public static List<CandidateDTO> MapCandidates(List<Candidate> candidates) => 
			candidates.Select(MapCandidate).ToList();
	}
}
