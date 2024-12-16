﻿using JobMatching.Application.DTO.Employer;
using JobMatching.Application.Interfaces.Mappers;
using JobMatching.Domain.Entities.Employer;

namespace JobMatching.Application.Utilities
{
    public class EmployerMapper : IEmployerMapper
    {
        public EmployerDTO ToDto(Employer employer)
        {
            return new EmployerDTO(
                Name: employer.Name,
                Jobs: employer.EmployerJobs.Select(j => j.JobId).ToList());
        }
    }
}
