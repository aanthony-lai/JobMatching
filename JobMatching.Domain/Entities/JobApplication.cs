using JobMatching.Domain.Enums;

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
				throw new ArgumentException(nameof(candidateId), 
					"An application must contain a valid Candidate Id.");

			if (jobId == Guid.Empty)
				throw new ArgumentException(nameof(JobId),
					"An application must contain a valid Job ID.");

			CandidateId = candidateId;
			JobId = jobId;
			JobApplicationId = Guid.NewGuid();
			ApplicationDate = DateTime.UtcNow;
			ApplicationStatus = ApplicationStatus.Pending;
		}
	}
}
