using System;

namespace DDD.Util.Develop.Command
{
    /// <summary>
    /// Command executing event result
    /// </summary>
    [Serializable]
    public class CommandStartingEventExecuteResult
    {
        /// <summary>
        /// Gets or sets whether allow to execute command
        /// </summary>
        public bool AllowExecuteCommand
        {
            get; set;
        }

        /// <summary>
        /// Gets the default success result
        /// </summary>
        public readonly static CommandStartingEventExecuteResult DefaultSuccess = new CommandStartingEventExecuteResult()
        {
            AllowExecuteCommand = true
        };
    }
}
