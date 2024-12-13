using MediatR;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobMatching.Domain.BaseClasses
{
    public abstract class EntityBase: IEquatable<EntityBase>
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

        public bool Equals(EntityBase other)
        {
            return this.Id == other.Id;
        }
    }
}
