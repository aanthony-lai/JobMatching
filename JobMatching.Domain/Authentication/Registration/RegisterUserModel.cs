using JobMatching.Domain.Entities.User;
using System.ComponentModel.DataAnnotations;

namespace JobMatching.Domain.Authentication.Registration;

public sealed record RegisterUserModel(
    string FirstName,
    string LastName,
    string EmployerName,
    string Password,
    string Email,
    UserType UserType) : IValidatableObject
{
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (UserType == UserType.Candidate)
        {
            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName))
                yield return new ValidationResult("First and last name can't be empty",
                    [nameof(FirstName), nameof(LastName)]);
        }
        else
        {
            if (string.IsNullOrWhiteSpace(EmployerName))
                yield return new ValidationResult("Employer name can't be empty",
                    [nameof(EmployerName)]);
        }

        if (string.IsNullOrWhiteSpace(Password))
            yield return new ValidationResult("Passoword can't be empt", [nameof(Password)]);

        if (string.IsNullOrWhiteSpace(Email))
            yield return new ValidationResult("Passoword can't be empt", [nameof(Email)]);
    }
}