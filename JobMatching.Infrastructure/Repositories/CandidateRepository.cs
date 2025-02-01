using JobMatching.Domain.Domain.Candidate.Entities;
using JobMatching.Domain.Repositories;
using JobMatching.Infrastructure.DataAccess;
using JobMatching.Infrastructure.DataAccess.Entities;
using JobMatching.Infrastructure.QueryExtensions;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.Infrastructure.Repositories;

public class CandidateRepository(AppDbContext appDbContext) : ICandidateRepository
{
    public async Task<IEnumerable<Candidate>> GetAsync(bool withTracking = false)
    {
        return await appDbContext.Candidates
            .AddTracking(withTracking)
            .Include(c => c.JobApplications)
                .ThenInclude(ja => ja.Job)
            .Include(c => c.Languages)
            .Include(c => c.Competences)
                .ThenInclude(comp => comp.Competence)
            .Select(c => ToDomain(c))
            .ToListAsync();
    }

    public async Task<Candidate?> GetByIdAsync(Guid candidateId, bool withTracking = false)
    {
        return await appDbContext.Candidates
            .AddTracking(withTracking)
            .Include(c => c.JobApplications)
                .ThenInclude(ja => ja.Job)
            .Include(c => c.Languages)
            .Include(c => c.Competences)
                .ThenInclude(comp => comp.Competence)
            .Select(c => ToDomain(c))
            .FirstOrDefaultAsync(c => c.Id == candidateId);
    }

    public async Task SaveAsync(Candidate domainCandidate)
    {
        var candidate = ToPersistence(domainCandidate);
        appDbContext.Update(candidate);
        await SaveAsync();
    }

    public async Task SaveAsync() => await appDbContext.SaveChangesAsync();

    private Candidate ToDomain(CandidateEntity candidate)
    {
        return Candidate.Load(candidate.Id,
                candidate.FirstName,
                candidate.LastName,
                candidate.UserId,
                candidate.JobApplications.Select(ja => CandidateApplication.Load(
                    ja.Id, ja.JobId, ja.Job.Title, ja.Status, ja.Created)).ToList(),
                candidate.Languages.Select(l => l.LanguageId).ToList(),
                candidate.Competences.Select(c => c.Competence)
                    .Select(comp => Domain.Domain.Candidate.Entities.CandidateCompetence
                    .Load(comp.Id, comp.Name, comp.CompetenceLevel)).ToList());
    }

    private CandidateEntity ToPersistence(Candidate domainCandidate)
    {
        return new CandidateEntity()
        {
            Id = domainCandidate.Id,
            FirstName = domainCandidate.Name.FirstName,
            LastName = domainCandidate.Name.LastName,
            UserId = domainCandidate.UserId
        };
    }
}