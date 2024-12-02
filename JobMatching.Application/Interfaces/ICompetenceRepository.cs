using JobMatching.Domain.Entities;

namespace JobMatching.Application.Interfaces;

public interface ICompetenceRepository
{
	Task<List<Competence>> GetCompetencesAsync(bool withTracking = true);
}
