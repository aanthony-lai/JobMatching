using MediatR;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobMatching.Domain.Entities
{
    public abstract class DomainEntityBase : IEquatable<DomainEntityBase>
    {
        public Guid Id { get; set; }

        private readonly List<IRequest> _domainEvents = new();

        [NotMapped]
        public IReadOnlyCollection<IRequest> DomainEvents => _domainEvents.AsReadOnly();

        public void AddDomainEvent(IRequest domainEvent) =>
            _domainEvents.Add(domainEvent);

        public void RemoveDomainEvent(IRequest domainEvent) =>
            _domainEvents.Remove(domainEvent);

        public void ClearDomainEvents() =>
            _domainEvents.Clear();

        public bool Equals(DomainEntityBase other)
        {
            return Id == other.Id;
        }
    }
}
