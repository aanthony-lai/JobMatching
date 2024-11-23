using JobMatching.Application.DTO;
using JobMatching.Domain.Entities;

namespace JobMatching.Application.Utilities.Mappers
{
    public static class UserMapper
    {
        public static UserDTO? Map(User user)
        {
            if (user is null)
                throw new ArgumentNullException("Cannot map null to UserDTO.", nameof(user));

			return new UserDTO(
                userId: user.UserId,
                firstName: user.UserName.FirstName,
                lastName: user.UserName.LastName,
                competences: CompetencesMapper.Map(user.Competences),
                applications: JobApplicationsMapper.Map(user.Applications));
        }
    }
}
