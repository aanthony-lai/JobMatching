using System.ComponentModel.DataAnnotations;

namespace JobMatching.Domain.Authentication.Registration;

public class RegisterUserModel : IValidatableObject
{
    public string UserName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LasName { get; set; } = string.Empty;
    public string EmployerName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public UserType UserType { get; set; }


    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrWhiteSpace(FirstName))
            yield return new ValidationResult("Name can't be empty.", [nameof(FirstName)]);

        if (string.IsNullOrWhiteSpace(LasName))
            yield return new ValidationResult("Invalid email.", [nameof(LasName)]);

        if (string.IsNullOrWhiteSpace(Password))
            yield return new ValidationResult("Passoword can't be empt", [nameof(Password)]);

        if (string.IsNullOrWhiteSpace(Email))
            yield return new ValidationResult("Passoword can't be empt", [nameof(Email)]);

        //Employer validation should be added.
    }
}