using JobMatching.Client.Types;
using System.ComponentModel.DataAnnotations;

namespace JobMatching.Client.Models
{
    public class RegisterCandidateModel: RegisterUserModel
    {
        [Required]
        [StringLength(20, ErrorMessage = "First name can't be empty and is allowed be a maximum of 20 characters.")]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(20, ErrorMessage = "Last name can't be empty and is allowed be a maximum of 20 characters.")]
        public string LastName { get; set; } = null!;

        public UserType UserType { get; } = UserType.Candidate;
    }
}
