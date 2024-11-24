using JobMatching.Application.DTO.Employer;
using JobMatching.Domain.Entities;

namespace JobMatching.Application.Utilities
{
	public static class EmployerJobMapper
	{
		public static EmployerJobDTO MapEmployerJob(Job job)
		{
			if (job is null)
				throw new ArgumentNullException("Cannot map null to EmployerJobDTO.", nameof(job));

			return new EmployerJobDTO(
				jobId: job.JobId,
				jobTitle: job.JobTitle,
				salaryRangeTop: job.SalaryRange.SalaryRangeTop,
				salaryRangeBottom: job.SalaryRange.SalaryRangeBottom,
				competences: CompetenceMapper.MapCompetences(job.Competences));
		}

		public static List<EmployerJobDTO> MapJobs(List<Job> jobs) => 
			jobs.Select(MapEmployerJob).ToList();
	}
}
