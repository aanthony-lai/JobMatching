using JobMatching.Application.DTO.Job;
using JobMatching.Domain.Entities.Job;

namespace JobMatching.Application.Interfaces.Mappers
{
    public interface IJobMapper
    {
        JobDTO MapToJobDto(Job job);
    }
}
