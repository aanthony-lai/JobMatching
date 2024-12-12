using JobMatching.Common.Exceptions;
using JobMatching.DataAccess.Context;
using JobMatching.DataAccess.QueryExtensions;
using JobMatching.Domain.Entities;
using JobMatching.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobMatching.DataAccess.Repositories
{
    public class JobApplicationRepository : IJobApplicationRepository
    {
        private readonly AppDbContext _appDbContext;

        public JobApplicationRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<JobApplication>> GetJobApplicationsByCandidateIdAsync(Guid candidateId, bool withTracking = true)
        {
            return await _appDbContext.JobApplications
                .AddTracking(withTracking)
                .Where(a => a.CandidateId == candidateId)
                .Include(a => a.Candidate.Competences)
                .Include(a => a.Candidate.Languages)
                    .ThenInclude(l => l.Language)
                .Include(a => a.Job.Employer)
                .Include(a => a.Job.JobCompetences)
                    .ThenInclude(jc => jc.Competence)
                .AsSplitQuery()
                .ToListAsync();
        }

        //Should maybe be moved to an individual class?
        public async Task<List<JobApplication>> GetJobApplicationsByJobIdAsync(Guid jobId, bool withTracking = true)
        {
            return await _appDbContext.JobApplications
                .AddTracking(withTracking)
                .Where(a => a.JobId == jobId)
                .Include(a => a.Candidate.Competences)
                .Include(a => a.Candidate.Languages)
                    .ThenInclude(l => l.Language)
                .Include(a => a.Job.Employer)
                .Include(a => a.Job.JobCompetences)
                    .ThenInclude(jc => jc.Competence)
                .AsSplitQuery()
                .ToListAsync();
        }

        //Should be removed later
        public async Task<List<JobApplication>> GetJobApplicationsAsync(bool withTracking = true)
        {
            return await _appDbContext.JobApplications
                .AddTracking(withTracking)
                .Include(a => a.Candidate.Competences)
                .Include(a => a.Candidate.Languages)
                    .ThenInclude(l => l.Language)
                .Include(a => a.Job.Employer)
                .Include(a => a.Job.JobCompetences)
                    .ThenInclude(jc => jc.Competence)
                .AsSplitQuery()
                .ToListAsync();
        }

        public async Task AddJobApplicationAsync(JobApplication jobApplication)
        {
            jobApplication.MetaData.SetUpdatedAt();

            if (_appDbContext.JobApplications.Any(
                ja => ja.CandidateId == jobApplication.CandidateId
                && ja.JobId == jobApplication.JobId))
            {
                throw new EntityAlreadyExistException("Candidate has already applied for this job.");
            }

            await _appDbContext.JobApplications.AddAsync(jobApplication);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
