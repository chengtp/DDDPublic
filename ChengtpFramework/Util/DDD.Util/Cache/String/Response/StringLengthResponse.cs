﻿namespace DDD.Util.Cache.String.Response
{
    /// <summary>
    /// String length response
    /// </summary>
    public class StringLengthResponse : CacheResponse
    {
        /// <summary>
        /// Gets or sets the string value length
        /// </summary>
        public long StringLength
        {
            get; set;
        }
    }
}
