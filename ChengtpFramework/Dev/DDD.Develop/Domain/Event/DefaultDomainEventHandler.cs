﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Develop.Domain.Event
{
    public class DefaultDomainEventHandler<Event> where Event : class, IDomainEvent
    {
        /// <summary>
        /// execute event operation
        /// </summary>
        public Func<Event, Task<DomainEventExecuteResult>> ExecuteEventOperationAsync
        {
            get; set;
        }

        public DomainEventExecuteResult Execute(IDomainEvent domainEvent)
        {
            return ExecuteAsync(domainEvent).Result;
        }

        public async Task<DomainEventExecuteResult> ExecuteAsync(IDomainEvent domainEvent)
        {
            if (ExecuteEventOperationAsync == null)
            {
                return DomainEventExecuteResult.EmptyResult("did't set any event operation");
            }
            var eventData = domainEvent as Event;
            if (eventData == null)
            {
                return DomainEventExecuteResult.EmptyResult("event data is null");
            }
            return await ExecuteEventOperationAsync(eventData).ConfigureAwait(false);
        }
    }
}
