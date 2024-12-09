namespace JobMatching.Common.SystemMessages.JobMessages
{
	public static class JobMessages
	{
		public static string JobNotFound(Guid jobId) => $"Job with ID: {jobId}, was not found";
		public static string InvalidJobId(Guid jobId) => $"The provided job ID: {jobId}, is invalid.";
		public static string InvalidJobTitle(string jobTitle) => $"The provided job title is invalid.";
	}
}
