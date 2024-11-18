using JobMatching.Application.DTO;
using JobMatching.Application.Interfaces;
using JobMatching.Application.Utilities.Mappers;
using JobMatching.Domain.Entities;

namespace JobMatching.Application.Services
{
    public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		
		public UserService(IUserRepository userRepository) 
		{
			_userRepository = userRepository;
		}

		public async Task<UserDTO?> GetUserByIdAsync(Guid userId)
		{
			var user = await _userRepository.GetUserByIdAsync(userId, withTracking: false);

			return UserMapper.Map(user);
		}

		public async Task<List<UserDTO>> GetUsersAsync()
		{
			var users = await _userRepository.GetUsersAsync(withTracking: false);

			return UsersMapper.Map(users)!;	
		}
	}
}
