﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Develop.Domain.Event
{
    /// <summary>
    /// default domain event handler
    /// </summary>
    public class DefaultImmediatelyDomainEventHandler<Event> : DefaultDomainEventHandler<Event>, IDomainEventHandler where Event : class, IDomainEvent
    {
        /// <summary>
        /// execute time
        /// </summary>
        public EventTriggerTime ExecuteTime { get; } = EventTriggerTime.Immediately;
    }
}
