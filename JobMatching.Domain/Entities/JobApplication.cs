using JobMatching.Common.SystemMessages.JobApplicationMessages;
using JobMatching.Domain.Enums;
using JobMatching.Domain.Exceptions;

namespace JobMatching.Domain.Entities
{
	public class JobApplication
	{
		public Guid JobApplicationId { get; init; }
		public Guid CandidateId { get; init; }
		public Candidate Candidate { get; private set; }
		public Guid JobId { get; init; }
		public Job Job { get; private set; } = null!;
		public DateTime ApplicationDate { get; private set; }
		public ApplicationStatus ApplicationStatus { get; private set; }

		protected JobApplication() { }

		public JobApplication(Guid candidateId, Guid jobId)
		{
			if (candidateId == Guid.Empty)
				throw new ArgumentNullException(nameof(candidateId),
					"An application must contain a valid candidate ID.");

			if (jobId == Guid.Empty)
				throw new ArgumentNullException(nameof(jobId),
					"An application must contain a valid job ID.");

			//if (candidate.JobApplications.Any(ja => ja.JobId == job.JobId))
			//	throw new DuplicateJobApplicationsException(
			//		JobApplicationMessages.JobApplicationAlreadyExists(candidate.Name.FirstName));

			JobApplicationId = Guid.NewGuid();
			CandidateId = candidateId;
			JobId = jobId;
			ApplicationDate = DateTime.UtcNow;
			ApplicationStatus = ApplicationStatus.Pending;
		}

		public JobApplication(Candidate candidate, Job job)
		{
			if (candidate is null)
				throw new ArgumentNullException(nameof(candidate),
					"An application must contain an existing candidate.");

			if (job is null)
				throw new ArgumentNullException(nameof(job),
					"An application must contain an existing job.");

			if (candidate.JobApplications.Any(ja => ja.JobId == job.JobId))
				throw new DuplicateJobApplicationsException(
					JobApplicationMessages.JobApplicationAlreadyExists(candidate.Name.FirstName));

			JobApplicationId = Guid.NewGuid();
			Candidate = candidate;
			Job = job;
			ApplicationDate = DateTime.UtcNow;
			ApplicationStatus = ApplicationStatus.Pending;
		}
	}
}
