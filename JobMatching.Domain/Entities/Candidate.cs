﻿using JobMatching.Domain.Exceptions;
using JobMatching.Domain.Interfaces;
using JobMatching.Domain.ValueObjects;
using JobMatching.Domain.ValueObjects.Name;

namespace JobMatching.Domain.Entities
{
	public class Candidate: IEntity
	{
		public Guid Id { get; init; }
		public Name Name { get; private set; } = null!;
		public List<Competence> Competences { get; private set; } = new List<Competence>();
		public List<JobApplication> JobApplications { get; private set; } = new();
		public User User { get; init; }
		public Guid UserId { get; init; }
		public MetaData MetaData { get; private set; }

		protected Candidate() { }
		public Candidate(string firstName, string lastName, string email)
		{
			Id = Guid.NewGuid();
			Name = Name.SetCandidateName(firstName, lastName);
			User = User.CreateUserCandidate(email, name: $"{firstName} {lastName}");
			UserId = User.Id;
			MetaData = new MetaData();
		}

		public void AddCompetence(Competence competence)
		{
			if (competence is null)
				throw new ArgumentNullException(nameof(competence),
					"The competence that you're trying to add is null");

			if (Competences.Contains(competence))
				throw new DuplicateCompetenceException(
					"The candidate already has this competence.");

			Competences.Add(competence);
		}
	}
}
