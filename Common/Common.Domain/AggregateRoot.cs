using System;
using System.Collections.Generic;
using System.Text;
using Common.Core.Events;

namespace Common.Domain
{
    public abstract class AggregateRoot : BaseEntity, IAggregateRoot
    {
        private readonly IEventPublisher _publisher;
        private readonly List<IDomainEvent> _domainEvents;

        protected AggregateRoot()
        {
            _domainEvents = new List<IDomainEvent>();
        }
        protected AggregateRoot(IEventPublisher publisher)
        {
            _domainEvents = new List<IDomainEvent>();
            _publisher = publisher;
        }
        public void Publish<T>(T @event) where T : IDomainEvent
        {
            _publisher.Publish(@event);
            _domainEvents.Add(@event);
        }

        public IReadOnlyCollection<IDomainEvent> GetEvents()
        {
            return _domainEvents.AsReadOnly();
        }

        public void ClearEvents()
        {
            _domainEvents.Clear();
        }
    }
}
