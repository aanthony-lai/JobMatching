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
				candidateId: candidate.Id,
				firstName: candidate.FullName.FirstName,
				lastName: candidate.FullName.LastName,
				competences: CompetenceMapper.MapCompetences(candidate.Competences));
		}

		public static List<CandidateDTO> MapCandidates(List<Candidate> candidates) => 
			candidates.Select(MapCandidate).ToList();
	}
}
