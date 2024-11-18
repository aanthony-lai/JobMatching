using JobMatching.Application.DTO;
using JobMatching.Domain.Entities;

namespace JobMatching.Application.Utilities.Mappers
{
    public static class UserJobMapper
    {
        public static UserJobDTO? Map(Job job)
        {
            if (job is null)
                throw new ArgumentNullException("Cannot map null to UserJobDTO", nameof(job));

            return new UserJobDTO(
                jobId: job.JobId,
                jobTitle: job.JobTitle,
                salaryTop: job.JobSalaryRange.SalaryRangeTop,
                salaryBottom: job.JobSalaryRange.SalaryRangeBottom,
                employerName: job.Employer.EmployerName,
                competences: CompetencesMapper.Map(job.Competences));
        }
    }
}
