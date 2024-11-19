using JobMatching.Application.DTO;

namespace JobMatching.Application.Interfaces
{
	public interface IUserService
	{
		Task<UserDTO?> GetUserByIdAsync(Guid userId);
		Task<List<UserDTO>> GetUsersAsync();
		Task AddUserCompetence(AddUserCompetenceDTO addUserCompetenceDto);
	}
}
