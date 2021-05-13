﻿namespace DDD.Util.Cache.String.Response
{
    /// <summary>
    /// String increment response
    /// </summary>
    public class StringIncrementResponse : CacheResponse
    {
        /// <summary>
        /// Gets or sets the new value
        /// </summary>
        public decimal NewValue
        {
            get; set;
        }
    }
}
