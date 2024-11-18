using JobMatching.Application.DTO;
using JobMatching.Domain.Entities;

namespace JobMatching.Application.Interfaces
{
	public interface IUserService
	{
		Task<UserDTO?> GetUserByIdAsync(Guid userId);
		Task<List<UserDTO>> GetUsersAsync();
	}
}
