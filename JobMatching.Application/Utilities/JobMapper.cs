﻿using JobMatching.Application.DTO.Job;
using JobMatching.Application.Interfaces.Mappers;
using JobMatching.Domain.Entities.Job;

namespace JobMatching.Application.Utilities
{
    public class JobMapper : IJobMapper
    {
        public JobDTO ToDto(Job job)
        {
            return new JobDTO(
                JobId: job.Id,
                Title: job.JobTitle,
                JobDescription: job.Description,
                MaxSalary: job.Salary.MaxSalary,
                MinSalary: job.Salary.MinSalary,
                PreferredCompetences: job.JobCompetences.Where(c => !c.IsCritical).Select(c => c.CompetenceId).ToList(),
                CriticalCompetences: job.JobCompetences.Where(c => c.IsCritical).Select(c => c.CompetenceId).ToList(),
                Applicants: job.Applicants.Select(a => a.CandidateId).ToList(),
                EmployerId: job.EmployerId);
        }
    }
}
