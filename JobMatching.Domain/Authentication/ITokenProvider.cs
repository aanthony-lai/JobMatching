using JobMatching.Domain.Entities.User;

namespace JobMatching.Domain.Authentication
{
    public interface ITokenProvider
    {
        string Create(DomainUser user);
    }
}
