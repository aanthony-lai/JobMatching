using JobMatching.Application.DTO;
using JobMatching.Domain.Entities;

namespace JobMatching.Application.Utilities.Mappers
{
    public static class EmployerJobsMapper
    {
        public static List<EmployerJobDTO> Map(List<Job> jobs)
        {
            return jobs.Select(job => new EmployerJobDTO(
                jobId: job.JobId,
                jobTitle: job.JobTitle,
                salaryTop: job.JobSalaryRange.SalaryRangeTop,
                salaryBottom: job.JobSalaryRange.SalaryRangeBottom,
                competences: CompetencesMapper.Map(job.Competences),
                applicants: ApplicantsMapper.Map(job.Applications)))
                .ToList();
        }
    }
}
