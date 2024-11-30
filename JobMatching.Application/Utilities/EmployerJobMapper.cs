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
				criticalCompetences: CompetenceMapper.MapJobCompetences(job.JobCompetences.Where(comp => comp.IsCritical).ToList()),
				nonCriticalCompetences: CompetenceMapper.MapJobCompetences(job.JobCompetences.Where(comp => !comp.IsCritical).ToList()));
		}

		public static List<EmployerJobDTO> MapJobs(List<Job> jobs) => 
			jobs.Select(MapEmployerJob).ToList();
	}
}
