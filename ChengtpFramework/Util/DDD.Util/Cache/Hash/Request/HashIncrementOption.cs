﻿using System.Threading.Tasks;
using DDD.Util.Cache.Hash.Response;

namespace DDD.Util.Cache.Hash.Request
{
    /// <summary>
    /// Hash increment option
    /// </summary>
    public class HashIncrementOption : CacheRequestOption<HashIncrementResponse>
    {
        /// <summary>
        /// Gets or sets the cache key
        /// </summary>
        public CacheKey Key
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the hash field
        /// </summary>
        public string HashField
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the increment value
        /// </summary>
        public dynamic IncrementValue
        {
            get; set;
        }

        /// <summary>
        /// Execute cache operation
        /// </summary>
        /// <param name="cacheProvider">Cache provider</param>
        /// <param name="server">Cache server</param>
        /// <returns>Return hash increment response</returns>
        protected override async Task<HashIncrementResponse> ExecuteCacheOperationAsync(ICacheProvider cacheProvider, CacheServer server)
        {
            return await cacheProvider.HashIncrementAsync(server, this).ConfigureAwait(false);
        }
    }
}
