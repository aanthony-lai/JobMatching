using JobMatching.Application.DTO.Job;
using JobMatching.Domain.Entities;
using System.Threading.Tasks.Dataflow;

namespace JobMatching.Application.Utilities
{
	public static class JobMapper
	{
		public static JobDTO MapJob(Job job)
		{
			if (job is null)
				throw new ArgumentNullException("Cannot map null to JobDTO", nameof(job));

			return new JobDTO(
				jobId: job.JobId,
				jobTitle: job.JobTitle,
				salaryRangeTop: job.SalaryRange.SalaryRangeTop,
				salaryRangeBottom: job.SalaryRange.SalaryRangeBottom,
				employerName: job.Employer.Name,
				competences: CompetenceMapper.MapJobCompetences(job.JobCompetences));
		}

		public static List<JobDTO> MapJobs(List<Job> jobs) => 
			jobs.Select(MapJob).ToList();
	}
}
