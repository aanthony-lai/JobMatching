using JobMatching.Application.DTO.Employer;
using JobMatching.Domain.Entities;

namespace JobMatching.Application.Utilities
{
	public static class JobMapper
	{
		public static JobDTO MapJob(Job job)
		{
			if (job is null)
				throw new ArgumentNullException("Cannot map null to JobDTO.", nameof(job));

			return new JobDTO(
				jobId: job.JobId,
				jobTitle: job.JobTitle,
				salaryRangeTop: job.SalaryRange.SalaryRangeTop,
				salaryRangeBottom: job.SalaryRange.SalaryRangeBottom,
				competences: CompetenceMapper.MapCompetences(job.Competences));
		}

		public static List<JobDTO> MapJobs(List<Job> jobs) => 
			jobs.Select(MapJob).ToList();
	}
}
