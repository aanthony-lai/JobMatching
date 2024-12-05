using JobMatching.Application.DTO.Job;
using JobMatching.Domain.Entities;
using JobMatching.Domain.Entities.JunctionEntities;
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
				JobId: job.Id,
				JobTitle: job.JobTitle,
				SalaryRangeTop: job.SalaryRange.SalaryRangeTop,
				SalaryRangeBottom: job.SalaryRange.SalaryRangeBottom,
				EmployerName: job.Employer.Name.EmployerName!,
				CriticalCompetences: job.JobCompetences
					.Where(jobComp => jobComp.IsCritical)
					.Select(jobComp => jobComp.Competence.CompetenceName).ToArray(),
				NonCriticalCompetences: job.JobCompetences
					.Where(jobComp => !jobComp.IsCritical)
					.Select(jobComp => jobComp.Competence.CompetenceName).ToArray());
		}

		public static List<JobDTO> MapJobs(List<Job> jobs) => 
			jobs.Select(MapJob).ToList();
	}
}
