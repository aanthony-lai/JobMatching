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
				JobId: job.Id,
				JobTitle: job.JobTitle,
				SalaryRangeTop: job.SalaryRange.SalaryRangeTop,
				SalaryRangeBottom: job.SalaryRange.SalaryRangeBottom,
				CriticalCompetences: job.JobCompetences
					.Where(comp => comp.IsCritical)
					.Select(comp => comp.Competence.CompetenceName).ToArray(),
				NonCriticalCompetences: job.JobCompetences
					.Where(comp => !comp.IsCritical)
					.Select(comp => comp.Competence.CompetenceName).ToArray());
		}

		public static List<EmployerJobDTO> MapJobs(List<Job> jobs) => 
			jobs.Select(MapEmployerJob).ToList();
	}
}
