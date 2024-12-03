namespace JobMatching.Domain.Exceptions
{
	public class DuplicateLanguageException: Exception
	{
		public DuplicateLanguageException() : base() { }
		public DuplicateLanguageException(string message) : base(message) { }
		public DuplicateLanguageException(string message, Exception inner) : base(message, inner) { }
	}
}
