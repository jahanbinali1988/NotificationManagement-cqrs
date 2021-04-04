﻿namespace Common.Core.Events
{
    public interface IEventPublisher
    {
        void Publish<T>(T @event) where T : IEvent;
    }
}
