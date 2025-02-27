﻿using JobMatching.Domain.Entities;

namespace JobMatching.Application.Interfaces;

public interface IJobRepository
{
	Task<Job?> GetJobByIdAsync(Guid jobId, bool withTracking = true);
	Task<List<Job>> GetByJobTitleAsync(string jobTitle, bool withTracking = true);
	Task<List<Job>> GetJobsAsync(bool withTracking = true);
	Task AddJobAsync(Job job);
	Task UpdateJobAsync(Job job);
    Task<bool> JobExistsAsync(Guid jobId);
}
