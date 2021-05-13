﻿using System.Collections.Generic;
using System.Threading.Tasks;
using DDD.Util.Cache.List.Response;

namespace DDD.Util.Cache.List.Request
{
    /// <summary>
    /// List right push option
    /// </summary>
    public class ListRightPushOption : CacheRequestOption<ListRightPushResponse>
    {
        /// <summary>
        /// Gets or sets the cache key
        /// </summary>
        public CacheKey Key
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the values
        /// </summary>
        public List<string> Values
        {
            get; set;
        }

        /// <summary>
        /// Execute cache operation
        /// </summary>
        /// <param name="cacheProvider">Cache provider</param>
        /// <param name="server">Cache server</param>
        /// <returns>Return right push response</returns>
        protected override async Task<ListRightPushResponse> ExecuteCacheOperationAsync(ICacheProvider cacheProvider, CacheServer server)
        {
            return await cacheProvider.ListRightPushAsync(server, this).ConfigureAwait(false);
        }
    }
}
