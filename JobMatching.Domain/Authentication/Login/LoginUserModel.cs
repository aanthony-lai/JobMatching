using System.ComponentModel.DataAnnotations;

namespace JobMatching.Domain.Authentication.Login
{
    public sealed class LoginUserModel : IValidatableObject
    {
        private const string ErrorMessage = "Invalid credentials";

        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(UserName))
                yield return new ValidationResult(ErrorMessage);
        }
    }
}
