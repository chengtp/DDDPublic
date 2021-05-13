﻿using System.Threading.Tasks;
using DDD.Util.Cache.String.Response;

namespace DDD.Util.Cache.String.Request
{
    /// <summary>
    /// String decrement option
    /// </summary>
    public class StringDecrementOption : CacheRequestOption<StringDecrementResponse>
    {
        /// <summary>
        /// Gets or sets the cache key
        /// </summary>
        public CacheKey Key
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the value
        /// </summary>
        public dynamic Value
        {
            get; set;
        }

        /// <summary>
        /// Execute cache operation
        /// </summary>
        /// <param name="cacheProvider">Cache provider</param>
        /// <param name="server">Cache server</param>
        /// <returns>Return string decrement response</returns>
        protected override async Task<StringDecrementResponse> ExecuteCacheOperationAsync(ICacheProvider cacheProvider, CacheServer server)
        {
            return await cacheProvider.StringDecrementAsync(server, this).ConfigureAwait(false);
        }
    }
}
