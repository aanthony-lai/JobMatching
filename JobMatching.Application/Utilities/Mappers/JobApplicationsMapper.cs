using JobMatching.Application.DTO;
using JobMatching.Domain.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace JobMatching.Application.Utilities.Mappers
{
    public class JobApplicationsMapper
    {
        public static List<JobApplicationDTO> Map(List<JobApplication> applications)
        {
            return applications.Select(application => new JobApplicationDTO(
                applicationId: application.ApplicationId,
                job: UserJobMapper.Map(application.Job),
                applicationDate: application.ApplicationDate,
                applicationStatus: application.ApplicationStatus))
                .ToList();
        }
    }
}
