using JobMatching.Domain.Entities;

namespace JobMatching.Application.UserManagement.Interfaces;

public interface IUserRepository
{
    Task<User?> GetUserByIdAsync(Guid userId);
    Task<IEnumerable<User>> GetUsersAsync();
}