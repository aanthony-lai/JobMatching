using JobMatching.Application.DTO;
using JobMatching.Application.Exceptions;
using JobMatching.Application.Interfaces;
using JobMatching.Application.Utilities.Mappers;

namespace JobMatching.Application.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly ICompetenceRepository _competenceRepository;

		public UserService(
			IUserRepository userRepository, 
			ICompetenceRepository competenceRepository)
		{
			_userRepository = userRepository;
			_competenceRepository = competenceRepository;
		}

		public async Task<UserDTO?> GetUserByIdAsync(Guid userId)
		{
			var user = await _userRepository.GetUserByIdAsync(userId, withTracking: false);

			if (user == null) 
				return null;

			return UserMapper.Map(user);
		}

		public async Task<List<UserDTO>> GetUsersAsync()
		{
			var users = await _userRepository.GetUsersAsync(withTracking: false);

			return UsersMapper.Map(users)!;
		}

		public async Task AddUserCompetence(AddUserCompetenceDTO addUserCompetenceDto)
		{
			var user = await _userRepository.GetUserByIdAsync(addUserCompetenceDto.UserId)
				?? throw new UserNotFoundException($"User with ID {addUserCompetenceDto.UserId} was not found.");

			var competence = await _competenceRepository.GetCompetenceByIdAsync(addUserCompetenceDto.CompetenceId)
				?? throw new CompetenceNotFoundException($"Competence with ID {addUserCompetenceDto.CompetenceId} was not found.");
			
			user.AddCompetence(competence);

			await _userRepository.UpdateUserAsync(user);
		}
	}
}
