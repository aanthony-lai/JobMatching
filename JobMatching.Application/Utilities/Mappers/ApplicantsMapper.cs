using JobMatching.Application.DTO;
using JobMatching.Domain.Entities;

namespace JobMatching.Application.Utilities.Mappers
{
    public static class ApplicantsMapper
    {
        public static List<ApplicantDTO> Map(List<JobApplication> applications)
        {
            return applications.Select(application => new ApplicantDTO(
                applicationId: application.ApplicationId,
                userId: application.UserId,
                firstName: application.User.UserName.FirstName,
                lastName: application.User.UserName.LastName,
                applicationDate: application.ApplicationDate,
                applicationStatus: application.ApplicationStatus))
                .ToList();
        }
    }
}
