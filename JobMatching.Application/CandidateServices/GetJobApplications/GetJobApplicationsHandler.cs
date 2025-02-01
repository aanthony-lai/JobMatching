using JobMatching.Common.Results;
using JobMatching.Domain.Errors;
using JobMatching.Domain.Repositories;
using MediatR;

namespace JobMatching.Application.CandidateServices.GetJobApplications
{
    public sealed class GetJobApplicationsHandler(
        ICandidateRepository candidateRepository) : IRequestHandler<GetJobApplicationsRequest, Result<IEnumerable<JobApplicationDTO>>>
    {
        public async Task<Result<IEnumerable<JobApplicationDTO>>> Handle(
            GetJobApplicationsRequest request, 
            CancellationToken cancellationToken)
        {
            var candidate = await candidateRepository.GetByIdAsync(request.CandidateId);

            if (candidate is null)
                return Result<IEnumerable<JobApplicationDTO>>.Failure(CandidateErrors.NotFound(request.CandidateId));

            return candidate.Applications
                .Select(j => new JobApplicationDTO(
                    j.JobId, 
                    j.Status, 
                    j.ApplicationDate)).ToList();
        }
    }
}
