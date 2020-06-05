﻿using DDD.Develop.Command.Modify;
using DDD.Develop.CQuery;
using DDD.Develop.Domain.Aggregation;
using DDD.Develop.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Develop.Domain.Repository.Event
{
    public class ModifyEventHandler : IRepositoryEventHandler
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
        public ModifyOperation Operation { get; set; }

        /// <summary>
        /// execute
        /// </summary>
        /// <param name="modify">modeify expression</param>
        /// <param name="query">query object</param>
        /// <param name="activationOption">activation option</param>
        /// <returns></returns>
        public IRepositoryEventHandleResult Execute(IModify modify, IQuery query, ActivationOption activationOption = null)
        {
            if (modify == null || Operation == null)
            {
                return DataOperationEventResult.Empty;
            }
            Operation(modify, query, activationOption);
            return DataOperationEventResult.Empty;
        }
    }
}
