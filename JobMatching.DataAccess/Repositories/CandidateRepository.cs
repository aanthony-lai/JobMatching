using JobMatching.Application.Interfaces;
using JobMatching.DataAccess.Context;
using JobMatching.DataAccess.QueryExtensions;
using JobMatching.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.DataAccess.Repositories;

public class CandidateRepository : ICandidateRepository
{
	private readonly AppDbContext _appDbContext;

	public CandidateRepository(AppDbContext appDbContext)
	{
		_appDbContext = appDbContext;
	}

	public async Task<Candidate?> GetCandidateByIdAsync(Guid candidateId, bool withTracking = true)
	{
		return await _appDbContext.Candidates
			.AddTracking(withTracking)
			.Include(c => c.Competences)
			.Include(c => c.JobApplications)
			.Include(c => c.Languages)
				.ThenInclude(lan => lan.Language)
			.FirstOrDefaultAsync(u => u.Id == candidateId);
	}

	public async Task<List<Candidate>> GetCandidatesAsync(bool withTracking = true)
	{
		return await _appDbContext.Candidates
			.AddTracking(withTracking)
			.Include(c => c.Competences)
			.Include(c => c.JobApplications)
			.Include(c => c.Languages)
				.ThenInclude(lan => lan.Language)
			.ToListAsync();
	}

	public async Task SaveCandidateAsync(Candidate candidate)
	{
		await _appDbContext.Candidates.AddAsync(candidate);
		await _appDbContext.SaveChangesAsync();
	}

	public async Task UpdateCandidateAsync(Candidate candidate)
	{
		candidate.MetaData.SetUpdatedAt();
		_appDbContext.Candidates.Update(candidate);
		await _appDbContext.SaveChangesAsync();
	}

	public async Task<bool> CandidateExistsAsync(Guid candidateId)
	{
		return await _appDbContext.Candidates.AnyAsync(c => c.Id == candidateId);
	}
}