using System;

namespace Common.Core.Events
{
    public abstract class DomainEvent : IDomainEvent
    {
        public Guid EventId { get; protected set; }
        public DateTime PublishDateTime { get; protected set; }
        protected DomainEvent()
        {
            this.EventId = Guid.NewGuid();
            this.PublishDateTime = DateTime.Now;
        }
    }
}
