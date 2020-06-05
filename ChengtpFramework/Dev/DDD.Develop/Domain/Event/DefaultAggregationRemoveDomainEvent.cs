using DDD.Develop.Domain.Aggregation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Develop.Domain.Event
{
    /// <summary>
    /// default aggregation remove domain event
    /// </summary>
    public class DefaultAggregationRemoveDomainEvent<T> : BaseDomainEvent
    {
        /// <summary>
        /// remove object
        /// </summary>
        public T Object
        {
            get; set;
        }
    }
}
