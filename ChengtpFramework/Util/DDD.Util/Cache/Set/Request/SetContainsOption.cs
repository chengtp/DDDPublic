﻿using System.Threading.Tasks;
using DDD.Util.Cache.Set.Response;

namespace DDD.Util.Cache.Set.Request
{
    /// <summary>
    /// Set contains option
    /// </summary>
    public class SetContainsOption : CacheRequestOption<SetContainsResponse>
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
        public string Value
        {
            get; set;
        }

        /// <summary>
        /// Execute cache operation
        /// </summary>
        /// <param name="cacheProvider">Cache provider</param>
        /// <param name="server">Cache server</param>
        /// <returns>Return set contains response</returns>
        protected override async Task<SetContainsResponse> ExecuteCacheOperationAsync(ICacheProvider cacheProvider, CacheServer server)
        {
            return await cacheProvider.SetContainsAsync(server, this).ConfigureAwait(false);
        }
    }
}
