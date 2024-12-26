namespace JobMatching.Domain.Authentication
{
    public interface ITokenProvider
    {
        string Create(LoginUserModel userModel);
    }
}
