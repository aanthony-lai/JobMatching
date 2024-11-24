namespace JobMatching.Common.SystemMessages.CompetenceMessages
{
	public static class CompetenceMessages
	{
		public static string CompetenceDoesNotExist(Guid competenceId) => $"Competence with ID: {competenceId}, does not exist";
	}
}
