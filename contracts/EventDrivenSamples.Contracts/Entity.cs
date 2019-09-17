using System.Collections.Generic;

namespace EventDrivenSamples.Contracts
{
    public abstract class Entity
    {
        public Entity()
        {
            PendingEvents = new Queue<IDomainEvent>();
        }

        protected string Id { get; set; }
        protected Queue<IDomainEvent> PendingEvents { get; }
    }
}