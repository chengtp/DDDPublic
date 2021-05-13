﻿namespace DDD.Util.Cache
{
    /// <summary>
    /// Cache request option
    /// </summary>
    public interface ICacheRequestOption
    {
        /// <summary>
        /// Gets or sets the cache object
        /// </summary>
        CacheObject CacheObject
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the command flags
        /// </summary>
        CacheCommandFlags CommandFlags { get; set; }
    }
}
