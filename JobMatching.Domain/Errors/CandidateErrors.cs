using JobMatching.Common.Results;

namespace JobMatching.Domain.Errors
{
    public static class CandidateErrors
    {
        public static readonly Error InvalidFirstName = new("First name can't be empty.");
        public static readonly Error InvalidLastName = new("Last name can't be empty.");
        public static readonly Error InvalidCompetence = new("You've selected an invalid competence.");
        public static readonly Error InvalidLanguage = new("You've selected an invalid language.");
        public static readonly Error InvalidJob = new("You've selected an invalid job ID.");

    }
}
