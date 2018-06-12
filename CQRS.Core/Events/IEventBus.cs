namespace CQRS.Core.Events
{
    public interface IEventsBus
    {
        void Publish<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}
