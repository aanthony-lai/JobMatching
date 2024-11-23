using JobMatching.Application.DTO;
using JobMatching.Domain.Entities;

namespace JobMatching.Application.Utilities.Mappers
{
    public static class UsersMapper
    {
        public static List<UserDTO?> Map(List<User> users)
        {
			return users.Select(UserMapper.Map).ToList();
        }
    }
}
