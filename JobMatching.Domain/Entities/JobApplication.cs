using JobMatching.Domain.Enums;

namespace JobMatching.Domain.Entities
{
	public class JobApplication
	{
		private Guid _candidateId;
		private Guid _jobId;

		public Guid JobApplicationId { get; init; }
		public Guid CandidateId
		{
			get => _candidateId;
			private set
			{
				if (value == Guid.Empty)
					throw new ArgumentException(
						"An application must contain a valid Candidate Id.",
						nameof(CandidateId));
				_candidateId = value;
			}
		}
		public Candidate Candidate { get; private set; }
		public Guid JobId
		{
			get => _jobId;
			private set
			{
				if (value == Guid.Empty)
					throw new ArgumentException(
						"An application must contain a valid Job ID.",
						nameof(JobId));

				_jobId = value;
			}
		}
		public Job Job { get; private set; } = null!;
		public DateTime ApplicationDate { get; private set; }
		public ApplicationStatus ApplicationStatus { get; private set; }

		protected JobApplication() { }

		public JobApplication(Guid candidateId, Guid jobId)
		{
			CandidateId = candidateId;
			JobId = jobId;
			JobApplicationId = Guid.NewGuid();
			ApplicationDate = DateTime.UtcNow;
			ApplicationStatus = ApplicationStatus.Pending;
		}
	}
}
