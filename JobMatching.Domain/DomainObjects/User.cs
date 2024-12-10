using JobMatching.Common.Results;
using JobMatching.Domain.Interfaces;
using JobMatching.Domain.Types;
using JobMatching.Domain.ValueObjects;

namespace JobMatching.Domain.Entities
{
    public class User : IEntity
    {
        public Guid Id { get; init; }
        public string Name { get; private set; } = null!;
        public Email Email { get; private set; } = null!;
        public UserType UserType { get; init; }
        public MetaData MetaData { get; private set; } = null!;

        protected User() { }
        private User(Email email, string name, UserType userType)
        {
            Id = Guid.NewGuid();
            Email = email;
            Name = name;
            UserType = userType;
            MetaData = new MetaData();
        }

        public static Result<User> Create(string email, string name, UserType userType)
        {
            var emailResult = Email.SetEmail(email);

            if (!emailResult.IsSuccess)
                return emailResult.Error;

            return Result<User>.Success(new User(emailResult.Value, name, userType));
        }

        public Result SetEmail(string email)
        {
            var emailResult = Email.SetEmail(email);

            if (!emailResult.IsSuccess)
                return Result.Failure(emailResult.Error);

            return Result.Success();
        }
    }
}
