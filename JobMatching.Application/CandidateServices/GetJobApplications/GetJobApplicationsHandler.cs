using JobMatching.Common.Results;
using JobMatching.Domain.Errors;
using JobMatching.Domain.Repositories;
using MediatR;

namespace JobMatching.Application.CandidateServices.GetJobApplications
{
    public sealed class GetJobApplicationsHandler : IRequestHandler<GetJobApplicationsRequest, Result<IEnumerable<JobApplicationDTO>>>
    {
        private readonly ICandidateRepository _candidateRepository;

        public GetJobApplicationsHandler(
            ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<Result<IEnumerable<JobApplicationDTO>>> Handle(
            GetJobApplicationsRequest request, 
            CancellationToken cancellationToken)
        {
            var candidate = await _candidateRepository.GetByIdAsync(request.CandidateId);

            if (candidate is null)
                return Result<IEnumerable<JobApplicationDTO>>.Failure(CandidateErrors.NotFound(request.CandidateId));

            return candidate.JobApplications
                .Select(j => new JobApplicationDTO(
                    j.JobId, 
                    j.Status, 
                    j.ApplicationDate))
                .ToList();
        }
    }
}
