using JobMatching.Application.Interfaces;
using JobMatching.DataAccess.Context;
using JobMatching.DataAccess.QueryExtensions;
using JobMatching.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.DataAccess.Repositories
{
    public class CompetenceRepository : ICompetenceRepository
	{
		private readonly AppDbContext _appDbContext;

		public CompetenceRepository(AppDbContext appDbContext) 
		{
			_appDbContext = appDbContext;
		}

		public async Task<List<Competence>> GetCompetencesAsync(bool withTracking = true)
		{
			return await _appDbContext.Competences
				.AddTracking(withTracking)
				.ToListAsync();
		}

		public async Task<Competence?> GetCompetenceByIdAsync(Guid competenceId, bool withTracking = true)
		{
			
			return await _appDbContext.Competences
				.AddTracking(withTracking)
				.FirstOrDefaultAsync(c => c.CompetenceId == competenceId);
		}
	}
}
