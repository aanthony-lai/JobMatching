using System.ComponentModel.DataAnnotations;

namespace JobMatching.Application.DTO
{
	public class AddUserCompetenceDTO
	{
		[Required]
		public Guid UserId { get; set; }
		
		[Required]
		public Guid CompetenceId { get; set; }
	}
}
