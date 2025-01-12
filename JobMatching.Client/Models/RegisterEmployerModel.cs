using JobMatching.Client.Types;
using System.ComponentModel.DataAnnotations;

namespace JobMatching.Client.Models
{
    public class RegisterEmployerModel: RegisterUserModel
    {
        [Required]
        [StringLength(20, ErrorMessage = "Employer name can't be empty and is allowed be a maximum of 20 characters.")]
        public string EmployerName { get; set; } = null!;

        public UserType UserType { get; } = UserType.Employer;
    }
}
