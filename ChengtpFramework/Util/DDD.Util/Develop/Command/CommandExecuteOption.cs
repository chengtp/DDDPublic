﻿using System;
using System.Threading;
using DDD.Util.Develop.DataAccess;

namespace DDD.Util.Develop.Command
{
    /// <summary>
    /// Command execute option
    /// </summary>
    [Serializable]
    public class CommandExecuteOption
    {
        /// <summary>
        /// Gets or sets the data isolation level
        /// </summary>
        public DataIsolationLevel? IsolationLevel { get; set; }

        /// <summary>
        /// Gets or sets whether execute by transaction
        /// </summary>
        public bool ExecuteByTransaction { get; set; } = true;

        /// <summary>
        /// Gets or sets the cancellation token
        /// </summary>
        public CancellationToken CancellationToken { get; set; } = default;

        /// <summary>
        /// Gets the default command execute option
        /// </summary>
        public static readonly CommandExecuteOption Default = new CommandExecuteOption();
    }
}
