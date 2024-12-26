using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using JobMatching.Domain.Entities.Candidate;

namespace JobMatching.Domain.Authentication
{
    public sealed class LoginUserModel: IValidatableObject
    {
        private const string ErrorMessage = "Invalid credentials";

        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Password))
                yield return new ValidationResult(ErrorMessage);
        }
    }
}
