namespace JobMatching.Infrastructure.Authentication;

public interface ITokenProvider
{
    string Create(User user);
}