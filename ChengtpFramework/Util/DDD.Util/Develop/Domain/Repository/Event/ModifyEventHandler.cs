using System;
using DDD.Util.Develop.Command.Modify;
using DDD.Util.Develop.CQuery;
using DDD.Util.Develop.Domain.Aggregation;
using DDD.Util.Develop.UnitOfWork;

namespace DDD.Util.Develop.Domain.Repository.Event
{
    /// <summary>
    /// Modify event handler
    /// </summary>
    public class ModifyEventHandler : IRepositoryEventHandler
    {
        /// <summary>
        /// Gets or sets the event type
        /// </summary>
        public EventType EventType { get; set; }

        /// <summary>
        /// Gets or sets handler repository type
        /// </summary>
        public Type HandlerRepositoryType { get; set; }

        /// <summary>
        /// Gets or sets the object type
        /// </summary>
        public Type ObjectType { get; set; }

        /// <summary>
        /// Gets or sets the operation
        /// </summary>
        public ModifyOperation Operation { get; set; }

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="modify">Modeify expression</param>
        /// <param name="query">Query object</param>
        /// <param name="activationOption">Activation option</param>
        /// <returns>Return repository event execute result</returns>
        public IRepositoryEventExecuteResult Execute(IModify modify, IQuery query, ActivationOption activationOption = null)
        {
            if (modify == null || Operation == null)
            {
                return DataOperationEventExecuteResult.Empty;
            }
            Operation(modify, query, activationOption);
            return DataOperationEventExecuteResult.Empty;
        }
    }
}
