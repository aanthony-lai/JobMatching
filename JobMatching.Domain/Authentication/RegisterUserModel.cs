using System.ComponentModel.DataAnnotations;

namespace JobMatching.Domain.Authentication;

public class RegisterUserModel: IValidatableObject
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrWhiteSpace(Name))
            yield return new ValidationResult("Name can't be empty.", new[] {nameof(Name)});
        
        if (string.IsNullOrWhiteSpace(Email) ||
            !Email.Contains("@"))
            yield return new ValidationResult("Invalid email.", new[] {nameof(Email)});
        
        if (string.IsNullOrWhiteSpace(Password))
            yield return new ValidationResult("Passoword can't be empt", new[] {nameof(Name)});
    }
}