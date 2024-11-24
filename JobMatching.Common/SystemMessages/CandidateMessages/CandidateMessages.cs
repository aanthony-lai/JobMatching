namespace JobMatching.Common.SystemMessages.CandidateMessages
{
    public static class CandidateMessages
    {
        public static string InvalidCandidateId(Guid candidateId) => $"The provided candidate ID: {candidateId}, is invalid.";
        public static string CandidateNotFound(Guid candidateId) => $"Candidate with the specified {candidateId} could not be found.";
    }
}
