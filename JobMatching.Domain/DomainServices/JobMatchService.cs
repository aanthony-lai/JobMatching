using JobMatching.Domain.Entities.Candidate;
using JobMatching.Domain.Entities.Competence;
using JobMatching.Domain.Interfaces;

namespace JobMatching.Domain.DomainServices
{
    public class JobMatchService : IJobMatchService
    {
        //public decimal CalculateOverallMatchGrade(CandidateApplication jobApplication)
        //{
        //    if (!ValidateCompetencesAreNotEmpty(jobApplication, false))
        //        return 0;

        //    List<Competence> candidateCompetences = jobApplication.Candidate.Competences;
        //    List<Competence> jobCompetences = GetJobCompetences(jobApplication, false);

        //    int totalCompetencesCount = jobCompetences.Count;
        //    int matchingCompetences = CalculateMatchingCompetences(candidateCompetences, jobCompetences);

        //    return ((decimal)matchingCompetences / totalCompetencesCount) * 100;
        //}

        //public bool DoesCandidateHaveAllCriticalCompetences(CandidateApplication jobApplication)
        //{
        //    if (!ValidateCompetencesAreNotEmpty(jobApplication, true))
        //        return false;

        //    List<Competence> candidateCompetences = jobApplication.Candidate.Competences;
        //    List<Competence> jobCriticalCompetences = GetJobCompetences(jobApplication, true);

        //    int totalCriticalCompetencesCount = jobCriticalCompetences.Count;
        //    int matchingCompetences = CalculateMatchingCompetences(candidateCompetences, jobCriticalCompetences);

        //    return totalCriticalCompetencesCount == matchingCompetences;
        //}

        //public string GetCricitcalCompetencesMatchSummary(CandidateApplication jobApplication)
        //{
        //    if (!ValidateCompetencesAreNotEmpty(jobApplication, true))
        //        return string.Empty;

        //    List<Competence> candidateCompetences = jobApplication.Candidate.Competences;
        //    List<Competence> jobCriticalCompetences = GetJobCompetences(jobApplication, true);

        //    int totalCriticalCompetencesCount = jobCriticalCompetences.Count;
        //    int matchingCompetences = CalculateMatchingCompetences(candidateCompetences, jobCriticalCompetences);

        //    return $"Critical competences match summary: {matchingCompetences} out of {totalCriticalCompetencesCount}";
        //}

        //private List<Competence> GetJobCompetences(CandidateApplication jobApplication, bool isCriticalCompetences)
        //{
        //    return isCriticalCompetences
        //        ? jobApplication.Job.JobCompetences.Where(jc => jc.IsCritical).Select(jc => jc.Competence).ToList()
        //        : jobApplication.Job.JobCompetences.Select(jc => jc.Competence).ToList();
        //}

        //private int CalculateMatchingCompetences(List<Competence> candidateCompetences, List<Competence> jobCompetences) =>
        //    jobCompetences.Count(jobCompetence => candidateCompetences
        //        .Any(userCompetence => userCompetence.Id == jobCompetence.Id));

        //private bool ValidateCompetencesAreNotEmpty(CandidateApplication jobApplication, bool checkForCriticalCompetences)
        //{
        //    if (checkForCriticalCompetences &&
        //       (!jobApplication.Candidate.Competences.Any() ||
        //        !jobApplication.Job.JobCompetences.Where(jc => jc.IsCritical).Any()))
        //    {
        //        return false;
        //    }
        //    else if (!jobApplication.Candidate.Competences.Any() ||
        //             !jobApplication.Job.JobCompetences.Any())
        //    {
        //        return false;
        //    }

        //    return true;
        //}
    }
}
