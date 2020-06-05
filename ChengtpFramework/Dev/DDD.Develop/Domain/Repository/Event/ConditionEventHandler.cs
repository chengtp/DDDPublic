using DDD.Develop.CQuery;
using DDD.Develop.Domain.Aggregation;
using DDD.Develop.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Develop.Domain.Repository.Event
{
    public class ConditionEventHandler : IRepositoryEventHandler
    {
        /// <summary>
        /// event type
        /// </summary>
        public EventType EventType { get; set; }

        /// <summary>
        /// handler repository type
        /// </summary>
        public Type HandlerRepositoryType { get; set; }

        /// <summary>
        /// object type
        /// </summary>
        public Type ObjectType { get; set; }

        /// <summary>
        /// operation
        /// </summary>
        public ConditionOperation Operation { get; set; }

        /// <summary>
        /// execute
        /// </summary>
        /// <param name="query">query object</param>
        /// <param name="option">activation option</param>
        /// <returns></returns>
        public IRepositoryEventHandleResult Execute(IQuery query, ActivationOption option = null)
        {
            if (Operation == null)
            {
                return DataOperationEventResult.Empty;
            }
            Operation(query, option);
            return DataOperationEventResult.Empty;
        }
    }
}
