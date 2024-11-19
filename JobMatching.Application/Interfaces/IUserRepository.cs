using JobMatching.Domain.Entities;
using System.Runtime.InteropServices;

namespace JobMatching.Application.Interfaces;

public interface IUserRepository
{
    Task<User?> GetUserByIdAsync(Guid userId, bool withTracking = true);
    Task<List<User>> GetUsersAsync(bool withTracking = true);
    Task UpdateUserAsync(User user);
}