using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace JobMatching.Domain.Authentication
{
    public sealed class DomainUser: IValidatableObject
    {
        private const string ErrorMessage = "Invalid credentials";

        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Password))
                yield return new ValidationResult(ErrorMessage);
        }
    }
}
