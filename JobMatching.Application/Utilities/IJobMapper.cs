using JobMatching.Application.DTO.Job;
using JobMatching.Domain.Domain.Job.Entities;

namespace JobMatching.Application.Utilities
{
    public interface IJobMapper
    {
        JobDTO MapToJobDto(Job job);
    }
}
