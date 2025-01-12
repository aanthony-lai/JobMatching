using JobMatching.Application.DTO.Job;
using JobMatching.Domain.Entities.Job;

namespace JobMatching.Application.Utilities
{
    public interface IJobMapper
    {
        JobDTO MapToJobDto(Job job);
    }
}
