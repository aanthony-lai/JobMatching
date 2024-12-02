using JobMatching.Common.SystemMessages.JobApplicationMessages;
using JobMatching.Domain.Enums;
using JobMatching.Domain.Exceptions;
using JobMatching.Domain.Interfaces;
using JobMatching.Domain.ValueObjects;

namespace JobMatching.Domain.Entities
{
    public class JobApplication: IEntity
	{
		public Guid Id { get; init; }
		public Guid CandidateId { get; init; }
		public Candidate Candidate { get; private set; }
		public Guid JobId { get; init; }
		public Job Job { get; private set; } = null!;
		public DateTime ApplicationDate { get; private set; }
		public ApplicationStatus ApplicationStatus { get; private set; }
		public MetaData MetaData { get; private set; } = null!;

		protected JobApplication() { }

		public JobApplication(Candidate candidate, Job job)
		{
			if (candidate is null)
				throw new ArgumentNullException(nameof(candidate),
					"An application must contain an existing candidate.");

			if (job is null)
				throw new ArgumentNullException(nameof(job),
					"An application must contain an existing job.");

			if (candidate.JobApplications.Any(ja => ja.JobId == job.Id))
				throw new DuplicateJobApplicationsException(
					JobApplicationMessages.JobApplicationAlreadyExists(candidate.Name.FirstName));

			Id = Guid.NewGuid();
			Candidate = candidate;
			Job = job;
			ApplicationDate = DateTime.UtcNow;
			ApplicationStatus = ApplicationStatus.Pending;
			MetaData = new MetaData();
		}
	}
}
