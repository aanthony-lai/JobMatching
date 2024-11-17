using JobMatching.Application.UserManagement.Interfaces;
using JobMatching.Domain.Entities;

namespace JobMatching.Application.UserManagement;

public class UserService: IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User?> GetUserByIdAsync(Guid userId)
    {
        var user = await _userRepository.GetUserByIdAsync(userId);
        return user;
    }

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        var users = await _userRepository.GetUsersAsync();
        return users;
    }
}