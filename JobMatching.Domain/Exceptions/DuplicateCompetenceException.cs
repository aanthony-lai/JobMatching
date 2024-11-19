namespace JobMatching.Domain.Exceptions
{
	public class DuplicateCompetenceException: Exception
	{
		public DuplicateCompetenceException(string paramName, string message): base(message) { }
	}
}
