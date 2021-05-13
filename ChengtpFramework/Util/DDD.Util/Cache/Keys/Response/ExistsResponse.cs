﻿namespace DDD.Util.Cache.Keys.Response
{
    /// <summary>
    /// Key exists response
    /// </summary>
    public class ExistsResponse : CacheResponse
    {
        /// <summary>
        /// Gets or sets the key count
        /// </summary>
        public long KeyCount
        {
            get; set;
        }

        /// <summary>
        /// Gets whether has key
        /// </summary>
        public bool HasKey
        {
            get
            {
                return KeyCount > 0;
            }
        }
    }
}
