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

		public async Task<Competence?> GetByIdAsync(Guid competenceId, bool withTracking = true)
		{
			return await _appDbContext.Competences
				.AddTracking(withTracking)
				.FirstOrDefaultAsync(comp => comp.Id == competenceId);
		}

		public async Task<List<Competence>> GetAllAsync(bool withTracking = true)
		{
			return await _appDbContext.Competences
				.AddTracking(withTracking)
				.ToListAsync();
		}

		public async Task<bool> ExistsAsync(Guid competenceId) =>
			await _appDbContext.Competences.AnyAsync(comp => comp.Id == competenceId);
	}
}
