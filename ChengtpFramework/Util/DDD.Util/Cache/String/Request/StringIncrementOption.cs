﻿using System.Threading.Tasks;
using DDD.Util.Cache.String.Response;

namespace DDD.Util.Cache.String.Request
{
    /// <summary>
    /// String increment option
    /// </summary>
    public class StringIncrementOption : CacheRequestOption<StringIncrementResponse>
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
        /// <returns>Return string increment response</returns>
        protected override async Task<StringIncrementResponse> ExecuteCacheOperationAsync(ICacheProvider cacheProvider, CacheServer server)
        {
            return await cacheProvider.StringIncrementAsync(server, this).ConfigureAwait(false);
        }
    }
}
