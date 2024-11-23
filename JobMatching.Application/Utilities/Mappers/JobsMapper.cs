using JobMatching.Application.DTO;
using JobMatching.Domain.Entities;

namespace JobMatching.Application.Utilities.Mappers
{
	public static class JobsMapper
	{
		public static List<JobDTO> Map(List<Job> jobs)
		{
			return jobs.Select(job => new JobDTO(
				jobId: job.JobId,
				jobTitle: job.JobTitle,
				salaryTop: job.JobSalaryRange.SalaryRangeTop,
				salaryBottom: job.JobSalaryRange.SalaryRangeBottom,
				employerName: job.Employer.EmployerName,
				competencesDto: CompetencesMapper.Map(job.Competences)))
				.ToList();
		}
	}
}
