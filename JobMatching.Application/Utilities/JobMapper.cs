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
				JobTitle: job.Title,
				SalaryRangeTop: job.Salary.MaxSalary,
				SalaryRangeBottom: job.Salary.MinSalary,
				EmployerName: job.Employer.Name,
				CriticalCompetences: job.JobCompetences
					.Where(jobComp => jobComp.IsCritical)
					.Select(jobComp => jobComp.Competence.Name).ToArray(),
				NonCriticalCompetences: job.JobCompetences
					.Where(jobComp => !jobComp.IsCritical)
					.Select(jobComp => jobComp.Competence.Name).ToArray());
		}

		public static List<JobDTO> MapJobs(List<Job> jobs) => 
			jobs.Select(MapJob).ToList();
	}
}
