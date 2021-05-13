﻿using System;

namespace DDD.Util.Develop.Command
{
    /// <summary>
    /// Command executed event parameter
    /// </summary>
    [Serializable]
    public class CommandCallbackEventParameter
    {
        /// <summary>
        /// Gets or sets the command
        /// </summary>
        public ICommand Command
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the command behavior
        /// </summary>
        public CommandBehavior CommandBehavior
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the event data
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Gets or sets whether the command execute successful
        /// </summary>
        public bool IsExecuteSuccess
        {
            get; set;
        }
    }
}
