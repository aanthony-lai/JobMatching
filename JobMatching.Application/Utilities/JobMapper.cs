using JobMatching.Application.DTO.Job;
using JobMatching.Domain.Domain.Job.Entities;

namespace JobMatching.Application.Utilities
{
    public class JobMapper : IJobMapper
    {
        public JobDTO MapToJobDto(Job domainJob) => 
            new JobDTO(
                JobId: domainJob.Id,
                Title: domainJob.JobTitle,
                JobDescription: domainJob.Description,
                MaxSalary: domainJob.Salary.MaxSalary,
                MinSalary: domainJob.Salary.MinSalary,
                PreferredCompetences: domainJob.JobCompetences.Where(c => !c.IsCritical).Select(c => c.CompetenceId).ToList(),
                CriticalCompetences: domainJob.JobCompetences.Where(c => c.IsCritical).Select(c => c.CompetenceId).ToList(),
                Applicants: domainJob.ApplicantIds.Select(id => id).ToList(),
                EmployerId: domainJob.EmployerId);
    }
}
