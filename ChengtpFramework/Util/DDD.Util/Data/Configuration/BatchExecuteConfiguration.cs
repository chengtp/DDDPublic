﻿namespace DDD.Util.Data.Configuration
{
    /// <summary>
    /// Batch execute configuration
    /// </summary>
    public class BatchExecuteConfiguration
    {
        /// <summary>
        /// Gets or sets the group statements count
        /// </summary>
        public int GroupStatementsCount
        {
            get; set;
        } = 1000;

        /// <summary>
        /// Gets or sets the group parameters count
        /// </summary>
        public int GroupParametersCount
        {
            get; set;
        } = 2000;

        /// <summary>
        /// Gets the default batch execute configuration
        /// </summary>
        public static readonly BatchExecuteConfiguration Default = new BatchExecuteConfiguration();
    }
}
