using JobMatching.Common.Results;
using JobMatching.Domain.Enums;

namespace JobMatching.Domain.Domain.Candidate.Entities
{
    public class CandidateApplication
    {
        public Guid JobApplicationId { get; }
        public Guid JobId { get; }
        public string JobTitle { get; } = string.Empty;
        public ApplicationStatus Status { get; }
        public DateTime ApplicationDate { get; }


        //Create job application
        private CandidateApplication(Guid jobId) => JobId = jobId;

        //Load job applications
        private CandidateApplication(
            Guid jobApplicationId,
            Guid jobId, 
            string jobTitle, 
            ApplicationStatus status, 
            DateTime applicationDate)
        {
            JobId = jobId;
            JobTitle = jobTitle;
            Status = status;
            ApplicationDate = applicationDate;
        }

        public static Result<CandidateApplication> Create(Guid jobId) => jobId == Guid.Empty 
                ? Result<CandidateApplication>.Failure(new Error("Invalid job ID."))
                : Result<CandidateApplication>.Success(new CandidateApplication(jobId));

        public static CandidateApplication Load(
            Guid jobApplicationId,
            Guid jobId,
            string jobTitle,
            ApplicationStatus status,
            DateTime applicationDate)
        {
            return new CandidateApplication(jobApplicationId, jobId, jobTitle, status, applicationDate);
        }
    }
}
