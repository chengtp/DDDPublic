﻿using System.Collections.Generic;
using System.Threading.Tasks;
using DDD.Util.Cache.Set.Response;

namespace DDD.Util.Cache.Set.Request
{
    /// <summary>
    /// Set remove option
    /// </summary>
    public class SetRemoveOption : CacheRequestOption<SetRemoveResponse>
    {
        /// <summary>
        /// Gets or sets the cache key
        /// </summary>
        public CacheKey Key
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the remove values
        /// </summary>
        public List<string> RemoveValues
        {
            get; set;
        }

        /// <summary>
        /// Execute cache operation
        /// </summary>
        /// <param name="cacheProvider">Cache provider</param>
        /// <param name="server">Cache server</param>
        /// <returns>Return set remove response</returns>
        protected override async Task<SetRemoveResponse> ExecuteCacheOperationAsync(ICacheProvider cacheProvider, CacheServer server)
        {
            return await cacheProvider.SetRemoveAsync(server, this).ConfigureAwait(false);
        }
    }
}
